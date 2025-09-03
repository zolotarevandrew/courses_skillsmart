namespace Tasks.Strings.LongestCommonPrefix;

public class LongestCommonPrefix
{
    /*
     * Given an array of strings,
     * find the longest common prefix shared by all strings in the array.
     * If no common prefix exists return the empty string
     */
    public static string Run( List<string> list )
    {
        string res = string.Empty;
        if (list.Count == 0) return res;

        string first = list[0];
        if (list.Count == 1) return list[0];
        
        for ( int i = 0; i < first.Length; i++ )
        {
            foreach ( string word in list )
            {
                if ( i >= word.Length ) return res;
                if ( word[i] != first[i] ) return res;
            }
            res += first[i];
        }
        
        return res;
    }
}