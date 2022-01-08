using System;
using System.Collections.Generic;
using AlgorithmsDataStructures;
using Xunit;

namespace DynamicList_4.Tests
{
    public partial class DynArrayTests
    {
        [Fact]
        public void Insert_ArrayEmptyToArrayLength_ShouldAppend()
        {
            //Arrange
            var array = new DynArray<int>();
            
            //Act
            array.Insert(1, array.count);
            
            //Assert
            Assert.Equal(1, array.count);
            Assert.Equal(1, array.array[0]);
            Assert.Equal(DynArray.MinArraySize, array.array.Length);
            Assert.Equal(DynArray.MinArraySize, array.capacity);
        }
        
        [Fact]
        public void Insert_NoElementsAtStart_ShouldHaveCorrectArray()
        {
            //Arrange
            var array = new DynArray<int>();
            
            //Act
            array.Insert(1, 0);
            
            //Assert
            Assert.Equal(1, array.count);
            Assert.Equal(1, array.array[0]);
            Assert.Equal(DynArray.MinArraySize, array.array.Length);
            Assert.Equal(DynArray.MinArraySize, array.capacity);
        }
        
        [Fact]
        public void Insert_HasThreeElementsAtStart_ShouldHaveCorrectArray()
        {
            //Arrange
            var array = new DynArray<int>();
            array.Append(1);
            array.Append(2);
            array.Append(3);
            
            //Act
            array.Insert(11, 0);
            
            //Assert
            Assert.Equal(4, array.count);
            Assert.Equal(11, array.array[0]);
            Assert.Equal(1, array.array[1]);
            Assert.Equal(2, array.array[2]);
            Assert.Equal(3, array.array[3]);
            Assert.Equal(DynArray.MinArraySize, array.array.Length);
            Assert.Equal(DynArray.MinArraySize, array.capacity);
        }
        
        [Fact]
        public void Insert_HasThreeElementsAtMiddle_ShouldHaveCorrectArray()
        {
            //Arrange
            var array = new DynArray<int>();
            array.Append(1);
            array.Append(2);
            array.Append(3);
            
            //Act
            array.Insert(11, 1);
            
            //Assert
            Assert.Equal(4, array.count);
            Assert.Equal(1, array.array[0]);
            Assert.Equal(11, array.array[1]);
            Assert.Equal(2, array.array[2]);
            Assert.Equal(3, array.array[3]);
            Assert.Equal(DynArray.MinArraySize, array.array.Length);
            Assert.Equal(DynArray.MinArraySize, array.capacity);
        }
        
        [Fact]
        public void Insert_HasThreeElementsAtLastElement_ShouldHaveCorrectArray()
        {
            //Arrange
            var array = new DynArray<int>();
            array.Append(1);
            array.Append(2);
            array.Append(3);
            
            //Act
            array.Insert(11, 2);
            
            //Assert
            Assert.Equal(4, array.count);
            Assert.Equal(1, array.array[0]);
            Assert.Equal(2, array.array[1]);
            Assert.Equal(11, array.array[2]);
            Assert.Equal(3, array.array[3]);
            Assert.Equal(DynArray.MinArraySize, array.array.Length);
            Assert.Equal(DynArray.MinArraySize, array.capacity);
        }
        
        [Fact]
        public void Insert_HasThreeElementsAtEnd_ShouldHaveCorrectArray()
        {
            //Arrange
            var array = new DynArray<int>();
            array.Append(1);
            array.Append(2);
            array.Append(3);
            
            //Act
            array.Insert(11, array.count);
            
            //Assert
            Assert.Equal(4, array.count);
            Assert.Equal(1, array.array[0]);
            Assert.Equal(2, array.array[1]);
            Assert.Equal(3, array.array[2]);
            Assert.Equal(11, array.array[3]);
            Assert.Equal(DynArray.MinArraySize, array.array.Length);
            Assert.Equal(DynArray.MinArraySize, array.capacity);
        }
        
        [Fact]
        public void Insert_HasThreeElementsAtEnd_ShouldThrowException()
        {
            //Arrange
            var array = new DynArray<int>();
            array.Append(1);
            array.Append(2);
            array.Append(3);
            
            //Act
            Assert.Throws<IndexOutOfRangeException>(() => array.Insert(11, array.count + 1));
        }
        
        [Fact] 
        public void Insert_OneMilionElementsEmptyArray_ShouldHaveElement()
        {
            //Arrange
            var array = new DynArray<int>();
            
            //Act
            for (int i = 0; i < 1000; i++)
            {
                array.Insert(i, 0);    
            }
            
            //Assert
            Assert.Equal(1000, array.count);
        }

        [Fact]
        public void Insert_Has15ElementsAtSecondElement_ShouldHaveCorrectArrayAndIncreasedCapacity()
        {
            //Arrange
            var array = new DynArray<int>();
            for (int i = 0; i < 15; i++)
            {
                array.Append(i+1);
            }
            
            //Act
            array.Insert(11, 2);
            
            //Assert
            Assert.Equal(16, array.count);
            Assert.Equal(1, array.array[0]);
            Assert.Equal(2, array.array[1]);
            Assert.Equal(11, array.array[2]);
            Assert.Equal(3, array.array[3]);
            Assert.Equal(4, array.array[4]);
            Assert.Equal(5, array.array[5]);
            Assert.Equal(6, array.array[6]);
            Assert.Equal(7, array.array[7]);
            Assert.Equal(8, array.array[8]);
            Assert.Equal(9, array.array[9]);
            Assert.Equal(10, array.array[10]);
            Assert.Equal(11, array.array[11]);
            Assert.Equal(12, array.array[12]);
            Assert.Equal(13, array.array[13]);
            Assert.Equal(14, array.array[14]);
            Assert.Equal(15, array.array[15]);
            Assert.Equal(DynArray.MinArraySize, array.array.Length);
            Assert.Equal(DynArray.MinArraySize, array.capacity);
        }
        
        [Fact]
        public void Insert_NotExistingIndexBelowZero_ShouldThrowException()
        {
            //Arrange
            var array = new DynArray<int>();
            
            //Act
            Assert.Throws<IndexOutOfRangeException>(() => array.Insert(1, -1));
        }

        [Fact]
        public void Insert_NotExistingIndexGreatedArrayLength_ShouldThrowException()
        {
            //Arrange
            var array = new DynArray<int>();
            
            //Act
            Assert.Throws<IndexOutOfRangeException>(() => array.Insert(1, array.count + 1));
        }
    }
}