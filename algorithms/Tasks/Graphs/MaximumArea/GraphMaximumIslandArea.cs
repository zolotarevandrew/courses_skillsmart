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
                int val = grid[row, col];
                Index index = new Index( row, col );
                if ( val == 0 || visited.Contains( index ) )
                {
                    continue;
                }

                int area = SearchThrough( grid, index, visited );
                max = Math.Max( max, area );
            }
        }

        return max;
    }
    
    static int SearchThrough( int[,] grid, Index index, HashSet<Index> visited )
    {
        visited.Add( index );
        Stack<Index> stack = new();
        stack.Push( index );
        int length = 0;
        while ( stack.Count > 0 )
        {
            Index curIdx = stack.Pop( );
            length++;
            IEnumerable<Index> adjList = GetAdjList( grid, curIdx );
            foreach ( Index idx in adjList )
            {
                if ( !visited.Add( idx ) )
                {
                    continue;
                }

                stack.Push( idx );
            }
        }

        return length;
    }

    private static IEnumerable<Index> GetAdjList( int[,] grid, Index curIdx )
    {
        bool IsPathExists( Index idx )
        {
            int rows = grid.GetLength( 0 );
            int cols = grid.GetLength( 1 );
            return ( idx.Row >= 0 && idx.Row < rows )
                   && ( idx.Column >= 0 && idx.Column < cols )
                   && grid[idx.Row, idx.Column] == 1;
        }

        Index right = curIdx with { Column = curIdx.Column + 1 };
        if ( IsPathExists( right ) ) yield return right;
        
        Index left = curIdx with { Column = curIdx.Column - 1 };
        if ( IsPathExists( left ) ) yield return left;
        
        Index down = curIdx with { Row = curIdx.Row + 1 };
        if ( IsPathExists( down ) ) yield return down;
        
        Index up = curIdx with { Row = curIdx.Row - 1 };
        if ( IsPathExists( up ) ) yield return up;
    }

    record struct Index( int Row, int Column );
}