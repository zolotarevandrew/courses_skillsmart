using Xunit;

namespace NativeCache_16.Tests
{
    public class SetTests
    {
        [Fact]
        public void Set_AllElementsSameHash_ShouldBeFull()
        {
            //Arrange
            var cache = new NativeCache<int>(5000);
            cache.hashFun = (s) => 1;
            
            //Act
            for (int i = 0; i < cache.size; i++)
            {
                cache.Set(i.ToString(), i);
            }
            
            for (int i = 0; i < cache.size; i++)
            {
                Assert.Equal(i, cache.Get(i.ToString()));
                Assert.Equal(i, cache.Get(i.ToString()));
                Assert.Equal(i, cache.Get(i.ToString()));
            }
            for (int i = 0; i < cache.size; i++)
            {
                Assert.Equal(3, cache.hits[i]);
            }
        }
        
        [Fact]
        public void Set_AllElementsDifferentHash_ShouldBeFull()
        {
            //Arrange
            var cache = new NativeCache<int>(100);

            //Act
            for (int i = 0; i < cache.size; i++)
            {
                cache.Set(i.ToString(), i);
            }
            
            for (int i = 0; i < cache.size; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Assert.Equal(i, cache.Get(i.ToString()));    
                }
            }
            cache.Set("232", 5);
            
            Assert.Equal(5, cache.Get("232"));
        }
        
        [Fact]
        public void Set_AllElementsAddMoreThanSize_ShouldRemoveByMinHits()
        {
            //Arrange
            var cache = new NativeCache<int>(100);
            cache.hashFun = (s) => 1;
            
            //Act
            for (int i = 0; i < cache.size; i++)
            {
                cache.Set(i.ToString(), i);
            }
            
            for (int i = 0; i < cache.size; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Assert.Equal(i, cache.Get(i.ToString()));    
                }
            }
            cache.Set("232", 5);
            
            Assert.Equal(0, cache.hits[1]);
            Assert.Equal("232", cache.slots[1]);
            Assert.Equal(5, cache.values[1]);
            
        }
    }
}