using System;
using AlgorithmsDataStructures;
using Xunit;

namespace DynamicList_4.Tests
{
    public partial class DynArrayTests
    {

        [Fact]
        public void Remove_NotExistingIndexBelowZero_ShouldThrowException()
        {
            //Arrange
            var array = new DynArray<int>();
            
            //Act
            Assert.Throws<IndexOutOfRangeException>(() => array.Remove(-1));
        }
        
        [Fact]
        public void Remove_EmptyIndexZero_ShouldThrowException()
        {
            //Arrange
            var array = new DynArray<int>();
            
            //Act
            Assert.Throws<IndexOutOfRangeException>(() => array.Remove(0));
        }
        
        [Fact]
        public void Remove_EmptyIndexGreaterZero_ShouldThrowException()
        {
            //Arrange
            var array = new DynArray<int>();
            
            //Act
            Assert.Throws<IndexOutOfRangeException>(() => array.Remove(2));
        }
        
        
        [Fact]
        public void Remove_HasOneElementIndexZero_ShouldRemove()
        {
            //Arrange
            var array = new DynArray<int>();
            array.Append(1);
            
            //Act
            array.Remove(0);
            
            //Assert
            Assert.Equal(DynArray.MinArraySize,array.array.Length);
            Assert.Equal(DynArray.MinArraySize,array.capacity);
            Assert.Equal(0,array.count);
            Assert.Equal(default(int),array.array[0]);
        }
        
        [Fact]
        public void Remove_HasThreeElementIndexZero_ShouldRemove()
        {
            //Arrange
            var array = new DynArray<int>();
            array.Append(1);
            array.Append(2);
            array.Append(3);
            
            //Act
            array.Remove(0);
            
            //Assert
            Assert.Equal(DynArray.MinArraySize,array.array.Length);
            Assert.Equal(DynArray.MinArraySize,array.capacity);
            Assert.Equal(2,array.count);
            Assert.Equal(2,array.array[0]);
            Assert.Equal(3,array.array[1]);
        }
        
        [Fact]
        public void Remove_HasThreeElementIndex2_ShouldRemove()
        {
            //Arrange
            var array = new DynArray<int>();
            array.Append(1);
            array.Append(2);
            array.Append(3);
            
            //Act
            array.Remove(2);
            
            //Assert
            Assert.Equal(DynArray.MinArraySize,array.array.Length);
            Assert.Equal(DynArray.MinArraySize,array.capacity);
            Assert.Equal(2,array.count);
            Assert.Equal(1,array.array[0]);
            Assert.Equal(2,array.array[1]);
        }
        
        [Fact]
        public void Remove_HasThreeElementIndex1_ShouldRemove()
        {
            //Arrange
            var array = new DynArray<int>();
            array.Append(1);
            array.Append(2);
            array.Append(3);
            
            //Act
            array.Remove(1);
            
            //Assert
            Assert.Equal(DynArray.MinArraySize,array.array.Length);
            Assert.Equal(DynArray.MinArraySize,array.capacity);
            Assert.Equal(2,array.count);
            Assert.Equal(1,array.array[0]);
            Assert.Equal(3,array.array[1]);
        }
        
        [Fact]
        public void Remove_Has32ElementRemoveOne_ShouldBeCorrectCapacityAndOther()
        {
            //Arrange
            var array = new DynArray<int>();
            for (int i = 0; i < 32; i++)
            {
                array.Append(i + 1);
            }
            
            //Act
            array.Remove(0);
            
            //Assert
            Assert.Equal(32,array.array.Length);
            Assert.Equal(32,array.capacity);
            Assert.Equal(31,array.count);
            
            for (int i = 0; i < 31; i++)
            {
                Assert.Equal(i + 2,array.array[i]);
            }
        }
        
        [Fact]
        public void Remove_Has32ElementRemoveTen_ShouldBeCorrectCapacityAndOther()
        {
            //Arrange
            var array = new DynArray<int>();
            for (int i = 0; i < 32; i++)
            {
                array.Append(i + 1);
            }
            
            //Act
            for (int i = 0; i < 10; i++)
            {
                array.Remove(0);
            }
            
            //Assert
            Assert.Equal(32,array.array.Length);
            Assert.Equal(32,array.capacity);
            Assert.Equal(22,array.count);
            
            for (int i = 0; i < 21; i++)
            {
                Assert.Equal(i + 11,array.array[i]);
            }
        }
        
        [Fact]
        public void Remove_Has32ElementRemove15_ShouldBeCorrectCapacityAndOther()
        {
            //Arrange
            var array = new DynArray<int>();
            for (int i = 0; i < 32; i++)
            {
                array.Append(i + 1);
            }
            
            //Act
            for (int i = 0; i < 15; i++)
            {
                array.Remove(0);
            }
            
            //Assert
            Assert.Equal(32,array.array.Length);
            Assert.Equal(32,array.capacity);
            Assert.Equal(17,array.count);
            
            for (int i = 0; i < 17; i++)
            {
                Assert.Equal(i + 16,array.array[i]);
            }
        }
        
        [Fact]
        public void Remove_Has14ElementRemoveOne_ShouldBeCorrectCapacityAndOther()
        {
            //Arrange
            var array = new DynArray<int>();
            for (int i = 0; i < 14; i++)
            {
                array.Append(i + 1);
            }
            
            //Act
            array.Remove(0);
            
            //Assert
            Assert.Equal(16,array.array.Length);
            Assert.Equal(16,array.capacity);
            Assert.Equal(13,array.count);
            
            for (int i = 0; i < 13; i++)
            {
                Assert.Equal(i + 2,array.array[i]);
            }
        }
        
        [Fact]
        public void Remove_Has32ElementRemoveAll_ShouldBeCorrectCapacityAndOther()
        {
            //Arrange
            var array = new DynArray<int>();
            for (int i = 0; i < 32; i++)
            {
                array.Append(i + 1);
            }
            
            //Act
            for (int i = 0; i < 32; i++)
            {
                array.Remove(0);    
            }

            //Assert
            Assert.Equal(DynArray.MinArraySize,array.array.Length);
            Assert.Equal(DynArray.MinArraySize,array.capacity);
            Assert.Equal(0,array.count);
            
            for (int i = 0; i < DynArray.MinArraySize; i++)
            {
                Assert.Equal(0,array.array[i]);    
            }
        }
        
        [Fact]
        public void Remove_NotExistingIndexGreatedArrayLength_ShouldThrowException()
        {
            //Arrange
            var array = new DynArray<int>();
            
            //Act
            Assert.Throws<IndexOutOfRangeException>(() => array.Remove(array.capacity + 1));
        }
    }
}