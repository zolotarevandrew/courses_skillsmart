namespace Tasks.Bits;

public class Bits
{
    public static string Convert( int num )
    {
        if ( num == 0 )
        {
            return string.Empty;
        }

        string res = Convert( num / 2 );
        return res + ( num % 2 );
    }

    public static int NumberOfOneBits( int num )
    {
        int res = 0;
        while ( num > 0 )
        {
            res += num & 1;
            num >>= 1;
        }
        return res;
    }
    
    public static int ReverseBits( int num )
    {
        int res = 0;
        for ( int i = 31; i >= 0 && num > 0; i-- )
        {
            int bit = num & 1;
            if (bit == 1)
            {
                res |= 1 << i; 
            }

            num >>= 1;
        }
        return res;
    }
    
    public static int ReverseBitsV2( int num )
    {
        int res = 0;
        for (int i = 0; i < 32; i++)
        {
            res <<= 1;
            res |= num & 1;
            num >>= 1;
        }

        return res;
    }

    /*
     * Given an array of nums containing n distinct numbers from the range [0,n]
     * One number is missing from the array. Find and return missing number
     */
    public static int MissingNumber( int[] arr )
    {
        // также можно через разницу сумм, взяв формулу n * (n + 1) / 2
        
        int res = arr.Length;
        for ( int idx = 0; idx < arr.Length; idx++ )
        {
            res ^= idx ^ arr[idx];
        }
        return res;
    }
    
    /*
     * You are given a non empty list of integers, where every element appears exactly twice
     * Except for one unique number that appears only once
     * 
     */
    public static int SingleNumber( int[] arr )
    {
        int res = 0;
        for ( int idx = 0; idx < arr.Length; idx++ )
        {
            res ^= arr[idx];
        }
        return res;
    }
    
    public static int Sum( int num1, int num2 )
    {
        while ( num2 != 0 )
        {
            var carry = num1 & num2;
            num1 ^= num2;
            num2 = carry << 1;
        }

        return num1;
    }

    /*
     * Given an integer n, compute the number of 1 bits in the binary representation
     * of every number from 0 to num
     * Return the list output such that output[i] represent the count of 1 bits in the binary form of i.
     */
    public static int[] CountingBits( int num )
    {
        List<int> res = [];
        for ( int i = 0; i <= num; i++ )
        {
            res.Add( OneBitCount( i ));
        }
        return res.ToArray(  );
    }
    
    public static int[] CountingBitsV2( int num )
    {
        int[] res = new int[num + 1];
        int offset = 1;
        for ( int idx = 1; idx <= num; idx++ )
        {
            if ( offset * 2 == idx )
            {
                offset = idx;
            }
            
            res[idx] = 1 + res[idx - offset];
        }
        return res;
    }

    private static int OneBitCount( int nn )
    {
        int res = 0;
        while ( nn != 0 )
        {
            res += nn & 1;
            nn >>= 1;
        }

        return res;
    }
}