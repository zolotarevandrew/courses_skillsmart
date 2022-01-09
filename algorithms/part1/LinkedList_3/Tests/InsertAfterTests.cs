using Xunit;

namespace LinkedList_3.Tests
{
    public partial class LinkedListTests
    {
        [Fact]
        public void InsertAfter_ListEmpty_ShouldHaveCorrectTailAndHead()
        {
            //Arrange
            var list = new LinkedList3();

            //Act
            list.InsertAfter(null, new Node(15));

            //Assert
            var head = list.head;
            Assert.NotNull(head);
            Assert.Null(head.next);
            Assert.Null(head.prev);
            Assert.Equal(15, head.value);

            var tail = list.tail;
            Assert.NotNull(tail);
            Assert.Null(tail.next);
            Assert.Null(tail.prev);
            Assert.Equal(15, tail.value);
            
            Assert.Equal(1, list.count);
        }
        
        [Fact]
        public void InsertAfter_ListHasOneElement_ShouldHaveCorrectTailAndHead()
        {
            //Arrange
            var list = new LinkedList3();

            //Act
            list.InsertAfter(null, new Node(16));
            list.InsertAfter(list.head, new Node(15));

            //Assert
            var head = list.head;
            Assert.NotNull(head);
            Assert.NotNull(head.next);
            Assert.Null(head.prev);
            Assert.Equal(16, head.value);
            Assert.Equal(15, head.next.value);

            var tail = list.tail;
            Assert.NotNull(tail);
            Assert.Null(tail.next);
            Assert.Equal(15, tail.value);
            Assert.Equal(16, tail.prev.value);
            Assert.Null(tail.prev.prev);
            
            Assert.Equal(2, list.count);
        }
        
        [Fact]
        public void InsertAfter_InsertAfterHeadTwoElements_ShouldHaveCorrectTailAndHead()
        {
            //Arrange
            var list = new LinkedList3();

            //Act
            list.InsertAfter(null, new Node(16));
            list.InsertAfter(list.head, new Node(15));
            list.InsertAfter(list.head.next, new Node(17));

            //Assert
            var head = list.head;
            Assert.NotNull(head);
            Assert.NotNull(head.next);
            Assert.Null(head.prev);
            Assert.Equal(16, head.value);
            Assert.Equal(15, head.next.value);
            Assert.Equal(17, head.next.next.value);

            var tail = list.tail;
            Assert.NotNull(tail);
            Assert.Null(tail.next);
            Assert.Equal(17, tail.value);
            Assert.Equal(15, tail.prev.value);
            Assert.Equal(16, tail.prev.prev.value);
            Assert.Null(tail.prev.prev.prev);
            
            Assert.Equal(3, list.count);
        }
        
        [Fact]
        public void InsertAfter_InsertAfterAtHeadThreeElements_ShouldHaveCorrectTailAndHead()
        {
            //Arrange
            var list = new LinkedList3();

            //Act
            list.InsertAfter(null, new Node(16));
            list.InsertAfter(null, new Node(15));
            list.InsertAfter(null, new Node(17));
            list.InsertAfter(null, new Node(19));

            //Assert
            var head = list.head;
            Assert.NotNull(head);
            Assert.NotNull(head.next);
            Assert.Null(head.prev);
            Assert.Equal(19, head.value);
            Assert.Equal(17, head.next.value);
            Assert.Equal(15, head.next.next.value);
            Assert.Equal(16, head.next.next.next.value);

            var tail = list.tail;
            Assert.NotNull(tail);
            Assert.Null(tail.next);
            Assert.Equal(16, tail.value);
            Assert.Equal(15, tail.prev.value);
            Assert.Equal(17, tail.prev.prev.value);
            Assert.Equal(19, tail.prev.prev.prev.value);
            Assert.Null(tail.prev.prev.prev.prev);
            
            Assert.Equal(4, list.count);
        }
        
        [Fact]
        public void InsertAfter_InsertAfterHeadThreeElements_ShouldHaveCorrectTailAndHead()
        {
            //Arrange
            var list = new LinkedList3();

            //Act
            list.InsertAfter(list.head, new Node(16));
            list.InsertAfter(list.head, new Node(15));
            list.InsertAfter(list.head, new Node(17));
            list.InsertAfter(list.head, new Node(19));

            //Assert
            var head = list.head;
            Assert.NotNull(head);
            Assert.NotNull(head.next);
            Assert.Null(head.prev);
            Assert.Equal(16, head.value);
            Assert.Equal(19, head.next.value);
            Assert.Equal(17, head.next.next.value);
            Assert.Equal(15, head.next.next.next.value);

            var tail = list.tail;
            Assert.NotNull(tail);
            Assert.Null(tail.next);
            Assert.Equal(15, tail.value);
            Assert.Equal(17, tail.prev.value);
            Assert.Equal(19, tail.prev.prev.value);
            Assert.Equal(16, tail.prev.prev.prev.value);
            Assert.Null(tail.prev.prev.prev.prev);
            
            Assert.Equal(4, list.count);
        }
        
        [Fact]
        public void InsertAfter_InsertAfterTailTwoElements_ShouldHaveCorrectTailAndHead()
        {
            //Arrange
            var list = new LinkedList3();

            //Act
            list.InsertAfter(list.tail, new Node(16));
            list.InsertAfter(list.tail, new Node(15));
            list.InsertAfter(list.tail, new Node(18));

            //Assert
            var head = list.head;
            Assert.NotNull(head);
            Assert.NotNull(head.next);
            Assert.Equal(16, head.value);
            Assert.Equal(15, head.next.value);
            Assert.Equal(18, head.next.next.value);

            var tail = list.tail;
            Assert.NotNull(tail);
            Assert.Null(tail.next);
            Assert.Equal(18, tail.value);
            Assert.Equal(15, tail.prev.value);
            Assert.Equal(16, tail.prev.prev.value);
            Assert.Null(tail.prev.prev.prev);
            
            Assert.Equal(3, list.count);
        }
        
        [Fact]
        public void InsertAfter_InsertAfterTailThreeElements_ShouldHaveCorrectTailAndHead()
        {
            //Arrange
            var list = new LinkedList3();

            //Act
            list.InsertAfter(list.tail, new Node(16));
            list.InsertAfter(list.tail, new Node(15));
            list.InsertAfter(list.tail, new Node(17));
            list.InsertAfter(list.tail, new Node(19));

            //Assert
            var head = list.head;
            Assert.NotNull(head);
            Assert.NotNull(head.next);
            Assert.Null(head.prev);
            Assert.Equal(16, head.value);
            Assert.Equal(15, head.next.value);
            Assert.Equal(17, head.next.next.value);
            Assert.Equal(19, head.next.next.next.value);

            var tail = list.tail;
            Assert.NotNull(tail);
            Assert.Null(tail.next);
            Assert.Equal(19, tail.value);
            Assert.Equal(17, tail.prev.value);
            Assert.Equal(15, tail.prev.prev.value);
            Assert.Equal(16, tail.prev.prev.prev.value);
            Assert.Null(tail.prev.prev.prev.prev);
            
            Assert.Equal(4, list.count);
        }
        
        [Fact]
        public void InsertAfter_InsertСustomThreeElements_ShouldHaveCorrectTailAndHead()
        {
            //Arrange
            var list = new LinkedList3();

            //Act
            list.InsertAfter(null, new Node(16));
            list.InsertAfter(list.tail, new Node(15));
            list.InsertAfter(list.head.next, new Node(17));
            list.InsertAfter(null, new Node(19));

            //Assert
            var head = list.head;
            Assert.NotNull(head);
            Assert.NotNull(head.next);
            Assert.Null(head.prev);
            Assert.Equal(19, head.value);
            Assert.Equal(16, head.next.value);
            Assert.Equal(15, head.next.next.value);
            Assert.Equal(17, head.next.next.next.value);

            var tail = list.tail;
            Assert.NotNull(tail);
            Assert.Null(tail.next);
            Assert.Equal(17, tail.value);
            Assert.Equal(15, tail.prev.value);
            Assert.Equal(16, tail.prev.prev.value);
            Assert.Equal(19, tail.prev.prev.prev.value);
            Assert.Null(tail.prev.prev.prev.prev);
            
            Assert.Equal(4, list.count);
        }
    }
}