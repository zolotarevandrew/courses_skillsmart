### 1. Обошёл всю структуру текущего проекта для поиска классов, которые работают с промежуточным состоянием.  
К моему удивлению, бизнес-логики немного, а основная масса кода — инфраструктурные вещи (httpclient, репозитории, интеграции, обвязка EF и другое).

Рандомно выбрал 6 классов для анализа.

---

### 1.1 GetAvailableFeatures

**До**  
- В цикле метод мутировал ранее полученный список и проходился по второму списку, используя `!Contains`.

**После**  
- Переделал на `Concat` двух `Enumerable`, вместо мутирования списка.  
- Результат — в `HashSet` или `Distinct`.

---

### 1.2 GetAllSurveysAnswers

**До**  
- Типичная проблема: в цикле собираем результат последовательно в `List` батчами, при этом выполняем поход в базу.

**После**  
- Самое простое — перешёл на `IAsyncEnumerable`.  
- Написал метод-расширение для батчинга (оказывается, завезут в .NET 9 из коробки) и использовал `SelectAwait`.  
- Получили ленивый async streaming почти из коробки.

---

### 1.3 GetTotalProvidersStatisticsAsync

**До**  
- Типичная проблема: в цикле собираем результат последовательно в `List`, а в конце отдаём сгруппированным и отсортированным с проекцией.

**После**  
- Перешёл на `IAsyncEnumerable`.  
- В нём уже есть встроенные `GroupBy`, затем `SelectAwait`, внутри него `AggregateAwaitAsync`, плюс `OrderBy`, `ThenBy`.  
- Правда, `GroupBy` всё равно заранее проходит всю `AsyncEnumerable`, но хотя бы так.

---

### 1.4 GetSentNotificationAverageRatesAsync

**До**  
- Типичная проблема: в цикле собираем результат последовательно в `Dictionary`.

**После**  
- Переход на `IAsyncEnumerable`, `ToAsyncEnumerable` и `SelectManyAwait`.

---

### 1.5 ExportReportAsync

**До**  
- Типичная проблема: в цикле собираем результат последовательно в `List`.

**После**  
- Перешёл на методы `IEnumerable`: `Select`, `Where`, `Select`.

---

### 1.6 GetSubstitutionsAsync

**До**  
- В методе собирается список подстановок `List<Substitution>` последовательно по ряду источников (сейчас 4).  
- Каждый вызов источника подстановок оборачивается для замера времени выполнения через `Stopwatch`, результат записывается в метрики, а результирующий список подстановок мутируется полученным результатом.

```csharp
private async Task<List<Substitution>> GetSubstitutionsAsync(
    ISubstitutionBuilder substitutionBuilder,
    Scenario scenario,
    string language,
    NotificationGuest? notificationGuest = null,
    BaseAnswer? answer = null )
{
    var stopwatch = new Stopwatch();
    long executionTime = 0;
    var substitutions = new List<Substitution>();

    if (notificationGuest != null)
    {
        executionTime = await stopwatch.ExecuteAndGetMillisecondsAsync(async () =>
            substitutions.AddRange(await substitutionBuilder.BuildAsync(notificationGuest)));
        _targetMetrics?.IncrementBuildGuestSubstitutionsTimeMs(executionTime);
    }

    substitutions.AddRange(await substitutionBuilder.BuildCommonAsync());

    if (notificationGuest?.SenderKind == SenderKind.Provider && notificationGuest.SenderId != null)
    {
        executionTime = await stopwatch.ExecuteAndGetMillisecondsAsync(async () =>
            substitutions.AddRange(await GetProviderSubstitutionsAsync(notificationGuest.SenderId.Value, language)));
        _targetMetrics?.IncrementBuildProviderSubstitutionsTimeMs(executionTime);
    }

    if (notificationGuest?.Booking != null)
    {
        executionTime = await stopwatch.ExecuteAndGetMillisecondsAsync(async () =>
            substitutions.AddRange(await substitutionBuilder.BuildAsync(
                notificationGuest,
                notificationGuest.Booking,
                notificationGuest.NotificationPublicId)));
        _targetMetrics?.IncrementBuildBookingSubstitutionsTimeMs(executionTime);
    }

    if (answer != null)
    {
        substitutions.AddRange(substitutionBuilder.Build(answer, scenario.UserKind));
    }

    return substitutions;
}
```

**Замечания**  
- Явно стоит переделать функцию в чистую, без мутирования `_targetMetrics`, так как это побочный эффект.  
- В идеале — для следования Open/Closed принципу, чтобы не передавать кучу параметров по цепочке, нужно завести тип данных "Запрос на получение/построение подстановок" — `SubstitutionBuildRequest<TRequest>`, похожий на Command:

```csharp
record NotificationGuestSubstitutionsRequest(NotificationGuest Guest) : SubstitutionBuildRequest;
record ProviderSubstitutionRequest(int Id, string Language) : SubstitutionBuildRequest;
record CommonSubstitutionRequest() : SubstitutionBuildRequest;
record BookingSubstitutionRequest(NotificationGuest Guest, Booking Booking, Guid NotificationPublicId) : SubstitutionBuildRequest;
record SurveyAnswerSubstitutionRequest(ScenarioUserKind Kind, BaseAnswer Answer) : SubstitutionBuildRequest;
```

Тогда `substitutionBuilder` имел бы один метод, принимающий `SubstitutionBuildRequest`, и обрабатывал запрос на основе типа.  
Добавляем контейнер для `Substitution` — `SubstitutionContainer` с методами `Empty` и `MergeWith`.

В таком случае код превратился бы в нечто следующее:

```csharp
private async (SubstitutionContainer, SubstitutionsBuilderMetricsState) GetSubstitutionsAsync(
    ISubstitutionBuilder substitutionBuilder,
    IEnumerable<SubstitutionBuildRequest> requests)
{
    return await requests
        .ToAsyncEnumerable()
        // появился только в .NET 10, либо писать свой метод, либо System.Linq.Async
        .AggregateAsync(
            (SubstitutionContainer.Empty, new SubstitutionsBuilderMetricsState()),
            async (container, request) =>
            {
                var (newContainer, newMetricsState) = await container.Item2.Calc(() =>
                    substitutionBuilder.BuildAsync(request));

                var resultContainer = container.Item1.MergeWith(newContainer);
                return (resultContainer, newMetricsState);
            });
}
```

Если оставаться в изначальном варианте и ничего сильно не рефакторить — можно придумать что-то на основе `StateMonad`.  
Но в данном случае это только усложнит ситуацию, потому что нормальной читаемой поддержки асинхронности у монад нет (по крайней мере в `language-ext` для C#). Даже если писать свою монаду на `Task`, это будет громоздко.  

**Вывод**  
Увидел следующие варианты, применимые к текущему проекту:

- Увеличение количества чистых функций и использование иммутабельности.  
  Как следствие — можно будет комбинировать функции через LINQ.  

- Использование монад:  
  - `Option` — чтобы избавиться от `null`.  
  - `Either` — для валидаций.  
  - `State` — идеально подойдёт для бизнес-логики, когда есть ряд шагов, которые нужно связать в цепочку и протащить мутацию состояния, при этом с побочным эффектом.  

- Использование возможностей `LINQ`, `IEnumerable`, `IAsyncEnumerable` по максимуму.
  
+ Нужно менять стиль мышления в команде :)


### 2

## Материал Скота Влашина
Есть материал Скота Влашина на тему того, что ввод-вывод всегда должен быть отделён от основной логики: достали из базы, выполнили логику на основе ФП-подхода, сохранили в базу.  

Такой подход, где только глобальное хранилище данных (БД, локальное) мутируется, позволяет избавиться от хранения промежуточных состояний. Понятно, что основные структуры данных, которые работают с бизнес-логикой, должны быть иммутабельны.

## Использование пайплайнов
Linq и собственные подходы.

## Использование state machines
Если есть сложная логика бизнес-процесса, можно перевесить её на какой-нибудь оркестратор, где код будет разбит на блоки с входными и выходными переменными, а сама логика внутри также будет простой. Состояние процесса будет храниться во внешнем хранилище (оркестраторе).

## Event Sourcing
Достаточно сложная штука, но если научиться «готовить», можно получить понятную и легко масштабируемую и изменяемую систему.