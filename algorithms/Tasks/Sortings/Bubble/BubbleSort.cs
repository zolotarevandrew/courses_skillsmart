namespace Tasks.Sortings.Bubble;

public static class BubbleSort
{
    public static int[] Apply( int[] array )
    {
        for ( int i = 0; i < array.Length; i++ )
        {
            bool swapped = false;
            for ( int j = 0; j < array.Length - i - 1; j++ )
            {
                int prev = array[j];
                int cur = array[j + 1];
                
                if ( prev > cur )
                {
                    array[j] = cur;
                    array[j + 1] = prev;
                    swapped = true;
                }
            }

            if ( !swapped ) break;
        }
        return array;
    }
}