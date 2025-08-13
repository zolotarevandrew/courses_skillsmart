namespace Tasks.Hashtables.Pairsum;

public class PairSumTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 3, 5, 7 };
        var target = 8;
        
        // Act
        var result = PairSum.Run(array, target);
        
        // Assert
        Assert.Equal( 1, result.Index1 );
        Assert.Equal( 2, result.Index2 );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 4, 6, 10 };
        var target = 16;
        
        // Act
        var result = PairSum.Run(array, target);
        
        // Assert
        Assert.Equal( 1, result.Index1 );
        Assert.Equal( 2, result.Index2 );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2, 9, 14, 7 };
        var target = 16;
        
        // Act
        var result = PairSum.Run(array, target);
        
        // Assert
        Assert.Equal( 0, result.Index1 );
        Assert.Equal( 2, result.Index2 );
    }
}