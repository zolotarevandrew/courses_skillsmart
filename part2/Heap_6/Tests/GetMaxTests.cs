using AlgorithmsDataStructures2;
using Xunit;

namespace Heap_6.Tests
{
    public partial class HeapTests
    {
        [Fact]
        public void GetMax_Depth0_ShouldHasZeroElements()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { }, 0);
            heap.Add(1);
            
            //Arrange
            Assert.Equal(1, heap.GetMax());
            Assert.Equal(0, heap.Count);
            Assert.Equal(0, heap.HeapArray[0]);
        }
        
        [Fact]
        public void GetMax_Depth1TwoElements_ShouldHasOneElement()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { 1 }, 1);
            heap.Add(2);
            
            //Arrange
            Assert.Equal(2, heap.GetMax());
            Assert.Equal(1, heap.Count);
            Assert.Equal(1, heap.HeapArray[0]);
            Assert.Equal(0, heap.HeapArray[1]);
        }
        
        [Fact]
        public void GetMax_Depth1ThreeElements_ShouldHasTwoElements()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { 1 }, 1);
            heap.Add(2);
            heap.Add(3);
            
            //Arrange
            Assert.Equal(3, heap.GetMax());
            Assert.Equal(2, heap.Count);
            Assert.Equal(2, heap.HeapArray[0]);
            Assert.Equal(1, heap.HeapArray[1]);
        }
        
        [Fact]
        public void GetMax_Depth2SevenElements_ShouldHasSixElements()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { 1 }, 2);
            heap.Add(2);
            heap.Add(3);
            heap.Add(4);
            heap.Add(5);
            heap.Add(6);
            heap.Add(7);
            
            //Arrange
            Assert.Equal(7, heap.GetMax());
            Assert.Equal(6, heap.Count);
            Assert.Equal(6, heap.HeapArray[0]);
            Assert.Equal(4, heap.HeapArray[1]);
            Assert.Equal(5, heap.HeapArray[2]);
            Assert.Equal(1, heap.HeapArray[3]);
            Assert.Equal(3, heap.HeapArray[4]);
            Assert.Equal(2, heap.HeapArray[5]);
        }
        
        [Fact]
        public void GetMax_Depth2SevenElements_ShouldRemoveAllElements()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] { 1 }, 2);
            heap.Add(2);
            heap.Add(3);
            heap.Add(4);
            heap.Add(5);
            heap.Add(6);
            heap.Add(7);
            
            //Arrange
            Assert.Equal(7, heap.GetMax());
            Assert.Equal(6, heap.Count);
            
            Assert.Equal(6, heap.GetMax());
            Assert.Equal(5, heap.Count);
            
            Assert.Equal(5, heap.GetMax());
            Assert.Equal(4, heap.Count);
            
            Assert.Equal(4, heap.GetMax());
            Assert.Equal(3, heap.Count);
            
            Assert.Equal(3, heap.GetMax());
            Assert.Equal(2, heap.Count);
            
            Assert.Equal(2, heap.GetMax());
            Assert.Equal(1, heap.Count);
            
            Assert.Equal(1, heap.GetMax());
            Assert.Equal(0, heap.Count);
            
            Assert.Equal(-1, heap.GetMax());
            Assert.Equal(0, heap.Count);
        }
        
        [Fact]
        public void GetMax_Depth10SevenElements_ShouldRemoveAllElements()
        {
            //Arrange
            var heap = new Heap();

            //Act
            heap.MakeHeap(new int[] {  }, 10);
            for (int i = 0; i < 1023; i++)
            {
                heap.Add(i + 1);
            }

            //Arrange
            Assert.Equal(1023, heap.Count);
            
            for (int i = 1023; i > 0; i--)
            {
                Assert.Equal(i, heap.GetMax());
            }
            Assert.Equal(-1, heap.GetMax());
            Assert.Equal(0, heap.Count);
        }
    }
}