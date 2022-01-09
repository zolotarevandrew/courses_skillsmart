using AlgorithmsDataStructures2;
using Xunit;

namespace Heap_6.Tests
{
    public partial class HeapTests
    {
        [Fact]
        public void AddKey_Depth0_ShouldHasOneElement()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { }, 0);
            heap.Add(1);
            
            //Arrange
            Assert.Equal(1, heap.Count);
            Assert.Equal(1, heap.HeapArray[0]);
        }
        
        [Fact]
        public void AddKey_Depth0_ShouldNotAdd()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { 1 }, 0);
            
            
            //Arrange
            Assert.False(heap.Add(2));
            Assert.Equal(1, heap.Count);
            Assert.Equal(1, heap.HeapArray[0]);
        }
        
        [Fact]
        public void AddKey_Depth1OneElementExists_ShouldAdd()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { 1 }, 1);

            //Arrange
            Assert.True(heap.Add(2));
            Assert.Equal(2, heap.Count);
            Assert.Equal(2, heap.HeapArray[0]);
            Assert.Equal(1, heap.HeapArray[1]);
            Assert.Equal(0, heap.HeapArray[2]);
        }
        
        [Fact]
        public void AddKey_Depth1ThreeElementsExists_ShouldNotAdd()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { 1, 2, 3 }, 1);

            //Arrange
            Assert.False(heap.Add(2));
            Assert.Equal(3, heap.Count);
            Assert.Equal(3, heap.HeapArray[0]);
            Assert.Equal(1, heap.HeapArray[1]);
            Assert.Equal(2, heap.HeapArray[2]);
        }
        
        [Fact]
        public void AddKey_Depth1Empty_ShouldAddAll()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { }, 1);
            

            //Arrange
            Assert.True(heap.Add(2));
            Assert.True(heap.Add(3));
            Assert.True(heap.Add(1));
            Assert.Equal(3, heap.Count);
            Assert.Equal(3, heap.HeapArray[0]);
            Assert.Equal(2, heap.HeapArray[1]);
            Assert.Equal(1, heap.HeapArray[2]);
        }
        
        [Fact]
        public void AddKey_Depth2ThreeElementsExists_ShouldAdd()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { 1, 2, 3 }, 2);

            //Arrange
            Assert.True(heap.Add(4));
            Assert.True(heap.Add(5));
            Assert.True(heap.Add(6));
            Assert.True(heap.Add(7));
            Assert.False(heap.Add(8));
            
            Assert.Equal(7, heap.Count);
            Assert.Equal(7, heap.HeapArray[0]);
            Assert.Equal(4, heap.HeapArray[1]);
            Assert.Equal(6, heap.HeapArray[2]);
            Assert.Equal(1, heap.HeapArray[3]);
            Assert.Equal(3, heap.HeapArray[4]);
            Assert.Equal(2, heap.HeapArray[5]);
            Assert.Equal(5, heap.HeapArray[6]);
        }
        
        [Fact]
        public void AddKey_Depth2SevenElements_ShouldAdd()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { }, 2);

            //Arrange
            Assert.True(heap.Add(1));
            Assert.True(heap.Add(2));
            Assert.True(heap.Add(3));
            Assert.True(heap.Add(4));
            Assert.True(heap.Add(5));
            Assert.True(heap.Add(6));
            Assert.True(heap.Add(7));
            Assert.False(heap.Add(8));
            
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