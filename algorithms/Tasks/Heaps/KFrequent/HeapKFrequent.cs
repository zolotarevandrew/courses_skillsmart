namespace Tasks.Heaps.KFrequent;

public class HeapKFrequent
{
    /*
     * Given an integer array nums and an integer k.
     * Find the k elements that appear most frequently in the array.
     */
    public static List<int> Run( int[] nums, int k )
    {
        if ( nums.Length == 0 || k <= 0 ) return [];
        
        Dictionary<int, int> frequencyByNum = new Dictionary<int, int>();
        for ( int i = 0; i < nums.Length; i++ )
        {
            int num = nums[i];
            if ( !frequencyByNum.TryAdd( num, 1 ) )
            {
                frequencyByNum[num]++;
            }
        }

        PriorityQueue<int, int> heap = new PriorityQueue<int, int>( k );
        foreach ( ( int num, int frequency ) in frequencyByNum )
        {
            heap.Enqueue( num, frequency );

            if ( heap.Count > k )
            {
                heap.Dequeue( );
            }
        }

        List<int> result = [];
        while ( heap.Count > 0 )
        {
            result.Add( heap.Dequeue() );
        }

        return result;
    }
}