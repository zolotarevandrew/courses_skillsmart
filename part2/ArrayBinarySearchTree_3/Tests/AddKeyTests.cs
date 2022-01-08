using System.Collections.Generic;
using AlgorithmsDataStructures2;
using Xunit;

namespace ArrayBinarySearchTree_3.Tests
{
    public partial class ArrayBstTests
    {
        [Fact]
        public void AddKey_Depth0AddTwoElements_ShouldBeCorrect()
        {
            //Arrange
            var tree = new aBST(0);
            
            //Act
            Assert.Equal(0, tree.AddKey(0));
            Assert.Equal(-1, tree.AddKey(1));

            AssertTree(tree, new List<int?> {0});
        }
        
        [Fact]
        public void AddKey_Depth1AddOneElement_ShouldBeCorrect()
        {
            //Arrange
            var tree = new aBST(1);
            
            //Act
            Assert.Equal(0, tree.AddKey(0));
            AssertTree(tree, new List<int?> {0, null, null});
        }
        
        [Fact]
        public void AddKey_Depth1AddTwoElements_ShouldBeCorrect()
        {
            //Arrange
            var tree = new aBST(1);
            
            //Act
            Assert.Equal(0, tree.AddKey(0));
            Assert.Equal(2, tree.AddKey(1));
            AssertTree(tree, new List<int?> {0, null, 1});
        }
        
        [Fact]
        public void AddKey_Depth1AddThreeElements_ShouldBeCorrect()
        {
            //Arrange
            var tree = new aBST(1);
            
            //Act
            Assert.Equal(0, tree.AddKey(2));
            Assert.Equal(1, tree.AddKey(1));
            Assert.Equal(2, tree.AddKey(3));
            Assert.Equal(-1, tree.AddKey(4));
            AssertTree(tree, new List<int?> {2, 1, 3});
        }
        
        [Fact]
        public void AddKey_Depth2AddFourElements_ShouldBeCorrect()
        {
            //Arrange
            var tree = new aBST(2);
            
            //Act
            Assert.Equal(0, tree.AddKey(8));
            Assert.Equal(1, tree.AddKey(4));
            Assert.Equal(2, tree.AddKey(10));
            Assert.Equal(3, tree.AddKey(2));
            AssertTree(tree, new List<int?> { 8, 4, 10, 2, null, null, null });
        }
        
        [Fact]
        public void AddKey_Depth2AddFiveElements_ShouldBeCorrect()
        {
            //Arrange
            var tree = new aBST(2);
            
            //Act
            Assert.Equal(0, tree.AddKey(8));
            Assert.Equal(1, tree.AddKey(4));
            Assert.Equal(2, tree.AddKey(10));
            Assert.Equal(3, tree.AddKey(2));
            Assert.Equal(4, tree.AddKey(5));
            AssertTree(tree, new List<int?> { 8, 4, 10, 2, 5, null, null });
        }
        
        [Fact]
        public void AddKey_Depth2AddSixElements_ShouldBeCorrect()
        {
            //Arrange
            var tree = new aBST(2);
            
            //Act
            Assert.Equal(0, tree.AddKey(8));
            Assert.Equal(1, tree.AddKey(4));
            Assert.Equal(2, tree.AddKey(10));
            Assert.Equal(6, tree.AddKey(11));
            Assert.Equal(3, tree.AddKey(2));
            Assert.Equal(4, tree.AddKey(5));
            
            Assert.Equal(-1, tree.AddKey(3));
            Assert.Equal(2, tree.AddKey(10));
            
            AssertTree(tree, new List<int?> { 8, 4, 10, 2, 5, null, 11 });
        }
        
        [Fact]
        public void AddKey_Depth2AddSevenElements_ShouldBeCorrect()
        {
            //Arrange
            var tree = new aBST(2);
            
            //Act
            Assert.Equal(0, tree.AddKey(8));
            Assert.Equal(1, tree.AddKey(4));
            Assert.Equal(2, tree.AddKey(10));
            Assert.Equal(6, tree.AddKey(11));
            Assert.Equal(3, tree.AddKey(2));
            Assert.Equal(4, tree.AddKey(5));
            Assert.Equal(5, tree.AddKey(9));
            
            Assert.Equal(-1, tree.AddKey(3));
            Assert.Equal(2, tree.AddKey(10));
            
            Assert.Equal(6, tree.AddKey(11));
            Assert.Equal(-1, tree.AddKey(26));
            Assert.Equal(0, tree.AddKey(8));
            
            AssertTree(tree, new List<int?> { 8, 4, 10, 2, 5, 9, 11 });
        }

        void AssertTree(aBST tree, List<int?> values)
        {
            for (int idx = 0; idx < tree.Tree.Length; idx++)
            {
                var item = tree.Tree[idx];
                Assert.Equal(values[idx], item);
            }
        }
    }
}