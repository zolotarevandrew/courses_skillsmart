namespace Tasks.DynamicProgramming.LongestPalindromicSubstring;

public partial class LongestPalindromicSubstringTests
{
    [Fact]
    public void RunPointer_Case1_ShouldBeOk( )
    {
        Assert.Equal( "racecar", LongestPalindromicSubstring.RunPointer( "racecarfun" ) );
    }
    
    [Fact]
    public void RunPointer_Case2_ShouldBeOk( )
    {
        Assert.Equal( "anana", LongestPalindromicSubstring.RunPointer( "banana" ) );
    }
    
    [Fact]
    public void RunPointer_Case3_ShouldBeOk( )
    {
        Assert.Equal( "civic", LongestPalindromicSubstring.RunPointer( "civic" ) );
    }
    
    [Fact]
    public void ExpandAroundCenter_OneChar_ShouldBeOk( )
    {
        Assert.Equal( "c", LongestPalindromicSubstring.ExpandAroundCenter( "c", 0, 0 ) );
    }
    
    [Fact]
    public void ExpandAroundCenter_TwoEqualsChar_ShouldBeOk( )
    {
        Assert.Equal( "cc", LongestPalindromicSubstring.ExpandAroundCenter( "cc", 0, 1 ) );
    }
    
    [Fact]
    public void ExpandAroundCenter_Case3_ShouldBeOk( )
    {
        Assert.Equal( "aba", LongestPalindromicSubstring.ExpandAroundCenter( "aba", 1, 1 ) );
    }
    
    [Fact]
    public void ExpandAroundCenter_Case4_ShouldBeOk( )
    {
        Assert.Equal( "abba", LongestPalindromicSubstring.ExpandAroundCenter( "abba", 1, 2 ) );
    }
    
    [Fact]
    public void ExpandAroundCenter_Case5_ShouldBeOk( )
    {
        Assert.Equal( "ababa", LongestPalindromicSubstring.ExpandAroundCenter( "ababa", 2, 2 ) );
    }
    
    [Fact]
    public void ExpandAroundCenter_Case6_ShouldBeOk( )
    {
        Assert.Equal( "i", LongestPalindromicSubstring.ExpandAroundCenter( "abiki", 2, 2 ) );
    }
}