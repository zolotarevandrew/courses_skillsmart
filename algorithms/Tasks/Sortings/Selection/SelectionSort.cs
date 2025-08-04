namespace Tasks.Sortings.Selection;

public static class SelectionSort
{
    /*
     * Sinking sort - selects the smallest element from the list and places it at the left most index of the list.
     * Divides the list into two parts, a sorted part and an unsorted part.
     * Initially the sorted part is empty, and the unsorted portion contains the entire list.
     * The algorithm repeateadly selects the smallest elements from the unsorted portion and swaps it with the first unsorted element.
     */
    public static int[] Apply( int[] array )
    {
        if ( array.Length <= 1 ) return array;
        
        for ( int sortedIdx = 0; sortedIdx < array.Length; sortedIdx++ )
        {
            int minIdx = sortedIdx;
            for ( int unsortedIdx = sortedIdx + 1; unsortedIdx < array.Length; unsortedIdx++ )
            {
                if ( array[unsortedIdx] < array[minIdx] )
                {
                    minIdx = unsortedIdx;
                }
            }
            
            ( array[minIdx], array[sortedIdx] ) = ( array[sortedIdx], array[minIdx] );
        }

        return array;
    }
}