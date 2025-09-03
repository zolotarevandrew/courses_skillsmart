namespace Tasks.Strings.Permutations;

public class PermutationInStringTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var s1 = "abc";
        var s2 = "eidacaboo";
        
        // Act
        bool res = PermutationInString.Run( s1, s2 );

        // Assert
        Assert.True( res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var s1 = "xyz";
        var s2 = "abcdef";
        
        // Act
        bool res = PermutationInString.Run( s1, s2 );

        // Assert
        Assert.False( res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var s1 = "cabbac";
        var s2 = "eidacabbcoo";
        
        // Act
        bool res = PermutationInString.Run( s1, s2 );

        // Assert
        Assert.True( res );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange
        var s1 = "cabbac";
        var s2 = "eidacabboo";
        
        // Act
        bool res = PermutationInString.Run( s1, s2 );

        // Assert
        Assert.False( res );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Arrange
        var s1 = "cabbac";
        var s2 = "eibdacaboo";
        
        // Act
        bool res = PermutationInString.Run( s1, s2 );

        // Assert
        Assert.False( res );
    }
    
    [Fact]
    public void Run_Case6_ShouldBeOk( )
    {
        // Arrange
        var s1 = "ab";
        var s2 = "aXb";
        
        // Act
        bool res = PermutationInString.Run( s1, s2 );

        // Assert
        Assert.False( res );
    }
}