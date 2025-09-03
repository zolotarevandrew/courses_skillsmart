namespace Tasks.Strings.PatternMatching;

public class RabinKarpMatchingTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var str = "aaaa";
        var pattern = "aa";

        // Act
        var res = RabinKarpMatching.Run( str, pattern );

        // Assert
        Assert.Equal( 3, res.Count );
        Assert.Equal( 0, res[0] );
        Assert.Equal( 1, res[1] );
        Assert.Equal( 2, res[2] );
    }
}