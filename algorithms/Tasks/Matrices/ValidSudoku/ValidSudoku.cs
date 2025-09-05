namespace Tasks.Matrices.ValidSudoku;

public class ValidSudoku
{
    /*
     * 9x9 sudoku board, each cell may contain 1, 9 or .
     * Each row must contain a digit 1 to 9 at most once.
     * Each column must contain a digit 1 to 9 at most once.
     * Each of nine 3x3 subboxes must contain the digits 1 to 9 at most once.
     */
    public static bool Run( int[,] matrix )
    {
        var set = new HashSet<int>();
        for ( int rowIdx = 0; rowIdx < 9; rowIdx++ )
        {
            set.Clear( );
            for ( int columnIdx = 0; columnIdx < 9; columnIdx++ )
            {
                int item = matrix[rowIdx, columnIdx];
                if ( item == 0 ) continue;
                if ( !set.Add( item ) ) return false;
            }
        }
        
        for ( int columnIdx = 0; columnIdx < 9; columnIdx++ )
        {
            set.Clear( );
            for ( int rowIdx = 0; rowIdx < 9; rowIdx++ )
            {
                int item = matrix[rowIdx, columnIdx];
                if ( item == 0 ) continue;
                if ( !set.Add( item ) ) return false;
            }
        }

        for ( int squareIdx = 0; squareIdx < 9; squareIdx++ )
        {
            set.Clear( );
            for ( int rowIdx = 0; rowIdx < 3; rowIdx++ )
            {
                for ( int columnIdx = 0; columnIdx < 3; columnIdx++ )
                {
                    int startRow = ( squareIdx / 3 ) * 3;
                    int startCol = ( squareIdx % 3 ) * 3;
                    int curRowIdx = startRow + rowIdx;
                    int curColumnIdx = startCol + columnIdx;

                    int item = matrix[curRowIdx, curColumnIdx];
                    if ( item == 0 ) continue;
                    if ( !set.Add( item ) ) return false;
                }
            }
        }
        
        return true;
    }
}