namespace Tasks.DynamicProgramming.LongestPalindromicSubstring;

public partial class LongestPalindromicSubstringTests
{
    [Fact]
    public void RunDp_Case1_ShouldBeOk( )
    {
        Assert.Equal( "racecar", LongestPalindromicSubstring.RunDp( "racecarfun" ) );
    }
    
    [Fact]
    public void RunDp_Case2_ShouldBeOk( )
    {
        Assert.Equal( "anana", LongestPalindromicSubstring.RunDp( "banana" ) );
    }
    
    [Fact]
    public void RunDp_Case3_ShouldBeOk( )
    {
        Assert.Equal( "civic", LongestPalindromicSubstring.RunDp( "civic" ) );
    }
}