namespace Tasks.Matrices.Spiral;

public class SpiralMatrix
{
    /*
     * given an m x n matrix return an array of all its elements in spiral order
     */
    public static int[] Run( int[,] matrix )
    {
        int m = matrix.GetLength( 0 );
        int n = matrix.GetLength( 1 );
        List<int> res = [];

        int top = 0;
        int bottom = m - 1;
        int left = 0;
        int right = n - 1;

        while ( left <= right && top <= bottom )
        {
            for ( int cl = left; cl <= right; cl++ )
            {
                res.Add( matrix[top, cl] );
            }

            top += 1;

            for ( int row = top; row <= bottom; row++ )
            {
                res.Add( matrix[row, right] );
            }

            right -= 1;

            if ( top <= bottom )
            {
                for ( int cl = right; cl >= left; cl-- )
                {
                    res.Add( matrix[bottom, cl] );
                }

                bottom -= 1;    
            }

            if ( left <= right )
            {
                for ( int row = bottom; row >= top; row-- )
                {
                    res.Add( matrix[row, left] );
                }

                left += 1;    
            }
        }

        return res.ToArray(  );
    }
}