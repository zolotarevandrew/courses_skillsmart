namespace Sorting;

public static class InsertionSort
{
    public static void Sort(int[] array)
    {
        for (int unsortedIdx = 1; unsortedIdx < array.Length; unsortedIdx++)
        {
            int currentUnsortedItem = array[unsortedIdx];
            
            int sortedPartEnd = unsortedIdx;
            
            while (sortedPartEnd > 0 && currentUnsortedItem < array[sortedPartEnd - 1])
            {
                array[sortedPartEnd] = array[sortedPartEnd - 1];
                sortedPartEnd--;
            }

            array[sortedPartEnd] = currentUnsortedItem;
        }
        
        
    }
}