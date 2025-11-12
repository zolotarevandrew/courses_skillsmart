namespace Tasks.DynamicProgramming.LongestPalindromicSubstring;

public class LongestPalindromicSubstring
{
    /*
     * Given a string s, find and return the longest substring in s that
     * reads same forward and backward
     */
    public static string Run( string s )
    {
        string max = string.Empty;
        for ( int i = 0; i < s.Length; i++ )
        {
            for ( int j = i; j < s.Length; j++ )
            {
                if ( !IsPalindrome( s, i, j ) ) continue;

                string substr = s[i..( j + 1 )];
                if ( substr.Length < max.Length ) continue;
                
                max = substr;
            }
        }
        return max;
    }

    public static bool IsPalindrome( string s )
    {
        int left = 0;
        int right = s.Length - 1;
        return IsPalindrome( s, left, right );
    }
    
    static bool IsPalindrome( string s, int left, int right )
    {
        while ( left < right )
        {
            if ( s[left] != s[right] ) return false;
            left++;
            right--;
        }

        return true;
    }
}