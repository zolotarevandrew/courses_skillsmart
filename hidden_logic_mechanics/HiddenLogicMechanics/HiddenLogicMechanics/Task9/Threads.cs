namespace HiddenLogicMechanics.Task9;

public class Threads
{
    private static int _counter = 0;

    public static void Main()
    {
        Thread thread1 = new Thread(Increment);
        Thread thread2 = new Thread(Increment);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine($"Counter: {_counter}");
    }

    private static void Increment( )
    {
        for ( int i = 0; i < 1000; i++ )
        {
            Interlocked.Increment( ref _counter );
        }
    }
}