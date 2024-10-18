using Xunit;

namespace Sorting.Tests
{
    public class SelectionSortTests
    {
        [Fact]
        public void Sort_OneNumber_ShouldBeOk()
        {
            int[] arr = new int[] { 1 };

            SelectionSort.Sort(arr);
            
            Assert.Equal(1, arr[0]);
        }
        
        [Fact]
        public void Sort_TwoEqualNumbers_ShouldBeOk()
        {
            int[] arr = new int[] { 4, 4 };

            SelectionSort.Sort(arr);
            
            Assert.Equal(4, arr[0]);
            Assert.Equal(4, arr[1]);
        }
        
        [Fact]
        public void Sort_TwoNotEqualNumbersUnsorted_ShouldBeOk()
        {
            int[] arr = new int[] { 4, 1 };

            SelectionSort.Sort(arr);
            
            Assert.Equal(1, arr[0]);
            Assert.Equal(4, arr[1]);
        }
        
        [Fact]
        public void Sort_TwoNotEqualNumbersSorted_ShouldBeOk()
        {
            int[] arr = new int[] { 1, 4 };

            SelectionSort.Sort(arr);
            
            Assert.Equal(1, arr[0]);
            Assert.Equal(4, arr[1]);
        }
        
        [Fact]
        public void Sort_ThreeNotEqualNumbersSorted_ShouldBeOk()
        {
            int[] arr = new int[] { 1, 3, 4 };

            SelectionSort.Sort(arr);
            
            Assert.Equal(1, arr[0]);
            Assert.Equal(3, arr[1]);
            Assert.Equal(4, arr[2]);
        }
        
        [Fact]
        public void Sort_ThreeNotEqualNumbersUnsorted_ShouldBeOk()
        {
            int[] arr = new int[] { 4, 3, 1 };

            SelectionSort.Sort(arr);
            
            Assert.Equal(1, arr[0]);
            Assert.Equal(3, arr[1]);
            Assert.Equal(4, arr[2]);
        }
        
        [Fact]
        public void Sort_SixUnsortedNumbers_ShouldBeOk()
        {
            int[] arr = new int[] { 5, 1, 3, 4, 6, 2 };

            SelectionSort.Sort(arr);
            
            Assert.Equal(1, arr[0]);
            Assert.Equal(2, arr[1]);
            Assert.Equal(3, arr[2]);
            Assert.Equal(4, arr[3]);
            Assert.Equal(5, arr[4]);
            Assert.Equal(6, arr[5]);
        }
    }
}