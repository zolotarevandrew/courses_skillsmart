namespace Tasks.Strings.LongRepeatingCharReplacement;

public class LongRepeatingCharReplacementTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange 
        string s = "AAAA";
        int k = 2;
        
        // Act
        int res = LongRepeatingCharReplacement.Run( s, k );
        
        // Assert
        Assert.Equal( 4, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange 
        string s = "AABA";
        int k = 1;
        
        // Act
        int res = LongRepeatingCharReplacement.Run( s, k );
        
        // Assert
        Assert.Equal( 4, res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange 
        string s = "ABAB";
        int k = 2;
        
        // Act
        int res = LongRepeatingCharReplacement.Run( s, k );
        
        // Assert
        Assert.Equal( 4, res );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange 
        string s = "AAAB";
        int k = 0;
        
        // Act
        int res = LongRepeatingCharReplacement.Run( s, k );
        
        // Assert
        Assert.Equal( 3, res );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Arrange 
        string s = "AABABBA";
        int k = 1;
        
        // Act
        int res = LongRepeatingCharReplacement.Run( s, k );
        
        // Assert
        Assert.Equal( 4, res );
    }
    
    [Fact]
    public void Run_Case6_ShouldBeOk( )
    {
        // Arrange 
        string s = "AACCBBA";
        int k = 2;
        
        // Act
        int res = LongRepeatingCharReplacement.Run( s, k );
        
        // Assert
        Assert.Equal( 4, res );
    }
    
    [Fact]
    public void Run_Case7_ShouldBeOk( )
    {
        // Arrange 
        string s = "ABCXYZ";
        int k = 1;
        
        // Act
        int res = LongRepeatingCharReplacement.Run( s, k );
        
        // Assert
        Assert.Equal( 2, res );
    }
    
    [Fact]
    public void Run_Case8_ShouldBeOk( )
    {
        // Arrange 
        string s = "tommarvolor";
        int k = 4;
        
        // Act
        int res = LongRepeatingCharReplacement.Run( s, k );
        
        // Assert
        Assert.Equal( 6, res );
    }
}