

namespace Tasks.Matrices.Saddle;

public class SaddleNumberTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        }; 
        
        // Act
        var res = SaddleNumber.Run( matrix );

        // Assert
        Assert.Equal( 1, res.Length );
        Assert.Equal( 7, res[0] );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            { 20, 30, 40 },
            { 10, 25, 35 },
            { 5, 15, 45 }
        }; 
        
        // Act
        var res = SaddleNumber.Run( matrix );

        // Assert
        Assert.Equal( 1, res.Length );
        Assert.Equal( 5, res[0] );
    }
}