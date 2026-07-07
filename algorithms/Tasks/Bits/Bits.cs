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
}