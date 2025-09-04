namespace Tasks.Matrices.Toeplitz;

public class ToeplitzMatrix
{
    /*
     * An m x n matrix is called a Toeplitz Matrix if every diagonal from top to left to the bottom right
     * has identical elements. 
     */
    public static bool Run( int[,] matrix )
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if ( rows == 0 || cols == 0 ) return true;

        for (int row = 0; row < rows - 1; row++)
        {
            for (int col = 0; col < cols - 1; col++)
            {
                if ( matrix[row, col] != matrix[row + 1, col + 1] )
                    return false;
            }
        }

        return true;
    }
}