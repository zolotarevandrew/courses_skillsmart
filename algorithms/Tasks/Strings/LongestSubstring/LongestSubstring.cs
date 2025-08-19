namespace Tasks.Strings.LongestSubstring;

public class LongestSubstring
{
    /*
     * Given a string s, find the length of the longest substring
     * that contains only unique characters
     */
    public static int Run( string s )
    {
        int res = 0;
        var seen = new HashSet<char>( );
        for ( int i = 0; i < s.Length; i++)
        {
            seen.Clear( );
            for ( int j = i; j < s.Length; j++ )
            {
                if (!seen.Add( s[j] ) ) break;
            }
            
            res = Math.Max( res, seen.Count );
        }
        
        return res;
    }
    
    public static int RunSlidingWindow( string s )
    {
        if ( s.Length == 0 ) return 0;
        
        int res = 0;
        int left = 0;
        var seen = new HashSet<char>( );

        for ( int right = 0; right < s.Length; right++ )
        {
            while ( seen.Contains( s[right] ) )
            {
                seen.Remove( s[left] );
                left++;
            }
            seen.Add( s[right] );
            res = Math.Max( res, right - left + 1 );
        }
        
        return res;
    }
}