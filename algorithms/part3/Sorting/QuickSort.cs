using System;

namespace Sorting;

public static class QuickSort
{
    public static void Sort(int[] array)
    {
        SortInternal(array, 0..array.Length);
    }
    
    internal static void SortInternal(int[] array, Range range)
    {
        var span = array.AsSpan(range);
        if (span.Length <= 1) return;

        var partition = CalcPartition(array, range);
        SortInternal(array, partition.Left);
        SortInternal(array, partition.Right);
    }

    public static Partition CalcPartition(int[] sourceArray, Range range)
    {
        var array = sourceArray.AsSpan(range);
        
        int left = 0;
        int pivotIndex = array.Length - 1;
        
        for (int right = 0; right < pivotIndex; right++)
        {
            if (array[right] <= array[pivotIndex])
            {
                array.Swap(left, right);
                left++;
            }
        }
        
        array.Swap(left, pivotIndex);


        int pivotInSource = range.Start.Value + left;
        
        var leftRange = range.Start..pivotInSource;
        var rightRange = (pivotInSource + 1)..(range.End);
        
        return new Partition(leftRange, rightRange);
    }
    
    public struct Partition
    {
        public Partition(Range left, Range right)
        {
            Left = left;
            Right = right;
        }

        public Range Left { get; }
        public Range Right { get; }
    }
}