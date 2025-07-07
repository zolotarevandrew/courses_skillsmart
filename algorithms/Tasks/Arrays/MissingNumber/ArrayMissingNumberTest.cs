namespace Tasks.Arrays.MissingNumber;

public class ArrayMissingNumberTest
{
    [Fact]
    public void FindMissingNumber_FiveElements_ShouldReturnSix( )
    {
        // Arrange
        var array = new int[] { 3, 0, 1 };
        
        // Act
        var result = ArrayMissingNumber.FindMissingNumber(array);
        
        // Assert
        Assert.Equal( result, 2 );
    }
    
    [Fact]
    public void FindMissingNumber_NineElements_ShouldReturnEight( )
    {
        // Arrange
        var array = new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
        
        // Act
        var result = ArrayMissingNumber.FindMissingNumber(array);
        
        // Assert
        Assert.Equal( result, 8 );
    }
    
    [Fact]
    public void FindMissingNumberV2_FiveElements_ShouldReturnSix( )
    {
        // Arrange
        var array = new int[] { 3, 0, 1 };
        
        // Act
        var result = ArrayMissingNumber.FindMissingNumberV2(array);
        
        // Assert
        Assert.Equal( result, 2 );
    }
    
    [Fact]
    public void FindMissingNumberV2_NineElements_ShouldReturnEight( )
    {
        // Arrange
        var array = new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
        
        // Act
        var result = ArrayMissingNumber.FindMissingNumberV2(array);
        
        // Assert
        Assert.Equal( result, 8 );
    }
    
    [Fact]
    public void FindMissingNumberV3_FiveElements_ShouldReturnSix( )
    {
        // Arrange
        var array = new int[] { 3, 0, 1 };
        
        // Act
        var result = ArrayMissingNumber.FindMissingNumberV3(array);
        
        // Assert
        Assert.Equal( result, 2 );
    }
    
    [Fact]
    public void FindMissingNumberV3_NineElements_ShouldReturnEight( )
    {
        // Arrange
        var array = new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
        
        // Act
        var result = ArrayMissingNumber.FindMissingNumberV3(array);
        
        // Assert
        Assert.Equal( result, 8 );
    }
}