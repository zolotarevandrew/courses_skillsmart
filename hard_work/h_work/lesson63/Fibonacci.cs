namespace h_work.lesson63;

public static class Fibonacci
{
    static IEnumerable<int> GetFibs(int num)
    {
        int a = 0, b = 1;
        for (int i = 0; i < num; i++)
        {
            yield return a;
            //swap with tuples deconstruction
            (a, b) = (b, a + b);
        }
    }

    public static void Example()
    {
        foreach (var num in GetFibs(20))
        {
            Console.WriteLine(num);
        }    
    }
}