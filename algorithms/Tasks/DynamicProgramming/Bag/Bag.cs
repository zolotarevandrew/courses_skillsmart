namespace Tasks.DynamicProgramming.Climbing;

public class Bag
{
    public static int[,] Run(int maxCapacity, (int weight, int price)[] elements)
    {
        int[,] dp = new int[elements.Length + 1, maxCapacity + 1];
        int rows = dp.GetLength(0);
        int cols = dp.GetLength(1);
        for (int rr = 1; rr < rows; rr++)
        {
            for (int cc = 1; cc < cols; cc++)
            {
                (int weight, int price) = elements[rr - 1];
                dp[rr, cc] = weight > cc
                    ? dp[rr - 1, cc]
                    : Math.Max(dp[rr - 1, cc], dp[rr - 1, cc - weight] + price);
            }
        }
        return dp;
    }
}
