namespace Tasks.Matrices.DiagonalSum;

public class DiagonalSumTests
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
        var res = DiagonalSum.Run( matrix );
        
        // Assert
        Assert.Equal( 25, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange 
        var matrix = new int[,]
        {
            { 2, 2, 2, 2 },
            { 2, 2, 2, 2 },
            { 2, 2, 2, 2 },
            { 2, 2, 2, 2 }
        };
        
        // Act
        var res = DiagonalSum.Run( matrix );
        
        // Assert
        Assert.Equal( 8, res );
    }
}