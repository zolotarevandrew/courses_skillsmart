using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NativeCache_16.Tests
{
    public class NativeCacheTests
    {
        [Fact]
        public void HashIdx_ShouldBeInRange()
        {
            var cache = new NativeCache<int>(5000);
            
            for (int i = 0; i < 10000000; i++)
            {
                var idx = cache.HashIdx(i.ToString());
                Assert.True(idx >= 0 && idx <= cache.size);
            }
        }
    }
}