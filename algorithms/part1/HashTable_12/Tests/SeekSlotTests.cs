using AlgorithmsDataStructures;
using Xunit;

namespace HashTable_12.Tests
{
    public partial class HashTableTests
    {
        [Fact]
        public void SeekSlot_EmptySize1_ShouldReturnIndex()
        {
            //Arrange
            var table = new HashTable(1, 1);

            //Act
            var idx = table.SeekSlot("12313123");
            
            //Assert
            Assert.True(idx <= table.size && idx >= 0);
        }
        
        [Fact]
        public void SeekSlot_EmptySize2_ShouldReturnIndex()
        {
            //Arrange
            var table = new HashTable(2, 1);

            //Act
            var idx = table.SeekSlot("12313123");
            
            //Assert
            Assert.True(idx <= table.size && idx >= 0);
        }
        
        [Fact]
        public void SeekSlot_EmptySize3_ShouldReturnIndex()
        {
            //Arrange
            var table = new HashTable(3, 1);

            //Act
            var idx = table.SeekSlot("12313123");
            
            //Assert
            Assert.True(idx <= table.size && idx >= 0);
        }
    }
}