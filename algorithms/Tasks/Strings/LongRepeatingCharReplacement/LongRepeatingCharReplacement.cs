namespace Tasks.Strings.LongRepeatingCharReplacement;

public class LongRepeatingCharReplacement
{
    /*
     You are given string s and integer k.
     You can replace at most k characters in the string to form substring where all characters are the same.
     Return the length of the longest sub substring.
     */
    public static int Run( string s, int k )
    {
        int left = 0;
        int res = 0;
        int max = 0;
        var dict = new Dictionary<char, int>( );
        for ( int right = 0; right < s.Length; right++ )
        {
            dict.TryAdd( s[right], 0 );
            dict[s[right]]++;
            int window = right - left + 1;
            max = Math.Max( max, dict[s[right]] );
            if ( window - max <= k )
            {
                res = Math.Max( res, window );
                continue;
            }

            dict[s[left]] -= 1;
            if ( dict[s[left]] <= 0 )
            {
                dict.Remove( s[left] );           
            }
            left += 1;

        }
        return res;
    }
}