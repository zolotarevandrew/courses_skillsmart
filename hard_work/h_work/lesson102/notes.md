### 1) `IDictionarySource` — "хорошая" абстракция источника словаря

```csharp
public interface IDictionarySource
{
    Task<IReadOnlyCollection<DictionaryItemContract>> GetAll(EDictionaryEntity entity, string countryCode, string lang);
    Task<DictionaryItemContract?> GetById(EDictionaryEntity entity, string countryCode, Guid id, string lang);
}
```

* Следует ISP;
* Легко реализовать шаблоны Null Object, Decorator (например, кэширование), Composite;
* Соответствует RAP — есть две реализации (файлы и БД).

### 2) `ICompanySearch` — "плохая" абстракция поисковика компании

```csharp
public interface ICompanySearchV1
{
    Task<CompanySearchResultContract> Search(CompanySearchContract contract);
    Task<List<Company>> Search(string countryCode, string plainText);
    Task<List<Company>> SearchByRegistrationNumber(string countryCode, string plainText);
    Task<List<Company>> SearchByBusinessName(string countryCode, string plainText);
}
```

* Нарушает ISP — множество методов с пересекающейся логикой;
* Нарушает OCP — добавление новых критериев требует изменения интерфейса, методы расширялись и добавлялись разными людьми в разное время;

#### Улучшенный вариант:

```csharp
public enum ECompanySearchCriteria
{
    CountryCode = 1,
    RegistrationNumber = 2,
    BusinessName = 3,
}

public class CompanySearchRequest(ECompanySearchCriteria criteria, string plainText)
{
    public ECompanySearchCriteria Criteria { get; } = criteria;
    public string PlainText { get; } = plainText;
}

public class CompanySearchResult : IEnumerable<Company> { }

public interface ICompanySearchV2
{
    Task<CompanySearchResult> Search(CompanySearchRequest request);
}
```

* Соблюдаем OCP — новые критерии можно добавить без изменения интерфейса. 
Обобщённый тип запроса облегчает расширение и обработку (при необходимости, можно сделать Generic-ом);
* Возможно внедрение декораторов, Null Object, Composite;

### 3) `IDataCollectionBannerService` — "плохая" абстракция баннеров

```csharp
public interface IDataCollectionBannerService
{
    Task DeactivateCurrentAobBanner(DataCollectionContext context);
    Task ActivateDataCollectionRequiredAobBanner(DataCollectionContext context, DateTime closeAccountAt);
    Task ActivateDataCollectionBlockedAobBannerOnProvided(DataCollectionModel dataCollection, DateTime closeAccountAt, AfterAccountOpeningDataCollectionConfig cfg);
    Task ActivateDataCollectionBlockedAobBannerOnClosing(DataCollectionModel dataCollection, DateTime closeAccountAt, AfterAccountOpeningDataCollectionConfig cfg);
}
```

* Нарушает ISP — множество методов добавления разных типов баннера.
* Нарушает OCP — добавление новых типов баннеров требует изменения интерфейса.

#### Улучшенный вариант:

```csharp
public abstract class DataCollectionAobBannerRequest { }
public class DataCollectionRequiredAobBannerRequest : DataCollectionAobBannerRequest { }

public interface IDataCollectionBannerService
{
    Task DeactivateCurrent(DataCollectionContext context);
    Task Activate<T>(DataCollectionContext context, T request) where T : DataCollectionAobBannerRequest;
}
```

* Возможно легко добавлять новые типы запросов без изменения интерфейса.

---

## Итого:

В поиске "хорошего интерфейса", почти не нашел ни одного, удовлетворяющему критериям по описанию задания.

Выделил следующие общие проблемы:
* **Раздутость интерфейсов** — методы добавляются хаотично, часто разными разработчиками, без учёта ISP;
* **Shallow-интерфейсы** — множество лишних зависимостей и leaky abstractions, которые приходится собирать фрагментами по всему проекту;
* **Заголовочные интерфейсы** — как следствие догматичному следованию DI (репозитории, сервисы и.т.д);
* **God-интерфейсы** — абстракции, которые были собраны без понимания решаемой задачи.

Для себя выделил следующий алгоритм действий:
1) **Описать суть абстракции** - как она используется текущими клиентами и как будет использована далее стратегически, без такой документации с большой долей вероятности интерфейс превратится в один из тех, что я описал выше;
2) **Проверить следование базовым принципам** - OCP, ISP, на уровне интерфейса и входных/выходных типов;
3) **Проверить композитность** - легко ли встроить декоратор, null object, composite, использовать перечислимый тип результата, замыкание.
