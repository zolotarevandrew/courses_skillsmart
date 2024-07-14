namespace h_work.lesson61;

public interface IAdditionOperator<TSelf>
    where TSelf : IAdditionOperator<TSelf>
{
    static abstract TSelf operator +(TSelf left, TSelf right);
}

public class Vector<T> : IAdditionOperator<Vector<T>> 
    where T : IAdditionOperator<T>
{
    private readonly List<T> _source;

    public Vector(List<T> source)
    {
        _source = source;
    }
    
    public static Vector<T> operator +(Vector<T> left, Vector<T> right)
    {
        if (left._source.Count != right._source.Count)
        {
            throw new InvalidOperationException("not supported list with different count of elements");
        }

        var lst = new List<T>();
        for (int idx = 0; idx < left._source.Count; idx++)
        {
            var item1 = left._source[idx];
            var item2 = right._source[idx];
            lst.Add(item1 + item2);
        }
        return new Vector<T>(lst);
    }
}

public struct AdditionInt : IAdditionOperator<AdditionInt>
{
    private readonly int _source;

    public AdditionInt(int source)
    {
        _source = source;
    }
    public static AdditionInt operator +(AdditionInt left, AdditionInt right)
    {
        return new AdditionInt(left._source + right._source);
    }
}

public struct AdditionString : IAdditionOperator<AdditionString>
{
    private readonly string _source;

    public AdditionString(string source)
    {
        _source = source;
    }
    public static AdditionString operator +(AdditionString left, AdditionString right)
    {
        return new AdditionString(left._source + right._source);
    }
}

public static class Example61
{
    public static void Test()
    {
        var g1 = 1;
        var g2 = 2;

        //3
        var g3 = g1 + g2;

        var vector1 = new Vector<AdditionInt>(new List<AdditionInt>
        {
            new(1),
            new(2)
        });
        var vector2 = new Vector<AdditionInt>(new List<AdditionInt>
        {
            new(3),
            new(4)
        });
        var vstr = new Vector<AdditionString>(new List<AdditionString>
        {
           new AdditionString("1"),
           new AdditionString("2")
        });

      
        //var vector3 = vector1 + vstr;
        var vector = vector1 + vector2;

        var res = vector;

        var vVector1 = new Vector<Vector<AdditionInt>>(new List<Vector<AdditionInt>>
        {
            vector1,
            vector2
        });
        var vVector2 = new Vector<Vector<AdditionInt>>(new List<Vector<AdditionInt>>
        {
            vector1,
            vector2
        });

        var vVector = vVector1 + vVector2;
            
    }
} 