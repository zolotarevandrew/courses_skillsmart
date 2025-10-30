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

        long[,] memo = new long[rows + 1, columns + 1];
        for (int r = 0; r <= rows; r++)
        for ( int c = 0; c <= columns; c++ )
            memo[r, c] = -1;

        long RunInternal( int row, int column )
        {
            if ( memo[row, column] != -1 )
                return memo[row, column];
            
            if ( row >= rows || column >= columns )
                return Int64.MaxValue;
 
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
}