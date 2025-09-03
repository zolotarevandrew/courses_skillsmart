namespace Tasks.Strings.LongestCommonPrefix;

public class LongestCommonPrefixTests
{
    [Fact]
    public void Run_HasCommonPrefixFirstLengthGreaterThanOthers_ShouldNotBeEmpty( )
    {
        // Arrange
        var strs = new List<string>
        {
            "interview",
            "interval",
            "internet"
        };

        // Act
        var res = LongestCommonPrefix.Run( strs );

        // Assert
        Assert.Equal( "inter", res );
    }
    
    [Fact]
    public void Run_HasCommonPrefixLastStringLengthLessThanOthers_ShouldNotBeEmpty( )
    {
        // Arrange
        var strs = new List<string>
        {
            "interview",
            "interval",
            "inter"
        };

        // Act
        var res = LongestCommonPrefix.Run( strs );

        // Assert
        Assert.Equal( "inter", res );
    }
    
    [Fact]
    public void Run_HasCommonPrefixFirstLengthLessThanOthers_ShouldNotBeEmpty( )
    {
        // Arrange
        var strs = new List<string>
        {
            "inter",
            "interview",
            "internet"
        };

        // Act
        var res = LongestCommonPrefix.Run( strs );

        // Assert
        Assert.Equal( "inter", res );
    }
    
    [Fact]
    public void Run_NoCommonPrefix_ShouldBeEmpty( )
    {
        // Arrange
        var strs = new List<string>
        {
            "hello",
            "world",
            "hi"
        };

        // Act
        var res = LongestCommonPrefix.Run( strs );

        // Assert
        Assert.Equal( string.Empty, res );
    }
}