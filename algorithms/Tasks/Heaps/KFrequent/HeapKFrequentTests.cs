namespace Tasks.Heaps.KFrequent;

public class HeapKFrequentTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Act
        List<int> res = HeapKFrequent.Run( [4, 4, 4, 6, 6, 7, 7, 7, 7], 2 );

        Assert.NotNull( res );
        Assert.Equal( 2, res.Count );
        Assert.Equal( 4, res[0] );
        Assert.Equal( 7, res[1] );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Act
        List<int> res = HeapKFrequent.Run( [0, 3, 1, 5], 0 );

        Assert.NotNull( res );
        Assert.Equal( 0, res.Count );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Act
        List<int> res = HeapKFrequent.Run( [0, 3, 1, 5], -1 );

        Assert.NotNull( res );
        Assert.Equal( 0, res.Count );
    }

    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Act
        List<int> res = HeapKFrequent.Run( [0, 3, 1, 5], 4 );

        Assert.NotNull( res );
        Assert.Equal( 4, res.Count );
        Assert.Equal( 0, res[0] );
        Assert.Equal( 5, res[1] );
        Assert.Equal( 1, res[2] );
        Assert.Equal( 3, res[3] );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Act
        List<int> res = HeapKFrequent.Run( [0, 3, 1, 5], 3 );

        Assert.NotNull( res );
        Assert.Equal( 3, res.Count );
        Assert.Equal( 5, res[0] );
        Assert.Equal( 1, res[1] );
        Assert.Equal( 3, res[2] );
    }
    
    [Fact]
    public void Run_Case6_ShouldBeOk( )
    {
        // Act
        List<int> res = HeapKFrequent.Run( [0, 3, 1, 5], 2 );

        Assert.NotNull( res );
        Assert.Equal( 2, res.Count );
        Assert.Equal( 5, res[0] );
        Assert.Equal( 3, res[1] );
    }
}