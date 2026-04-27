namespace Tasks.Graphs.FloodFill;

public class PacificAntlanticFlowTests
{

    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        int[,] grid =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        // Act
        var res = PacificAntlanticFlow.Run( grid );
        
        Assert.NotEmpty( res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        int[,] grid =
        {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 }
        };

        // Act
        var res = PacificAntlanticFlow.Run( grid );
        
        Assert.NotEmpty( res );
    }
    
}