namespace Tasks.Arrays.MaximumContainerArea;

public class ArrayMaximumContainerArea
{
    /*
     * Given an array of height where height[i] is the height of the vertical line at position i.
     * Find the maximum area of water a container can store, where the container by the two lines and the x-axis.
     */
    public static int Run( int[] array )
    {
        int area = 0;
        for ( int left = 0; left < array.Length; left++ )
        {
            for ( int right = left + 1; right < array.Length; right++ )
            {
                int height = Math.Min( array[left], array[right] );
                int width = right - left;
                int curArea = height * width;
                area = Math.Max( area, curArea );
            }
        }
        return area;
    }
    
    public static int RunTwoPointers( int[] array )
    {
        int area = 0;
        int left = 0;
        int right = array.Length - 1;
        while ( left < right )
        {
            int height = Math.Min( array[left], array[right] );
            int width = right - left;
            int curArea = height * width;
            area = Math.Max( area, curArea );

            if ( height == array[left] )
            {
                left++;
            }

            if ( height == array[right] )
            {
                right--;
            }
        }
        return area;
    }
}