namespace Tasks.Search.SearchRotatedArray;

public static class SearchRotatedArray
{
    /*
     * Given sorted array of nums that has been rotated.
     * The array contains unique integers.
     * Find the max element in the array.
     */
    public static int RunBinarySearch( int[] array, int val )
    {
        if ( array.Length == 0 ) return -1;


        int left = 0, right = array.Length - 1;
        while ( left <= right )
        {
            int mid = ( left + right ) / 2;
            if ( array[mid] == val )
            {
                return mid;
            }

            if ( array[left] <= array[mid] )
            {
                if ( array[left] <= val && val < array[mid] )
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            else
            {
                if ( array[mid] < val && val <= array[right] )
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
        }

        return -1;
    }
}