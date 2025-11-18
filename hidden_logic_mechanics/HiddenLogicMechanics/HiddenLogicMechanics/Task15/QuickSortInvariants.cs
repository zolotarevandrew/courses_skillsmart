namespace HiddenLogicMechanics.Task15;

public class QuickSortInvariants
{
    public static int[] Apply( int[] array )
    {
        Apply( array, 0, array.Length - 1 );
        return array;
    }
    
    static void Apply( int[] array, int start, int end )
    {
        if ( start >= end ) return;
        
        int pivot = Partition( array, start, end );
        Apply( array, start, pivot - 1 );
        Apply( array, pivot + 1, end );
    }

    /*
     * {P: arr.length > 0 и start < end }
     * Partition(arr, start, end)
     * { Q:
     *  array[res] = old_array[end]  &&
     *   (start .. res - 1 <= array[res]) &&
     *   (res + 1 .. end > array[res])
     * }
     *
     * Инвариант цикла
     * I: start <= i < end, start - 1 ≤ res < i, pivot = arr[end]
     *  (start..res  <= pivot) &&
     *  (res + 1 .. i - 1 > pivot)
     * 1. До начала первой итерации цикла: i = start и res = start - 1
        Проверка инварианта: 
        start - 1 <= start - 1 < i - да
        start..start-1 <= pivot - да
        start..start-1 > pivot - да
       2. Допустим, перед некоторой итерацией i = k, start <= k < end
          В теле цикла выполняем 
          
          res_next = res + 1, k_next = k + 1, если arr[k] <= pivot и ставим его на это место.
          Значит в начале следующей итерации, start..res_next <= pivot
          res_next+1 до k_next -1 > pivot - Инвариант сохраняется.
          
          k_next = k + 1, arr[k] > pivot
          Значит в начале следующей итерации 
            start..res <= pivot и res + 1 до k > pivot - потому что ничего не меняли и arr[k] > pivot
      3. Цикл завершается, когда i = end
        pivot встает на место res + 1
     */
    static int Partition( int[] array, int start, int end )
    {
        int pivot = array[end];
        int res = start - 1;
        for ( int i = start; i < end; i++ )
        {
            if ( array[i] <= pivot )
            {
                res++;
                Swap( array, res, i );
            }
        }

        res++;
        Swap( array, res, end );

        return res;
    }

    private static void Swap( int[] array, int i, int i1 )
    {
        ( array[i], array[i1] ) = ( array[i1], array[i] );
    }
}

