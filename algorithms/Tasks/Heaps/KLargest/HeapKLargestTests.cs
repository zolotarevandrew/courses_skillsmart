namespace Tasks.Heaps.KLargest;

public class HeapKLargestTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Act
        int res = HeapKLargest.Run( [0, 3, 1, 5, 2, 7, 8, 4], 4 );

        // Assert
        Assert.Equal( 4, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Act
        int res = HeapKLargest.Run( [0, 3, 1], 4 );

        // Assert
        Assert.Equal( -1, res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Act
        int res = HeapKLargest.Run( [0, 3, 1], 0 );

        // Assert
        Assert.Equal( -1, res );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Act
        int res = HeapKLargest.Run( [0, 3, 1], -1 );

        // Assert
        Assert.Equal( -1, res );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Act
        int res = HeapKLargest.Run( [0, 3, 1, 5], 4 );

        // Assert
        Assert.Equal( 0, res );
    }
    
    [Fact]
    public void Run_Case6_ShouldBeOk( )
    {
        // Act
        int res = HeapKLargest.Run( [0, 3, 1, 5], 3 );

        // Assert
        Assert.Equal( 1, res );
    }
    
    [Fact]
    public void Run_Case7_ShouldBeOk( )
    {
        // Act
        int res = HeapKLargest.Run( [0, 3, 1, 5], 2 );

        // Assert
        Assert.Equal( 3, res );
    }
    
    [Fact]
    public void Run_Case8_ShouldBeOk( )
    {
        // Act
        int res = HeapKLargest.Run( [0, 3, 1, 5], 1 );

        // Assert
        Assert.Equal( 5, res );
    }
    
    [Fact]
    public void Run_Case9_ShouldBeOk( )
    {
        // Act
        int res = HeapKLargest.Run( [8, 7, 6, 5, 4, 3, 2, 1], 4 );

        // Assert
        Assert.Equal( 5, res );
    }
    
    [Fact]
    public void Run_Case10_ShouldBeOk( )
    {
        // Act
        int res = HeapKLargest.Run( [1, 2, 3, 4, 8, 5, 7, 6], 4 );

        // Assert
        Assert.Equal( 5, res );
    }
}