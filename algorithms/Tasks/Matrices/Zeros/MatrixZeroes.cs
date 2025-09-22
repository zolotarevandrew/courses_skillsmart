using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;

namespace Tasks.Matrices.Zeros;

public class MatrixZeroes
{
    /*
     * Given an m x n matrix, task is to modify the matrix that if any element is 0,
     * its entire row and column is set to 0.
     * You can not use additional memory
     */
    public static void Run( int[,] matrix )
    {
        bool firstRowHasZero = false;
        bool firstColHasZero = false;
        for ( int row = 0; row < matrix.GetLength( 0 ); row++ )
        {
            for ( int col = 0; col < matrix.GetLength( 1 ); col++ )
            {
                if ( matrix[row, col] == 0 )
                {
                    if ( row == 0 )
                    {
                        firstRowHasZero = true;
                    }

                    if ( col == 0 )
                    {
                        firstColHasZero = true;
                    }
                    matrix[row, 0] = 0;
                    matrix[0, col] = 0;
                }
            }
        }
        
        for ( int row = 1; row < matrix.GetLength( 0 ); row++ )
        {
            for ( int col = 1; col < matrix.GetLength( 1 ); col++ )
            {
                if ( matrix[row, 0] == 0 || matrix[0, col] == 0)
                {
                    matrix[row, col] = 0;
                }
            }
        }

        if ( firstRowHasZero )
        {
            for ( int col = 0; col < matrix.GetLength( 1 ); col++ )
            {
                matrix[0, col] = 0;
            }
        }
        
        if ( firstColHasZero )
        {
            for ( int row = 0; row < matrix.GetLength( 0 ); row++ )
            {
                matrix[row, 0] = 0;
            }
        }
    }
    
    public static void RunV2( int[,] matrix )
    {
        HashSet<int> rows = new HashSet<int>();
        HashSet<int> columns = new HashSet<int>();
        for ( int row = 0; row < matrix.GetLength( 0 ); row++ )
        {
            for ( int col = 0; col < matrix.GetLength( 1 ); col++ )
            {
                if ( matrix[row, col] == 0 )
                {
                    rows.Add( row );
                    columns.Add( col );
                }
            }
        }
        
        for ( int row = 0; row < matrix.GetLength( 0 ); row++ )
        {
            for ( int col = 0; col < matrix.GetLength( 1 ); col++ )
            {
                if ( rows.Contains( row ) || columns.Contains( col ) )
                {
                    matrix[row, col] = 0;
                }
            }
        }
    }
}