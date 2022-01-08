using System;
using AlgorithmsDataStructures;
using Xunit;

namespace BloomFilter_15.Tests
{
    public partial class BloomFilterTests
    {
        [Fact]
        public void Hash1_MillionValues_ShouldBeInRange0_32()
        {
            var filter = new BloomFilter(10);

            for (int i = 0; i < 1000000; i++)
            {
                var item = filter.Hash1(i.ToString());
                Assert.True(item is >= 0 and < 32);
            }
        }
        
        [Fact]
        public void Hash2_MillionValues_ShouldBeInRange0_32()
        {
            var filter = new BloomFilter(10);

            for (int i = 0; i < 1000000; i++)
            {
                var item = filter.Hash2(i.ToString());
                Assert.True(item is >= 0 and < 32);
            }
        }
    }
}