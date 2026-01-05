namespace Tasks.Heaps.KLargest;

public class HeapKLargest
{
    /*
     * Given an integer array nums and an integer k.
     * Find the element that ranks as kth highest in the array
     * When sorted in descending order.
     * Note that it is the kth largest element in the sorted sequence,
     * not necessarily a distinct value.
     */
    public static int Run( int[] nums, int k )
    {
        if ( nums.Length == 0 ) return -1;
        if ( k <= 0 || k > nums.Length ) return -1;

        PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>( k );

        for ( int i = 0; i < k; i++ )
        {
            priorityQueue.Enqueue( nums[i], nums[i] );
        }
        
        for ( int i = k; i < nums.Length; i++ )
        {
            int element = priorityQueue.Peek( );
            if ( nums[i] > element )
            {
                priorityQueue.DequeueEnqueue( nums[i], nums[i] );    
            }
        }

        int res = priorityQueue.Dequeue( );
        priorityQueue.Clear( );
        return res;
    }
}