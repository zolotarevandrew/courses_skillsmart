namespace Tasks.Stacks.Polish;

public class PolishNotationTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var str = "2 1 + 3 *";

        // Act
        var res = PolishNotation.Run( str );

        // Assert
        Assert.Equal( 9, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var str = "2 3 4 * +";
        
        // Act
        var res = PolishNotation.Run( str );

        // Assert
        Assert.Equal( 14, res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var str = "10 2 3 + - 4 *";
        
        // Act
        var res = PolishNotation.Run( str );

        // Assert
        Assert.Equal( 20, res );
    }
}