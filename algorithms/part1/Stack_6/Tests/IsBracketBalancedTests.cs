using Xunit;

namespace Stack_6.Tests
{
    public class IsBracketBalancedTests
    {
        [Fact]
        public void IsBrackedBalanced_EmptyStr_ShouldReturnFalse()
        {
            Assert.False("".IsBracketBalanced());
        }
        
        [Fact]
        public void IsBrackedBalanced_InvalidChars_ShouldReturnFalse()
        {
            Assert.False("1".IsBracketBalanced());
        }
        
        [Fact]
        public void IsBrackedBalanced_ValidStr_ShouldReturnTrue()
        {
            Assert.True("(()((())()))".IsBracketBalanced());
        }
        
        [Fact]
        public void IsBrackedBalanced_ValidStr2_ShouldReturnTrue()
        {
            Assert.True("(())".IsBracketBalanced());
        }
        
        [Fact]
        public void IsBrackedBalanced_ValidStr3_ShouldReturnTrue()
        {
            Assert.True("(((())))(())".IsBracketBalanced());
        }
        
        [Fact]
        public void IsBrackedBalanced_ValidStr4_ShouldReturnTrue()
        {
            Assert.True("(((())))(())(())".IsBracketBalanced());
        }
        
        [Fact]
        public void IsBrackedBalanced_NotBalancedStr1_ShouldReturnFalse()
        {
            Assert.False("(()()(()".IsBracketBalanced());
        }
        
        [Fact]
        public void IsBrackedBalanced_NotBalancedStr2_ShouldReturnFalse()
        {
            Assert.False("((())".IsBracketBalanced());
        }
        
        
        [Fact]
        public void IsBrackedBalanced_NotBalancedStr3_ShouldReturnFalse()
        {
            Assert.False("((())))))((((())))(((())".IsBracketBalanced());
        }
    }
}