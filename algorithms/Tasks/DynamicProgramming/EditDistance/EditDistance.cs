namespace Tasks.DynamicProgramming.EditDistance;

public class EditDistance
{
    /*
     * You are given two string word1 and word2, both consisting lowercase English Letters.
     * You can transform word1 into word2 using the following three operations any number of times:
     * - Insert character at any position
     * - Delete a character at any position
     * - Replace a character with a different one
     *
     * Return the minimum number of operations required to make word1 equal to word2.
     */
    public static int Run( string word1, string word2, int w1Idx = 0, int w2Idx = 0 )
    {
        if ( w1Idx == word1.Length )
        {
            return word2.Length - w2Idx;
        }

        if ( w2Idx == word2.Length )
        {
            return word1.Length - w1Idx;
        }

        if ( word1[w1Idx] == word2[w2Idx] )
        {
            return Run( word1, word2, w1Idx + 1, w2Idx + 1 );
        }

        int replaceLength = Run( word1, word2, w1Idx + 1, w2Idx + 1 );
        int insertLength = Run( word1, word2, w1Idx, w2Idx + 1 );
        int deleteLength = Run( word1, word2, w1Idx + 1, w2Idx );

        return 1 + Math.Min( deleteLength, Math.Min( replaceLength, insertLength ) );
    }
    
    public static int RunDp( string word1, string word2 )
    {
        int[,] dp = new int[word1.Length + 1, word2.Length + 1];
        
        for ( int row = 0; row <= word1.Length; row++ )
        {
            dp[row, 0] = row;
        }

        for ( int col = 0; col <= word2.Length; col++ )
        {
            dp[0, col] = col;
        }
        
        for ( int row = 1; row <= word1.Length; row++ )
        {
            for ( int col = 1; col <= word2.Length; col++ )
            {
                if ( word1[row - 1] == word2[col - 1] )
                {
                    dp[row, col] = dp[row - 1, col - 1];
                    continue;
                }

                int replace = dp[row - 1, col - 1];
                int insert = dp[row, col - 1];
                int delete = dp[row - 1, col];

                dp[row, col] = 1 + Math.Min( delete, Math.Min( replace, insert ) );
                
            }
        }

        return dp[word1.Length, word2.Length];
    }
}