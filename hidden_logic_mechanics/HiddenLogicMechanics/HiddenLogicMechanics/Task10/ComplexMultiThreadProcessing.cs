using System.Collections.Concurrent;

namespace HiddenLogicMechanics.Task10;

public class ComplexMultiThreadProcessing
{
    private static readonly int SIZE = 6;
    private static readonly int THREADS = 4;
    private static readonly int[] data = new int[SIZE];
    private static long sum = 0;

    public static void Run( )
    {
        Random random = new Random( );
        for ( int i = 0; i < SIZE; i++ )
        {
            data[i] = i;
        }
        ParallelOptions options = new ParallelOptions
        {
            MaxDegreeOfParallelism = THREADS
        };
        int chunkSize = 2;
        OrderablePartitioner<Tuple<int, int>> ranges = Partitioner.Create( 0, data.Length, chunkSize );
        Parallel.ForEach( ranges, options, range =>
        {
            long local = 0;
            for ( int i = range.Item1; i < range.Item2; i++ )
                local += data[i];
            Console.WriteLine(range);
            Interlocked.Add( ref sum, local );
        } );
        Console.WriteLine( sum );
    }
}