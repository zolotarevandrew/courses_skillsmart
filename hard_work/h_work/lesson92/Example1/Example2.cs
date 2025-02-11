namespace h_work.lesson92.Example1;

using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using static MonoidExtensions;

class Program
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
        
        var combinedExpression = Fold(filters, new SqlExpressionMonoid<User>());
        string sqlQuery = $"SELECT * FROM users WHERE {SqlExpressionConverter.ToSql(combinedExpression)};";

        Console.WriteLine(sqlQuery);
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
    
    record User(string Name, int Age, string City);
}

public readonly struct SqlExpressionMonoid<T> : IMonoid<Expression<Func<T, bool>>>
{
    public Expression<Func<T, bool>> Combine(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
    {
        var parameter = Expression.Parameter(typeof(T));

        var combinedBody = Expression.AndAlso(
            Expression.Invoke(left, parameter),
            Expression.Invoke(right, parameter)
        );

        return Expression.Lambda<Func<T, bool>>(combinedBody, parameter);
    }

    public Expression<Func<T, bool>> Zero => x => true;
}

public static class SqlExpressionConverter
{
    public static string ToSql<T>(Expression<Func<T, bool>> expression)
    {
        return new ExpressionToSqlVisitor().Convert(expression.Body);
    }
}

public class ExpressionToSqlVisitor : ExpressionVisitor
{
    private readonly StringBuilder _sql = new();

    public string Convert(Expression expression)
    {
        Visit(expression);
        return _sql.ToString();
    }

    protected override Expression VisitBinary(BinaryExpression node)
    {
        _sql.Append("(");
        Visit(node.Left);

        switch (node.NodeType)
        {
            case ExpressionType.AndAlso:
                _sql.Append(" AND ");
                break;
            default: throw new NotSupportedException();
        }

        Visit(node.Right);
        _sql.Append(")");
        return node;
    }

    protected override Expression VisitMember(MemberExpression node)
    {
        switch (node.Expression)
        {
            case ParameterExpression:
                _sql.Append(node.Member.Name);
                break;
            case ConstantExpression constantExpr:
            {
                var value = ((FieldInfo)node.Member).GetValue(constantExpr.Value);
                Visit(Expression.Constant(value));
                break;
            }
            default:
                throw new NotSupportedException();
        }

        return node;
    }

    protected override Expression VisitConstant(ConstantExpression node)
    {
        switch (node.Value)
        {
            case bool booleanValue:
                _sql.Append(booleanValue ? "1=1" : "1=0");
                break;
            case string str:
                _sql.Append($"'{str}'");
                break;
            default:
                _sql.Append(node.Value);
                break;
        }

        return node;
    }
}
