namespace Tasks.DynamicProgramming.MinimumPath;

public class MinimumPathSumTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        int[,] arr = new int[,]
        {
            { 2, 4, 1 },
            { 3, 2, 1 },
            { 5, 3, 2 }
        };
        
        // Act
        var res = MinimumPathSum.Run( arr );

        // Assert
        Assert.Equal( 10, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        int[,] arr = new int[,]
        {
            { 3, 1, 2 },
            { 6, 4, 3 }
        };
        
        // Act
        var res = MinimumPathSum.Run( arr );

        // Assert
        Assert.Equal( 9, res );
    }
}