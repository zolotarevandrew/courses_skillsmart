namespace Tasks.Strings.PatternMatching;

public class RabinKarpMatching
{
    public static List<int> Run( string text, string pattern )
    {
        var result = new List<int>();
        if ( string.IsNullOrEmpty( pattern ) || string.IsNullOrEmpty( text ) ) return result;

        int n = text.Length, m = pattern.Length;
        if (m > n) return result;

        const long B = 256;                 
        const long M = 1_000_000_007;       
        
        long pow = 1;
        for (int i = 0; i < m - 1; i++)
            pow = (pow * B) % M;

        long ph = 0, wh = 0;
        for (int i = 0; i < m; i++)
        {
            ph = (ph * B + pattern[i]) % M;
            wh = (wh * B + text[i]) % M;
        }

        for (int i = 0; i <= n - m; i++)
        {
            if (ph == wh)
            {
                bool match = true;
                for (int j = 0; j < m; j++)
                {
                    if (text[i + j] != pattern[j]) { match = false; break; }
                }
                if (match) result.Add(i);
            }

            if (i < n - m)
            {
                long outChar = text[i];
                long inChar  = text[i + m];
                
                long withoutOut = (wh - (outChar * pow) % M + M) % M;
                wh = (withoutOut * B + inChar) % M;
            }
        }

        return result;
    }
}