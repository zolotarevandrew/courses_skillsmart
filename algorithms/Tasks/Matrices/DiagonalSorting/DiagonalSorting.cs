namespace Tasks.Matrices.DiagonalSorting;

public class DiagonalSorting
{
    /*
     * Given m x n matrix.
     * Sort elements among each diagonal in ascending order.
     * Return the modified matrix
     */
    public static void Run( int[,] matrix )
    {
        List<int> cached = new List<int>();

        int rows = matrix.GetLength(0);
        if (rows < 2) return;

        int columns = matrix.GetLength(1);
        if (columns < 2) return;

        for (int startRow = rows - 1; startRow >= 0; startRow--)
        {
            cached.Clear();
            CacheDiagonal(startRow, 0);
            SortDiagonal(startRow, 0);
        }

        for (int startColumn = 1; startColumn < columns; startColumn++)
        {
            cached.Clear();
            CacheDiagonal(0, startColumn);
            SortDiagonal(0, startColumn);
        }


        void CacheDiagonal(int startRow, int startColumn)
        {
            do
            {
                cached.Add(matrix[startRow, startColumn]);
                startRow++;
                startColumn++;
            }
            while (startRow < rows && startColumn < columns);
        }

        void SortDiagonal(int startRow, int startColumn)
        {
            cached.Sort();
            int idx = 0;
            do
            {
                matrix[startRow, startColumn] = cached[idx];
                startRow++;
                startColumn++;
                idx++;
            }
            while (startRow < rows && startColumn < columns);
        }
    }
    
    public static void RunV2( int[,] matrix )
    {
        Dictionary<int, List<int>> cache = new Dictionary<int, List<int>>( );

        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for ( int row = 0; row < rows; row++ )
        {
            for ( int column = 0; column < columns; column++ )
            {
                int key = row - column;
                int item = matrix[row, column];
                if ( !cache.ContainsKey( key ) )
                {
                    cache[key] = [];
                }
                
                cache[key].Add( item );
            }
        }

        foreach ( int key in cache.Keys )
        {
            List<int> list = cache[key];
            list.Sort();
            list.Reverse();
        }

        for ( int row = 0; row < rows; row++ )
        {
            for ( int column = 0; column < columns; column++ )
            {
                int key = row - column;
                List<int> list = cache[key];
                int last = list[^1];
                matrix[row, column] = last;

                list.RemoveAt( list.Count - 1 );
            }
        }
    }
}