namespace Tasks.Sortings.Insertion;

public static class InsertionSort
{
    /*
     * Diving list into a sorted portion and unsorted portion
     * Initially the sorted portion contains first element.
     * Unsorted portion contains the rest of the elements.
     * Algorithm repeateadly takes the first element from unsorted portion
     * and inserts it into correct position of sorted portion.
     * This process continues until the unsorted portion is empty.
     */
    public static int[] Apply( int[] array )
    {
        if ( array.Length <= 1 ) return array;
        
        for ( int curIdx = 1; curIdx < array.Length; curIdx++ )
        {
             int insertValue = array[curIdx];
             int prevIdx = curIdx - 1;
            
             while ( prevIdx >= 0 && array[prevIdx] > insertValue )
             {
                 array[prevIdx + 1] = array[prevIdx];
                 prevIdx--;
             }
             
             array[prevIdx + 1] = insertValue;
        }
        
        return array;
    }
}