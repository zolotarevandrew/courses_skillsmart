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

### 2) Обобщение замыкания - 

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
Планирую поэкспериментировать над тем, как интегрировать такую модель с Entity Framework и заменить собственную реализацию на типы из LanguageExt.


### 3) Обобщение замыкания - 

```csharp
public delegate T Sanitizer<T>(T input);
```
Интерфейс санитизации входных данных. 
Также поддерживает композицию правил, если выделять функции по сущности отдельно.

### 4) Составные типы - 

```csharp

```


### 5) Составные типы - 

```csharp

```


---

## Итого:

Итого