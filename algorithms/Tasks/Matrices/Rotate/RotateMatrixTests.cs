using Tasks.Matrices.Toeplitz;

namespace Tasks.Matrices.Rotate;

public class RotateMatrixTests
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
        
        var expected = new int[,]
        {
            { 7, 4, 1 },
            { 8, 5, 2 },
            { 9, 6, 3 },
        };
        
        // Act
        var res = RotateMatrix.Run( matrix );
        
        // Assert
        Assert.Equal( res, expected );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange 
        var matrix = new int[,]
        {
            { 1, 2 },
            { 4, 5 },
        };
        
        var expected = new int[,]
        {
            { 4, 1 },
            { 5, 2 },
        };
        
        // Act
        var res = RotateMatrix.Run( matrix );
        
        // Assert
        Assert.Equal( res, expected );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange 
        var matrix = new int[,]
        {
            { 1 },
            { 2 },
        };
        
        var expected = new int[,]
        {
            { 1 },
            { 2 },
        };
        
        // Act
        var res = RotateMatrix.Run( matrix );
        
        // Assert
        Assert.Equal( res, expected );
    }
}