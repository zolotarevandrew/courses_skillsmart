using Tasks.Arrays.MissingNumber;

namespace Tasks.Arrays.SortingColors;

public class ArraySortingColorTest
{
    [Fact]
    public void SortColors_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 0, 1, 2, 1, 2, 0, 1, 0, 2 };
        var expected = new int[] { 0, 0, 0, 1, 1, 1, 2, 2, 2 };
        
        // Act
        ArraySortingColors.SortColors(array);
        
        // Assert
        Assert.Equal( expected, array );
    }
    
    [Fact]
    public void SortColors_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2, 1, 0, 2, 1, 0, 2 };
        var expected = new int[] { 0, 0, 1, 1, 1, 2, 2, 2 };
        
        // Act
        ArraySortingColors.SortColors(array);
        
        // Assert
        Assert.Equal( expected, array );
    }
    
    [Fact]
    public void SortColorsV2_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 0, 1, 2, 1, 2, 0, 1, 0, 2 };
        var expected = new int[] { 0, 0, 0, 1, 1, 1, 2, 2, 2 };
        
        // Act
        ArraySortingColors.SortColorsV2(array);
        
        // Assert
        Assert.Equal( expected, array );
    }
    
    [Fact]
    public void SortColorsV2_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2, 1, 0, 2, 1, 0, 2 };
        var expected = new int[] { 0, 0, 1, 1, 1, 2, 2, 2 };
        
        // Act
        ArraySortingColors.SortColorsV2(array);
        
        // Assert
        Assert.Equal( expected, array );
    }
    
    [Fact]
    public void SortColorsDutchFlag_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 0, 1, 2, 1, 2, 0, 1, 0, 2 };
        var expected = new int[] { 0, 0, 0, 1, 1, 1, 2, 2, 2 };
        
        // Act
        ArraySortingColors.SortColorsDutchFlag(array);
        
        // Assert
        Assert.Equal( expected, array );
    }
    
    [Fact]
    public void SortColorsDutchFlag_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2, 1, 0, 2, 1, 0, 2 };
        var expected = new int[] { 0, 0, 1, 1, 1, 2, 2, 2 };
        
        // Act
        ArraySortingColors.SortColorsDutchFlag(array);
        
        // Assert
        Assert.Equal( expected, array );
    }
    
    [Fact]
    public void SortColorsDutchFlag_Case3_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2, 2, 2, 0, 1, 1 };
        var expected = new int[] { 0, 1, 1, 2, 2, 2 };
        
        // Act
        ArraySortingColors.SortColorsDutchFlag(array);
        
        // Assert
        Assert.Equal( expected, array );
    }
}