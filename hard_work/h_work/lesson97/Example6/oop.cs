

public class MyComparer<T> : IComparer<T>
{
    public int Compare(T x, T y) => Comparer<T>.Default.Compare(x, y);
}