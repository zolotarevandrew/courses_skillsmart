namespace Tasks.MinimumSpanningTrees.MinimumCost;

public class MinimumCostTests
{
    [Fact]
    public void Run_Points_ShouldBeOk( )
    {
        // Arrange
        MinimumCost.Point[] points =
        [
            new ( 1, 1 ),
            new ( 3, 3 ),
            new ( 6, 8 ),
            new ( 4, 2 ),
            new ( 10, 0 ),
        ];

        // Assert
        Assert.Equal( 22, MinimumCost.Run( points ) );
    }
}