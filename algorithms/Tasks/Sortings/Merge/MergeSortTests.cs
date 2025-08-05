namespace Tasks.Sortings.Merge;

public class MergeSortTests
{
    [Fact]
    public void Apply_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 3, 3, 1, 1, 0, 2 };
        var expected = new int[] { 0, 1, 1, 2, 3, 3 };
        
        // Act
        var res = MergeSort.Apply(array);
        
        // Assert
        Assert.Equal( res, expected );
    }
    
    [Fact]
    public void Apply_Case11_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { -5, 3, 1, 0, 2 };
        var expected = new int[] { -5, 0, 1, 2, 3 };
        
        // Act
        var res = MergeSort.Apply(array);
        
        // Assert
        Assert.Equal( res, expected );
    }
    
    [Fact]
    public void Apply_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        var expected = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        
        // Act
        var res = MergeSort.Apply(array);
        
        // Assert
        Assert.Equal( res, expected );
    }
    
    [Fact]
    public void Apply_Case22_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 7, 6, 5, 1, 2, 3, 4, 0, -1 };
        var expected = new int[] { -1, 0, 1, 2, 3, 4, 5, 6, 7 };
        
        // Act
        var res = MergeSort.Apply(array);
        
        // Assert
        Assert.Equal( res, expected );
    }
    
    [Fact]
    public void Apply_Case3_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 7, 6, 5, 1, 2, 3, 4 };
        var expected = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        
        // Act
        var res = MergeSort.Apply(array);
        
        // Assert
        Assert.Equal( res, expected );
    }
    
    [Fact]
    public void Apply_Case4_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 7 };
        var expected = new int[] { 7 };
        
        // Act
        var res = MergeSort.Apply(array);
        
        // Assert
        Assert.Equal( res, expected );
    }
    
    [Fact]
    public void Apply_Case5_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 7, 2 };
        var expected = new int[] { 2, 7 };
        
        // Act
        var res = MergeSort.Apply(array);
        
        // Assert
        Assert.Equal( res, expected );
    }
    
    [Fact]
    public void Apply_Case6_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 7, 1, 2 };
        var expected = new int[] { 1, 2, 7 };
        
        // Act
        var res = MergeSort.Apply(array);
        
        // Assert
        Assert.Equal( res, expected );
    }
    
    [Fact]
    public void Apply_Case7_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 7, 3, 2, 1 };
        var expected = new int[] { 1, 2, 3, 7 };
        
        // Act
        var res = MergeSort.Apply(array);
        
        // Assert
        Assert.Equal( res, expected );
    }
}