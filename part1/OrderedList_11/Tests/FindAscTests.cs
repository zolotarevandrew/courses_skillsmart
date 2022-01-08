using AlgorithmsDataStructures;
using Xunit;

namespace OrderedList_11.Tests
{
    public partial class OrderedListTests
    {
        [Fact]
        public void FindAsc_ListEmpty_ShouldBeCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            
            //Act
            var res = list.Find(15);
            
            //Assert
            Assert.Null(res);
        }
        
        [Fact]
        public void FindAsc_OneElement_ShouldBeCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            list.Add(15);
            
            //Act
            var res = list.Find(15);
            
            //Assert
            Assert.NotNull(res);
            Assert.Equal(15, res.value);
        }
        
        [Fact]
        public void FindAsc_TwoElements_ShouldBeCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            list.Add(15);
            list.Add(16);
            
            //Act
            var res = list.Find(15);
            
            //Assert
            Assert.NotNull(res);
            Assert.Equal(15, res.value);
        }
        
        [Fact]
        public void FindAsc_FourElementsNotExisting1_ShouldBeNull()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            list.Add(15);
            list.Add(1);
            list.Add(3);
            list.Add(2);
            
            //Act
            var res = list.Find(0);
            
            //Assert
            Assert.Null(res);
        }
        
        [Fact]
        public void FindAsc_FourElementsNotExisting2_ShouldBeNull()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            list.Add(15);
            list.Add(1);
            list.Add(3);
            list.Add(2);
            
            //Act
            var res = list.Find(5000);
            
            //Assert
            Assert.Null(res);
        }
        
        [Fact]
        public void FindAsc_FourElements_ShouldBeCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            list.Add(15);
            list.Add(1);
            list.Add(3);
            list.Add(2);
            
            //Act
            var res = list.Find(3);
            
            //Assert
            Assert.NotNull(res);
            Assert.Equal(3, res.value);
        }
        
        [Fact]
        public void FindAsc_FiveElements_ShouldBeCorrectData()
        {
            //Arrange
            var list = new OrderedList<int>(true);
            list.Add(15);
            list.Add(1);
            list.Add(3);
            list.Add(2);
            list.Add(280);
            
            //Act
            var res = list.Find(280);
            
            //Assert
            Assert.NotNull(res);
            Assert.Equal(280, res.value);
        }
    }
}