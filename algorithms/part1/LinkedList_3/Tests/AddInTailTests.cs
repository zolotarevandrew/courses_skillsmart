using Xunit;

namespace LinkedList_3.Tests
{
    public partial class LinkedListTests
    {
        [Fact] 
        public void ListEmpty_ShouldHaveNullHeadAndTail()
        {
            //Arrange
            var list = new LinkedList3();

            //Assert
            var head = list.head;
            Assert.Null(head);

            var tail = list.tail;
            Assert.Null(tail);
            Assert.Equal(0, list.count);
        }
        
        [Fact] 
        public void AddInTail_ListEmpty_ShouldHaveHeadAndTail()
        {
            //Arrange
            var list = new LinkedList3();

            var insertNode = new Node(15);
            
            //Act
            list.AddInTail(insertNode);
            
            //Assert
            var head = list.head;
            Assert.NotNull(head);
            Assert.Null(head.next);
            Assert.Equal(insertNode.value, head.value);

            var tail = list.tail;
            Assert.NotNull(tail);
            Assert.Null(tail.next);
            Assert.Equal(insertNode.value, tail.value);
            
            Assert.Equal(1, list.count);
        }
        
        [Fact]
        public void AddInTail_ListNotEmpty_ShouldHaveCorrectHeadAndTail()
        {
            //Arrange
            var list = new LinkedList3();

            var node1 = new Node(15);
            var node2 = new Node(16);
            var node3 = new Node(17);
            var node4 = new Node(18);
            var node5 = new Node(19);
            var node6 = new Node(20);
            var node7 = new Node(21);
            
            //Act
            list.AddInTail(node1);
            list.AddInTail(node2);
            list.AddInTail(node3);
            list.AddInTail(node4);
            list.AddInTail(node5);
            list.AddInTail(node6);
            list.AddInTail(node7);

            //Assert
            var head = list.head;
            Assert.NotNull(head);
            Assert.NotNull(head.next);
            Assert.Equal(node1.value, head.value);
            Assert.Equal(node2.value, head.next.value);

            var tail = list.tail;
            Assert.NotNull(tail);
            Assert.Null(tail.next);
            Assert.Equal(node7.value, tail.value);
            
            Assert.Equal(7, list.count);
        }
        
        [Fact]
        public void AddInTail_MillionElements_ShouldHaveCorrectHeadAndTail()
        {
            //Arrange
            var list = new LinkedList3();
            
            //Act
            for (int i = 1; i <= 1000000; i++)
            {
                list.AddInTail(new Node(i));
            }

            //Assert
            var head = list.head;
            Assert.NotNull(head);
            Assert.NotNull(head.next);
            Assert.Equal(1, head.value);
            Assert.Equal(2, head.next.value);
            
            list.AddInTail(new Node(1000001));

            var tail = list.tail;
            Assert.NotNull(tail);
            Assert.Null(tail.next);
            Assert.Equal(1000001, tail.value);
            
            Assert.Equal(1000001, list.count);
        }
    }
}