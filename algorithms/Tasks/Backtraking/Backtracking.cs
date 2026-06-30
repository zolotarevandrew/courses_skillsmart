using System.Security.Cryptography;

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
    
    /// Given m x n grid of characters board and a string word
    /// check if the word can be formed by a sequence of adjacent characters in the grid
    /// Adjacent cells are horizontally or vertically neighboring, and the same cell can not be reused more than once
    public static bool WordSearch( char[,] board, string word )
    {
        int rows =  board.GetLength(0);
        int cols = board.GetLength( 1 );

        for ( int row = 0; row < rows; row++ )
        {
            for ( int col = 0; col < cols; col++ )
            {
                if ( board[row, col] == word[0] )
                {
                    HashSet<(int row, int col)> visited = new HashSet<(int row, int col)>( );
                    bool found = BacktrackWordSearch(
                        board,
                        row,
                        col,
                        word,
                        visited,
                        0
                    );
                    if ( found ) return true;
                }
            }
        }

        return false;
    }

    private static bool BacktrackWordSearch( 
        char[,] board, 
        int row, 
        int col, 
        string word,
        HashSet<(int row, int col)> visited,
        int idx )
    {
        if ( idx == word.Length )
        {
            return true;
        }

        bool isAvailable = row < board.GetLength( 0 ) && row >= 0
                           && col < board.GetLength( 1 ) && col >= 0
                           && board[row, col] == word[idx]
                           && !visited.Contains( ( row, col ) );
        if ( !isAvailable ) return false;

        visited.Add( ( row, col ) );

        bool res = BacktrackWordSearch( board, row + 1, col, word, visited, idx + 1 )
            || BacktrackWordSearch( board, row - 1, col, word, visited, idx + 1 )
            || BacktrackWordSearch( board, row, col + 1, word, visited, idx + 1 )
            || BacktrackWordSearch( board, row, col - 1, word, visited, idx + 1 );
        
        visited.Remove( ( row, col ) );

        return res;
    }

    private static IEnumerable<(int curRow, int curCol)> Directions( char[,] board, int row, int col )
    {
        int rows = board.GetLength( 0 );
        int cols = board.GetLength( 1 );

        bool IsAvailable( int r, int c )
        {
            return r < rows & r >= 0 && c < cols && c >= 0;
        }

        if ( IsAvailable( row - 1, col ) )
        {
            yield return ( row - 1, col );
        }
        
        if ( IsAvailable( row + 1, col ) )
        {
            yield return ( row + 1, col );
        }

        if ( IsAvailable( row, col + 1 ) )
        {
            yield return ( row, col + 1 );
        }

        if ( IsAvailable( row, col - 1 ) )
        {
            yield return ( row, col - 1 );
        }
    }

    public static List<List<int>> Sets( int[] nums )
    {
        List<List<int>> res = [];
        BacktrackSets( [], res, 0, nums );
        
        return res;
    }
    
    static void BacktrackSets(
        List<int> path,
        List<List<int>> res,
        int start,
        int[] nums )
    {
        res.Add( path.ToList( ) );

        for ( int idx = start; idx < nums.Length; idx++ )
        {
            path.Add( nums[idx] );
            BacktrackSets( path, res, idx + 1, nums );
            path.RemoveAt( path.Count - 1 );
        }
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