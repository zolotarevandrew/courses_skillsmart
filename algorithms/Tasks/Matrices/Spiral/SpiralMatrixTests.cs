namespace Tasks.Matrices.Spiral;

public class SpiralMatrixTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            { 1, 2, 3 },
            { 6, 5, 4 },
            { 7, 8, 9 }
        }; 
        
        var expected = new int[] { 1, 2, 3, 4, 9, 8, 7, 6, 5 };
        
        // Act
        var res = SpiralMatrix.Run( matrix );

        // Assert
        Assert.Equal( expected, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            { 1, 6, 4, 7 },
            { 3, 2, 8, 2 },
            { 6, 7, 1, 5 },
            { 3, 1, 8, 2 }
        }; 
        
        var expected = new int[] { 1, 6, 4, 7, 2, 5, 2, 8, 1, 3, 6, 3, 2, 8, 1, 7 };
        
        // Act
        var res = SpiralMatrix.Run( matrix );

        // Assert
        Assert.Equal( expected, res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            { 1, 6, 4, 7 },
            { 3, 2, 8, 2 },
        }; 
        
        var expected = new int[] { 1, 6, 4, 7, 2,8, 2, 3 };
        
        // Act
        var res = SpiralMatrix.Run( matrix );

        // Assert
        Assert.Equal( expected, res );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            { 1, 6, },
            { 3, 2 },
            { 4, 5 },
            { 2, 3 },
        }; 
        
        var expected = new int[] { 1, 6, 2, 5, 3, 2, 4, 3 };
        
        // Act
        var res = SpiralMatrix.Run( matrix );

        // Assert
        Assert.Equal( expected, res );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            { 1, 2, 3, 4 },
            { 10, 11, 12, 5 },
            { 9, 8, 7, 6 }
        }; 
        
        var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        
        // Act
        var res = SpiralMatrix.Run( matrix );

        // Assert
        Assert.Equal( expected, res );
    }
}