using AlgorithmsDataStructures2;
using Xunit;

namespace Heap_6.Tests
{
    public partial class HeapTests
    {
        [Fact]
        public void MakeHeap_Depth0_ShouldHasOneElement()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { 1 }, 0);
            
            //Arrange
            Assert.Equal(1, heap.Count);
            Assert.Equal(1, heap.HeapArray[0]);
        }
        
        [Fact]
        public void MakeHeap_Depth1_ShouldHasOneElement()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { 1 }, 1);
            
            //Arrange
            Assert.Equal(1, heap.Count);
            Assert.Equal(1, heap.HeapArray[0]);
            Assert.Equal(0, heap.HeapArray[1]);
            Assert.Equal(0, heap.HeapArray[2]);
        }
        
        [Fact]
        public void MakeHeap_Depth1_ShouldHasTwoElement()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { 1, 2 }, 1);
            
            //Arrange
            Assert.Equal(2, heap.Count);
            Assert.Equal(2, heap.HeapArray[0]);
            Assert.Equal(1, heap.HeapArray[1]);
            Assert.Equal(0, heap.HeapArray[2]);
        }
        
        [Fact]
        public void MakeHeap_Depth1_ShouldHasThreeElement()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { 1, 2, 3 }, 1);
            
            //Arrange
            Assert.Equal(3, heap.Count);
            Assert.Equal(3, heap.HeapArray[0]);
            Assert.Equal(1, heap.HeapArray[1]);
            Assert.Equal(2, heap.HeapArray[2]);
        }
        
        [Fact]
        public void MakeHeap_Depth2_ShouldHasThreeElement()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { 1, 2, 3 }, 1);
            
            //Arrange
            Assert.Equal(3, heap.Count);
            Assert.Equal(3, heap.HeapArray[0]);
            Assert.Equal(1, heap.HeapArray[1]);
            Assert.Equal(2, heap.HeapArray[2]);
        }
        
        [Fact]
        public void MakeHeap_Depth2_ShouldHasFiveElement()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { 1, 2, 3, 4, 5 }, 2);
            
            //Arrange
            Assert.Equal(5, heap.Count);
            Assert.Equal(5, heap.HeapArray[0]);
            Assert.Equal(4, heap.HeapArray[1]);
            Assert.Equal(2, heap.HeapArray[2]);
            Assert.Equal(1, heap.HeapArray[3]);
            Assert.Equal(3, heap.HeapArray[4]);
        }
        
        [Fact]
        public void MakeHeap_Depth2_ShouldHas7Element()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 2);
            
            //Arrange
            Assert.Equal(7, heap.Count);
            Assert.Equal(7, heap.HeapArray[0]);
            Assert.Equal(4, heap.HeapArray[1]);
            Assert.Equal(6, heap.HeapArray[2]);
            Assert.Equal(1, heap.HeapArray[3]);
            Assert.Equal(3, heap.HeapArray[4]);
            Assert.Equal(2, heap.HeapArray[5]);
            Assert.Equal(5, heap.HeapArray[6]);
        }
    }
}