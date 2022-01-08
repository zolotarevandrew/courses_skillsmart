using AlgorithmsDataStructures;
using Xunit;

namespace Stack_6.Tests
{
    public partial class StackTests
    {
        [Fact]
        public void Pop_StackEmpty_ShouldReturnDefault()
        {
            //Arrange
            var stack = new Stack<int>();
            
            //Act
            var res = stack.Pop();
            
            //Assert
            Assert.Equal(0, res);
        }
        
        [Fact]
        public void Pop_StackHasOneElement_ShouldReturnItem()
        {
            //Arrange
            var stack = new Stack<int>();
            stack.Push(1);
            
            //Act
            var res = stack.Pop();
            
            //Assert
            Assert.Equal(1, res);
            Assert.Equal(0, stack.Size());
        }
        
        [Fact]
        public void Pop_StackNotEmpty_ShouldReturnItem()
        {
            //Arrange
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            
            //Act
            
            var res = stack.Pop();
            Assert.Equal(4, res);
            Assert.Equal(3, stack.Size());
            
            res = stack.Pop();
            Assert.Equal(3, res);
            Assert.Equal(2, stack.Size());
            
            res = stack.Pop();
            Assert.Equal(2, res);
            Assert.Equal(1, stack.Size());
            
            res = stack.Pop();
            Assert.Equal(1, res);
            Assert.Equal(0, stack.Size());
            
            res = stack.Pop();
            Assert.Equal(0, res);
            Assert.Equal(0, stack.Size());
        }
    }
}