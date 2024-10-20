using System;
using Xunit;

namespace Sorting.Tests;

public class MergeSortMergeTests
{
    [Fact]
    public void Merge_TwoElementsUnsorted_ShouldBeOk()
    {
        Memory<int> arr = new int[] { 39, 38 };
        var buffer = new int[arr.Length];

        var (left, right) = MergeSort.Divide(arr);
        MergeSort.Merge(arr, left, right, buffer);
        
        Assert.Equal(38, arr.Span[0]);
        Assert.Equal(39, arr.Span[1]);
    }
    
    [Fact]
    public void Merge_TwoElementsSorted_ShouldBeOk()
    {
        Memory<int> arr = new int[] { 38, 39 };
        var buffer = new int[arr.Length];

        var (left, right) = MergeSort.Divide(arr);
        MergeSort.Merge(arr, left, right, buffer);
        
        Assert.Equal(38, arr.Span[0]);
        Assert.Equal(39, arr.Span[1]);
    }
    
    
    [Fact]
    public void Merge_ThreeElements_ShouldBeOk()
    {
        Memory<int> arr = new int[] { 3, 1, 2 };
        var buffer = new int[arr.Length];

        var (left, right) = MergeSort.Divide(arr);
        MergeSort.Merge(arr, left, right, buffer);
        
        Assert.Equal(1, arr.Span[0]);
        Assert.Equal(2, arr.Span[1]);
        Assert.Equal(3, arr.Span[2]);
    }
    
    [Fact]
    public void Merge_FourElementsUnsorted_ShouldBeOk()
    {
        Memory<int> arr = new int[] { 1, 3, 2, 4 };
        var buffer = new int[arr.Length];

        var (left, right) = MergeSort.Divide(arr);
        MergeSort.Merge(arr, left, right, buffer);
        
        Assert.Equal(1, arr.Span[0]);
        Assert.Equal(2, arr.Span[1]);
        Assert.Equal(3, arr.Span[2]);
        Assert.Equal(4, arr.Span[3]);
    }
    
    [Fact]
    public void Merge_FourElementsSorted_ShouldBeOk()
    {
        Memory<int> arr = new int[] { 1, 2, 3, 4 };
        var buffer = new int[arr.Length];

        var (left, right) = MergeSort.Divide(arr);
        MergeSort.Merge(arr, left, right, buffer);
        
        Assert.Equal(1, arr.Span[0]);
        Assert.Equal(2, arr.Span[1]);
        Assert.Equal(3, arr.Span[2]);
        Assert.Equal(4, arr.Span[3]);
    }
    
    [Fact]
    public void Merge_FiveElementsUnsorted_ShouldBeOk()
    {
        Memory<int> arr = new int[] { 5, 6, 1, 3, 4 };
        var buffer = new int[arr.Length];

        var (left, right) = MergeSort.Divide(arr);
        MergeSort.Merge(arr, left, right, buffer);
        
        Assert.Equal(1, arr.Span[0]);
        Assert.Equal(3, arr.Span[1]);
        Assert.Equal(4, arr.Span[2]);
        Assert.Equal(5, arr.Span[3]);
        Assert.Equal(6, arr.Span[4]);
    }
}