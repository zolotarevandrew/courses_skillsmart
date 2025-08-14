namespace Tasks.Hashtables.LongestConsecutiveSequence;

public class LongestConsecutiveSequence
{
    /*
     * given an array of colors consisting red, green, blue, by number 0,1,2
     * sort the array so all red, green, blue are in order
     */
    public static int Run( int[] array )
    {
        HashSet<int> set = new HashSet<int>( array );
        int longest = 0;
        foreach ( int t in array )
        {
            int streak = 0;
            int cur = t;
            while ( set.Contains( cur ) )
            {
                streak++;
                cur++;
            }
            
            longest = Math.Max( longest, streak );
        }

        return longest;
    }
    
    public static int Run2( int[] array )
    {
        HashSet<int> set = new HashSet<int>( array );
        int longest = 0;
        foreach ( int value in set )
        {
            if ( set.Contains( value - 1 ) ) continue;

            int streak = 1;
            int cur = value + 1;
            while ( set.Contains( cur ) )
            {
                streak++;
                cur++;
            }
            
            longest = Math.Max( longest, streak );
            
        }

        return longest;
    }
}