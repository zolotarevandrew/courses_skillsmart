using System;
using System.Collections.Generic;
using AlgorithmsDataStructures;
using Xunit;

namespace DynamicList_4.Tests
{
    public partial class DynArrayTests
    {
        [Fact]
        public void MakeArray_CapacityBelowZero_ShouldThrowInvalidOperationException()
        {
            //Arrange
            var array = new DynArray<int>();

            //Act
            Assert.Throws<InvalidOperationException>( () => array.MakeArray(-1));

            //Assert
        }
        
        [Fact]
        public void MakeArray_Capacity1_ShouldBeCorrectCapacity()
        {
            //Arrange
            var array = new DynArray<int>();

            //Act
            array.MakeArray(1);

            //Assert
            Assert.Equal(1, array.capacity);
            Assert.Equal(1, array.array.Length);
        }
        
        [Fact]
        public void MakeArray_Capacity25_ShouldBeCorrectCapacity()
        {
            //Arrange
            var array = new DynArray<int>();

            //Act
            array.MakeArray(25);

            //Assert
            Assert.Equal(25, array.capacity);
            Assert.Equal(25, array.array.Length);
        }
        
        [Fact]
        public void MakeArray_HasOneElementCapacity25_ShouldBeCorrectCapacityAndArray()
        {
            //Arrange
            var array = new DynArray<int>();
            array.Append(1);

            //Act
            array.MakeArray(25);

            //Assert
            Assert.Equal(25, array.capacity);
            Assert.Equal(25, array.array.Length);
            Assert.Equal(1, array.array[0]);
        }
        
        [Fact]
        public void MakeArray_Has15ElementsCapacity16_ShouldBeCorrectCapacityAndArray()
        {
            //Arrange
            var array = new DynArray<int>();

            for (int i = 0; i < 15; i++)
            {
                array.Append(i+1);    
            }

            //Act
            array.MakeArray(DynArray.MinArraySize);

            //Assert
            Assert.Equal(DynArray.MinArraySize, array.capacity);
            Assert.Equal(DynArray.MinArraySize, array.array.Length);
            for (int i = 0; i < 15; i++)
            {
                Assert.Equal(i+1, array.array[i]);
            }
        }
        
        [Fact]
        public void MakeArray_Has15ElementsCapacity8_ShouldThrowException()
        {
            //Arrange
            var array = new DynArray<int>();

            for (int i = 0; i < 15; i++)
            {
                array.Append(i+1);    
            }

            //Act
            Assert.Throws<System.ArgumentException>(() => array.MakeArray(8));
            
        }
        
        [Fact]
        public void MakeArray_Has8ElementsCapacity8_ShouldNotThrowException()
        {
            //Arrange
            var array = new DynArray<int>();

            for (int i = 0; i < 8; i++)
            {
                array.Append(i+1);    
            }

            //Act
            array.MakeArray(8);
            
            //Assert
            Assert.Equal(8, array.capacity);
            Assert.Equal(8, array.array.Length);
            for (int i = 0; i < 8; i++)
            {
                Assert.Equal(i+1, array.array[i]);
            }
        }
    }
}