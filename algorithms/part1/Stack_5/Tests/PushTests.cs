using Xunit;
using AlgorithmsDataStructures;

namespace Stack_5.Tests
{
    public partial class StackTests
    {
        [Fact]
        public void Push_StackEmpty_ShouldBeCorrectSize()
        {
            //Arrange
            var stack = new Stack<int>();
            
            //Act
            stack.Push(1);
            
            //Assert
            Assert.Equal(1, stack.Size());
        }
        
        [Fact]
        public void Push_StackNtEmpty_ShouldBeCorrectSize()
        {
            //Arrange
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            
            //Act
            stack.Push(1);
            
            //Assert
            Assert.Equal(3, stack.Size());
        }
    }
}