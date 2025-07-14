namespace Tasks.Arrays.ProductExceptSelf;

public static class ArrayProductExceptSelf
{
    /*
     * Given integer array of nums. Return an array result
     * that result[i] contains the product of all elements in nums except num[i]
     * The solution must use O(n) time and must not use division
     *
     * in - 2, 3, 4, 5
     * out - 60, 40, 30, 24
     *
     * in - 1, 2, 0, 4
     * out - 0, 0, 8, 0
     *
     * 2 - * 3 4 5 = 120 / 2 = 60
     * 3 - 2 * 4 5 = 2 * 3 * 4 * 5
     * 4 - 2 3 * 5
     * 5 - 2 3 4 *
     */
    public static long[] ProductExceptSelf( int[] array )
    {
        int n = array.Length;
        long[] res = new long [n];
        for ( int i = 0; i < n; i++ )
        {
            res[i] = 1;
        }

        for ( int i = 1; i < n; i++ )
        {
            res[i] = array[i - 1] * res[i - 1];
        }

        int product = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            res[i] *= product;
            product *= array[i];
        }

        return res;
    }
    
    public static long[] ProductExceptSelfV2( int[] array )
    {
        int n = array.Length;
        int zeroCnt = 0;
        int product = 1;
        for (int i = 0; i < n; i++)
        {
            if ( array[i] == 0 )
            {
                zeroCnt++;
                continue;
            }
            product *= array[i];
        }

        long[] res = new long[n];
        if ( zeroCnt > 1 )
        {
            return new long[n];
        }
        
        for (int i = 0; i < n; i++)
        {
            if ( zeroCnt > 0 )
            {
                res[i] = array[i] == 0 ? product : 0;
                continue;
            }
            res[i] = product / array[i];
        }

        return res;
    }
}