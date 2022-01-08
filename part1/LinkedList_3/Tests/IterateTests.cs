using System.Linq;
using Xunit;

namespace LinkedList_3.Tests
{
    public partial class LinkedListTests
    {
        [Fact] 
        public void Iterate_ListEmpty_ShouldReturnEmpty()
        {
            //Arrange
            var list = new LinkedList3();
            
            //Act
            var nodes = list.Iterate();
            
            //Assert
            Assert.True(!nodes.Any());
        }
        
        [Fact] 
        public void Iterate_ListHasOneElements_ShouldReturnOneElementList()
        {
            //Arrange
            var list = new LinkedList3();
            list.AddInTail(new Node(15));
            
            //Act
            var nodes = list.Iterate().ToList();
            
            //Assert
            Assert.True(nodes.Any());
            Assert.Equal(15, nodes[0].value);
        }
        
        [Fact] 
        public void Iterate_ListHasTwoElements_ShouldReturnTwoElementList()
        {
            //Arrange
            var list = new LinkedList3();
            list.AddInTail(new Node(15));
            list.AddInTail(new Node(16));
            
            //Act
            var nodes = list.Iterate().ToList();
            
            //Assert
            Assert.True(nodes.Any());
            Assert.Equal(15, nodes[0].value);
            Assert.Equal(16, nodes[1].value);
        }
        
        [Fact] 
        public void Iterate_ListHasFourElements_ShouldReturnFourElementList()
        {
            //Arrange
            var list = new LinkedList3();
            list.AddInTail(new Node(15));
            list.AddInTail(new Node(16));
            list.AddInTail(new Node(17));
            list.AddInTail(new Node(18));
            
            //Act
            var nodes = list.Iterate().ToList();
            
            //Assert
            Assert.True(nodes.Any());
            Assert.Equal(15, nodes[0].value);
            Assert.Equal(16, nodes[1].value);
            Assert.Equal(17, nodes[2].value);
            Assert.Equal(18, nodes[3].value);
        }
    }
}