namespace Tasks.Graphs.FloodFill;

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
    public static List<List<int>> Run( int[,] heights )
    {
        List<List<int>> res = [];
        HashSet<Index> visited = new HashSet<Index>();
        bool Dfs( Index idx, int prevValue, List<int> curPath )
        {
            if ( !IsPathExists( heights, idx, prevValue ) ) return false;
            //if ( !visited.Add( idx ) ) return false;
            
            int value = heights[idx.Row, idx.Col];
            curPath.Add( value );
            
            Index left = new ( idx.Row , idx.Col - 1 );
            Index right = new ( idx.Row, idx.Col + 1 );
            Index bottom = new ( idx.Row + 1, idx.Col );
            Index top = new (idx.Row - 1, idx.Col);

            bool hasLeft = Dfs( left, value, [..curPath] );
            bool hasRight = Dfs( right, value, [..curPath] );
            bool hasBottom = Dfs( bottom, value, [..curPath] );
            bool hasTop = Dfs( top, value, [..curPath] );
            
            bool hasAny = hasLeft || hasRight || hasBottom || hasTop;

            if ( !hasAny )
            {
                res.Add( curPath );
            }

            return true;
        }

        Dfs( new ( 0, 0 ), heights[0, 0], [] );
        return res;
    }

    static bool IsPathExists( int[,] grid, Index idx, int value )
    {
        int rows = grid.GetLength( 0 );
        int cols = grid.GetLength( 1 );

        return idx.Row >= 0 && idx.Row < rows
                               && idx.Col >= 0 && idx.Col < cols
                               && grid[idx.Row, idx.Col] >= value;
    }

    record struct Index( int Row, int Col );
}