using AlgorithmsDataStructures;
using Xunit;

namespace BloomFilter_15.Tests
{
    public class Bit32ArrayTests
    {
        [Fact]
        public void Get_NotSet_ShouldReturnFalse()
        {
            var arr = new Bit32Array();
            
            Assert.False(arr.Get(1));
        }
        
        [Fact]
        public void Set1_Get_ShouldReturnTrue()
        {
            var arr = new Bit32Array();
            arr.Set(1, true);
            Assert.True(arr.Get(1));
        }

        [Fact]
        public void Set_GetNotSetted_ShouldReturnFalse()
        {
            var arr = new Bit32Array();
            arr.Set(1, true);
            Assert.False(arr.Get(2));
        }
        
        [Fact]
        public void Set_Get32_ShouldReturnTrue()
        {
            var arr = new Bit32Array();
            arr.Set(32, true);
            Assert.True(arr.Get(32));
            for (int i = 1; i < 32; i++)
            {
                Assert.False(arr.Get(i));
            }
        }
        
        [Fact]
        public void Set_Get32_ShouldReturnFalse()
        {
            var arr = new Bit32Array();
            for (int i = 0; i < 32; i++)
            {
                Assert.False(arr.Get(i));
            }
        }
        
        [Fact]
        public void Set1To16_Get_ShouldReturnCorrect()
        {
            var arr = new Bit32Array();
            for (int i = 1; i < 16; i++)
            {
                arr.Set(i, true);
                Assert.True(arr.Get(i));
            }
            for (int i = 16; i < 32; i++)
            {
                Assert.False(arr.Get(i));
            }
        }
        
        [Fact]
        public void Set_CheckAllVariants_ShouldBeCorrect()
        {
            for (int i = 0; i < 32; i++)
            {
                var arr = new Bit32Array();
                arr.Set(i, true);
                Assert.True(arr.Get(i));
            }
        }
    }
}