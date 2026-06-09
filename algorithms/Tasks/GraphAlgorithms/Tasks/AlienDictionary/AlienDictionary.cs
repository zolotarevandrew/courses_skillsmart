namespace Tasks.GraphAlgorithms.Tasks.AlienDictionary;

public class AlienDictionary
{
    // You are given a list of words dict in a custom alien language
    // where the words are sorted lexicographically according to alien's dictionary order.
    // The language has k unique letters
    // Your task is to find one possible order of the characters in the alien language.
    // If no valid ordering exists return an empty string
    public static List<char> Run( string[] dict, int k )
    {
        Dictionary<char, int> indegrees = dict
            .SelectMany( c => c.Select( h => h ) )
            .Distinct( )
            .ToDictionary( c => c, c => 0 );
        Dictionary<char, HashSet<char>> graph = [];
        
        // if only one?
        for ( int start = 0; start < dict.Length - 1; start++ )
        {
            string strStart = dict[start];
            string strNext = dict[start + 1];
            int minLength = Math.Min( strStart.Length, strNext.Length );
            bool foundDifference = false;
            for ( int i = 0; i < minLength; i++ )
            {
                char startChar =  strStart[i];
                char nextChar = strNext[i];
                if ( startChar != nextChar )
                {
                    if ( !graph.ContainsKey( startChar ) )
                    {
                        graph[startChar] = [];
                    }

                    if ( graph[startChar].Add( nextChar ) )
                    {
                        indegrees[nextChar]++;    
                    }

                    foundDifference = true;
                    break;
                }
            }

            if ( !foundDifference && strStart.Length > strNext.Length )
            {
                return [];
            }
        }
        Queue<char> queue = new Queue<char>();
        foreach ( var key in indegrees.Keys )
        {
            if ( indegrees[key] == 0 )
            {
                queue.Enqueue( key );
            }
        }

        List<char> order = [];
        while ( queue.TryDequeue( out char curNode ) )
        {
            order.Add( curNode );
            graph.TryGetValue( curNode, out HashSet<char>? set );
            foreach ( char edge in set ?? [] )
            {
                indegrees[edge]--;
                if ( indegrees[edge] == 0 )
                {
                    queue.Enqueue( edge );
                }
            }
        }

        return order;
    }
}