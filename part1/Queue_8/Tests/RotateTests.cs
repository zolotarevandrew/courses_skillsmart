using System;
using AlgorithmsDataStructures;
using Xunit;

namespace Queue_8.Tests
{
    public class RotateTests
    {
        [Fact]
        public void Rotate_QueueEmptyRotateBy1_ShouldThrowException()
        {
            //Arrange
            var queue = new Queue<int>();

            //Act
            Assert.Throws<InvalidOperationException>( () => queue.Rotate(1));
        }
        
        [Fact]
        public void Rotate_QueueEmptyRotateBy0_ShouldThrowException()
        {
            //Arrange
            var queue = new Queue<int>();

            //Act
            Assert.Throws<InvalidOperationException>( () => queue.Rotate(0));
        }
        
        [Fact]
        public void Rotate_QueueEmptyRotateByMinus1_ShouldThrowException()
        {
            //Arrange
            var queue = new Queue<int>();

            //Act
            Assert.Throws<InvalidOperationException>( () => queue.Rotate(-1));
            
        }
        
        [Fact]
        public void Rotate_QueueHasOneElement1_ShouldBeCorrectQueue()
        {
            //Arrange
            var queue = new Queue<int>();
            queue.Enqueue(1);

            //Act
            queue.Rotate(1);
            
            //Assert
            Assert.Equal(1, queue.Size());
            Assert.Equal(1, queue.Dequeue());
        }
        
        [Fact]
        public void Rotate_QueueHasTwoElement1_ShouldBeCorrectQueue()
        {
            //Arrange
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            //Act
            queue.Rotate(1);
            
            //Assert
            Assert.Equal(2, queue.Size());
            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(1, queue.Dequeue());
        }
        
        [Fact]
        public void Rotate_QueueHasFourElement1_ShouldBeCorrectQueue()
        {
            //Arrange
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            //Act
            queue.Rotate(1);
            
            //Assert
            Assert.Equal(4, queue.Size());
            Assert.Equal(4, queue.Dequeue());
            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(3, queue.Dequeue());
        }
        
        [Fact]
        public void Rotate_QueueHasFourElement2_ShouldBeCorrectQueue()
        {
            //Arrange
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            //Act
            queue.Rotate(2);
            
            //Assert
            Assert.Equal(4, queue.Size());
            Assert.Equal(3, queue.Dequeue());
            Assert.Equal(4, queue.Dequeue());
            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(2, queue.Dequeue());
        }
        
        [Fact]
        public void Rotate_QueueHasFourElement3_ShouldBeCorrectQueue()
        {
            //Arrange
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            //Act
            queue.Rotate(3);
            
            //Assert
            Assert.Equal(4, queue.Size());
            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(3, queue.Dequeue());
            Assert.Equal(4, queue.Dequeue());
            Assert.Equal(1, queue.Dequeue());
        }
        
        [Fact]
        public void Rotate_QueueHasFourElement4_ShouldBeCorrectQueue()
        {
            //Arrange
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            //Act
            queue.Rotate(4);
            
            //Assert
            Assert.Equal(4, queue.Size());
            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(3, queue.Dequeue());
            Assert.Equal(4, queue.Dequeue());
        }
    }
}