namespace Tasks.Strings.LongestSubstring;

public class LongestSubstringTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange 
        
        // Act
        var res = LongestSubstring.Run( "abccba" );
        
        // Assert
        Assert.Equal( 3, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange 
        
        // Act
        var res = LongestSubstring.Run( "aaaaaa" );
        
        // Assert
        Assert.Equal( 1, res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange 
        
        // Act
        var res = LongestSubstring.Run( "xyzabcxz" );
        
        // Assert
        Assert.Equal( 6, res );
    }
    
    [Fact]
    public void RunSlidingWindow_Case1_ShouldBeOk( )
    {
        // Arrange 
        
        // Act
        var res = LongestSubstring.RunSlidingWindow( "abcccba" );
        
        // Assert
        Assert.Equal( 3, res );
    }
    
    [Fact]
    public void RunSlidingWindow_Case2_ShouldBeOk( )
    {
        // Arrange 
        
        // Act
        var res = LongestSubstring.RunSlidingWindow( "aaaaaa" );
        
        // Assert
        Assert.Equal( 1, res );
    }
    
    [Fact]
    public void RunSlidingWindow_Case3_ShouldBeOk( )
    {
        // Arrange 
        
        // Act
        var res = LongestSubstring.RunSlidingWindow( "xyzabcxz" );
        
        // Assert
        Assert.Equal( 6, res );
    }
}