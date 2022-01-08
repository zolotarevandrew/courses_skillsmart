using AlgorithmsDataStructures;
using Xunit;

namespace HashTable_12.Tests
{
    public partial class HashTableTests
    {

        [Fact]
        public void Put_EmptySize1_ShouldReturnIndex()
        {
            //Arrange
            var table = new HashTable(1, 1);

            //Act
            var str = "12313123";
            var idx = table.Put(str);
            
            //Assert
            Assert.True(idx <= table.size && idx >= 0);

            var item = table.Find(str);
            Assert.Equal(item, idx);
        }
        
        [Fact]
        public void Put_EmptySize2_ShouldReturnIndex()
        {
            //Arrange
            var table = new HashTable(2, 1);

            //Act
            var str = "12313123";
            var idx = table.Put(str);
            
            //Assert
            Assert.True(idx <= table.size && idx >= 0);

            var item = table.Find(str);
            Assert.Equal(item, idx);
        }
        
        [Fact]
        public void Put_FullSize2_ShouldReturnIndex()
        {
            //Arrange
            var table = new HashTable(2, 1);

            //Act
            var str = "12313123";
            var idx = table.Put(str);
            Assert.True(idx <= table.size && idx >= 0);
            var item = table.Find(str);
            Assert.Equal(item, idx);

            str = "12313123";
            var idx2 = table.Put(str);
            Assert.True(idx2 <= table.size && idx2 >= 0);
            var item2 = table.Find(str);
            Assert.Equal(item2, idx);
            
            var idx3 = table.Put(str);
            Assert.Equal(-1, idx3);
            
            var idx4 = table.Put(str);
            Assert.Equal(-1, idx4);
        }
    }
}