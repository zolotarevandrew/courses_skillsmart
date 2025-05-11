### 1) ISP - IBackgroundProcess

```csharp
public interface IBackgroundProcess 
{
    void Execute([NotNull] BackgroundProcessContext context);
}
```
На неделе разбирался в исходниках hangfire и заметил этот интерфейс, который
является абстракцией фонового процесса в рамках выделенного thread-a.

Имеет более одной реализации (легко применить декоратор, null object или сделать composite) и типизирован расширяемым параметром выполнения.

Внутри некоторых реализаций, запускается список «дочерних» фоновых процессов.

### 2) ISP - IFlowMachine

```csharp
public interface IFlowMachine 
{
    Task<BankOnboardingStepContext> Next(BankOnboardingStepContext currentStep, BankOnboardingContext onboardingContext);
    Task<BankOnboardingStepContext> Prev(BankOnboardingStepContext currentStep, BankOnboardingContext onboardingContext);
}
```
Является абстракцией флоу онбординга, позволяет двигаться по шагам вперед и назад (они неотделимы), имеет множество реализаций.
Для того чтобы интерфейс следовал ocp, поправил сигнатуру метода и добавил bankonboardingstepcontext
(Enum-a текущего шага недостаточно, поскольку приходится доставать более подробную информацию о шаге).

### 3) ISP - IMessagePublisher

```csharp
public interface IMessagePublisher 
{
    Task Publish<TMessage>(PublishContext<TMessage> context, CancellationToken token)
        where TMessage: Message;
}
```
Абстракция для отправки сообщения в условную шину.
Очень специфичная, может иметь несколько реализаций (rabbitmqpublisher, dbqueuepublisher, inmemory).
При желании отправлять в отдельные очереди, можно завести специфичные Message и делать роутинг внутри конкретной реализации.


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

Интерфейс фильтрации элементов из коллекции, на примере IQueryable.
C минимизацией аллокаций. (Близко к монойду)

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

Интерфейс для профилирования "логов", с возможностью агрегации результата из нескольких источников.



---

## Итого:

Получилось так, что все примеры представляют общие, архитектурные абстракции с множеством реализаций, они будут редко изменяться и часто использоваться.

Вспоминая все свои интерфейсы осознал, что множество из них были подвержены итеративному процессу изменений.
На тот момент - это казалось нормальным, но сейчас понятно, что это были попытки расширить/собрать неверно выделенные абстракции.

В очередной раз убедился в силе функционального подхода и буду направлять свой фокус именно туда.