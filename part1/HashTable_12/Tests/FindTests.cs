using System.Collections.Generic;
using AlgorithmsDataStructures;
using Xunit;

namespace HashTable_12.Tests
{
    public partial class HashTableTests
    {
        [Fact]
        public void Find_EmptySize1_ShouldReturnNotFound()
        {
            //Arrange
            var table = new HashTable(1, 1);

            //Act
            var str = "12313123";
            var idx = table.Find(str);
            
            //Assert
            Assert.Equal(-1, idx);
        }
        
        [Fact]
        public void Find_NotEmptySize1_ShouldReturnNotFound()
        {
            //Arrange
            var table = new HashTable(1, 1);

            //Act
            var str = "12313123";
            table.Put(str);
            var idx = table.Find("1");
            
            //Assert
            Assert.Equal(-1, idx);
        }
        
        [Fact]
        public void Find_NotEmptySize17_ShouldReturnNotFound()
        {
            //Arrange
            var table = new HashTable(17, 13);

            //Act
            var str = "12313123";
            for (int i = 0; i < 17; i++)
            {
                table.Put(str);
            }

            var idx = table.Find("1");
            
            //Assert
            Assert.Equal(-1, idx);
        }
        
        [Fact]
        public void Find_NotEmptySize17_ShouldReturnIndex()
        {
            //Arrange
            var table = new HashTable(17, 13);

            //Act
            var str = "12313123";
            for (int i = 0; i < 17; i++)
            {
                table.Put(str);
            }
            
            
            var idx = table.Find(str);
            
            //Assert
            Assert.True(idx >=0 && idx< table.size);
        }
        
        [Fact]
        public void Find_DifferentStringsNotEmptySize17_ShouldReturnIndex()
        {
            //Arrange
            var table = new HashTable(17, 13);

            //Act
            var lst = new List<string>
            {

            };
            for (int i = 0; i < 17; i++)
            {
                var str = i.ToString() + i.ToString();
                var addIdx = table.Put(str);
                if (addIdx == -1) continue;
                lst.Add(str);
            }

            foreach (var item in lst)
            {
                var idx = table.Find(item);
                //Assert
                Assert.True(idx >=0 && idx< table.size);
            }
        }
    }
}