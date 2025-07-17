namespace Tasks.Arrays.MaximumContainerArea;

public class ArrayMaximumContainerAreaTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2, 3, 10, 5, 7, 8, 9 };
        
        // Act
        var result = ArrayMaximumContainerArea.Run(array);
        
        // Assert
        Assert.Equal( 36, result );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 1, 1, 1 };
        
        // Act
        var result = ArrayMaximumContainerArea.Run(array);
        
        // Assert
        Assert.Equal( 3, result );
    }
    
    [Fact]
    public void RunTwoPointers_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2, 3, 10, 5, 7, 8, 9 };
        
        // Act
        var result = ArrayMaximumContainerArea.RunTwoPointers(array);
        
        // Assert
        Assert.Equal( 36, result );
    }
    
    [Fact]
    public void RunTwoPointers_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 1, 1, 1 };
        
        // Act
        var result = ArrayMaximumContainerArea.RunTwoPointers(array);
        
        // Assert
        Assert.Equal( 3, result );
    }
}