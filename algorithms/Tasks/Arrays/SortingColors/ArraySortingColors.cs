namespace Tasks.Arrays.SortingColors;

public static class ArraySortingColors
{
    /*
     * Given an array of colors consisting red,green,blue  represented by 0,1,2
     * sort array so red,green,blue in sequence
     */

    public static void SortColors( int[] array )
    {
        Array.Sort( array );
    }
    
    public static void SortColorsV2( int[] array )
    {
        int red = 0;
        int green = 0;
        int blue = 0;
        
        foreach ( int t in array )
        {
            if ( t == 0 ) red++;
            if ( t == 1 ) green++;
            if ( t == 2 ) blue++;
        }

        for ( int i = 0; i < array.Length; i++ )
        {
            if ( red > 0 )
            {
                array[i] = 0;
                red--;
                continue;
            }
            
            if ( green > 0 )
            {
                array[i] = 1;
                green--;
                continue;
            }

            if ( blue > 0 )
            {
                array[i] = 2;
                blue--;
            }
        }
    }
    
    public static void SortColorsV3( int[] array )
    {
        int red = 0;
        int green = 0;
        int blue = 0;
        
        foreach ( int t in array )
        {
            if ( t == 0 ) red++;
            if ( t == 1 ) green++;
            if ( t == 2 ) blue++;
        }

        for ( int i = 0; i < array.Length; i++ )
        {
            if ( red > 0 )
            {
                array[i] = 0;
                red--;
                continue;
            }
            
            if ( green > 0 )
            {
                array[i] = 1;
                green--;
                continue;
            }

            if ( blue > 0 )
            {
                array[i] = 2;
                blue--;
            }
        }
    }

    public static void SortColorsDutchFlag( int[] array )
    {
        /*
         * low = 0, mid = 0, hi = 7

2 1 2 0 2 1 0 1

Бежим по циклу всех элементов, а сам индекс не используем

1) mid = 2, hi = 1
hi—
Swap hi, mid

1 1 2 0 2 1 0 2

2) mid = 1, hi  = 0
low++
mid++
Swap hi, mid

0 1 2 0 2 1 1 2

3) mid = 1, hi = 1
mid++

0 1 2 0 2 1 1 2

4) как в пункте 1

0 1 1 0 2 1 2 2

5) как в пункте 3
 
0 1 1 0 2 1 2 2

6) mid = 0, hi = 1
Swap(low, mid)
low++
mid++

0 0 1 1 2 1 2 2
7) также как в пункте 1

0 0 1 1 1 2 2 2
         */
        int low = 0, mid = 0, high = array.Length - 1;
        while (mid <= high)
        {
            switch ( array[mid] )
            {
                case 0:
                {
                    Swap( mid, low );
                    low++;
                    mid++;
                    break;
                }

                case 1:
                {
                    mid++;
                    break;
                }

                case 2:
                {
                    Swap( high, mid );
                    high--;
                    break;
                }
                    
                default: throw new ArgumentOutOfRangeException();
            }
        }

        void Swap( int index1, int index2 )
        {
            ( array[index1], array[index2] ) = ( array[index2], array[index1] );
        }
    }
}