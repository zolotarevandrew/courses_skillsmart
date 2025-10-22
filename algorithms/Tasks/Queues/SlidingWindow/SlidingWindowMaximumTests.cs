namespace Tasks.Queues.SlidingWindow;

public class SlidingWindowMaximumTests
{

    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var arr = new int[]
        {
            1,3,-1,-3,5,3,6,7
        };
        int k = 3;

        // Act
        var res = SlidingWindowMaximum.Run( arr, k );

        // Assert
        Assert.Equal( 6, res.Count );
        Assert.Equal( 3, res[ 0 ] );
        Assert.Equal( 3, res[ 1 ] );
        Assert.Equal( 5, res[ 2 ] );
        Assert.Equal( 5, res[ 3 ] );
        Assert.Equal( 6, res[ 4 ] );
        Assert.Equal( 7, res[ 5 ] );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var arr = new int[]
        {
            9,11
        };
        int k = 2;

        // Act
        var res = SlidingWindowMaximum.Run( arr, k );

        // Assert
        Assert.Equal( 1, res.Count );
        Assert.Equal( 11, res[ 0 ] );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var arr = new int[]
        {
            9,11
        };
        int k = 3;

        // Act
        var res = SlidingWindowMaximum.Run( arr, k );

        // Assert
        Assert.Equal( 0, res.Count );
    }
}