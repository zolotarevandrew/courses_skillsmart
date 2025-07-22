namespace Tasks.Arrays.MaximumSubArray;

public static class MaximumSubArray
{
    /*
     * Given an array of integers, identify the contigious subarray containing at least one element.
     * That has the maximum sum and return the sum
     */
    public static int Run(int [] array)
    {
        if (array.Length == 0) return 0;

        int maxSum = array[0];
        
        for ( int i = 0; i < array.Length; i++ )
        {
            int curSum = array[i];
            for ( int j = i + 1; j < array.Length; j++ )
            {
                curSum += array[j];
                maxSum = Math.Max( maxSum, curSum );
            }
        }
        return maxSum;
    }
    
    public static int RunSlidingWindow(int [] array)
    {
        if ( array.Length == 0 ) return 0;

        int maxSum = array[0];
        int currentSum = array[0];

        for ( int i = 1; i < array.Length; i++ )
        {
            if (currentSum <= 0)
            {
                currentSum = array[i];
            }
            else
            {
                currentSum += array[i];
            }
            maxSum = Math.Max( maxSum, currentSum );
        }

        return maxSum;
    }
}