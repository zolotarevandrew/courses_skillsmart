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

        if ( rows == 0 || columns == 0 ) return 0;
        
        for ( int r = 0; r < rows; r++ )
        {
            for ( int c = 0; c < columns; c++ )
            {
                maxLength = Math.Max( maxLength, Calc( ( r, c ), Int32.MinValue ) );
            }
        }
        
        bool IsStrictlyIncreasing( (int Row, int Col) idx, int prev )
        {
            if ( idx.Row < 0 || idx.Col < 0 || idx.Row >= rows || idx.Col >= columns ) return false;
            return matrix[idx.Row, idx.Col] > prev;
        }
        int Calc( (int Row, int Col) idx, int prev )
        {
            if ( !IsStrictlyIncreasing( idx, prev ) ) return 0;
            
            int r = idx.Row;
            int c = idx.Col;
            int cur = matrix[r, c];
            
            int leftLength = Calc( ( r, c - 1 ), cur );
            int rightLength = Calc( ( r, c + 1 ), cur );
            int downLength = Calc( ( r - 1, c ), cur );
            int upLength = Calc( ( r + 1, c ), cur );

            int curMax = Math.Max( Math.Max( leftLength, rightLength ), Math.Max( downLength, upLength ) );
            return 1 + curMax;
        }
        
        return maxLength;
    }
}