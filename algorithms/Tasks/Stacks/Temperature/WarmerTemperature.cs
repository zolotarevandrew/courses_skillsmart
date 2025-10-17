namespace Tasks.Stacks.Temperature;

public class WarmerTemperature
{
    /*
     * Given an array of integers representing the daily temperatures,
     * return an array where answer[i] is the number of days you have to wait after the i-th day
     * to get a warmer temperature. If no such day exists, set answer[i] = 0
     */
    public static int[] RunBruteforce( int[] temperatures )
    {
        int[] result = new int[temperatures.Length];
        for ( int i = 0; i < temperatures.Length; i++ )
        {
            for ( int j = i + 1; j < temperatures.Length; j++ )
            {
                if ( temperatures[j] > temperatures[i] )
                {
                    result[i] = j - i;
                    break;
                }
            }
        }
        return result;
    }
    
    public static int[] RunMonotonicStack( int[] temperatures )
    {
        int[] result = new int[temperatures.Length];
        Stack<int> stack = new Stack<int>( );
        for ( int i = 0; i < temperatures.Length; i++ )
        {
            while ( stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i])
            {
                int idx = stack.Pop( );
                result[idx] = i - idx;
            }
            
            stack.Push( i );
        }
        return result;
    }
}