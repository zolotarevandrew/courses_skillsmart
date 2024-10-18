using System;
using Xunit;

namespace Sorting.Tests
{
    public class QuickSortPartitionTests
    {
        [Fact]
        public void CalcPartition_TwoNumbers_ShouldBeOk()
        {
            int[] arr = new int[] { 1, 2 };

            var partition = QuickSort.CalcPartition(arr, 0..arr.Length);
            
            Assert.Equal(1, arr[0]);
            Assert.Equal(2, arr[1]);
            
            var leftSpan = arr.AsSpan(partition.Left);
            Assert.Equal(1, leftSpan.Length);
            Assert.Equal(1, leftSpan[0]);
            
            var rightSpan = arr.AsSpan(partition.Right);
            Assert.Equal(0, rightSpan.Length);
        }
        
        [Fact]
        public void CalcPartition_ThreeNumber_ShouldBeOk()
        {
            int[] arr = new int[] { 3, 1, 2 };

            var partition = QuickSort.CalcPartition(arr, 0..);
            
            Assert.Equal(1, arr[0]);
            Assert.Equal(2, arr[1]);
            Assert.Equal(3, arr[2]);
            
            var leftSpan = arr.AsSpan(partition.Left);
            Assert.Equal(1, leftSpan.Length);
            Assert.Equal(1, leftSpan[0]);
            
            var rightSpan = arr.AsSpan(partition.Right);
            Assert.Equal(1, rightSpan.Length);
            Assert.Equal(3, rightSpan[0]);
        }
        
        [Fact]
        public void CalcPartition_FourNumbers_ShouldBeOk()
        {
            int[] arr = new int[] { 1, 3, 4, 2 };

            var partition = QuickSort.CalcPartition(arr, 0..);
            
            Assert.Equal(1, arr[0]);
            Assert.Equal(2, arr[1]);
            Assert.Equal(4, arr[2]);
            Assert.Equal(3, arr[3]);
            
            var leftSpan = arr.AsSpan(partition.Left);
            Assert.Equal(1, leftSpan.Length);
            Assert.Equal(1, leftSpan[0]);
            
            var rightSpan = arr.AsSpan(partition.Right);
            Assert.Equal(2, rightSpan.Length);
            Assert.Equal(4, rightSpan[0]);
            Assert.Equal(3, rightSpan[1]);
        }
        
        [Fact]
        public void CalcPartition_FivesNumbersSorted_ShouldBeOk()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };

            var partition = QuickSort.CalcPartition(arr, 0..);
            
            Assert.Equal(1, arr[0]);
            Assert.Equal(2, arr[1]);
            Assert.Equal(3, arr[2]);
            Assert.Equal(4, arr[3]);
            Assert.Equal(5, arr[4]);
            
            var leftSpan = arr.AsSpan(partition.Left);
            Assert.Equal(4, leftSpan.Length);
            Assert.Equal(1, leftSpan[0]);
            Assert.Equal(2, leftSpan[1]);
            Assert.Equal(3, leftSpan[2]);
            Assert.Equal(4, leftSpan[3]);

            var rightSpan = arr.AsSpan(partition.Right);
            Assert.Equal(0, rightSpan.Length);
        }
        
        [Fact]
        public void CalcPartition_FivesNumbersUnsorted_ShouldBeOk()
        {
            int[] arr = new int[] { 5, 2, 1, 3, 4 };

            var partition = QuickSort.CalcPartition(arr, 0..);

            Assert.Equal(2, arr[0]);
            Assert.Equal(1, arr[1]);
            Assert.Equal(3, arr[2]);
            Assert.Equal(4, arr[3]);
            Assert.Equal(5, arr[4]);
            
            var leftSpan = arr.AsSpan(partition.Left);
            Assert.Equal(3, leftSpan.Length);
            Assert.Equal(2, leftSpan[0]);
            Assert.Equal(1, leftSpan[1]);
            Assert.Equal(3, leftSpan[2]);

            var rightSpan = arr.AsSpan(partition.Right);
            Assert.Equal(1, rightSpan.Length);
            Assert.Equal(5, rightSpan[0]);
        }
        
        [Fact]
        public void CalcPartition_SixNumbersUnsorted_ShouldBeOk()
        {
            int[] arr = new int[] { 5, 2, 6, 1, 3, 4 };

            var partition = QuickSort.CalcPartition(arr, 0..);

            Assert.Equal(2, arr[0]);
            Assert.Equal(1, arr[1]);
            Assert.Equal(3, arr[2]);
            Assert.Equal(4, arr[3]);
            Assert.Equal(6, arr[4]);
            Assert.Equal(5, arr[5]);
            
            var leftSpan = arr.AsSpan(partition.Left);
            Assert.Equal(3, leftSpan.Length);
            Assert.Equal(2, leftSpan[0]);
            Assert.Equal(1, leftSpan[1]);
            Assert.Equal(3, leftSpan[2]);

            var rightSpan = arr.AsSpan(partition.Right);
            Assert.Equal(2, rightSpan.Length);
            Assert.Equal(6, rightSpan[0]);
            Assert.Equal(5, rightSpan[1]);
        }
        
        [Fact]
        public void CalcPartition_SixNumbersUnsortedFirstThreeElements_ShouldBeOk()
        {
            int[] arr = new int[] { 5, 2, 6, 1, 3, 4 };
            
            var partition = QuickSort.CalcPartition(arr, 0..3);

            Assert.Equal(5, arr[0]);
            Assert.Equal(2, arr[1]);
            Assert.Equal(6, arr[2]);
            
            var leftSpan = arr.AsSpan(partition.Left);
            Assert.Equal(2, leftSpan.Length);
            Assert.Equal(5, leftSpan[0]);
            Assert.Equal(2, leftSpan[1]);

            var rightSpan = arr.AsSpan(partition.Right);
            Assert.Equal(0, rightSpan.Length);
        }
        
        [Fact]
        public void CalcPartition_SixNumbersUnsortedLastThreeElements_ShouldBeOk()
        {
            int[] arr = new int[] { 5, 2, 6, 1, 3, 4 };
            
            var partition = QuickSort.CalcPartition(arr, 3..6);

            Assert.Equal(1, arr[3]);
            Assert.Equal(3, arr[4]);
            Assert.Equal(4, arr[5]);
            
            var leftSpan = arr.AsSpan(partition.Left);
            Assert.Equal(2, leftSpan.Length);
            Assert.Equal(1, leftSpan[0]);
            Assert.Equal(3, leftSpan[1]);

            var rightSpan = arr.AsSpan(partition.Right);
            Assert.Equal(0, rightSpan.Length);
        }
        
    }
}