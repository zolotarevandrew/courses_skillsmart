namespace Tasks.Graphs.Clone;

public class CloneGraphTests
{

    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node1 = new CloneGraph.Node
        {
            Value = 1
        };
        CloneGraph.Node node = new CloneGraph.Node
        {
            Value = 0,
            Neighbors =
            [
                node1,

                new CloneGraph.Node
                {
                    Value = 4,
                    Neighbors =
                    [
                        new CloneGraph.Node
                        {
                            Value = 8,
                            Neighbors =
                            [
                                new CloneGraph.Node
                                {
                                    Value = 9,
                                    Neighbors =
                                    [
                                        new CloneGraph.Node
                                        {
                                            Value = 5,
                                            Neighbors =
                                            [
                                                node1
                                            ]
                                        }
                                    ]
                                }
                            ]
                        }
                    ]
                }
            ]
        };

        // Act
        var res = CloneGraph.Run( node );
        
        Assert.NotNull( res );
    }
}