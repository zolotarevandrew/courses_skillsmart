namespace Tasks.Sortings.Quick;

public static class QuickSort
{
    /*
       Works by selecting pivot element partioning array around the pivot
       and then recursively sorting the sub arrays.
       
       Pivot:
       First element,
       Last Element,
       Random Element
       Median of three - median of first, middle and last element
       
       Once the pivot is chosen the array is rearranged so that all elements smaller than the pivot appear on the left.
       Greater on the right.
       This is done recursively until the array is sorted.
     */
    public static int[] Apply( int[] array )
    {
        Apply( array, 0, array.Length - 1 );
        return array;
    }
    
    private static void Apply( int[] array, int start, int end )
    {
        if ( start >= end ) return;
        
        int pivot = Partition( array, start, end );
        Apply( array, start, pivot - 1 );
        Apply( array, pivot + 1, end );
    }

    public static int Partition( int[] array, int start, int end )
    {
        int pivot = array[end];
        int i = start - 1;
        for ( int j = start; j < end; j++ )
        {
            if ( array[j] <= pivot )
            {
                i++;
                Swap( array, i, j );
            }
        }

        i++;
        Swap( array, i, end );

        return i;
    }

    private static void Swap( int[] array, int i, int i1 )
    {
        ( array[i], array[i1] ) = ( array[i1], array[i] );
    }
}