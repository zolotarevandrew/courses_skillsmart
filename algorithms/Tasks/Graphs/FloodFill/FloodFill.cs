namespace Tasks.Graphs.FloodFill;

public static class FloodFill
{
    /// <summary>
    /// Given m x n grid represented an image, perform a flood fill from pixel at (sr, sc)
    /// and change all connected pixels of the same color to a new color.
    /// Connected pixels are those sharing a side and a having a same color as the starting pixel.
    /// Return the modified image
    /// </summary>
    public static void Run( int[,] grid, (int sr, int sc) fill, int color )
    {
        int startColor = grid[fill.sr, fill.sc];
        if ( startColor == color ) return;
        Dfs( fill );
        
        void Dfs( (int curRow, int curCol) idx )
        {
            if ( !IsPathExists( grid, idx ) ) return;
            if ( grid[idx.curRow, idx.curCol] != startColor ) return;

            grid[idx.curRow, idx.curCol] = color;
        
            var left = ( idx.curRow , idx.curCol - 1 );
            var right = ( idx.curRow, idx.curCol + 1 );
            var bottom = ( idx.curRow + 1, idx.curCol );
            var top = ( idx.curRow - 1, idx.curCol );
        
            Dfs( left );
            Dfs( right );
            Dfs( top );
            Dfs( bottom );
        }
    }

    static bool IsPathExists( int[,] grid, (int curRow, int curCol) idx )
    {
        int rows = grid.GetLength( 0 );
        int cols = grid.GetLength( 1 );

        return idx.curRow >= 0 && idx.curRow < rows
                               && idx.curCol >= 0 && idx.curCol < cols;
    }
}