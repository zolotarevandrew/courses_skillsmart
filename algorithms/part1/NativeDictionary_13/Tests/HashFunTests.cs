using System.Collections.Generic;
using AlgorithmsDataStructures;
using Xunit;

namespace NativeDictionary_13.Tests
{
    public partial class NativeDictionaryTests
    {
        [Fact]
        public void HashFun_Size1_ShouldReturnIndex()
        {
            //Arrange
            var table = new NativeDictionary<int>(1);
            var dict = new Dictionary<string, string>();

            //Act
            var idx = table.HashFun("12313123");
            
            //Assert
            Assert.True(idx <= table.size && idx >= 0);
        }
        
        [Fact]
        public void HashFun_Size2_ShouldReturnIndex()
        {
            //Arrange
            var table = new NativeDictionary<int>(2);

            //Act
            var idx = table.HashFun("4141241");
            
            //Assert
            Assert.True(idx <= table.size && idx >= 0);
        }
        
        [Fact]
        public void HashFun_Size17_ShouldReturnIndex()
        {
            //Arrange
            var table = new NativeDictionary<int>(17);

            //Act
            for (int i = 0; i < 10000; i++)
            {
                var idx = table.HashFun(i.ToString());
            
                //Assert
                Assert.False(idx < 0);
                Assert.True(idx <= table.size && idx >= 0);    
            }
        }
    }
}