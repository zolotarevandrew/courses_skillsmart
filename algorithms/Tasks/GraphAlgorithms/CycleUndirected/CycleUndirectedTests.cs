namespace Tasks.GraphAlgorithms.CycleUndirected;

public class CycleUndirectedTests
{
    [Fact]
    public void HasCycle_NoCycles_ShouldBeFalse( )
    {
        // Arrange
        var node1 = new CycleUndirected.Vertex( 1 );
        var node2 = new CycleUndirected.Vertex( 2 );
        var node3 = new CycleUndirected.Vertex( 3 );
        var node4 = new CycleUndirected.Vertex( 4 );
        var node5 = new CycleUndirected.Vertex( 5 );
        var node6 = new CycleUndirected.Vertex( 6 );
        var graph = new CycleUndirected.Graph
        {
            Value = new Dictionary<CycleUndirected.Vertex, List<CycleUndirected.Vertex>>
            {
                { node1, [node2, node6] },
                { node2, [node3] },
                { node3, [node4] },
                { node4, [node5] },
            }
        };

        // Assert
        Assert.False( CycleUndirected.HasCycle( graph ) );
    }
    
    [Fact]
    public void HasCycle_WithCycles_ShouldBeTrue( )
    {
        // Arrange
        var node1 = new CycleUndirected.Vertex( 1 );
        var node2 = new CycleUndirected.Vertex( 2 );
        var node3 = new CycleUndirected.Vertex( 3 );
        var node4 = new CycleUndirected.Vertex( 4 );
        var node5 = new CycleUndirected.Vertex( 5 );
        var node6 = new CycleUndirected.Vertex( 6 );
        var graph = new CycleUndirected.Graph
        {
            Value = new Dictionary<CycleUndirected.Vertex, List<CycleUndirected.Vertex>>
            {
                { node1, [node2, node6] },
                { node2, [node3] },
                { node3, [node4] },
                { node4, [node5] },
                { node5, [node6] },
            }
        };

        // Assert
        Assert.True( CycleUndirected.HasCycle( graph ) );
    }
}