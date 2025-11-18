namespace Tasks.DynamicProgramming.DecodeWays;

public class DecodeWays
{
    /*
     * A string made up of digits can be decoded into UPPer case English letters.
     * using the following mapping:
     * A -> 1, B -> 2, Z -> 26.
     *
     * To decode a given number string, you must partition the digits into valid groups,
     * where each group represents a number that maps to a letter.
     *
     * For example a string "2715" can be decoded as:
     * "BGAE" with the grouping (2 7 15)
     * "BGO" with the grouping (2 7 15)
     *
     * Given a string s containing only digits, return the number of different ways to decode it.
     * You may assume that the answers fits in 32 bit integer.
     */
    public static int Run( string s )
    {
        return CalcInternal( s, 0 );
    }

    static int CalcInternal( string s, int idx )
    {
        if ( idx == s.Length ) return 1;
        if ( s[idx] == '0' ) return 0;

        int res = CalcInternal( s, idx + 1 );

        if ( idx + 1 < s.Length )
        {
            int num = int.Parse( s.AsSpan( idx, 2 ) );
            if ( num <= 26 )
            {
                res += CalcInternal( s, idx + 2 );
            }
        }

        return res;
    }
}