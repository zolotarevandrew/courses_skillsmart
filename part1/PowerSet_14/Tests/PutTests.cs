using AlgorithmsDataStructures;
using Xunit;

namespace PowerSet_14.Tests
{
    public partial class PowerSetTests
    {
        [Fact]
        public void Put_EmptySet_ShouldPut()
        {
            //Arrange
            var set = new PowerSet<string>();
            
            //Act
            set.Put("12345");
            
            //Assert
            Assert.True(set.Get("12345"));
            Assert.False(set.Get("2345"));
            Assert.Equal(1, set.Size());
        }
        
        [Fact]
        public void Put_NotEmptySet_ShouldPut()
        {
            //Arrange
            var set = new PowerSet<string>();
            
            //Act
            set.Put("12345");
            set.Put("123456");
            
            //Assert
            Assert.True(set.Get("12345"));
            Assert.True(set.Get("123456"));
            Assert.False(set.Get("1234"));
            Assert.Equal(2, set.Size());
        }
        
        [Fact]
        public void Put_ExistingValue_ShouldPut()
        {
            //Arrange
            var set = new PowerSet<string>();
            
            //Act
            set.Put("12345");
            set.Put("12345");
            set.Put("12345");
            set.Put("12345");
            set.Put("12345");
            set.Put("12345");
            set.Put("12345");
            
            //Assert
            Assert.True(set.Get("12345"));
            Assert.False(set.Get("1234"));
            Assert.Equal(1, set.Size());
        }
        
        [Fact]
        public void Put_TenElements_ShouldPut()
        {
            //Arrange
            var set = new PowerSet<string>();
            
            //Act
            for (int i = 0; i < 10; i++)
            {
                set.Put(i.ToString());
            }

            //Assert
            for (int i = 0; i < 10; i++)
            {
                Assert.True(set.Get(i.ToString()));
            }
            Assert.False(set.Get("150"));
            
            Assert.Equal(10, set.Size());
        }
        
        [Fact]
        public void Put_TwentyThousandsElements_ShouldPut()
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
                Assert.True(set.Get(i.ToString()));
            }
            Assert.False(set.Get("21150"));
            
            Assert.Equal(20000, set.Size());
        }
    }
}