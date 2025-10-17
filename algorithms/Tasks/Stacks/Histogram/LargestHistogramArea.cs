namespace Tasks.Stacks.Histogram;

public class LargestHistogramArea
{
    /*
     * Given an array of integers heights representing the heights of histogram's bars.
     * Where each bar has a width of 1, return the largest rectangular area in the histogram.
     */
    public static int Run( int[] arr )
    {
        if ( arr.Length == 0 )
            return 0;

        int maxArea = arr[0];

        for (int i = 0; i < arr.Length; i++)
        {
            int minArea = arr[i]; 
            for (int j = i + 1; j < arr.Length; j++)
            {
                minArea = Math.Min(arr[j], minArea);
                int curArea = minArea * (j - i + 1);
                maxArea = Math.Max(curArea, maxArea);
            }
        }

        return maxArea;
    }
    
    public static int RunStacks( int[] source )
    {
        if ( source.Length == 0 ) return 0;

        int maxArea = 0;
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i <= source.Length; i++)
        {
            int cur = i == source.Length 
                ? 0 
                : source[i];
            while ( stack.Count > 0 && source[stack.Peek( )] > cur )
            {
                int height = source[stack.Pop( )];
                
                int leftIndex = stack.Count > 0 ? stack.Peek() + 1 : 0;
                int rightIndex = i - 1;
                
                int width = rightIndex - leftIndex + 1;
                
                maxArea = Math.Max( maxArea, height * width );
            }
            
            stack.Push( i );
        }

        return maxArea;
    }
}