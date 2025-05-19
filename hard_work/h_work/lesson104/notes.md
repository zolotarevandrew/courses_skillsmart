### 1) Обобщение замыкания - NumberOperation

```csharp
decimal start = 1;
var composed = NumberOperations.Compose(
    NumberOperations.WithLogging( "x3", NumberOperations.Multiply( 3 ) ),
    NumberOperations.WithLogging( "-3", NumberOperations.Minus( 25 ) )
);
Console.WriteLine(composed( 1 ));

public delegate T NumberOperation<T>( T number ) where T : INumber<T>;

public static class NumberOperations
{
    public static NumberOperation<T> Empty<T>() where T : INumber<T> => number => number;
    
    public static NumberOperation<T> Multiply<T>( T factor ) 
        where T : INumber<T> => number => number * factor;

    public static NumberOperation<T> Minus<T>( T number2 )
        where T : INumber<T> => number1 => number1 - number2;
    
    public static NumberOperation<T> WithLogging<T>(string name, NumberOperation<T> op)
        where T : INumber<T>
    {
        return input =>
        {
            var result = op(input);
            Console.WriteLine($"{name}: {input} → {result}");
            return result;
        };
    }
    
    public static NumberOperation<T> Compose<T>(params NumberOperation<T>[] operations)
        where T : INumber<T>
    {
        NumberOperation<T> composed = Empty<T>();

        foreach (NumberOperation<T> operation in operations)
        {
            NumberOperation<T> previous = composed;
            composed = x => operation(previous(x));
        }

        return composed;
    }
}
```
Абстракция числовой операции основана на существующем интерфейсе INumber<T>, который реализуют основные числовые структуры.
Добавлена возможность логирования и других cross-cutting concerns.
В результате снова получился моноид :)

### 2) Обобщение замыкания - EntityRule

```csharp
using GuestRule = EntityRule<Guest>;

Guest myGuest = new Guest(1)
{
    Booking = new GuestBooking()
};

Option<Guest> result = GuestRules.VisibilityRule(myGuest);
Console.WriteLine( result.HasValue ? result.Value!.ToString() : "null" );

public record Guest( long Id ) : IEntity
{
    public GuestBooking? Booking { get; init; }
    public bool IsHidden { get; init; }
    
    public long Id { get; private set; } = Id;
}

public interface IEntity
{
    long Id { get; }
}

public class GuestBooking { }

public readonly struct Option<T>( T value )
{
    public T? Value { get; } = value;
    public bool HasValue => Value != null;
}

public delegate Option<T> EntityRule<T>( T entity ) where T : IEntity;

public static class GuestRules
{
    public static readonly GuestRule VisibilityRule = EntityRulesExtensions
        .Combine<Guest>(
            HasBooking,
            NotHidden,
            ApplyHidden
        );
    
    public static Option<Guest> HasBooking( Guest guest ) =>
        guest.Booking != null ? Some( guest ) : None<Guest>();

    public static Option<Guest> NotHidden( Guest guest ) =>
        !guest.IsHidden ? Some( guest ) : None<Guest>();

    public static Option<Guest> ApplyHidden( Guest guest ) =>
        Some( guest with { IsHidden = true } );

    private static Option<T> Some<T>( T value ) => new (value);
    private static Option<T> None<T>() => new ();
}

public static class EntityRulesExtensions
{
    public static EntityRule<T> Combine<T>( params EntityRule<T>[] rules )
        where T : IEntity
    {
        return entity =>
        {
            foreach ( EntityRule<T> rule in rules )
            {
                Option<T> result = rule( entity );
                if ( !result.HasValue )
                    return result;

                entity = result.Value!;
            }

            return new Option<T>( entity );
        };
    }
}

```
Попытался реализовать "DSL" для работы с сущностями на основе обобщённого интерфейса EntityRule.
В итоге интуитивно пришёл к подходам из функционального программирования.
Забавно, что на уровне реализации в .NET методы всё равно отделены от данных: в каждый метод неявно передаётся ссылка this на текущий объект.
Планирую поэкспериментировать над тем, как интегрировать функциональную модель с Entity Framework и LanguageExt.


### 3) Обобщение замыкания - Sanitizer

```csharp
public delegate T Sanitizer<T>(T input);
```
Интерфейс санитизации входных данных. 
Также поддерживает композицию правил, если выделять функции по сущности отдельно.

### 4) Составные типы - IDomainEntity

```csharp
public abstract class DomainEvent {}
public sealed class DomainEventsGroup : IEnumerable<DomainEvent>
{
    private readonly List<DomainEvent> _events = new();

    public void Add(DomainEvent domainEvent)
    {
        if (domainEvent == null) throw new ArgumentNullException(nameof(domainEvent));
        _events.Add(domainEvent);
    }

    public DomainEventsGroup Combine(DomainEventsGroup other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        
        DomainEventsGroup result = new DomainEventsGroup();
        result._events.AddRange(_events);
        result._events.AddRange(other._events);
        return result;
    }

    public IEnumerator<DomainEvent> GetEnumerator() => _events.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public interface IDomainEntity
{
    long Id { get; }
    DomainEventsGroup GetEvents();
}

public  class GuestBooking {}

public abstract class BaseDomainEntity : IDomainEntity
{
    protected readonly DomainEventsGroup Events = new();
    public long Id { get; protected set; }
    
    public DomainEventsGroup GetEvents() => Events;
}
public class Guest : BaseDomainEntity
{
    public GuestBooking? Booking { get; private set; }

    public void ChangeBooking(GuestBooking booking)
    {
        Booking = booking;
        Events.Add(new GuestBookingChanged
        {
            GuestId = Id
        });
    }
}

public class GuestBookingChanged : DomainEvent
{
    public long GuestId { get; set; }
}
```
Инкапсулируем поведение и операции над DomainEvent в обёртку DomainEventsGroup,
чтобы удобно добавлять, валидировать, объединять, фильтровать и отправлять доменные события на уровне Entity Framework.

### 5) Составные типы - IRequestHandler

```csharp
public readonly struct Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public string? Error { get; }

    private Result(bool isSuccess, T? value, string? error)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    public static Result<T> Success(T value) => new(true, value, null);
    public static Result<T> Failure(string error) => new(false, default, error);

    public Result<U> Map<U>(Func<T, U> mapper)
        => IsSuccess ? Result<U>.Success(mapper(Value!)) : Result<U>.Failure(Error!);

    public Result<U> Bind<U>(Func<T, Result<U>> binder)
        => IsSuccess ? binder(Value!) : Result<U>.Failure(Error!);

    public TResult Match<TResult>(Func<T, TResult> onSuccess, Func<string, TResult> onFailure)
        => IsSuccess ? onSuccess(Value!) : onFailure(Error!);
}

public interface IRequestHandler<in TRequest, TResponse>
{
    Result<TResponse> Handle(TRequest request);
}
```
Интерфейс для обработки условных запросов.
Результат представлен в виде составного типа, реализованного через "монаду Either" — Result.

---

## Итого:

Выделю следующий набор правил для повседневного использования:
1. **Заранее прорабатывать и описывать абстракции** — как средство контроля над Leaky Abstraction (аналогично практике на курсе ООАП).
2. **Создавать интерфейсы с ограниченным количеством методов** — не более 3–4, соблюдать принципы ISP и OCP.
3. **Оборачивать входные параметры методов в осмысленные типы** — для повышения расширяемости и читаемости.
4. **Стремиться к компонуемости выходных значений** — реализовывать через функциональные подходы либо структуры типа `IEnumerable`.
5. **Переходить к функциональному стилю мышления** — использовать делегаты и интерфейсы с одним методом, реализующие замыкание, как универсальное средство композиции.
6. **Активно искать архитектурные абстракции** — приоритезировать те, что способствуют ускорению разработки, упрощению поддержки, минимизации однотипного кода.

Очень сильно потянуло в сторону ФП, поскольку надоело писать и поддерживать однотипный ООП код
с кучей условий, который:
- тяжело протестировать;
- кидает исключения где попало, невозможно нормально прервать цепочку и получить результат;
- тесно привязывает методы к сущности, которые тяжело отвязать и компоновать;

Как бонус - теперь при прочтении интерфейсов сразу вижу типичные проблемы, когда они плохо спроектированы и могу итеративно это исправить.