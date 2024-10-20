using System;
using Xunit;

namespace Sorting.Tests;

public class MergeSortDivideTests
{
    [Fact]
    public void Divide_TwoElements_ShouldBeOk()
    {
        Memory<int> arr = new int[] { 1, 2 };

        var (left, right) = MergeSort.Divide(arr);
        
        Assert.Equal(1, left.Span[0]);
        Assert.Equal(1, left.Length);
        
        Assert.Equal(1, right.Length);
        Assert.Equal(2, right.Span[0]);
    }
    
    [Fact]
    public void Divide_ThreeElements_ShouldBeOk()
    {
        Memory<int> arr = new int[] { 1, 2, 3 };

        var (left, right) = MergeSort.Divide(arr);
        
        Assert.Equal(1, left.Span[0]);
        Assert.Equal(1, left.Length);
        
        Assert.Equal(2, right.Length);
        Assert.Equal(2, right.Span[0]);
        Assert.Equal(3, right.Span[1]);
    }
    
    [Fact]
    public void Divide_FourElements_ShouldBeOk()
    {
        Memory<int> arr = new int[] { 1, 2, 3, 4 };

        var (left, right) = MergeSort.Divide(arr);
        
        Assert.Equal(1, left.Span[0]);
        Assert.Equal(2, left.Span[1]);
        Assert.Equal(2, left.Length);
        
        Assert.Equal(2, right.Length);
        Assert.Equal(3, right.Span[0]);
        Assert.Equal(4, right.Span[1]);
    }
    
    [Fact]
    public void Divide_FiveElements_ShouldBeOk()
    {
        Memory<int> arr = new int[] { 1, 2, 3, 4, 5 };

        var (left, right) = MergeSort.Divide(arr);
        
        Assert.Equal(1, left.Span[0]);
        Assert.Equal(2, left.Span[1]);
        Assert.Equal(2, left.Length);
        
        Assert.Equal(3, right.Length);
        Assert.Equal(3, right.Span[0]);
        Assert.Equal(4, right.Span[1]);
        Assert.Equal(5, right.Span[2]);
    }
}