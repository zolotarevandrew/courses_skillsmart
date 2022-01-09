using System;
using AlgorithmsDataStructures;
using Xunit;

namespace OrderedList_11.Tests
{
    public partial class OrderedListTests
    {
        [Fact]
        public void AddIntAsc_Empty_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            
            //Act
            list.Add(1);
            
            //Assert
            Assert.Equal(1, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 1);
        }
        
        [Fact]
        public void AddIntAsc_TwoElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            
            //Act
            list.Add(1);
            list.Add(2);
            
            //Assert
            Assert.Equal(2, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 1, 2);
        }
        
        [Fact]
        public void AddIntAsc_TwoElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            
            //Act
            list.Add(2);
            list.Add(1);
            
            //Assert
            Assert.Equal(2, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 1, 2);
        }
        
        [Fact]
        public void AddIntAsc_ThreeElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            
            //Act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            
            //Assert
            Assert.Equal(3, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 1, 2, 3);
        }
        
        [Fact]
        public void AddIntAsc_ThreeElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            
            //Act
            list.Add(3);
            list.Add(2);
            list.Add(1);
            
            //Assert
            Assert.Equal(3, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 1, 2, 3);
        }
        
        [Fact]
        public void AddIntAsc_FourElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            
            //Act
            list.Add(2);
            list.Add(1);
            list.Add(3);
            list.Add(4);
            
            //Assert
            Assert.Equal(4, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 1, 2, 3, 4);
        }
        
        [Fact]
        public void AddIntAsc_FourElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            
            //Act
            list.Add(4);
            list.Add(3);
            list.Add(1);
            list.Add(2);
            
            //Assert
            Assert.Equal(4, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 1, 2, 3, 4);
        }
        
        [Fact]
        public void AddIntAsc_FiveElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            
            //Act
            list.Add(2);
            list.Add(1);
            list.Add(5);
            list.Add(3);
            list.Add(4);

            //Assert
            Assert.Equal(5, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 1, 2, 3, 4, 5);
        }
        
        [Fact]
        public void AddIntAsc_FiveElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            
            //Act
            list.Add(4);
            list.Add(3);
            list.Add(5);
            list.Add(1);
            list.Add(2);

            //Assert
            Assert.Equal(5, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 1, 2, 3, 4, 5);
        }
        
        [Fact]
        public void AddIntAsc_SixElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            
            //Act
            list.Add(2);
            list.Add(1);
            list.Add(5);
            list.Add(3);
            list.Add(4);
            list.Add(0);

            //Assert
            Assert.Equal(6, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 0, 1, 2, 3, 4, 5);
        }
        
        [Fact]
        public void AddIntAsc_SixElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            
            //Act
            list.Add(0);
            list.Add(4);
            list.Add(3);
            list.Add(5);
            list.Add(1);
            list.Add(2);

            //Assert
            Assert.Equal(6, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 0, 1, 2, 3, 4, 5);
        }
        
        [Fact]
        public void AddIntAsc_SevenElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            
            //Act
            list.Add(2);
            list.Add(1);
            list.Add(5);
            list.Add(4);
            list.Add(0);
            list.Add(3);
            list.Add(111);

            //Assert
            Assert.Equal(7, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 0, 1, 2, 3, 4, 5, 111);
        }
        
        [Fact]
        public void AddIntAsc_SevenElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            
            //Act
            list.Add(111);
            list.Add(5);
            list.Add(4);
            list.Add(3);
            list.Add(2);
            list.Add(1);
            list.Add(0);

            //Assert
            Assert.Equal(7, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 0, 1, 2, 3, 4, 5, 111);
        }

        void AssertList<T>(OrderedList<T> list, params T[] array)
        {
            var all = list.GetAll();
            if (all.Count == 0) throw new InvalidOperationException("list is empty");

            int idx = 0;
            var start = all[idx];
            Assert.Equal(start.value, list.head.value);
            while(start != null)
            {
                Assert.Equal(start.value, array[idx]);
                start = start.next;
                idx++;
            }
            
            idx = list.Count() - 1;
            start = all[list.Count() - 1];
            Assert.Equal(start.value, list.tail.value);
            while(start != null)
            {
                Assert.Equal(start.value, array[idx]);
                start = start.prev;
                idx--;
            }
        }
    }
}