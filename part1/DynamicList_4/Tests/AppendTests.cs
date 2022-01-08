using AlgorithmsDataStructures;
using Xunit;

namespace DynamicList_4.Tests
{
    public partial class DynArrayTests
    {
        [Fact]
        public void Append_EmptyArray_ShouldHaveElement()
        {
            //Arrange
            var array = new DynArray<int>();
            
            //Act
            array.Append(1);
            
            //Assert
            Assert.Equal(1, array.count);
            Assert.Equal(1, array.array[0]);
            Assert.Equal(DynArray.MinArraySize, array.capacity);
        }

        [Fact] 
        public void Append_OneMilionElementsEmptyArray_ShouldHaveElement()
        {
            //Arrange
            var array = new DynArray<int>();
            
            //Act
            for (int i = 0; i < 1000000; i++)
            {
                array.Append(i);    
            }
            
            
            //Assert
            Assert.Equal(1000000, array.count);
            for (int i = 0; i < 1000000; i++)
            {
                Assert.Equal(i, array.array[i]);
            }
            Assert.Equal(1048576, array.capacity);
        }
        
        [Fact]
        public void Append_NotEmptyArray_ShouldHaveElements()
        {
            //Arrange
            var array = new DynArray<int>();
            array.Append(1);
            
            //Act
            array.Append(2);
            
            //Assert
            Assert.Equal(2, array.count);
            Assert.Equal(1, array.array[0]);
            Assert.Equal(2, array.array[1]);
            Assert.Equal(DynArray.MinArraySize, array.capacity);
        }
        
        [Fact]
        public void Append_Add15Elements_ShouldHaveElements()
        {
            //Arrange
            var array = new DynArray<int>();

            
            //Act
            for (int i = 0; i < 15; i++)
            {
                array.Append(i+1);    
            }
            
            //Assert
            Assert.Equal(15, array.count);
            for (int i = 0; i < 15; i++)
            {
                Assert.Equal(i+1, array.array[i]);
            }
            Assert.Equal(DynArray.MinArraySize, array.capacity);
        }
        
        [Fact]
        public void Append_Add16Elements_ShouldHaveElementsAndCapacityIncreased()
        {
            //Arrange
            var array = new DynArray<int>();

            
            //Act
            for (int i = 0; i < 16; i++)
            {
                array.Append(i+1);    
            }
            
            //Assert
            Assert.Equal(16, array.count);
            for (int i = 0; i < 16; i++)
            {
                Assert.Equal(i+1, array.array[i]);
            }
            Assert.Equal(DynArray.MinArraySize, array.capacity);
        }
        
        [Fact]
        public void Append_Add17Elements_ShouldHaveElementsAndCapacityIncreased()
        {
            //Arrange
            var array = new DynArray<int>();

            
            //Act
            for (int i = 0; i < 17; i++)
            {
                array.Append(i+1);    
            }
            
            //Assert
            Assert.Equal(17, array.count);
            for (int i = 0; i < 17; i++)
            {
                Assert.Equal(i+1, array.array[i]);
            }
            Assert.Equal(DynArray.IncreasedCapacity(), array.capacity);
        }
        
        [Fact]
        public void Append_Add31Elements_ShouldHaveElementsAndCapacityIncreased()
        {
            //Arrange
            var array = new DynArray<int>();

            
            //Act
            for (int i = 0; i < 31; i++)
            {
                array.Append(i+1);    
            }
            
            //Assert
            Assert.Equal(31, array.count);
            for (int i = 0; i < 31; i++)
            {
                Assert.Equal(i+1, array.array[i]);
            }
            Assert.Equal(DynArray.IncreasedCapacity(), array.capacity);
        }
        
        [Fact]
        public void Append_Add32Elements_ShouldHaveElementsAndCapacityIncreased()
        {
            //Arrange
            var array = new DynArray<int>();

            
            //Act
            for (int i = 0; i < 32; i++)
            {
                array.Append(i+1);    
            }
            
            //Assert
            Assert.Equal(32, array.count);
            for (int i = 0; i < 32; i++)
            {
                Assert.Equal(i+1, array.array[i]);
            }
            Assert.Equal(DynArray.IncreasedCapacity(DynArray.MinArraySize), array.capacity);
        }
    }
}