namespace Tasks.Heaps.KClosest;


public class HeapKClosestTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Act
        List<HeapPoint> res = HeapKClosest.Run( [
            new HeapPoint( 4, 4 ),
            new HeapPoint( 1, 2 ),
            new HeapPoint( 2, 3 )
        ], 2 );

        // Assert
        Assert.NotNull( res );
        Assert.Equal( 2, res.Count );
        Assert.Equal( new HeapPoint( 1, 2 ), res[0] );
        Assert.Equal( new HeapPoint( 2, 3 ), res[1] );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Act
        List<HeapPoint> res = HeapKClosest.Run( [
            new HeapPoint( 4, 4 ),
            new HeapPoint( 1, 2 ),
            new HeapPoint( 2, 3 ),
            new HeapPoint( 1, 1 )
        ], 2 );

        // Assert
        Assert.NotNull( res );
        Assert.Equal( 2, res.Count );
        Assert.Equal( new HeapPoint(1, 1), res[0] );
        Assert.Equal( new HeapPoint(1, 2), res[1] );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Act
        List<HeapPoint> res = HeapKClosest.Run( [
            new HeapPoint( -1, -1 ),
            new HeapPoint( 2, 2 ),
            new HeapPoint( 0, 1 ),
            new HeapPoint( 1, -1 )
        ], 3 );

        // Assert
        Assert.NotNull( res );
        Assert.Equal( 3, res.Count );
        Assert.Equal( new HeapPoint( 0, 1 ), res[0] );
        Assert.Equal( new HeapPoint( 1, -1 ), res[1] );
        Assert.Equal( new HeapPoint( -1, -1 ), res[2] );
    }
}