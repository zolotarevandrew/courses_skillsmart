using AlgorithmsDataStructures;
using Xunit;

namespace Deque_10.Tests
{
    public class IsPalindromeTests
    {
        [Fact]
        public void IsPalindrome_EmptyString_ShouldReturnFalse()
        {
            //Assert
            Assert.False("".IsPalindrome());
        }
        
        [Fact]
        public void IsPalindrome_OneSymbString_ShouldReturnTrue()
        {
            //Assert
            Assert.True("1".IsPalindrome());
        }
        
        [Fact]
        public void IsPalindrome_TwoSymbString_ShouldReturnTrue()
        {
            //Assert
            Assert.True("11".IsPalindrome());
        }
        
        [Fact]
        public void IsPalindrome_TwoSymbString_ShouldReturnFalse()
        {
            //Assert
            Assert.False("12".IsPalindrome());
        }
        
        [Fact]
        public void IsPalindrome_ThreeSymbString_ShouldReturnTrue()
        {
            //Assert
            Assert.True("121".IsPalindrome());
        }
        
        [Fact]
        public void IsPalindrome_ThreeSymbString_ShouldReturnFalse()
        {
            //Assert
            Assert.False("122".IsPalindrome());
        }
        
        [Fact]
        public void IsPalindrome_FourSymbString_ShouldReturnTrue()
        {
            //Assert
            Assert.True("1221".IsPalindrome());
        }
        
        [Fact]
        public void IsPalindrome_FourSymbString_ShouldReturnFalse()
        {
            //Assert
            Assert.False("1251".IsPalindrome());
        }
        
        [Fact]
        public void IsPalindrome_FiveSymbString_ShouldReturnTrue()
        {
            //Assert
            Assert.True("12321".IsPalindrome());
        }
        
        [Fact]
        public void IsPalindrome_FiveSymbString_ShouldReturnFalse()
        {
            //Assert
            Assert.False("12361".IsPalindrome());
        }
        
        [Fact]
        public void IsPalindrome_AzorString_ShouldReturnTrue()
        {
            //Assert
            Assert.True("арозаупаланалапуазора".IsPalindrome());
        }
        
        [Fact]
        public void IsPalindrome_InvalidAzorString_ShouldReturnFalse()
        {
            //Assert
            Assert.False("арозаупаланалапуазор".IsPalindrome());
        }
    }
}

