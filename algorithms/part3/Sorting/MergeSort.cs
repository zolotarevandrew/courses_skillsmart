using System;

namespace Sorting;

public static class MergeSort
{
    public static void Sort(int[] array)
    {
        int[] buffer = new int[array.Length];
        InternalSort(array.AsMemory(), buffer);
    }
    
    public static void InternalSort(Memory<int> array, int[] buffer)
    {
        if (array.Length <= 1) return;

        var (left, right) = Divide(array);
        InternalSort(left, buffer);
        InternalSort(right, buffer);
        
        Merge(array, left, right, buffer);
    }
    
    public static (Memory<int> Left, Memory<int> Right) Divide(Memory<int> array)
    {
        int mid = (array.Length / 2) - 1;
        return (array[..(mid + 1)], array[(mid+1)..array.Length]);
    }

    public static void Merge(Memory<int> array, Memory<int> left, Memory<int> right, int[] buffer)
    {
        int leftIndex = 0, rightIndex = 0, tempIndex = 0;

        Memory<int> memoryBuffer = buffer.AsMemory(0, array.Length);
        
        while (leftIndex < left.Length && rightIndex < right.Length)
        {
            memoryBuffer.Span[tempIndex++] = left.Span[leftIndex] < right.Span[rightIndex]
                ? left.Span[leftIndex++]
                : right.Span[rightIndex++];
        }

        var leftRemaining = left.Slice(leftIndex, left.Length - leftIndex);
        leftRemaining.CopyTo(memoryBuffer.Slice(tempIndex, memoryBuffer.Length - tempIndex));
        
        var rightRemaining = right.Slice(rightIndex, right.Length - rightIndex);
        rightRemaining.CopyTo(memoryBuffer.Slice(tempIndex, memoryBuffer.Length - tempIndex));
        
        memoryBuffer.CopyTo(array);
    }
}