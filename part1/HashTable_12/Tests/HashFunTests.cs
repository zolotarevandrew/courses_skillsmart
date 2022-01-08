using AlgorithmsDataStructures;
using Xunit;

namespace HashTable_12.Tests
{
    public partial class HashTableTests
    {
        [Fact]
        public void HashFun_Size1_ShouldReturnIndex()
        {
            //Arrange
            var table = new HashTable(1, 1);

            //Act
            var idx = table.HashFun("12313123");
            
            //Assert
            Assert.True(idx <= table.size && idx >= 0);
        }
        
        [Fact]
        public void HashFun_Size2_ShouldReturnIndex()
        {
            //Arrange
            var table = new HashTable(2, 1);

            //Act
            var idx = table.HashFun("4141241");
            
            //Assert
            Assert.True(idx <= table.size && idx >= 0);
        }
        
        [Fact]
        public void HashFun_Size17_ShouldReturnIndex()
        {
            //Arrange
            var table = new HashTable(17, 3);

            //Act
            for (int i = 0; i < 10000; i++)
            {
                var idx = table.HashFun("4141241");
            
                //Assert
                Assert.False(idx < 0);
                Assert.True(idx <= table.size && idx >= 0);    
            }
        }
    }
}