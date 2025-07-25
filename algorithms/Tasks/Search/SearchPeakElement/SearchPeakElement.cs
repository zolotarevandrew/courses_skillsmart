namespace Tasks.Search.SearchPeakElement;

public static class SearchPeakElement
{
    /*
     * A peak element is an element strictly greater than its neighbours
     * Given a 0 indexed array nums, return index of any peak element.
     * Assume nums[-1] and nums[nums.length] = -infinity
     */
    public static int Run( int[] array )
    {
        if ( array.Length == 0 ) return -1;
        
        for ( int i = 0; i < array.Length; i++ )
        {
            int current = array[i];
            int left = GetSafe(i - 1);
            int right = GetSafe(i + 1);

            if ( current >= left && current >= right )
            {
                return i;
            }
        }
        
        int GetSafe( int index )
        {
            if ( index < 0 ) return Int32.MinValue;
            if ( index >= array.Length ) return Int32.MinValue;

            return array[index];
        }
        
        return -1;
    }

    public static int RunBinarySearch( int[] array )
    {
        if ( array.Length == 0 ) return -1;

        int left = 0, right = array.Length - 1;
        while ( left < right )
        {
            int mid = ( left + right ) / 2;
            if ( array[mid] < array[mid + 1] )
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }
}