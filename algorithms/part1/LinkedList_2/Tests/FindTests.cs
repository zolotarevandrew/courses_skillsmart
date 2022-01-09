using AlgorithmsDataStructures;
using Xunit;

namespace LinkedList_2.Tests
{
    public partial class LinkedListTests
    {
        [Fact] 
        public void Find_ListEmpty_ShouldReturnNull()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList2();
            
            //Act
            var foundNode = list.Find(15);
            
            //Assert
            Assert.Null(foundNode);
        }
        
        [Fact] 
        public void Find_ListNotEmptyNotExistingValue_ShouldReturnNull()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList2();
            
            list.AddInTail(new Node(15));
            list.AddInTail(new Node(16));
            list.AddInTail(new Node(17));
            list.AddInTail(new Node(18));
            //Act
            var foundNode = list.Find(21);
            
            //Assert
            Assert.Null(foundNode);
        }
        
        [Fact] 
        public void Find_ListNotEmptyExistingValue_ShouldReturnNode()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList2();
            
            list.AddInTail(new Node(15));
            list.AddInTail(new Node(16));
            list.AddInTail(new Node(17));
            list.AddInTail(new Node(18));
            
            //Act
            var searchingValue = 16;
            var foundNode = list.Find(searchingValue);
            
            //Assert
            Assert.NotNull(foundNode);
            Assert.Equal(searchingValue, foundNode.value);
        }
        
        [Fact] 
        public void Find_MillionElementsExistingValue_ShouldReturnNode()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList2();
            
            //Act
            for (int i = 1; i <= 1000000; i++)
            {
                list.AddInTail(new Node(i));
            }

            //Assert
            var searchingValue = 499999;
            var foundNode = list.Find(searchingValue);
            Assert.NotNull(foundNode);
            Assert.Equal(searchingValue, foundNode.value);
            
            searchingValue = 199999;
            foundNode = list.Find(searchingValue);
            Assert.NotNull(foundNode);
            Assert.Equal(searchingValue, foundNode.value);
        }
    }
}