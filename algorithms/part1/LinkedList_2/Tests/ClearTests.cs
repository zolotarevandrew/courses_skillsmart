using AlgorithmsDataStructures;
using Xunit;

namespace LinkedList_2.Tests
{
    public partial class LinkedListTests
    {
        [Fact] 
        public void Clear_ListEmpty_ShouldHaveNullHeadAndTail()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList2();

            //Act
            list.Clear();
            
            //Assert
            var head = list.head;
            Assert.Null(head);

            var tail = list.tail;
            Assert.Null(tail);
            Assert.Equal(0, list.count);
        }
        
        [Fact] 
        public void Clear_ListNotEmpty_ShouldHaveNullHeadAndTail()
        {
            //Arrange
            var list = new AlgorithmsDataStructures.LinkedList2();

            //Act
            list.AddInTail(new Node(15));
            list.AddInTail(new Node(16));
            list.AddInTail(new Node(17));
            list.AddInTail(new Node(18));
            list.Clear();
            
            //Assert
            var head = list.head;
            Assert.Null(head);

            var tail = list.tail;
            Assert.Null(tail);
            Assert.Equal(0, list.count);
        }
    }
}