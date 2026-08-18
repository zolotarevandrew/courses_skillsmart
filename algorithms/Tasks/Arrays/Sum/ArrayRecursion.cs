namespace Tasks.Arrays.Sum;

public class ArrayRecursion
{
    public static long Sum( int[] arr )
    {
        if ( arr.Length == 0 ) return 0;
        return arr[0] + Sum( arr[1..] );
    }

    public static int Count( int[] arr )
    {
        if ( arr.Length == 0 ) return 0;
        return 1 + Count( arr[1..] );
    }
    
    public static int Max( int[] arr )
    {
        if ( arr.Length == 0 ) return -1;
        return Math.Max( arr[0], Max( arr[1..] ) );
    }

    public static int BinSearch( int[] arr, int value )
    {
        static int InternalBinSearch( int[] arr, int value, int low, int hi )
        {
            if ( low > hi ) return -1;
            
            int mid = (low + hi) / 2;
            if ( arr[mid] == value ) return mid;
            return arr[mid] < value
                ? InternalBinSearch( arr, value, mid + 1, hi )
                : InternalBinSearch( arr, value, low, mid - 1 );
        }

        return InternalBinSearch( arr, value, 0, arr.Length - 1 );
    }
}