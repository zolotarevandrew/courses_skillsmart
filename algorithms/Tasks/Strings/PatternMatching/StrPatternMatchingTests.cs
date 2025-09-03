namespace Tasks.Strings.PatternMatching;

public class StrPatternMatchingTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var str = "thigraaprogram";
        var pattern = "gram";

        // Act
        var res = StrPatternMatching.Run( str, pattern );

        // Assert
        Assert.Equal( 1, res.Count );
        Assert.Equal( 10, res[0] );
    }
}