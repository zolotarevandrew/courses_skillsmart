using AlgorithmsDataStructures;
using Xunit;

namespace LinkedList_1.Tests
{
    public partial class LinkedListTests
    {
        [Fact] 
        public void FindAll_ListEmpty_ShouldReturnNull()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList();
            
            //Act
            var foundNode = list.Find(15);
            
            //Assert
            Assert.Null(foundNode);
        }
        
        [Fact] 
        public void FindAll_ListNotEmptyNotExistingValue_ShouldReturnEmptyList()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList();
            
            list.AddInTail(new Node(15));
            list.AddInTail(new Node(16));
            list.AddInTail(new Node(17));
            list.AddInTail(new Node(18));
            //Act
            var foundNodes = list.FindAll(21);
            
            //Assert
            Assert.True(foundNodes.Count == 0);
        }
        
        [Fact] 
        public void FindAll_ListNotEmptyExistingValue_ShouldReturnList()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList();
            
            list.AddInTail(new Node(15));
            list.AddInTail(new Node(16));
            list.AddInTail(new Node(17));
            list.AddInTail(new Node(18));
            
            //Act
            var searchingValue = 16;
            var foundNodes = list.FindAll(searchingValue);
            
            //Assert
            Assert.True(foundNodes.Count == 1);

            foreach (var t in foundNodes)
            {
                Assert.Equal(searchingValue, t.value);
            }
        }
        
        [Fact] 
        public void FindAll_MillionElementsExistingValue_ShouldReturnList()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList();
            
            //Act
            for (int i = 1; i <= 1000000; i++)
            {
                list.AddInTail(new Node(i));
            }
            list.InsertAfter(null, new Node(499999));
            list.AddInTail(new Node(499999));
            list.InsertAfter(null, new Node(499999));
            list.AddInTail(new Node(499999));

            //Assert
            var searchingValue = 499999;
            var foundNodes = list.FindAll(searchingValue);
            Assert.True(foundNodes.Count == 5);

            foreach (var t in foundNodes)
            {
                Assert.Equal(searchingValue, t.value);
            }
        }
    }
}