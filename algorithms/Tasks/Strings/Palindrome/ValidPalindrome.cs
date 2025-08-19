using static System.Char;

namespace Tasks.Strings;

public class ValidPalindrome
{
    /*
     * if after converting all uppercase letters to lowercase letters,
     * and removing non alphanumeric characters,
     * it reads the same backward as forward
     * the string is the same as the original string, then the string is a palindrome.
     *
     */
    public static bool RunTwoPointer( string s )
    {
        int left = 0, right = s.Length - 1;

        while ( left < right )
        {
            if ( !IsLetterOrDigit( s[left] ) )
            {
                left++;
                continue;
            }
            
            if ( !IsLetterOrDigit( s[right] ) )
            {
                right--;
                continue;
            }
            
            if ( ToLower( s[left] ) != ToLower( s[right] ) )
            {
                return false;
            }
            
            left++;
            right--;
        }

        return true;
    }
    
    public static bool RunReverse( string s )
    {
        string filteredString = new string(s.Where(char.IsLetterOrDigit).ToArray());
        string reversedString = new string(filteredString.Reverse().ToArray());

        return filteredString == reversedString;
    }
}