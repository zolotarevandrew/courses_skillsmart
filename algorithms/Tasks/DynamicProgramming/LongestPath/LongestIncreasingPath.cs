namespace Tasks.DynamicProgramming.LongestPath;

public class LongestIncreasingPath
{
    /*
     * You are given m x n matrix, return the length of longest strictly increasing path.
     * You may move up, down, right, left, but not diagonally or out of bounds.
     */
    public static int Run( int[,] matrix )
    {
        int maxLength = 0;
        int rows = matrix.GetLength( 0 );
        int columns = matrix.GetLength( 1 );
        for ( int r = 0; r < rows; r++ )
        {
            for ( int c = 0; c < columns; c++ )
            {
                maxLength = Math.Max( maxLength, Calc( ( r, c ), 1 ) );
            }
        }
        
        bool IsStrictlyIncreasing( (int Row, int Col) idx, int item )
        {
            if ( idx.Row < 0 || idx.Col < 0 || idx.Row >= rows || idx.Col >= columns ) return false;
            return matrix[idx.Row, idx.Col] > item;
        }
        int Calc( (int Row, int Col) idx, int length )
        {
            int leftLength = -1;
            int rightLength = -1;
            int downLength = -1;
            int upLength = -1;
            
            int r = idx.Row;
            int c = idx.Col;
            int item = matrix[r, c];

            (int, int) left = ( r, c - 1 );
            (int, int) right = ( r, c + 1 );
            (int, int) down = ( r - 1, c );
            (int, int) up = ( r + 1, c );

            if ( IsStrictlyIncreasing( left, item ) )
            {
                leftLength = length + Calc( left, 1 );
            }
            if ( IsStrictlyIncreasing( right, item ) )
            {
                rightLength = length + Calc( right, 1 );
            }
            if ( IsStrictlyIncreasing( down, item ) )
            {
                downLength = length + Calc( down, 1 );
            }
            if ( IsStrictlyIncreasing( up, item ) )
            {
                upLength = length + Calc( up, 1 );
            }

            int curMax = Math.Max( Math.Max( leftLength, rightLength ), Math.Max( downLength, upLength ) );
            return Math.Max( length, curMax );
        }
        
        return maxLength;
    }
}