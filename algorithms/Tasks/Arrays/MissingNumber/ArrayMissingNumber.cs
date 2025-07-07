namespace Tasks.Arrays.MissingNumber;

public class ArrayMissingNumber
{
    /*
     * Given an array of integers containing n distinct number in the range [0..n], find the missing number.
     */

    public static int FindMissingNumber( int[] array )
    {
        int n = array.Length;
        int sum = 0;
        for ( int i = 0; i < n; i++ )
        {
            sum += array[i];
        }

        int expectedSum = ( n * ( n + 1 ) ) / 2;
        return expectedSum - sum;
    }

    public static int FindMissingNumberV2( int[] array )
    {
        var set = new HashSet<int>( array );
        int n = array.Length;
        foreach ( int number in Enumerable.Range( 0, n ) )
        {
            if ( !set.Contains( number ) ) return number;
        }

        return -1;
    }
    
    public static int FindMissingNumberV3( int[] array )
    {
        // 0 1 2 3 - length 4, last 3
        Array.Sort( array );
        if ( array[0] != 0 ) return 0;
        
        int last = array.Length - 1;
        if ( array[^1] != last ) return last;
        
        for ( int i = 1; i < array.Length - 1; i++ )
        {
            if (array[i] != i) return i;
        }
        
        return -1;
    }
}