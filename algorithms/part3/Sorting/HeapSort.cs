using System;

namespace Sorting;

public static class HeapSort
{
    public static void Sort(int[] array)
    {
        //building max heap
        for (int parentIdx = (array.Length / 2) - 1; parentIdx >= 0; parentIdx--)
        {
            Heapify(array, parentIdx);
        }

        for (int idx = array.Length - 1; idx > 0; idx--)
        {
            array.Swap(0, idx);

            var memory = array.AsMemory(0..idx);
            Heapify(memory, 0);
        }
    }
    
    public static void Heapify(Memory<int> array, int heapifyIdx)
    {
        int Max(int idx1, int idx2) => array.SafeGetByIndex(idx1) > array.SafeGetByIndex(idx2) ? idx1 : idx2;
        
        int maxElementIdx = Max(heapifyIdx, Max(heapifyIdx * 2 + 1, heapifyIdx * 2 + 2));
        if (maxElementIdx == heapifyIdx) return;
        
        array.Span.Swap(heapifyIdx, maxElementIdx);

        Heapify(array, maxElementIdx);
    }

}