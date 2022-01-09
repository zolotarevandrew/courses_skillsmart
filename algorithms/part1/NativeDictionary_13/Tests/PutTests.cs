using AlgorithmsDataStructures;
using Xunit;

namespace NativeDictionary_13.Tests
{
    public partial class NativeDictionaryTests
    {
        [Fact]
        public void Put_EmptySize1_ShouldGet()
        {
            //Arrange
            var table = new NativeDictionary<int>(1);

            //Act
            var key = "123";
            table.Put(key, 1);
            
            //Assert
            Assert.Equal(1, table.Get(key));
            Assert.True(table.IsKey(key));
        }
        
        [Fact]
        public void Put_EmptySize1Override_ShouldGet()
        {
            //Arrange
            var table = new NativeDictionary<int>(1);

            //Act
            var key = "123";
            table.Put(key, 1);
            
            //Assert
            Assert.Equal(1, table.Get(key));
            Assert.True(table.IsKey(key));
            
            table.Put(key, 12);
            
            //Assert
            Assert.Equal(12, table.Get(key));
            Assert.True(table.IsKey(key));
        }
        
        [Fact]
        public void Put_EmptySize2_ShouldGet()
        {
            //Arrange
            var table = new NativeDictionary<int>(2);

            //Act
            var key = "123";
            table.Put(key, 1);
            
            var key2 = "1234";
            table.Put(key2, 12);
            
            //Assert
            Assert.Equal(1, table.Get(key));
            Assert.Equal(12, table.Get(key2));
            Assert.True(table.IsKey(key));
            Assert.True(table.IsKey(key2));
        }
        
        [Fact]
        public void Put_EmptySize20_ShouldGet()
        {
            //Arrange
            var table = new NativeDictionary<int>(20);

            //Act
            for (int idx = 0; idx < 20; idx++)
            {
                var key = idx.ToString() + "23";
                var value = idx + 1;
                table.Put(key, idx + 1);

                //Assert
                Assert.True(table.IsKey(key));
                Assert.Equal(value, table.Get(key));
            }
            
            Assert.False(table.IsKey("2551"));
            Assert.Equal(0, table.Get("2551"));
        }
    }
}