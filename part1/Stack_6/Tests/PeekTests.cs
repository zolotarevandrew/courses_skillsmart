using AlgorithmsDataStructures;
using Xunit;

namespace Stack_6.Tests
{
    public partial class StackTests
    {
        [Fact]
        public void Peek_StackEmpty_ShouldReturnDefault()
        {
            //Arrange
            var stack = new Stack<int>();
            
            //Act
            var res = stack.Peek();
            
            //Assert
            Assert.Equal(0, res);
        }
        
        [Fact]
        public void Peek_StackHasOneElement_ShouldReturnItem()
        {
            //Arrange
            var stack = new Stack<int>();
            stack.Push(1);
            
            //Act
            var res = stack.Peek();
            
            //Assert
            Assert.Equal(1, res);
            Assert.Equal(1, stack.Size());
        }
        
        [Fact]
        public void Peek_StackNotEmpty_ShouldReturnItem()
        {
            //Arrange
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            
            //Act
            
            var res = stack.Peek();
            Assert.Equal(4, res);
            Assert.Equal(4, stack.Size());
        }
    }
}