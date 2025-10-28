namespace Tasks.DynamicProgramming.Climbing;

public class ClimbingStairs
{
    /*
     * You are given an integer n, which represents a total number of steps in a staircase.
     * You can climb either 1 step or 2 steps at a time.
     * Return the number of unique ways you can reach the top.
     */
    public static int Run( int n )
    {
        if ( n <= 2 )
        {
            return n;
        }

        int oneStep = Run( n - 1 );
        int secondStep = Run( n - 2 );
        return oneStep + secondStep;
    }
    
    public static int RunMemo( int n, Dictionary<int, int> memo )
    {
        if ( memo.TryGetValue( n, out int runMemo ) )
        {
            return runMemo;
        }
        
        if ( n <= 2 )
        {
            return n;
        }

        int oneStep = RunMemo( n - 1, memo );
        int secondStep = RunMemo( n - 2, memo );
        memo[n] = oneStep + secondStep;
        return memo[n];
    }
    
    public static int RunTabulation( int n )
    {
        if ( n <= 2 )
        {
            return n;
        }

        int[] dp = new int[n + 1];
        dp[1] = 1;
        dp[2] = 2;

        for ( int idx = 3; idx <= n; idx++ )
        {
            dp[idx] = dp[idx - 1] + dp[idx - 2];
        }

        return dp[n];
    }
}