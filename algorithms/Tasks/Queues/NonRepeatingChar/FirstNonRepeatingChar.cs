namespace Tasks.Queues.NonRepeatingChar;

public class FirstNonRepeatingChar
{
    /*
     * Given a string s, return the first non-repeating char.
     * (a char with frequency of 1 within string)
     */
    public static char? RunBruteforce( string s )
    {
        foreach ( char c in s )
        {
            int cnt = s.Count( c2 => c == c2 );
            if ( cnt == 1 ) return c;
        }
        return null;
    }

    public static char? RunQueue( string s )
    {
        Dictionary<char, int> count = new Dictionary<char, int>( );
        Queue<char> queue = new Queue<char>( );
        foreach ( char c in s )
        {
            if ( count.TryAdd( c, 1 ) )
            {
                queue.Enqueue( c );
                continue;
            }

            count[c] += 1;
        }

        while ( queue.Count > 0 )
        {
            char c = queue.Dequeue( );
            if ( count[c] == 1 ) return c;
        }

        return null;
    }
}