namespace Tasks.GraphAlgorithms.TopologicalSorting;

public class TopologicalSortingTests
{
    [Fact]
    public void HasCycle_WithCycles_ShouldBeTrue( )
    {
        // Arrange
        var node1 = new TopologicalSorting.Vertex( 1 );
        var node2 = new TopologicalSorting.Vertex( 2 );
        var node3 = new TopologicalSorting.Vertex( 3 );
        var node4 = new TopologicalSorting.Vertex( 4 );
        var node5 = new TopologicalSorting.Vertex( 5 );
        var node6 = new TopologicalSorting.Vertex( 6 );
        var graph = new TopologicalSorting.Graph
        {
            Value = new Dictionary<TopologicalSorting.Vertex, List<TopologicalSorting.Vertex>>
            {
                { node1, [node2, node4] },
                { node2, [node3] },
                { node3, [node5] },
                { node5, [node6] },
            }
        };

        // Assert
        var res = TopologicalSorting.DfsSort( graph );
        Assert.Equal( 6, res.Count );
        var values = res.Select( c => c.Value ).ToList( );
        Assert.Equal( values, [1, 4, 2, 3, 5, 6] );
    }
}