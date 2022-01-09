using System.Collections.Generic;
using AlgorithmsDataStructures;
using Xunit;

namespace PowerSet_14.Tests
{
    public partial class PowerSetTests
    {
        [Fact]
        public void Remove_Empty_ShouldReturnFalse()
        {
            //Arrange
            var set = new PowerSet<string>();

            //Assert
            Assert.False(set.Remove("125"));
            Assert.Equal(0, set.Size());
        }
        
        [Fact]
        public void Remove_NotEmpty_ShouldReturnTrue()
        {
            //Arrange
            var set = new PowerSet<string>();
            
            //Act
            string item = "125";
            set.Put(item);

            //Assert
            Assert.True(set.Remove(item));
            Assert.False(set.Get(item));
            Assert.Equal(0, set.Size());
        }
        
        [Fact]
        public void Remove_TwoElementsNotEmpty_ShouldReturnTrue()
        {
            //Arrange
            var set = new PowerSet<string>();
            
            //Act
            string item = "125";
            string item2 = "1254";
            set.Put(item);
            set.Put(item2);

            //Assert
            Assert.True(set.Remove(item));
            Assert.False(set.Get(item));
            Assert.Equal(1, set.Size());
            Assert.True(set.Get(item2));
        }
        
        [Fact]
        public void Remove_TenElementsNotEmpty_ShouldReturnTrue()
        {
            //Arrange
            var set = new PowerSet<string>();
            
            //Act
            for (int i = 0; i < 10; i++)
            {
                set.Put(i.ToString());    
            }

            //Assert
            Assert.True(set.Remove("1"));
            Assert.True(set.Remove("2"));
            Assert.True(set.Remove("3"));
            Assert.True(set.Remove("4"));
            Assert.True(set.Remove("9"));
            
            Assert.False(set.Get("1"));
            Assert.False(set.Get("2"));
            Assert.False(set.Get("3"));
            Assert.False(set.Get("4"));
            Assert.False(set.Get("9"));
            
            Assert.True(set.Get("0"));
            Assert.True(set.Get("5"));
            Assert.True(set.Get("6"));
            Assert.True(set.Get("7"));
            Assert.True(set.Get("8"));
            
            Assert.Equal(5, set.Size());
        }
        
        [Fact]
        public void Remove_TwentyThousandsElementsNotEmpty_ShouldReturnTrue()
        {
            //Arrange
            var set = new PowerSet<string>();
            
            //Act
            for (int i = 0; i < PowerSetConsts.MaxSize; i++)
            {
                set.Put(i.ToString());    
            }

            //Assert
            for (int i = 0; i < PowerSetConsts.MaxSize; i++)
            {
                Assert.True(set.Remove(i.ToString()));
                Assert.False(set.Get(i.ToString()));
            }
            
            Assert.Equal(0, set.Size());
        }
    }
}