namespace Tasks.Matrices.DiagonalSum;

public class DiagonalSum
{
    /*
     * Given a square matrix, calculate the sum of of the elements on both primary and secondary diagonals.
     * If element belongs to both diagonals, include it only once
     */
    public static int Run( int[,] matrix )
    {
        int rows = matrix.GetLength( 0 );
        int total = 0;
        for ( int idx = 0; idx < rows; idx++ )
        {
            total += matrix[idx, idx];
            if ( idx != rows - idx - 1 )
            {
                total += matrix[idx, rows - idx - 1];    
            }
            
        }
        return total;
    }
}