namespace Tasks.Graphs.PacificFlow;

public static class PacificAntlanticFlow
{
    /// <summary>
    /// Given m x n matrix heights where heights[r][c] represents the elevation of the cell.
    /// The grid represents an island bordered by the pacific ocean (top and left edges)
    /// and the Atlantic ocean (bottom and right edges).
    /// Rainwater can flow from a cell to a neighboring cell (up, down, left, right) if the neighboring's cell height
    /// is less than or equal to the current cell's height
    /// Return the list of coordinates where water can flow to both the Pacific and Atlantic Ocean
    /// </summary>
    public static List<Index> Run( int[,] heights )
    {
        HashSet<Index> pacific = [];
        HashSet<Index> atlantic = [];
        
        int rows = heights.GetLength( 0 );
        int cols = heights.GetLength( 1 );
        
        for ( int col = 0; col < cols; col++ )
        {
            int topValue = heights[0, col];
            Index topIdx = new Index( 0, col );
            Dfs( heights, topIdx, topValue, pacific );

            int bottomValue = heights[rows - 1, col];
            Index bottomIdx = new Index( rows - 1, col );
            Dfs( heights, bottomIdx, bottomValue, atlantic );
        }
        

        for ( int row = 0; row < rows; row++ )
        {
            int leftValue = heights[row, 0];
            Index leftIdx = new Index( row, 0 );
            Dfs( heights, leftIdx, leftValue, pacific );

            int rightValue = heights[row, cols - 1];
            Index rightIdx = new Index( row, cols - 1 );
            Dfs( heights, rightIdx, rightValue, atlantic );
        }

        return pacific.Intersect( atlantic ).ToList( );
    }
    
    static void Dfs( int[,] heights, Index idx, int prevValue, HashSet<Index> visited )
    {
        if ( !IsPathExists( heights, idx, prevValue, visited ) ) return;
        visited.Add( idx );
            
        int value = heights[idx.Row, idx.Col];
            
        Index left = new ( idx.Row , idx.Col - 1 );
        Index right = new ( idx.Row, idx.Col + 1 );
        Index bottom = new ( idx.Row + 1, idx.Col );
        Index top = new (idx.Row - 1, idx.Col);

        Dfs( heights, left, value, visited );
        Dfs( heights, right, value, visited );
        Dfs( heights, bottom, value, visited );
        Dfs( heights, top, value, visited );
    }

    static bool IsPathExists( int[,] grid, Index idx, int value, HashSet<Index> visited )
    {
        int rows = grid.GetLength( 0 );
        int cols = grid.GetLength( 1 );

        return idx.Row >= 0 && idx.Row < rows
                            && idx.Col >= 0 && idx.Col < cols
                            && grid[idx.Row, idx.Col] >= value
                            && !visited.Contains( idx );
    }

    public readonly record struct Index( int Row, int Col );
}