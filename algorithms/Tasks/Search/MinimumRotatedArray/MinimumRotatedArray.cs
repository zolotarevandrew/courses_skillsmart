namespace Tasks.Search.MinimumRotatedArray;

public static class MinimumRotatedArray
{
    /*
     * Given sorted array of nums that has been rotated.
     * The array contains unique integers.
     * Find the minimum element in the array.
     */
    public static int Run( int[] array )
    {
        if ( array.Length == 0 ) return -1;
        int min = array[0];
        for ( int i = 1; i < array.Length; i++ )
        {
            if ( array[i] < array[i - 1] )
            {
                return array[i];
            }
        }
        return min;
    }
    
    public static int RunBinarySearch( int[] array )
    {
        if ( array.Length == 0 ) return -1;
        if ( array.Length == 1 ) return array[0];
        if ( array.Length == 2 ) return Math.Min( array[0], array[1] );
        
        int left = 0, right = array.Length - 1;
        while ( left < right )
        {
            int mid = ( left + right ) / 2;
            
            if ( array[mid] > array[right] )
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }
        return array[left];
    }
}