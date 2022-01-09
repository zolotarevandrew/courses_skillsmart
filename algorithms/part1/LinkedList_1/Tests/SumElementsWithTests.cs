using AlgorithmsDataStructures;
using Xunit;

namespace LinkedList_1.Tests
{
    public partial class LinkedListTests
    {
        [Fact]
        public void SumElementsWith_EmptyLists_ShouldReturnEmptyList()
        {
            //Arrange
            var list1 = new AlgorithmsDataStructures.LinkedList();
            
            //Act
            var result = list1.SumElementsWith(new AlgorithmsDataStructures.LinkedList());
            
            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.count);
        }
        
        [Fact]
        public void SumElementsWith_NotEqualByLengthLists_ShouldReturnNull()
        {
            //Arrange
            var list1 = new AlgorithmsDataStructures.LinkedList();
            list1.AddInTail(new Node(1));
            
            //Act
            var result = list1.SumElementsWith(new AlgorithmsDataStructures.LinkedList());
            
            //Assert
            Assert.Null(result);
        }
        
        [Fact]
        public void SumElementsWith_EqualByLengthLists_OneElement_ShouldReturnCorrectNewList()
        {
            //Arrange
            var list1 = new AlgorithmsDataStructures.LinkedList();
            list1.AddInTail(new Node(1));
            
            var list2 = new AlgorithmsDataStructures.LinkedList();
            list2.AddInTail(new Node(2));
            
            //Act
            var result = list1.SumElementsWith(list2);
            
            //Assert
            Assert.NotNull(result);
            Assert.Equal(list1.count, result.count);
            Assert.Equal(list2.count, result.count);
            
            Assert.Equal(3, result.head.value);
            Assert.Equal(null, result.head.next);
            Assert.Equal(null, result.tail.next);
        }
        
        [Fact]
        public void SumElementsWith_EqualByLengthLists_MillionElements_ShouldReturnCorrectNewList()
        {
            //Arrange
            var list1 = new AlgorithmsDataStructures.LinkedList();
            var list2 = new AlgorithmsDataStructures.LinkedList();

            for (int i = 1; i <= 1000000; i++)
            {
                list1.AddInTail(new Node(i));
                list2.AddInTail(new Node(i));
            }

            //Act
            var result = list1.SumElementsWith(list2);
            
            //Assert
            Assert.NotNull(result);
            Assert.Equal(list1.count, result.count);
            Assert.Equal(list2.count, result.count);

            var all = result.GetAll();
            for (int i = 0; i < 1000000; i++)
            {
                var item = all[i];
                Assert.Equal((i + 1) *2 , item.value);
            }
        }
    }
}