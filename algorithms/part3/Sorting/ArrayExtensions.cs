using System;

namespace Sorting;

public static class ArrayExtensions
{
    public static void Swap(this int[] array, int fromIdx, int toIdx)
    {
        (array[toIdx], array[fromIdx]) = (array[fromIdx], array[toIdx]);
    }
    
    public static void Swap(this Span<int> array, int fromIdx, int toIdx)
    {
        (array[toIdx], array[fromIdx]) = (array[fromIdx], array[toIdx]);
    }
}