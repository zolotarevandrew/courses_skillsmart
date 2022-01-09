using AlgorithmsDataStructures;
using Xunit;

namespace Queue_7.Tests
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
            
            //Assert
            Assert.Equal(3, queue.Size());
        }
    }
}