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
    
    public static string RunDp( string s )
    {
        bool[,] dp = new bool[s.Length, s.Length];
        for ( int i = 0; i < s.Length; i++ )
        {
            dp[i, i] = true;
        }

        int start = 0, max_l = 1;
        for ( int i = 0; i < s.Length - 1; i++ )
        {
            if ( s[i] != s[i + 1] ) continue;
            dp[i, i + 1] = true;
            
            start = i;
            max_l = 2;
        }

        for ( int length = 3; length <= s.Length; length++ )
        {
            for ( int i = 0; i <= s.Length - length; i++ )
            {
                int j = i + length - 1;
                if ( s[i] == s[j] && dp[i + 1, j - 1] )
                {
                    dp[i, j] = true;
                    start = i;
                    max_l = length;
                }
            }
        }

        return s.Substring( start, max_l );
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