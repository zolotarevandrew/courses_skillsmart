using System.Runtime.InteropServices;

namespace Tasks.Matrices.Rotate;

public class RotateMatrix
{
    public static int[,] Run( int[,] matrix )
    {
        int len = matrix.GetLength( 0 );
        if ( len != matrix.GetLength( 1 ) ) return matrix;

        for ( int row = 0; row < len - 1; row++ )
        {
            for ( int column = row + 1; column < len; column++ )
            {
                ( matrix[row, column], matrix[column, row] ) = ( matrix[column, row], matrix[row, column] );
            }
        }

        Span<int> flat = MemoryMarshal.CreateSpan( ref matrix[0, 0], matrix.Length );
        int cols = matrix.GetLength( 1 );
        for ( int row = 0; row < len; row++ )
        {
            Span<int> rowSpan = flat.Slice( row * cols, cols );
            rowSpan.Reverse();
        }
        
        return matrix;
    }
}