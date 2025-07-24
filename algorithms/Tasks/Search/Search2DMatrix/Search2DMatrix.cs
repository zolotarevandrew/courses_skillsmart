namespace Tasks.Search.Search2DMatrix;

public static class Search2DMatrix
{
    /*
     * Given m * n integer matrix.
     * Each row is sorted in ascending order.
     * The first number in each row is greater than the last number in the previous row.
     *
     * Write a function that returns true if the value val is in the matrix.
     * The solution must use O log(m * n) time
     *
     */
    public static bool RunBinarySearch( int[][] matrix, int target )
    {
        if ( matrix.Length == 0 ) return false;

        int rows = matrix.Length;
        int columns = matrix[0].Length;
        int lastIndex = rows * columns - 1;

        int left = 0, right = lastIndex;
        while ( left <= right )
        {
            int mid = ( left + right ) / 2;
            int midValue = GetByFlatIndex( matrix, mid );
            if ( midValue == target )
            {
                return true;
            }
            
            if ( midValue < target )
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        
        return false;
    }

    public static int GetByFlatIndex( int[][] matrix, int flatIndex )
    {
        int columns = matrix[0].Length;
        
        int row = flatIndex / columns;
        int column = flatIndex % columns;

        return matrix[row][column];
    }
}