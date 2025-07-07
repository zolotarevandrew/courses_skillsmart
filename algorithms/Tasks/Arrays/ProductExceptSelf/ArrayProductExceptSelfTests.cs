namespace Tasks.Arrays.ProductExceptSelf;

public class ArrayProductExceptSelfTests
{
    [Fact]
    public void ProductExceptSelf_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2, 3, 4, 5 };
        var expected = new long[] { 60, 40, 30, 24 };
        
        // Act
        var result = ArrayProductExceptSelf.ProductExceptSelf(array);
        
        // Assert
        Assert.Equal( expected, result );
    }
    
    [Fact]
    public void ProductExceptSelf_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2, 0, 4 };
        var expected = new long[] { 0, 0, 8, 0 };
        
        // Act
        var result = ArrayProductExceptSelf.ProductExceptSelf(array);
        
        // Assert
        Assert.Equal( expected, result );
    }
    
    [Fact]
    public void ProductExceptSelfV2_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2, 3, 4, 5 };
        var expected = new long[] { 60, 40, 30, 24 };
        
        // Act
        var result = ArrayProductExceptSelf.ProductExceptSelfV2(array);
        
        // Assert
        Assert.Equal( expected, result );
    }
    
    [Fact]
    public void ProductExceptSelfV2_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2, 0, 4 };
        var expected = new long[] { 0, 0, 8, 0 };
        
        // Act
        var result = ArrayProductExceptSelf.ProductExceptSelfV2(array);
        
        // Assert
        Assert.Equal( expected, result );
    }
}