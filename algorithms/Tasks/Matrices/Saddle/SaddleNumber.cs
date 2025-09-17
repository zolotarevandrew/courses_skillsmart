namespace Tasks.Matrices.Saddle;

public class SaddleNumber
{
    /*
     * m x n matrix containing distinct numbers.
     * A saddle number is defined as a number that is a smallest in its row
     * and at the same the largest in its column.
     * Find all saddle numbers return in any order
     */
    public static int[] Run( int[,] matrix )
    {
        int[] minInRows = new int[matrix.GetLength( 0 )];
        int[] maxInColumns = new int[matrix.GetLength( 1 )];

        for ( int row = 0; row < matrix.GetLength( 0 ); row++ )
        {
            int min = matrix[row, 0];
            for ( int col = 0; col < matrix.GetLength( 1 ); col++ )
            {
                min = Math.Min( min, matrix[row, col] );
            }

            minInRows[row] = min;
        }

        for ( int col = 0; col < matrix.GetLength( 1 ); col++ )
        {
            int max = matrix[col, 0];
            for ( int row = 0; row < matrix.GetLength( 0 ); row++ )
            {
                max = Math.Max( max, matrix[row, col] );
            }

            maxInColumns[col] = max;
        }

        List<int> saddle = [];
        for ( int row = 0; row < matrix.GetLength( 0 ); row++ )
        {
            for ( int col = 0; col < matrix.GetLength( 1 ); col++ )
            {
                int elem = matrix[row, col];
                if ( elem == minInRows[row] && elem == maxInColumns[col] )
                {
                    saddle.Add( elem );
                }
            }
        }
        
        return saddle.ToArray(  );
    }
}