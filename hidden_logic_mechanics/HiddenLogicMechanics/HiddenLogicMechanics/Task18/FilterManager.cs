using System.Linq.Expressions;
using static HiddenLogicMechanics.Task18.StringQueryFilters;
namespace HiddenLogicMechanics.Task18;

public interface IQueryFilter<TElement>
{
    IQueryable<TElement> Apply( IQueryable<TElement> items );
}

public abstract class ConditionalQueryFilter<TElement> 
    : IQueryFilter<TElement>
{
    protected abstract bool IsEnabled { get; }
    protected abstract Expression<Func<TElement,bool>> Predicate { get; }

    public IQueryable<TElement> Apply( IQueryable<TElement> items )
    {
        return IsEnabled
            ? items.Where( Predicate )
            : items;
    }
}

public static class QueryableExtensions
{
    public static IQueryable<T> ApplyFilter<T>( this IQueryable<T> items, IQueryFilter<T> filter )
    {
        return filter.Apply( items );
    }
}

public class Guest
{
    public string Name { get; set; }
}

public class IfGenericFilter<TValue, TElement> : ConditionalQueryFilter<TElement>
{
    private readonly TValue _value;
    protected override bool IsEnabled { get; }
    protected override Expression<Func<TElement, bool>> Predicate { get; }

    public IfGenericFilter( 
        Func<TValue, bool> enabled,
        TValue value, 
        Func<TValue,TElement, bool> filter )
    {
        _value = value;
        IsEnabled = enabled( value );
        Predicate = element => filter( _value, element );
    } 
}

public static class StringQueryFilters
{
    public static IfGenericFilter<string, T> SearchContains<T>( string searchText, Func<T, string> selector )
    {
        return new IfGenericFilter<string, T>(
            static s => !string.IsNullOrEmpty( s ),
            searchText,
            ( val, elem ) => selector( elem ).ToLower( ).Contains( val.Trim( ).ToLower( ) )
        );
    }    
}


public static class FilterManager
{
    /*
     * Для фильтрации объектов из БД - постоянно пишутся одни и те же условия, по типичным паттернам.
     * Пытаемся придумать абстракции для удобной комбинации таких операций.
     */
    public static void Run( )
    {
        string searchText = "331";
        IQueryable<Guest> guests = new List<Guest>
            {
                new Guest
                {
                    Name = "1233"
                }
            }.AsQueryable( )
            .ApplyFilter( SearchContains<Guest>( searchText, static g => g.Name ) );
        Console.WriteLine( guests.Count( ) );
    }
}