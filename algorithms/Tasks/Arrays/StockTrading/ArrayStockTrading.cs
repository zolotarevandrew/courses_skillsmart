namespace Tasks.Arrays.StockTrading;

public class ArrayStockTrading
{
    /*
     * Given an array of prices where prices[i] is the stock price of the day[i]
     * Determine the maximum profit you can achieve by byiung and selling once.
     * Return 0 if no profit is possible.
     */

    public static int Run( int[] array )
    {
        if ( array.Length == 0 ) return 0;
        
        int max = 0;
        
        for ( int i = 0; i < array.Length; i++ )
        {
            for ( int j = i + 1; j < array.Length; j++ )
            {
                int buy = array[i];
                int sell = array[j];
                int profit = sell - buy;
                max = Math.Max( max, profit );
            }
        }
        return max;
    }
    
    public static int RunSlidingWindow( int[] array )
    {
        if ( array.Length == 0 ) return 0;

        int minPrice = int.MaxValue;
        int maxProfit = 0;
        foreach ( int t in array )
        {
            minPrice = Math.Min( minPrice, t );
            maxProfit = Math.Max( maxProfit, t - minPrice );
        }

        return maxProfit;
    }
}