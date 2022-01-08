using System;
using AlgorithmsDataStructures;
using Xunit;

namespace DynamicList_4.Tests
{
    public partial class DynArrayTests
    {
        [Fact]
        public void GetItem_ArrayEmpty_ShouldThrowException()
        {
            //Arrange
            var array = new DynArray<int>();
            
            //Act
            Assert.Throws<IndexOutOfRangeException>(() => array.GetItem(0));

            //Assert
        }
        
        [Fact]
        public void GetItem_HasOneElementInvalidIndex_ShouldThrowException()
        {
            //Arrange
            var array = new DynArray<int>();
            array.Append(1);
            
            //Act
            Assert.Throws<IndexOutOfRangeException>(() => array.GetItem(1));

            //Assert
        }
        
        [Fact]
        public void GetItem_HasOneElementValidIndex_ShouldReturnElement()
        {
            //Arrange
            var array = new DynArray<int>();
            array.Append(1);
            
            //Act
            var item = array.GetItem(0);

            //Assert
            Assert.Equal(item, 1);
        }
        
        [Fact]
        public void GetItem_HasFourElementValidIndex_ShouldReturnElement()
        {
            //Arrange
            var array = new DynArray<int>();
            array.Append(1);
            array.Insert(2, 0);
            array.Append(3);
            array.Insert(4, 1);
            
            //Act
            Assert.Equal(4, array.count);
            
            var item = array.GetItem(0);
            Assert.Equal(item, 2);
            
            item = array.GetItem(1);
            Assert.Equal(item, 4);
            
            item = array.GetItem(2);
            Assert.Equal(item, 1);
            
            item = array.GetItem(3);
            Assert.Equal(item, 3);
        }
    }
}