using System.Linq;
namespace Tasks.Sortings.Counting;

public static class CountingSort
{
    /*
     * Efficient when the range value is small compared to number of elements to be sorted.
     * The basic idea is to count the frequency of each distinct element in the input array.
     * And use that information to place the elements in their correct sorted positions
     * 1. Counting phase - first determine the range of input data (i.e the minimum and maximum values)
     * It then creates the counting array (or histogram) to store the frequency of each element in the frequence array.
     * 
     * 2. Cumulative counting phase (optional) - the counting array is modified to store еру cumulative count of elements.
     * This helps in determining the correct position of each element in the frequency array.
     *
     * 3. Sorting phase - iterates through the input array, places each element in its correct position
     * in the output array based on cumulative count, and decrements the count for that element
     */
    public static int[] Apply( int[] array )
    {
        if ( array.Length <= 1 ) return array;
        
        (int min, int max) = FindMinMax( array );
        int range = max - min + 1;
        
        int[] counts = new int[range];
        foreach ( int val in array )
        {
            counts[val - min] += 1;
        }
        
        List<int> sorted = [];
        for ( int idx = 0; idx < counts.Length; idx++ )
        {
            int freq = counts[idx];
            int value = min + idx;
            for ( int i = 0; i < freq; i++ )
            {
                sorted.Add(value);
            }
        }
        
        return sorted.ToArray();
    }

    static (int Min, int Max) FindMinMax( int[] array )
    {
        int min = array[0], max = array[0];

        foreach ( int val in array )
        {
            if ( val < min ) min = val;
            if ( val > max ) max = val;
        }

        return ( min, max );
    }
}