using System.Collections.Generic;
using AlgorithmsDataStructures;
using Xunit;

namespace BloomFilter_15.Tests
{
    public partial class BloomFilterTests
    {
        [Fact]
        public void Get_NotAdded_ShouldReturnFalse()
        {
            var filter = new BloomFilter(10);

            Assert.False(filter.IsValue("0123456789"));
        }
        
        [Fact]
        public void Get_Added_ShouldReturnTrue()
        {
            //Arrange
            var filter = new BloomFilter(10);

            //Act
            var str = "0123456789";
            filter.Add(str);

            //Assert
            Assert.True(filter.IsValue(str));
        }
        
        [Fact]
        public void Get_AddedTenElements_ShouldReturnTrue()
        {
            //Arrange

            //Act
            var test = new List<string>
            {
                "0123456789",
                "1234567890",
                "2345678901",
                "3456789012",
                "4567890123",
                "5678901234",
                "6789012345",
                "7890123456",
                "8901234567",
                "9012345678"
            };
            
            var filter = new BloomFilter(10);
            for (int i = 0; i < test.Count; i++)
            {
                var str = test[i];
                filter.Add(str);
                
                for (int j = 0; j < i; j++)
                {
                    str = test[j];
                    Assert.True(filter.IsValue(str));
                }
            }
            
            for (int i = 0; i < test.Count; i++)
            {
                var str = test[i];
                var item = str[..^1];
                Assert.False(filter.IsValue(item));
            }
        }
    }
}