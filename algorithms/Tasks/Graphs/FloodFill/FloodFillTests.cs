namespace Tasks.Graphs.FloodFill;

public class FloodFillTests
{

    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        int[,] grid =
        {
            { 1, 1, 1 },
            { 1, 1, 0 },
            { 1, 0, 1 }
        };
        
        int[,] expected =
        {
            { 2, 2, 2 },
            { 2, 2, 0 },
            { 2, 0, 1 }
        };

        // Act
        FloodFill.Run( grid, ( 1, 1 ), 2 );
        
        // Assert
        Assert.Equal( expected, grid );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        int[,] grid =
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
        };
        
        int[,] expected =
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
        };

        // Act
        FloodFill.Run( grid, ( 0, 0 ), 0 );
        
        // Assert
        Assert.Equal( expected, grid );
    }
}