namespace Tasks.Graphs.MaximumArea;

public class GraphMaximumIslandArea
{
    /*
     * Given a 2D binary matrix, find the maximum area of an island.
     * An island is defined as a group of adjacent 1s (land), connected horizontally or vertically,
     * surrounded by 0s (water). Assume all grid edges are surrounded by water.
     * The area of an island os the total number of 1s it contains.
     * If no island exists return 0.
     */
    public static int Run( int[,] grid )
    {
        HashSet<Index> visited = new ( );
        int max = 0;
        for ( int row = 0; row < grid.GetLength( 0 ); row++ )
        {
            for ( int col = 0; col < grid.GetLength( 1 ); col++ )
            {
                Index index = new Index( row, col );
                max = Math.Max( max, SearchThrough( grid, index, visited ) );
            }
        }

        return max;
    }
    
    static int SearchThrough( int[,] grid, Index idx, HashSet<Index> visited )
    {
        int rows = grid.GetLength( 0 );
        int cols = grid.GetLength( 1 );

        bool isValidIdx = ( idx.Row >= 0 && idx.Row < rows )
                          && ( idx.Column >= 0 && idx.Column < cols );
        bool shouldSkip = !isValidIdx
                          || visited.Contains( idx )
                          || grid[idx.Row, idx.Column] != 1;
        if ( shouldSkip ) return 0;

        visited.Add( idx );
        
        int right = SearchThrough( grid, idx with { Column = idx.Column + 1 }, visited );
        int left = SearchThrough( grid, idx with { Column = idx.Column - 1 }, visited );
        int down = SearchThrough( grid, idx with { Row = idx.Row + 1 }, visited );
        int up = SearchThrough( grid, idx with { Row = idx.Row - 1 }, visited );

        return 1 + right + left + down + up;
    }

    record struct Index( int Row, int Column );
}