namespace Tasks.Stacks.Histogram;

public class LargestHistogramAreaTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var arr = new int[]
        {
            2, 1, 5, 6, 2, 3
        };

        // Act
        var res = LargestHistogramArea.Run( arr );

        // Assert
        Assert.Equal( 10, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var arr = new int[]
        {
            2, 4
        };

        // Act
        var res = LargestHistogramArea.Run( arr );

        // Assert
        Assert.Equal( 4, res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var arr = new int[]
        {
            1
        };

        // Act
        var res = LargestHistogramArea.Run( arr );

        // Assert
        Assert.Equal( 1, res );
    }
    
    [Fact]
    public void RunStacks_Case1_ShouldBeOk( )
    {
        // Arrange
        var arr = new int[]
        {
            2, 1, 5, 6, 2, 3
        };

        // Act
        var res = LargestHistogramArea.RunStacks( arr );

        // Assert
        Assert.Equal( 10, res );
    }
    
    [Fact]
    public void RunStacks_Case2_ShouldBeOk( )
    {
        // Arrange
        var arr = new int[]
        {
            2, 4
        };

        // Act
        var res = LargestHistogramArea.RunStacks( arr );

        // Assert
        Assert.Equal( 4, res );
    }
    
    [Fact]
    public void RunStacks_Case3_ShouldBeOk( )
    {
        // Arrange
        var arr = new int[]
        {
            1
        };

        // Act
        var res = LargestHistogramArea.RunStacks( arr );

        // Assert
        Assert.Equal( 1, res );
    }
}