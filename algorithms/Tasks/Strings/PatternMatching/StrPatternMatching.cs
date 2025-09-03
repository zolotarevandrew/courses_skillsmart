namespace Tasks.Strings.PatternMatching;

public class StrPatternMatching
{
    /*
     * 
     */
    public static List<int> Run( string text, string pattern )
    {
        var res = new List<int>( );
        int textLength = text.Length;
        int patternLength = pattern.Length;

        for ( int i = 0; i <= textLength - patternLength; i++ )
        {
            int start = 0;
            while ( start < patternLength && text[i + start] == pattern[start] )
            {
                start++;
            }

            if ( start == patternLength )
            {
                res.Add( i );
            }
        }

        return res;
    }
}