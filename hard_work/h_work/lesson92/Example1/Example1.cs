using System.Linq.Expressions;
using static h_work.lesson92.Example1.MonoidExtensions;

namespace h_work.lesson92.Example1;

public class Example1
{
    static void Main()
    {
        var users = new List<User>
        {
            new("Alice", 30, "New York"),
            new("Bob", 25, "San Francisco"),
            new("Charlie", 35, "New York"),
        };
        
        var filters = GetFilters(age: 28, city: "New York");
        
        var combinedFilter = Fold(filters, new PredicateMonoid<User>()).Compile();

        var filteredUsers = users.Where(combinedFilter).ToList();

        foreach (var user in filteredUsers)
        {
            Console.WriteLine($"{user.Name}, {user.Age}, {user.City}");
        }
    }
    
    static IEnumerable<Expression<Func<User, bool>>> GetFilters(int age, string city)
    {
        return new List<Expression<Func<User, bool>>>
        {
            EqualAgeFilter(age),
            EqualCityFilter(city)
        };
    }

    static Expression<Func<User, bool>> EqualAgeFilter(int age) => u => u.Age > age;
    static Expression<Func<User, bool>> EqualCityFilter(string city) => u => u.City == city;
}

record User(string Name, int Age, string City);
public readonly struct PredicateMonoid<T> : IMonoid<Expression<Func<T, bool>>>
{
    public Expression<Func<T, bool>> Combine(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
    {
        var parameter = Expression.Parameter(typeof(T), "x");

        var combinedBody = Expression.AndAlso(
            Expression.Invoke(left, parameter),
            Expression.Invoke(right, parameter)
        );

        return Expression.Lambda<Func<T, bool>>(combinedBody, parameter);
    }

    public Expression<Func<T, bool>> Zero => _ => true;
}

public interface ISemiGroup<T>
{
    T Combine(T left, T right);
}

public interface IMonoid<T> : ISemiGroup<T>
{
    T Zero { get; }
}

public static class MonoidExtensions
{
    public static T Fold<T, M>(IEnumerable<T> collection, M monoid)
        where M : struct, IMonoid<T>
    {
        var result = monoid.Zero;
        foreach (var item in collection)
        {
            result = monoid.Combine(result, item);
        }

        return result;
    }
}