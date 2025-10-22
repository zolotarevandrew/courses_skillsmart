namespace Tasks.Queues.SlidingWindow;

public class SlidingWindowMaximum
{
    /*
     * You are given an array of integers num, and a sliding window of size k
     * that moves from the very left of the array to the very right.
     * You can only see the k numbers in the window at each move.
     * The sliding window moves one position to the right at a time.
     * Return the array of the maximums for each window position.
     */
    public static List<int> Run( int[] num, int k )
    {
        List<int> res = new List<int>();

        if ( num.Length < k || k <= 0 ) return res;

        for ( int left = 0; left <= num.Length - k; left++ )
        {
            int right = left + k;
            int max = num[left];
            for ( int i = left + 1; i < right; i++ )
            {
                max = Math.Max( max, num[i] );
            }
            res.Add( max );
        }

        return res;
    }
}