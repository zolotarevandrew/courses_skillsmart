using AlgorithmsDataStructures2;
using Xunit;

namespace ArrayBinarySearchTree_3.Tests
{
    public partial class ArrayBstTests
    {
        [Fact]
        public void TreeLength_Depth0_ShouldBe1()
        {
            Assert.Equal(1, new aBST(0).Tree.Length);
        }
        
        [Fact]
        public void TreeLength_Depth1_ShouldBe3()
        {
            Assert.Equal(3, new aBST(1).Tree.Length);
        }
        
        [Fact]
        public void TreeLength_Depth2_ShouldBe7()
        {
            Assert.Equal(7, new aBST(2).Tree.Length);
        }
        
        [Fact]
        public void TreeLength_Depth3_ShouldBe15()
        {
            Assert.Equal(15, new aBST(3).Tree.Length);
        }
        
        [Fact]
        public void TreeLength_Depth4_ShouldBe31()
        {
            Assert.Equal(31, new aBST(4).Tree.Length);
        }
    }
}