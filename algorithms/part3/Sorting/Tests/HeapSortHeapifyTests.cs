using Xunit;

namespace Sorting.Tests;

public class HeapSortHeapifyTests
{
    [Fact]
    public void Heapify_OneElement_ShouldBeOk()
    {
        //Arrange
        var arr = new int[] { 1 };

        //Act
        HeapSort.Heapify(arr, 0);

        //Assert
        Assert.Equal(1, arr[0]);
    }
    
    [Fact]
    public void Heapify_TwoElements_ShouldBeOk()
    {
        //Arrange
        var arr = new int[] { 1, 2 };

        //Act
        HeapSort.Heapify(arr, 0);

        //Assert
        Assert.Equal(2, arr[0]);
        Assert.Equal(1, arr[1]);
    }
    
    [Fact]
    public void Heapify_ThreeElements_ShouldBeOk()
    {
        //Arrange
        var arr = new int[] { 1, 3, 2 };

        //Act
        HeapSort.Heapify(arr, 0);

        //Assert
        Assert.Equal(3, arr[0]);
        Assert.Equal(1, arr[1]);
        Assert.Equal(2, arr[2]);
    }
}