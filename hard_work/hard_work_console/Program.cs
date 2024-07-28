
//we just dont need it..
static IEnumerable<int> FibsSum(IEnumerable<int> fibs)
{
    int fsum = 0;
    foreach (var fib in fibs)
    {
        fsum += fib;
        yield return fsum;
    }
}

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

foreach (var num in GetFibs(20))
{
    Console.WriteLine(num);
}