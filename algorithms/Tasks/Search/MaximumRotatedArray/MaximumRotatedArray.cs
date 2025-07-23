namespace Tasks.Search.MaximumRotatedArray;

public static class MaximumRotatedArray
{
    /*
     * Given sorted array of nums that has been rotated.
     * The array contains unique integers.
     * Find the max element in the array.
     */
    public static int RunBinarySearch( int[] array )
    {
        if ( array.Length == 0 ) return -1;
        if ( array.Length == 1 ) return array[0];
        
        int left = 0, right = array.Length - 1;
        while ( left < right )
        {
            int mid = ( left + right + 1 ) / 2;
            
            if ( array[mid] >= array[left] )
            {
                left = mid;
            }
            else
            {
                right = mid - 1;
            }
        }
        return array[left];
    }
}