namespace Tasks.Strings.Permutations;

public class PermutationInString
{
    /*
     * Give two string s1 and s2.
     * Return true if any permutation of s1 is a substring of s2;
     */
    public static bool Run( string s1, string s2)
    {
        Dictionary<char, int> f1 = new Dictionary<char, int>( );
        Dictionary<char, int> f2 = new Dictionary<char, int>( );
        
        foreach ( char c in s1 )
        {
            f1.TryAdd( c, 0 );
            f1[c]++;
        }

        int f1Length = s1.Length;
        int f2Length = s2.Length;
        
        if (f1Length > f2Length ) return false;

        for ( int idx = 0; idx < f1Length; idx++ )
        {
            f2.TryAdd( s2[idx], 0 );
            f2[s2[idx]]++;
        }

        for ( int i = f1Length; i < f2Length; i++ )
        {
            if ( DictEquals() ) return true;
            
            f2.TryAdd( s2[i], 0 );
            f2[s2[i]]++;
            
            f2[s2[i - f1Length]]--;
            if ( f2[s2[i - f1Length]] == 0 )
            {
                f2.Remove( s2[i - f1Length] );
            } 
        }

        bool DictEquals( )
        {
            return f1.Count == f2.Count && f1.All( kv => f2.TryGetValue( kv.Key, out int v ) && v == kv.Value );
        }

        return DictEquals();
    }
    
}