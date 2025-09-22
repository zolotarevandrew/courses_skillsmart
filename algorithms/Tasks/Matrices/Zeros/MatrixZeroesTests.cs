

namespace Tasks.Matrices.Zeros;

public class MatrixZeroesTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            { 2, 2, 2 },
            { 2, 0, 2 },
            { 2, 2, 2 }
        };
        var expected = new int[,]
        {
            { 2, 0, 2 },
            { 0, 0, 0 },
            { 2, 0, 2 }
        };
        
        // Act
        MatrixZeroes.Run( matrix );

        // Assert
        Assert.Equal( expected, matrix );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            { 2, 0, 2 },
            { 2, 0, 2 },
            { 2, 2, 2 }
        };
        var expected = new int[,]
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 2, 0, 2 }
        };
        
        // Act
        MatrixZeroes.Run( matrix );

        // Assert
        Assert.Equal( expected, matrix );
    }
    
    [Fact]
    public void RunV2_Case1_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            { 2, 2, 2 },
            { 2, 0, 2 },
            { 2, 2, 2 }
        };
        var expected = new int[,]
        {
            { 2, 0, 2 },
            { 0, 0, 0 },
            { 2, 0, 2 }
        };
        
        // Act
        MatrixZeroes.RunV2( matrix );

        // Assert
        Assert.Equal( expected, matrix );
    }
    
    [Fact]
    public void RunV2_Case2_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            { 2, 0, 2 },
            { 2, 0, 2 },
            { 2, 2, 2 }
        };
        var expected = new int[,]
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 2, 0, 2 }
        };
        
        // Act
        MatrixZeroes.RunV2( matrix );

        // Assert
        Assert.Equal( expected, matrix );
    }
}