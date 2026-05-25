namespace Tasks.Graphs.PacificFlow;

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
        Assert.Equal( 5, res.Count );
        Assert.True( res.Contains( new PacificAntlanticFlow.Index( 2, 0 ) ) );
        Assert.True( res.Contains( new PacificAntlanticFlow.Index( 2, 1 ) ) );
        Assert.True( res.Contains( new PacificAntlanticFlow.Index( 2, 2 ) ) );
        Assert.True( res.Contains( new PacificAntlanticFlow.Index( 0, 2 ) ) );
        Assert.True( res.Contains( new PacificAntlanticFlow.Index( 1, 2 ) ) );
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
        Assert.Equal( 9, res.Count );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        int[,] grid =
        {
            { 1, 2, 2, 3, 5 },
            { 3, 2, 3, 4, 4 },
            { 2, 4, 5, 3, 1 },
            { 6, 7, 1, 4, 5 },
            { 5, 1, 1, 2, 4 },
        };

        // Act
        List<PacificAntlanticFlow.Index> res = PacificAntlanticFlow.Run( grid );
        
        Assert.NotEmpty( res );
        Assert.Equal( 7, res.Count );
        Assert.True( res.Contains( new PacificAntlanticFlow.Index( 0, 4 ) ) );
        Assert.True( res.Contains( new PacificAntlanticFlow.Index( 1, 4 ) ) );
        Assert.True( res.Contains( new PacificAntlanticFlow.Index( 1, 3 ) ) );
        
        Assert.True( res.Contains( new PacificAntlanticFlow.Index( 2, 2 ) ) );
        
        Assert.True( res.Contains( new PacificAntlanticFlow.Index( 4, 0 ) ) );
        Assert.True( res.Contains( new PacificAntlanticFlow.Index( 3, 0 ) ) );
        Assert.True( res.Contains( new PacificAntlanticFlow.Index( 3, 1 ) ) );
    }
    
}