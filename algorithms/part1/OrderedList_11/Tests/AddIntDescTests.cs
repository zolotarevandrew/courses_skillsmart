using System;
using AlgorithmsDataStructures;
using Xunit;

namespace OrderedList_11.Tests
{
    public partial class OrderedListTests
    {
        [Fact]
        public void AddIntDesc_Empty_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(false);
            
            //Act
            list.Add(1);
            
            //Assert
            Assert.Equal(1, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 1);
        }
        
        [Fact]
        public void AddIntDesc_TwoElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(false);
            
            //Act
            list.Add(1);
            list.Add(2);
            
            //Assert
            Assert.Equal(2, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 2, 1);
        }
        
        [Fact]
        public void AddIntDesc_TwoElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(false);
            
            //Act
            list.Add(2);
            list.Add(1);
            
            //Assert
            Assert.Equal(2, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 2, 1);
        }
        
        [Fact]
        public void AddIntDesc_ThreeElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(false);
            
            //Act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            
            //Assert
            Assert.Equal(3, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 3, 2, 1);
        }
        
        [Fact]
        public void AddIntDesc_ThreeElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(false);
            
            //Act
            list.Add(3);
            list.Add(2);
            list.Add(1);
            
            //Assert
            Assert.Equal(3, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 3, 2, 1);
        }
        
        [Fact]
        public void AddIntDesc_FourElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(false);
            
            //Act
            list.Add(2);
            list.Add(1);
            list.Add(3);
            list.Add(4);
            
            //Assert
            Assert.Equal(4, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 4, 3, 2, 1);
        }
        
        [Fact]
        public void AddIntDesc_FourElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(false);
            
            //Act
            list.Add(4);
            list.Add(3);
            list.Add(1);
            list.Add(2);
            
            //Assert
            Assert.Equal(4, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 4, 3, 2, 1);
        }
        
        [Fact]
        public void AddIntDesc_FiveElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(false);
            
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
            AssertList(list, 5, 4, 3, 2, 1);
        }
        
        [Fact]
        public void AddIntDesc_FiveElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(false);
            
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
            AssertList(list, 5, 4, 3, 2, 1);
        }
        
        [Fact]
        public void AddIntDesc_SixElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(false);
            
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
            AssertList(list, 5, 4, 3, 2, 1, 0);
        }
        
        [Fact]
        public void AddIntDesc_SixElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(false);
            
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
            AssertList(list, 5, 4, 3, 2, 1, 0);
        }
        
        [Fact]
        public void AddIntDesc_SevenElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(false);
            
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
            AssertList(list, 111, 5, 4, 3, 2, 1, 0);
        }
        
        [Fact]
        public void AddIntDesc_SevenElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(false);
            
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
            AssertList(list, 111, 5, 4, 3, 2, 1, 0);
        }
    }
}