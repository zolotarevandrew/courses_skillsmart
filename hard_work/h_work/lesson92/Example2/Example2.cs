namespace h_work.lesson92.Example2;

public class Example2
{
    public void Main()
    {
        var ring24 = new ModuloRing(24);

        int time1 = 18;
        int time2 = 10;

        int result = ring24.Combine(time1, time2);
        int doubleTime = ring24.Times(time1, 2); 
    }
}

public interface IRing<T> : IGroup<T>
{
    T One { get; }
    T Times(T left, T right);
}

public readonly struct ModuloRing(int mod) : IRing<int>
{
    public int Zero => 0;
    public int One => 1;
    public int Combine(int left, int right) => (left + right) % mod;
    public int Times(int left, int right) => (left * right) % mod;
    public int Inverse(int item) => (mod - item) % mod;
}