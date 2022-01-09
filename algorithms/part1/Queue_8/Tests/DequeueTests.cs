using AlgorithmsDataStructures;
using Xunit;

namespace Queue_8.Tests
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
        
        [Fact]
        public void Dequeue_NotEmptyQueueAndEnqueue_ShouldHaveCorrectSizeAndElement()
        {
            //Arrange
            var queue = new Queue<int>();
            
            //Act
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            
            var elem = queue.Dequeue();
            Assert.Equal(2, queue.Size());
            Assert.Equal(1, elem);
            
            elem = queue.Dequeue();
            Assert.Equal(1, queue.Size());
            Assert.Equal(2, elem);

            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);
            queue.Enqueue(9);
            queue.Enqueue(10);
            
            Assert.Equal(6, queue.Size());
            
            elem = queue.Dequeue();
            Assert.Equal(5, queue.Size());
            Assert.Equal(3, elem);
            
            elem = queue.Dequeue();
            Assert.Equal(4, queue.Size());
            Assert.Equal(6, elem);
            
            elem = queue.Dequeue();
            Assert.Equal(3, queue.Size());
            Assert.Equal(7, elem);

            elem = queue.Dequeue();
            Assert.Equal(2, queue.Size());
            Assert.Equal(8, elem);
            
            elem = queue.Dequeue();
            Assert.Equal(1, queue.Size());
            Assert.Equal(9, elem);
            
            elem = queue.Dequeue();
            Assert.Equal(0, queue.Size());
            Assert.Equal(10, elem);
            
            elem = queue.Dequeue();
            Assert.Equal(0, queue.Size());
            Assert.Equal(0, elem);
        }
    }
}