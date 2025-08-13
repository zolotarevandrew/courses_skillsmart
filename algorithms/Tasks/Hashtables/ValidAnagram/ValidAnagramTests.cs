namespace Tasks.Hashtables.ValidAnagram;

public class ValidAnagramTests
{
    [Fact]
    public void Run_Valid_ShouldBeTrue( )
    {
        // Arrange
        var s = "listen";
        var t = "silent";
        
        // Act
        var result = ValidAnagram.Run(s, t);
        
        // Assert
        Assert.True( result );
    }
    
    [Fact]
    public void Run_ValidWithDuplicates_ShouldBeTrue( )
    {
        // Arrange
        var s = "listenn";
        var t = "silennt";
        
        // Act
        var result = ValidAnagram.Run(s, t);
        
        // Assert
        Assert.True( result );
    }
    
    [Fact]
    public void Run_NotValidSameLength_ShouldBeFalse( )
    {
        // Arrange
        var s = "hello";
        var t = "world";
        
        // Act
        var result = ValidAnagram.Run(s, t);
        
        // Assert
        Assert.False( result );
    }
    
    [Fact]
    public void Run_NotValidDifferentLength_ShouldBeFalse( )
    {
        // Arrange
        var s = "anagram";
        var t = "nagarama";
        
        // Act
        var result = ValidAnagram.Run(s, t);
        
        // Assert
        Assert.False( result );
    }
}