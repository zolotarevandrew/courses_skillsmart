using System;
 
 namespace Sorting;
 
 public static class QuickSortWithMemory
 {
     public static void Sort(int[] array)
     {
         SortInternal(array.AsMemory(0..array.Length));
     }
     
     internal static void SortInternal(Memory<int> memory)
     {
         if (memory.Length <= 1) return;
 
         var partition = CalcPartition(memory);
         SortInternal(partition.Left);
         SortInternal(partition.Right);
     }
 
     public static Partition CalcPartition(Memory<int> memory)
     {
         var array = memory.Span;
         
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
         
         return new Partition(memory[..left], memory[(left + 1)..]);
     }
     
     public struct Partition
     {
         public Partition(Memory<int> left, Memory<int> right)
         {
             Left = left;
             Right = right;
         }
 
         public Memory<int> Left { get; }
         public Memory<int> Right { get; }
     }
 }