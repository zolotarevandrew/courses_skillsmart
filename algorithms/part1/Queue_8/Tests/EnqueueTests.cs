using AlgorithmsDataStructures;
using Xunit;

namespace Queue_8.Tests
{
    public class QueueTests
    {
        [Fact]
        public void Enqueue_EmptyQueue_ShouldHaveCorrectSize()
        {
            //Arrange
            var queue = new Queue<int>();
            
            //Act
            queue.Enqueue(1);
            
            //Assert
            Assert.Equal(1, queue.Size());
        }
        
        [Fact]
        public void Enqueue_NotEmptyQueue_ShouldHaveCorrectSize()
        {
            //Arrange
            var queue = new Queue<int>();
            
            //Act
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);
            
            //Assert
            Assert.Equal(8, queue.Size());
        }
    }
}