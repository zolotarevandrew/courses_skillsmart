namespace Tasks.DynamicProgramming.LongestPalindromicSubstring;

public class LongestPalindromicSubstringTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        Assert.Equal( "racecar", LongestPalindromicSubstring.Run( "racecarfun" ) );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        Assert.Equal( "anana", LongestPalindromicSubstring.Run( "banana" ) );
    }
    
    [Fact]
    public void IsPalindrome_Empty_ShouldBeOk( )
    {
        Assert.True( LongestPalindromicSubstring.IsPalindrome( "" ) );
    }
    
    [Fact]
    public void IsPalindrome_OneChar_ShouldBeOk( )
    {
        Assert.True( LongestPalindromicSubstring.IsPalindrome( "1" ) );
    }
    
    [Fact]
    public void IsPalindrome_TwoEqualChar_ShouldBeTrue( )
    {
        Assert.True( LongestPalindromicSubstring.IsPalindrome( "11" ) );
    }
    
    [Fact]
    public void IsPalindrome_TwoDifferentChar_ShouldBeFalse( )
    {
        Assert.False( LongestPalindromicSubstring.IsPalindrome( "12" ) );
    }
    
    [Fact]
    public void IsPalindrome_ThreeDifferentChar_ShouldBeFalse( )
    {
        Assert.False( LongestPalindromicSubstring.IsPalindrome( "123" ) );
    }
    
    [Fact]
    public void IsPalindrome_ThreePalindromeChar_ShouldBeTrue( )
    {
        Assert.True( LongestPalindromicSubstring.IsPalindrome( "121" ) );
    }
    
    [Fact]
    public void IsPalindrome_FourPalindromeChar_ShouldBeTrue( )
    {
        Assert.True( LongestPalindromicSubstring.IsPalindrome( "1221" ) );
    }
    
    [Fact]
    public void IsPalindrome_FourDifferentChar_ShouldBeFalse( )
    {
        Assert.False( LongestPalindromicSubstring.IsPalindrome( "1224" ) );
    }
    
    [Fact]
    public void IsPalindrome_FiveDifferentChar_ShouldBeFalse( )
    {
        Assert.False( LongestPalindromicSubstring.IsPalindrome( "12225" ) );
    }
    
    [Fact]
    public void IsPalindrome_FivePalindromeChar_ShouldBeTrue( )
    {
        Assert.True( LongestPalindromicSubstring.IsPalindrome( "anana" ) );
    }
}