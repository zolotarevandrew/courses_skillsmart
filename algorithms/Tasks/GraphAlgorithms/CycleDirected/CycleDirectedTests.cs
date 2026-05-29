namespace Tasks.GraphAlgorithms.CycleDirected;

public class CycleDirectedTests
{
    [Fact]
    public void HasCycle_NoCycles_ShouldBeFalse( )
    {
        // Arrange
        var node1 = new CycleDirected.Vertex( 1 );
        var node2 = new CycleDirected.Vertex( 2 );
        var node3 = new CycleDirected.Vertex( 3 );
        var node4 = new CycleDirected.Vertex( 4 );
        var graph = new CycleDirected.Graph
        {
            Value = new Dictionary<CycleDirected.Vertex, List<CycleDirected.Vertex>>
            {
                { node1, [node2, node3] },
                { node2, [node4] },
                { node3, [node4] }
            }
        };

        // Assert
        Assert.False( CycleDirected.HasCycle( graph ) );
    }
    
    [Fact]
    public void HasCycle_WithCycles_ShouldBeTrue( )
    {
        // Arrange
        var node1 = new CycleDirected.Vertex( 1 );
        var node2 = new CycleDirected.Vertex( 2 );
        var node3 = new CycleDirected.Vertex( 3 );
        var node4 = new CycleDirected.Vertex( 4 );
        var graph = new CycleDirected.Graph
        {
            Value = new Dictionary<CycleDirected.Vertex, List<CycleDirected.Vertex>>
            {
                { node1, [node2] },
                { node2, [node3] },
                { node3, [node4] },
                { node4, [node2] }
            }
        };

        // Assert
        Assert.True( CycleDirected.HasCycle( graph ) );
    }
}