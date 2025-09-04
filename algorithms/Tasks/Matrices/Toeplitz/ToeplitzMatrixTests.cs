namespace Tasks.Matrices.Toeplitz;

public class ToeplitzMatrixTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange 
        var matrix = new int[,]
        {
            { 2, 3, 4, 5 },
            { 6, 2, 3, 4 },
            { 9, 6, 2, 3 }
        };
        
        // Act
        var res = ToeplitzMatrix.Run( matrix );
        
        // Assert
        Assert.True( res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange 
        var matrix = new int[,]
        {
            { 7, 8 },
            { 6, 7 },
            { 5, 6 }
        };
        
        // Act
        var res = ToeplitzMatrix.Run( matrix );
        
        // Assert
        Assert.True( res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeFalse( )
    {
        // Arrange 
        var matrix = new int[,]
        {
            { 7, 8 },
            { 6, 9 },
            { 5, 6 }
        };
        
        // Act
        var res = ToeplitzMatrix.Run( matrix );
        
        // Assert
        Assert.False( res );
    }
}