namespace Tasks.Hashtables.ValidAnagram;

public static class ValidAnagram
{
    /*
     * Two string s and t.
     * Determine whether t is anagram of s.
     * They contain same type and count of alphanumeric characters. 
     */
    public static bool Run( string s, string t )
    {
        if ( s.Length != t.Length ) return false;

        Dictionary<char, int> dict = new Dictionary<char, int>( );
        for ( int idx = 0; idx < s.Length; idx++ )
        {
            dict.TryAdd( s[idx], 0 );
            dict[s[idx]]++;

            dict.TryAdd( t[idx], 0 );
            dict[t[idx]]--;
        }

        return dict.All( c => c.Value == 0 );
    }
}