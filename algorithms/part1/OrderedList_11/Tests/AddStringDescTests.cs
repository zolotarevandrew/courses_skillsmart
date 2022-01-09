using System;
using AlgorithmsDataStructures;
using Xunit;

namespace OrderedList_11.Tests
{
    public partial class OrderedListTests
    {
        [Fact]
        public void AddStringDesc_Empty_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(false);
            
            //Act
            list.Add("a");
            
            //Assert
            Assert.Equal(1, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, "a");
        }
        
        [Fact]
        public void AddStringDesc_TwoElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(false);
            
            //Act
            list.Add("a");
            list.Add("b");
            
            //Assert
            Assert.Equal(2, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, "b", "a");
        }
        
        [Fact]
        public void AddStringDesc_TwoElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(false);
            
            //Act
            list.Add("b");
            list.Add("a");
            
            //Assert
            Assert.Equal(2, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, "b", "a");
        }
        
        [Fact]
        public void AddStringDesc_ThreeElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(false);
            
            //Act
            list.Add("a");
            list.Add("b");
            list.Add("c");
            
            //Assert
            Assert.Equal(3, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, "c", "b", "a");
        }
        
        [Fact]
        public void AddStringDesc_ThreeElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(false);
            
            //Act
            list.Add("c");
            list.Add("b");
            list.Add("a");
            
            //Assert
            Assert.Equal(3, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, "c", "b", "a");
        }
        
        [Fact]
        public void AddStringDesc_FourElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(false);
            
            //Act
            list.Add("b");
            list.Add("a");
            list.Add("c");
            list.Add("d");
            
            //Assert
            Assert.Equal(4, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, "d", "c", "b", "a");
        }
        
        [Fact]
        public void AddStringDesc_FourElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(false);
            
            //Act
            list.Add("d");
            list.Add("c");
            list.Add("a");
            list.Add("b");
            
            //Assert
            Assert.Equal(4, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, "d", "c", "b", "a");
        }
        
        [Fact]
        public void AddStringDesc_FiveElements_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(false);
            
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
            AssertList(list, "e", "d", "c", "b", "a");
        }
        
        [Fact]
        public void AddStringDesc_FiveElementsReverse_ShouldHaveCorrectData()
        {
            //Arrange
            var list = new OrderedList<string>(false);
            
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
            AssertList(list, "e", "d", "c", "b", "a");
        }
    }
}