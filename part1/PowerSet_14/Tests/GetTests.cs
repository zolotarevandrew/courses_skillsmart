using AlgorithmsDataStructures;
using Xunit;

namespace PowerSet_14.Tests
{
    public partial class PowerSetTests
    {
        [Fact]
        public void Get_EmptySet_ShouldReturnFalse()
        {
            //Arrange
            var set = new PowerSet<string>();
            
            //Act

            //Assert
            Assert.False(set.Get("2345"));
            Assert.Equal(0, set.Size());
        }
    }
}