using AlgorithmsDataStructures;
using Xunit;

namespace OrderedList_11.Tests
{
    public partial class OrderedListTests
    {
        [Fact]
        public void RemoveAsc_ListEmpty_ShouldBeCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            
            //Act
            list.Delete(15);
            
            //Assert
            Assert.Equal(0, list.Count());
        }
        
        [Fact]
        public void RemoveAsc_OneElement_ShouldBeCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            list.Add(15);
            
            //Act
            list.Delete(15);
            
            //Assert
            Assert.Equal(0, list.Count());
            Assert.Null(list.head);
            Assert.Null(list.tail);
        }
        
        [Fact]
        public void RemoveAsc_TwoElements_ShouldBeCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            list.Add(15);
            list.Add(16);
            
            //Act
            list.Delete(15);
            
            //Assert
            Assert.Equal(1, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 16);
        }
        
        [Fact]
        public void RemoveAsc_FourElements_ShouldBeCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            list.Add(15);
            list.Add(1);
            list.Add(3);
            list.Add(2);
            
            //Act
            list.Delete(15);
            
            //Assert
            Assert.Equal(3, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 1, 2, 3);
        }
        
        [Fact]
        public void RemoveAsc_FiveElements_ShouldBeCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            list.Add(15);
            list.Add(1);
            list.Add(3);
            list.Add(2);
            list.Add(280);
            
            //Act
            list.Delete(280);
            
            //Assert
            Assert.Equal(4, list.Count());
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            AssertList(list, 1, 2, 3, 15);
        }
    }
}