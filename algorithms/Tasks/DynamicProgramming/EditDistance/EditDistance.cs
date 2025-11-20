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
    public static int Run( string word1, string word2, int w1Idx, int w2Idx )
    {


        int replaceLength = Run( word1, word2, w1Idx + 1, w2Idx + 1 );
        int insertLength = Run( word1, word2, w1Idx, w2Idx + 1 );
        int deleteLength = Run( word1, word2, w1Idx + 1, w2Idx );
        
        return 0;
    }
}