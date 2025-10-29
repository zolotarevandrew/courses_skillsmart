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

        if ( rows == 0 || columns == 0 ) return 0;

        bool IsInRange( (int Row, int Column) index )
        {
            return index.Row < rows && index.Column < columns;
        }
        long RunInternal( int row, int column )
        {
            bool isEnd = row == rows - 1 && column == columns - 1;
            if ( isEnd )
            {
                return arr[row, column];
            }

            int sum = arr[row, column];
            (int, int) rightPath = ( row, column + 1 );
            long rightSum = IsInRange( rightPath )
                ? sum + RunInternal( rightPath.Item1, rightPath.Item2 )
                : Int64.MaxValue;

            (int, int) downPath = ( row + 1, column );
            long downSum = IsInRange( downPath )
                ? sum + RunInternal( downPath.Item1, downPath.Item2 )
                : Int64.MaxValue;

            return Math.Min( rightSum, downSum );
        }

        return RunInternal( 0, 0 );
    }
}