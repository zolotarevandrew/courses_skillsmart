using Tasks.Arrays.ProductExceptSelf;

namespace Tasks.Arrays.SortedPairSum;

public class ArraySortedPairSumTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2, 7, 11, 15 };
        
        // Act
        var result = ArraySortedPairSum.Run(array, 9);
        
        // Assert
        Assert.Equal( 1, result.Index1 );
        Assert.Equal( 2, result.Index2 );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2, 3, 4, 4, 9 };
        
        // Act
        var result = ArraySortedPairSum.Run(array, 8);
        
        // Assert
        Assert.Equal( 4, result.Index1 );
        Assert.Equal( 5, result.Index2 );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { -3, -1, 0, 2, 4, 10 };
        
        // Act
        var result = ArraySortedPairSum.Run( array, 9 );
        
        // Assert
        Assert.Equal( 2, result.Index1 );
        Assert.Equal( 6, result.Index2 );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 0, 0, 3, 4 };
        
        // Act
        var result = ArraySortedPairSum.Run( array, 0 );
        
        // Assert
        Assert.Equal( 1, result.Index1 );
        Assert.Equal( 2, result.Index2 );
    }
}