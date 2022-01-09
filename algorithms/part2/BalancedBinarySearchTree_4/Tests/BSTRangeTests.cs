using AlgorithmsDataStructures2;
using Xunit;

namespace BalancedBinarySearchTree_4.Tests
{
    public class BSTRangeTests
    {
        [Fact]
        public void BSTRange_0_7_ShouldBeCorrect()
        {
            var range = new BalancedBST.BSTRange(0, 7);
            
            Assert.Equal(8, range.Count);
            Assert.Equal(4 , range.Middle);

            var left = range.Left;
            Assert.NotNull(left);
            Assert.Equal(2, left.Value.Middle);
            
            var right = range.Right;
            Assert.NotNull(right);
            Assert.Equal(6, right.Value.Middle);
        }
        
        [Fact]
        public void BSTRange_0_3_ShouldBeCorrect()
        {
            var range = new BalancedBST.BSTRange(0, 3);
            
            Assert.Equal(4, range.Count);
            Assert.Equal(2 , range.Middle);

            var left = range.Left;
            Assert.NotNull(left);
            Assert.Equal(1, left.Value.Middle);
            
            var right = range.Right;
            Assert.NotNull(right);
            Assert.Equal(3, right.Value.Middle);
        }
        
        [Fact]
        public void BSTRange_5_7_ShouldBeCorrect()
        {
            var range = new BalancedBST.BSTRange(5, 7);
            
            Assert.Equal(3, range.Count);
            Assert.Equal(6 , range.Middle);

            var left = range.Left;
            Assert.NotNull(left);
            Assert.Equal(5, left.Value.Middle);
            
            var right = range.Right;
            Assert.NotNull(right);
            Assert.Equal(7, right.Value.Middle);
        }
        
        [Fact]
        public void BSTRange_0_0_ShouldBeCorrect()
        {
            var range = new BalancedBST.BSTRange(0, 0);
            
            Assert.Equal(1, range.Count);
            Assert.Equal(0 , range.Middle);

            var left = range.Left;
            Assert.Null(left);
            var right = range.Right;
            Assert.Null(right);
        }
        
        [Fact]
        public void BSTRange_3_3_ShouldBeCorrect()
        {
            var range = new BalancedBST.BSTRange(3, 3);
            
            Assert.Equal(1, range.Count);
            Assert.Equal(3 , range.Middle);

            var left = range.Left;
            Assert.Null(left);
            var right = range.Right;
            Assert.Null(right);
        }
        
        [Fact]
        public void BSTRange_10_10_ShouldBeCorrect()
        {
            var range = new BalancedBST.BSTRange(10, 10);
            
            Assert.Equal(1, range.Count);
            Assert.Equal(10 , range.Middle);

            var left = range.Left;
            Assert.Null(left);
            var right = range.Right;
            Assert.Null(right);
        }
    }
}