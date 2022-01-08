using AlgorithmsDataStructures;
using Xunit;

namespace NativeDictionary_13.Tests
{
    public partial class NativeDictionaryTests
    {
        [Fact]
        public void Get_EmptySize1_ShouldReturnDefault()
        {
            //Arrange
            var table = new NativeDictionary<int>(1);

            //Act
            var key = "123";
            
            //Assert
            Assert.Equal(0, table.Get(key));
            Assert.False(table.IsKey(key));
        }
        
        [Fact]
        public void Get_NotEmptySize1_ShouldReturnKey()
        {
            //Arrange
            var table = new NativeDictionary<int>(1);

            //Act
            var key = "123";
            table.Put(key, 233);
            
            //Assert
            Assert.Equal(233, table.Get(key));
            Assert.True(table.IsKey(key));
        }
    }
}