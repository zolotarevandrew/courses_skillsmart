namespace Tasks.Strings.PatternMatching;

public class KmpMatching
{
    /*
     * 
     */
    public static List<int> Run( string text, string pattern )
    {
        var matches = new List<int>( );
        int m = pattern.Length;
        int n = text.Length;
        
        var prefix = Prefix( pattern );
        int i = 0;
        int j = 0;

        while ( i < n )
        {
            if (text[i] == pattern[j])
            {
                i++; j++;
                if (j == m)
                {
                    matches.Add(i - j);
                    j = prefix[j - 1];
                }
            }
            else
            {
                if (j > 0)
                {
                    j = prefix[j - 1]; 
                }
                else
                {
                    i++;
                }
            }
        }
        
        return matches;
    }

    /*
     *  ababcabab

        1) q = 1 (b), k = 0, res[1] = 0
        2) q = 2 (a), k = 1, res[2] = 1
        3) q = 3 (b), k = 2, res[3] = 2,
        4) q = 4 (c), k = 0, res[4] = 0,
        5) q = 5 (a), k = 1, res[5] = 1
        6) q = 6 (b), k = 2, res[6] = 2
        7) q = 7 (a), k = 3, res[7] = 3
        8) q = 8 (b), k = 4, res[8] = 4
        
        failure function, prefix function
        longest-proper-prefix-which-is-also-suffix
        how far to shift the pattern so that we can reuse previously matched characters
        Each character is examined at most once, yielding an overall time O(n + m)
     */
    public static int[] Prefix( string pattern )
    {
        var res = new int[pattern.Length];
        int k = 0;

        for ( int q = 1; q < pattern.Length; q++ )
        {
            while ( k > 0 && pattern[k] != pattern[q] )
            {
                k = res[k - 1];
            }

            if ( pattern[k] == pattern[q] )
            {
                k += 1;
            }

            res[q] = k;
        }
        
        return res;
    }
}