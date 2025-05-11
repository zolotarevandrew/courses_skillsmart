### 1) ISP - IBackgroundProcess

```csharp
public interface IBackgroundProcess 
{
    void Execute([NotNull] BackgroundProcessContext context);
}
```
На неделе разбирался в исходниках hangfire и заметил этот интерфейс, который
является абстракцией фонового процесса в рамках выделенного thread-a.

Имеет более одной реализации (легко применить декоратор, null object или сделать composite) и типизирован обобщённым параметром выполнения.

Внутри некоторых реализаций, запускаются несколько "дочерних" фоновых процессов.

### 2) ISP - IFlowMachine

```csharp
public interface IFlowMachine 
{
    Task<BankOnboardingStepContext> Next(BankOnboardingStepContext currentStep, BankOnboardingContext onboardingContext);
    Task<BankOnboardingStepContext> Prev(BankOnboardingStepContext currentStep, BankOnboardingContext onboardingContext);
}
```
Представляет абстракцию переходов между шагами онбординга, позволяет двигаться вперед и назад, имеет множество реализаций.
Для того чтобы интерфейс следовал OCP, поправил сигнатуру метода и добавил bankonboardingstepcontext
(одного лишь enum-значения текущего шага недостаточно, так как требуется получать более подробную информацию о шаге).

### 3) ISP - IMessagePublisher

```csharp
public interface IMessagePublisher 
{
    Task Publish<TMessage>(PublishContext<TMessage> context, CancellationToken token)
        where TMessage: Message;
}
```
Абстракция для публикации сообщений в очередь/шину.
Может иметь несколько реализаций, таких как RabbitMqPublisher, DbQueuePublisher, InMemoryPublisher.
При желании отправлять в отдельные очереди, можно определить специализированные типы сообщений (Message) и реализовать маршрутизацию внутри конкретной реализации.


### 4) Closure of operations - EntityFilter

```csharp
using MyEntityFilter = EntityFilter<MyEntity>;

public delegate IQueryable<TEntity> EntityFilter<TEntity>( IQueryable<TEntity> queryable );

public class MyEntity
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public static class MyEntityFilters
{
    public static MyEntityFilter ById => queryable => queryable
        .Where( c => !string.IsNullOrEmpty( c.Id ) );
    
    public static MyEntityFilter ByEmptyName => queryable => queryable
        .Where( c => string.IsNullOrEmpty( c.Name ) );
}

public class FiltersChain
{
    public static List<MyEntity> Apply( IQueryable<MyEntity> myEntityQueryable )
    {
        IEnumerable<MyEntityFilter> myEntityFilters = GetMyEntityFilters( );
        return myEntityFilters
            .Aggregate( myEntityQueryable, ( current, filter ) => filter( current ) )
            .ToList( );
    }

    //add conditions
    private static IEnumerable<MyEntityFilter> GetMyEntityFilters( )
    {
        yield return MyEntityFilters.ById;
        yield return MyEntityFilters.ByEmptyName;
    }
}
```

Интерфейс для фильтрации элементов из коллекции, на основе IQueryable и с минимальными аллокациями,
в духе монойда.

### 5) Closure of operations - ILogProfiler

```csharp
public interface ILogProfiler
{
    ProfiledLog Handle<TLog>( TLog log )
        where TLog : LogForProfile;
}

public class ProfiledLog( IEnumerable<LogProfileResult> source ) : IEnumerable<LogProfileResult>
{
    private readonly IEnumerable<LogProfileResult> _source = source;
    public ProfiledLog MergeWith( ProfiledLog merged )
    {
        return new ProfiledLog( _source.Concat( merged._source ) );
    }
    
    public IEnumerator<LogProfileResult> GetEnumerator( )
    {
        return source.GetEnumerator( );
    }

    IEnumerator IEnumerable.GetEnumerator( )
    {
        return GetEnumerator( );
    }
}

public class LogProfileResult
{
    
}

public abstract class LogForProfile {};
```

Интерфейс для профилирования логов с возможностью агрегировать результаты из нескольких источников.

---

## Итого:

Получилось так, что все примеры представляют собой общие архитектурные абстракции с множеством реализаций. 
Они будут редко изменяться и часто использоваться.

Вспоминая свои интерфейсы осознал, что множество из них подвергались итеративным изменениям.
На тот момент это казалось нормальным, но теперь ясно, что это были попытки исправить изначально неверно выделенные абстракции.

В очередной раз убедился в силе функционального подхода и буду сосредотачивать свое внимание именно на нем.