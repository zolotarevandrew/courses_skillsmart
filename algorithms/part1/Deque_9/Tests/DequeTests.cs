using AlgorithmsDataStructures;
using Xunit;

namespace Deque_9.Tests
{
    public class DequeTests
    {
        [Fact]
        public void Test()
        {
            int a = 0;
            if (a-- == -1)
            {
                
            }
        }
        [Fact]
        public void AddFront_Empty_ShouldHaveCorrectData()
        {
            //Arrange
            var deque = new Deque<int>();
            
            //Act
            //1
            deque.AddFront(1);
            
            //Assert
            Assert.Equal(1, deque.Size());
            Assert.Equal(1, deque.RemoveFront());
            Assert.Equal(0, deque.RemoveFront());
            Assert.Equal(0, deque.Size());
        }
        
        [Fact]
        public void AddFront_NotEmpty_ShouldHaveCorrectData()
        {
            //Arrange
            var deque = new Deque<int>();
            
            //Act
            // 4 3 2 1
            deque.AddFront(1);
            deque.AddFront(2);
            deque.AddFront(3);
            deque.AddFront(4);
            
            //Assert
            Assert.Equal(4, deque.Size());
            
            Assert.Equal(4, deque.RemoveFront());
            Assert.Equal(3, deque.Size());
            
            Assert.Equal(3, deque.RemoveFront());
            Assert.Equal(2, deque.Size());
            
            Assert.Equal(2, deque.RemoveFront());
            Assert.Equal(1, deque.Size());
            
            Assert.Equal(1, deque.RemoveFront());
            Assert.Equal(0, deque.Size());
            
            Assert.Equal(0, deque.RemoveFront());
            Assert.Equal(0, deque.Size());
        }
        
        [Fact]
        public void AddTail_Empty_ShouldHaveCorrectData()
        {
            //Arrange
            var deque = new Deque<int>();
            
            //Act
            //1
            deque.AddTail(1);
            
            //Assert
            Assert.Equal(1, deque.Size());
            Assert.Equal(1, deque.RemoveTail());
            Assert.Equal(0, deque.RemoveTail());
            Assert.Equal(0, deque.Size());
        }
        
        [Fact]
        public void AddTail_NotEmpty_ShouldHaveCorrectData()
        {
            //Arrange
            var deque = new Deque<int>();
            
            //Act
            //1 2 3 4
            deque.AddTail(1);
            deque.AddTail(2);
            deque.AddTail(3);
            deque.AddTail(4);
            
            //Assert
            Assert.Equal(4, deque.Size());
            
            Assert.Equal(4, deque.RemoveTail());
            Assert.Equal(3, deque.Size());
            
            Assert.Equal(3, deque.RemoveTail());
            Assert.Equal(2, deque.Size());
            
            Assert.Equal(2, deque.RemoveTail());
            Assert.Equal(1, deque.Size());
            
            Assert.Equal(1, deque.RemoveTail());
            Assert.Equal(0, deque.Size());
            
            Assert.Equal(0, deque.RemoveTail());
            Assert.Equal(0, deque.Size());
        }
        
        [Fact]
        public void AddTail_AddFront_ShouldHaveCorrectData()
        {
            //Arrange
            var deque = new Deque<int>();
            
            //Act
            //4 3 1 2
            deque.AddTail(1);
            deque.AddTail(2);
            deque.AddFront(3);
            deque.AddFront(4);
            
            //Assert
            Assert.Equal(4, deque.Size());
            
            Assert.Equal(2, deque.RemoveTail());
            Assert.Equal(3, deque.Size());
            
            Assert.Equal(1, deque.RemoveTail());
            Assert.Equal(2, deque.Size());
            
            Assert.Equal(3, deque.RemoveTail());
            Assert.Equal(1, deque.Size());
            
            Assert.Equal(4, deque.RemoveFront());
            Assert.Equal(0, deque.Size());
            
            Assert.Equal(0, deque.RemoveFront());
            Assert.Equal(0, deque.Size());
            
            Assert.Equal(0, deque.RemoveTail());
            Assert.Equal(0, deque.Size());
        }
        
        [Fact]
        public void RemoveTailFront_FiveElements_ShouldHaveCorrectData()
        {
            //Arrange
            
            var deque = new Deque<int>();
            
            //Act
            //5 4 3 1 2
            deque.AddTail(1);
            deque.AddTail(2);
            deque.AddFront(3);
            deque.AddFront(4);
            deque.AddFront(5);

            //Assert
            var item = deque.RemoveFront();
            Assert.Equal(4, deque.Size());
            Assert.Equal(5, item);
            
            item = deque.RemoveTail();
            Assert.Equal(3, deque.Size());
            Assert.Equal(2, item);
            
            item = deque.RemoveFront();
            Assert.Equal(2, deque.Size());
            Assert.Equal(4, item);
            
            item = deque.RemoveTail();
            Assert.Equal(1, deque.Size());
            Assert.Equal(1, item);
            
            item = deque.RemoveTail();
            Assert.Equal(0, deque.Size());
            Assert.Equal(3, item);
            
            item = deque.RemoveTail();
            Assert.Equal(0, deque.Size());
            Assert.Equal(0, item);
            
            item = deque.RemoveFront();
            Assert.Equal(0, deque.Size());
            Assert.Equal(0, item);

        }
        
        [Fact]
        public void RemoveFront_FiveElements_ShouldHaveCorrectData()
        {
            //Arrange
            
            var deque = new Deque<int>();
            
            //Act
            //5 4 3 1 2
            deque.AddTail(1);
            deque.AddTail(2);
            deque.AddFront(3);
            deque.AddFront(4);
            deque.AddFront(5);

            //Assert
            var item = deque.RemoveFront();
            Assert.Equal(4, deque.Size());
            Assert.Equal(5, item);
            
            item = deque.RemoveFront();
            Assert.Equal(3, deque.Size());
            Assert.Equal(4, item);
            
            item = deque.RemoveFront();
            Assert.Equal(2, deque.Size());
            Assert.Equal(3, item);
            
            item = deque.RemoveFront();
            Assert.Equal(1, deque.Size());
            Assert.Equal(1, item);
            
            item = deque.RemoveFront();
            Assert.Equal(0, deque.Size());
            Assert.Equal(2, item);
            
            item = deque.RemoveTail();
            Assert.Equal(0, deque.Size());
            Assert.Equal(0, item);
            
            item = deque.RemoveFront();
            Assert.Equal(0, deque.Size());
            Assert.Equal(0, item);
        }
        
        [Fact]
        public void RemoveFrontTail_SixElements_ShouldHaveCorrectData()
        {
            //Arrange
            
            var deque = new Deque<int>();
            
            //Act
            //5 4 3 1 2 6
            deque.AddTail(1);
            deque.AddTail(2);
            deque.AddFront(3);
            deque.AddFront(4);
            deque.AddFront(5);
            deque.AddTail(6);

            //Assert
            deque.RemoveFront();
            deque.RemoveTail();
            deque.RemoveTail();
            deque.RemoveTail();
            
            Assert.Equal(2, deque.Size());
            Assert.Equal(4, deque.RemoveFront());
            Assert.Equal(3, deque.RemoveFront());
            Assert.Equal(0, deque.RemoveFront());
            Assert.Equal(0, deque.RemoveTail());

        }
        
        [Fact]
        public void RemoveFrontTail_SevenElements_ShouldHaveCorrectData()
        {
            //Arrange
            
            var deque = new Deque<int>();
            
            //Act
            //11 5 4 3 1 2 6
            deque.AddTail(1);
            deque.AddTail(2);
            deque.AddFront(3);
            deque.AddFront(4);
            deque.AddFront(5);
            deque.AddTail(6);
            deque.AddFront(11);

            //Assert
            deque.RemoveTail();
            deque.RemoveFront();
            deque.RemoveTail();
            deque.RemoveFront();
            
            Assert.Equal(3, deque.Size());
            Assert.Equal(4, deque.RemoveFront());
            Assert.Equal(3, deque.RemoveFront());
            Assert.Equal(1, deque.RemoveTail());

            Assert.Equal(0, deque.RemoveTail());
            Assert.Equal(0, deque.RemoveFront());
        }
        
        [Fact]
        public void RemoveAll_SevenElementsAdd_ShouldHaveCorrectData()
        {
            //Arrange
            
            var deque = new Deque<int>();
            
            //Act
            //11 5 4 3 1 2 6
            deque.AddTail(1);
            deque.AddTail(2);
            deque.AddFront(3);
            deque.AddFront(4);
            deque.AddFront(5);
            deque.AddTail(6);
            deque.AddFront(11);

            //Assert
            deque.RemoveFront();
            deque.RemoveFront();
            deque.RemoveFront();
            deque.RemoveFront();
            deque.RemoveFront();
            deque.RemoveFront();

            Assert.Equal(1, deque.Size());
            deque.AddTail(5);
            //6 5
            
            Assert.Equal(6, deque.RemoveFront());
            Assert.Equal(1, deque.Size());
            deque.AddFront(1);
            deque.AddTail(2);
            //1 5 2
            
            Assert.Equal(2, deque.RemoveTail());
            Assert.Equal(2, deque.Size());
            
            //1 5
            Assert.Equal(5, deque.RemoveTail());
            Assert.Equal(1, deque.RemoveFront());
            
            Assert.Equal(0, deque.RemoveTail());
            Assert.Equal(0, deque.RemoveFront());
        }
    }
}

