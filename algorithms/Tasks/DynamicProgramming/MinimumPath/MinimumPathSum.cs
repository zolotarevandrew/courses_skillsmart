namespace Tasks.DynamicProgramming.MinimumPath;

public class MinimumPathSum
{
    /*
     * You are given an m x n grid filled with non negative integers.
     * Task is to find a path from top-left corner to the bottom right corner
     * that minimizes the sum of all numbers along the way.
     * You may only move down or right at any point.
     */
    public static long Run( int[,] arr )
    {
        int rows = arr.GetLength( 0 );
        int columns = arr.GetLength( 1 );
        
        long RunInternal( int row, int column )
        {
            bool isEnd = row == rows - 1 && column == columns - 1;
            if ( isEnd ) return arr[row, column];

            if ( row >= rows || column >= columns )
                return Int64.MaxValue;

            long sum = arr[row, column];
            long rightSum = RunInternal( row, column + 1 );
            long downSum = RunInternal( row + 1, column );

            return sum + Math.Min( rightSum, downSum );
        }

        return RunInternal( 0, 0 );
    }
    
    public static long RunMemo( int[,] arr )
    {
        int rows = arr.GetLength( 0 );
        int columns = arr.GetLength( 1 );

        long[,] memo = new long[rows, columns];
        for (int r = 0; r < rows; r++)
        for ( int c = 0; c < columns; c++ )
            memo[r, c] = -1;

        long RunInternal( int row, int column )
        {
            if ( row >= rows || column >= columns )
                return Int64.MaxValue;
            
            if ( memo[row, column] != -1 )
                return memo[row, column];
 
            if ( row == rows - 1 && column == columns - 1 )
                return arr[row, column];
            
            long sum = arr[row, column];
            long rightSum = RunInternal( row, column + 1 );
            long downSum = RunInternal( row + 1, column );

            long minSum = sum + Math.Min( rightSum, downSum );
            memo[row, column] = minSum;
            return minSum;
        }

        return RunInternal( 0, 0 );
    }
    
    public static long RunTabulation( int[,] arr )
    {
        int rows = arr.GetLength( 0 );
        int columns = arr.GetLength( 1 );

        if ( rows == 0 || columns == 0 ) return 0;

        long[,] dp = new long[rows, columns];
        dp[0, 0] = arr[0, 0];

        for ( int c = 1; c < columns; c++ )
        {
            dp[0, c] = dp[0, c - 1] + arr[0, c];
        }
        
        for ( int r = 1; r < rows; r++ )
        {
            dp[r, 0] = dp[r - 1, 0] + arr[r, 0];
        }

        for ( int r = 1; r < rows; r++ )
        {
            for ( int c = 1; c < columns; c++ )
            {
                long min = Math.Min( dp[r - 1, c], dp[r, c - 1] );
                dp[r, c] = min + arr[r, c];
            }
        }

        return dp[rows - 1, columns - 1];
    }
}