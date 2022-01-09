using AlgorithmsDataStructures;
using Xunit;

namespace Queue_7.Tests
{
    public class DequeueTests
    {
        [Fact]
        public void Dequeue_EmptyQueue_ShouldReturnDefault()
        {
            //Arrange
            var queue = new Queue<int>();
            
            //Act
            var res = queue.Dequeue();
            
            //Assert
            Assert.Equal(0, queue.Size());
            Assert.Equal(0, res);
        }
        
        [Fact]
        public void Dequeue_NotEmptyQueue_ShouldHaveCorrectSizeAndElement()
        {
            //Arrange
            var queue = new Queue<int>();
            
            //Act
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            var res = queue.Dequeue();
            
            //Assert
            Assert.Equal(2, queue.Size());
            Assert.Equal(1, res);
        }
        
        [Fact]
        public void Dequeue_NotEmptyQueue1_ShouldHaveCorrectSizeAndElement()
        {
            //Arrange
            var queue = new Queue<int>();
            
            //Act
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            var res = queue.Dequeue();
            Assert.Equal(2, queue.Size());
            Assert.Equal(1, res);
            
            res = queue.Dequeue();
            Assert.Equal(1, queue.Size());
            Assert.Equal(2, res);
            
            res = queue.Dequeue();
            Assert.Equal(0, queue.Size());
            Assert.Equal(3, res);
            
            res = queue.Dequeue();
            Assert.Equal(0, queue.Size());
            Assert.Equal(0, res);
        }
    }
}