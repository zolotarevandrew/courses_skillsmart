namespace Tasks.Strings.PatternMatching;

public class KmpMatchingTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var str = "aaaa";
        var pattern = "aa";

        // Act
        var res = KmpMatching.Run( str, pattern );

        // Assert
        Assert.Equal( 1, res.Count );
        Assert.Equal( 10, res[0] );
    }
    
    [Fact]
    public void Prefix_FirstAndLastEquals_ShouldBeOk( )
    {
        // Arrange
        var pattern = "abcba";

        // Act
        var res = KmpMatching.Prefix( pattern );

        // Assert
        Assert.Equal( pattern.Length, res.Length );
        
        Assert.Equal( 0, res[0] );
        Assert.Equal( 0, res[1] );
        Assert.Equal( 0, res[2] );
        Assert.Equal( 0, res[3] );
        Assert.Equal( 1, res[4] );
    }
    
    [Fact]
    public void Prefix_UniqueCharacters_ShouldBeOk( )
    {
        // Arrange
        var pattern = "abcde";

        // Act
        var res = KmpMatching.Prefix( pattern );

        // Assert
        Assert.Equal( pattern.Length, res.Length );
        
        Assert.Equal( 0, res[0] );
        Assert.Equal( 0, res[1] );
        Assert.Equal( 0, res[2] );
        Assert.Equal( 0, res[3] );
        Assert.Equal( 0, res[4] );
    }
    
    [Fact]
    public void Prefix_MultipleRepetitions_ShouldBeOk( )
    {
        // Arrange
        var pattern = "abcab";

        // Act
        var res = KmpMatching.Prefix( pattern );

        // Assert
        Assert.Equal( pattern.Length, res.Length );
        
        Assert.Equal( 0, res[0] );
        Assert.Equal( 0, res[1] );
        Assert.Equal( 0, res[2] );
        Assert.Equal( 1, res[3] );
        Assert.Equal( 2, res[4] );
    }
    
    [Fact]
    public void Prefix_MultipleRepetitionsWithReverts_ShouldBeOk( )
    {
        // Arrange
        var pattern = "aabaaab";

        // Act
        var res = KmpMatching.Prefix( pattern );

        // Assert
        Assert.Equal( pattern.Length, res.Length );
        
        Assert.Equal( 0, res[0] );
        Assert.Equal( 1, res[1] );
        Assert.Equal( 0, res[2] );
        Assert.Equal( 1, res[3] );
        Assert.Equal( 2, res[4] );
        Assert.Equal( 2, res[5] );
        Assert.Equal( 3, res[6] );
    }
    
}