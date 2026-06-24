namespace Tasks.Backtraking;

public class Backtracking
{
    static char[] Choices =
    [
        '0', '1'
    ];
    
    public static List<string> GenerateBinaryString( int n )
    {
        List<string> generated = [];
        GenerateBinaryStringInternal( [], n, generated );
        return generated;
    }

    public static List<List<int>> Permutation( int[] nums )
    {
        List<List<int>> res = [];
        bool[] visited = new bool[nums.Length];
        
        BacktrackPerm( [], visited, res, nums );
        
        return res;
    }

    static void BacktrackPerm(
        List<int> path,
        bool[] visited,
        List<List<int>> res,
        int[] nums )
    {
        if ( path.Count == nums.Length )
        {
            res.Add( path.ToList( ) );
            return;
        }

        for ( int idx = 0; idx < nums.Length; idx++ )
        {
            if ( visited[idx] ) continue;
            path.Add( nums[idx] );
            visited[idx] = true; 
            
            BacktrackPerm( path, visited, res, nums );

            path.RemoveAt( path.Count - 1 );
            visited[idx] = false;
        }
    }

    public static string[] NQueen( int n )
    {
        string[] solutions = new string[n];
        int[,] board = new int[n, n];
        HashSet<int> cols = [];
        HashSet<int> diags = [];
        HashSet<int> antiDiags = [];
        
        Backtrack( 0 );

        return solutions;

        void Backtrack( int row )
        {
            if ( row == n )
            {
                for ( int r = 0; r < n; r++ )
                {
                    string cur = string.Empty;
                    for ( int c = 0; c < n; c++ )
                    {
                        cur += board[r, c];
                    }

                    solutions[r] = cur;
                }
                
                return;
            }

            for ( int col = 0; col < n; col++ )
            {
                if ( cols.Contains( col )
                    || diags.Contains( row - col )
                    || antiDiags.Contains( row + col )
                    )
                {
                    continue;
                }
                
                board[row, col] = 1;
                cols.Add( col );
                diags.Add( row - col );
                antiDiags.Add( row + col );
                
                Backtrack( row + 1 );
                
                board[row, col] = 0;
                cols.Remove( col );
                diags.Remove( row - col );
                antiDiags.Remove( row + col );
            }
        }
    }
    
    

    private static void GenerateBinaryStringInternal( 
        List<char> current, 
        int maxLength, 
        List<string> generated )
    {
        // check if valid solution
        if ( current.Count == maxLength )
        {
            // process solution
            generated.Add( string.Join( "", current ) );
            return;
        }
        
        foreach ( var choice in  Choices )
        {
            current.Add( choice );
            GenerateBinaryStringInternal( current, maxLength, generated );
            current.RemoveAt( current.Count - 1 );
        }
    }
}