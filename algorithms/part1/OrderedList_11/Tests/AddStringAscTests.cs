using System;
using AlgorithmsDataStructures;
using Xunit;

namespace OrderedList_11.Tests
{
    public partial class OrderedListTests
    {
        [Fact]
        public void AddStringAsc_Empty_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(true);
            
            //Act
            list.Add("a");
            
            //Assert
            Assert.Equal(1, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, "a");
        }
        
        [Fact]
        public void AddStringAsc_TwoElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(true);
            
            //Act
            list.Add("a");
            list.Add("b");
            
            //Assert
            Assert.Equal(2, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, "a", "b");
        }
        
        [Fact]
        public void AddStringAsc_TwoElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(true);
            
            //Act
            list.Add("b");
            list.Add("a");
            
            //Assert
            Assert.Equal(2, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, "a", "b");
        }
        
        [Fact]
        public void AddStringAsc_ThreeElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(true);
            
            //Act
            list.Add("a");
            list.Add("b");
            list.Add("c");
            
            //Assert
            Assert.Equal(3, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, "a", "b", "c");
        }
        
        [Fact]
        public void AddStringAsc_ThreeElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(true);
            
            //Act
            list.Add("c");
            list.Add("b");
            list.Add("a");
            
            //Assert
            Assert.Equal(3, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, "a", "b", "c");
        }
        
        [Fact]
        public void AddStringAsc_FourElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(true);
            
            //Act
            list.Add("b");
            list.Add("a");
            list.Add("c");
            list.Add("d");
            
            //Assert
            Assert.Equal(4, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, "a", "b", "c", "d");
        }
        
        [Fact]
        public void AddStringAsc_FourElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(true);
            
            //Act
            list.Add("d");
            list.Add("c");
            list.Add("a");
            list.Add("b");
            
            //Assert
            Assert.Equal(4, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, "a", "b", "c", "d");
        }
        
        [Fact]
        public void AddStringAsc_FiveElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(true);
            
            //Act
            list.Add("b");
            list.Add("a");
            list.Add("e");
            list.Add("c");
            list.Add("d");

            //Assert
            Assert.Equal(5, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, "a", "b", "c", "d", "e");
        }
        
        [Fact]
        public void AddStringAsc_FiveElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(true);
            
            //Act
            list.Add("d");
            list.Add("c");
            list.Add("e");
            list.Add("a");
            list.Add("b");

            //Assert
            Assert.Equal(5, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, "a", "b", "c", "d", "e");
        }
    }
}