using System.Collections.Generic;
using AlgorithmsDataStructures2;
using Xunit;

namespace ArrayBinarySearchTree_3.Tests
{
    public partial class ArrayBstTests
    {
        [Fact]
        public void FindKeyIndexTests_Depth0EmptyTree_ShouldBeCorrect()
        {
            //Arrange
            var tree = new aBST(0);
            
            //Act
            var idx = tree.FindKeyIndex(0);
            Assert.Equal(0, idx);
            AssertTree(tree, new List<int?>{ null });
        }
        
        [Fact]
        public void FindKeyIndexTests_Depth0RootAdded_ShouldBeCorrect()
        {
            //Arrange
            var tree = new aBST(0);
            tree.AddKey(0);
            
            //Act
            var idx = tree.FindKeyIndex(0);
            Assert.Equal(0, idx);
            
            idx = tree.FindKeyIndex(2);
            Assert.Null(idx);
            
            AssertTree(tree, new List<int?>{ 0 });
        }
        
        [Fact]
        public void FindKeyIndexTests_Depth1EmptyTree_ShouldBeCorrect()
        {
            //Arrange
            var tree = new aBST(1);
   
            //Act
            var idx = tree.FindKeyIndex(0);
            Assert.Equal(0, idx);

            AssertTree(tree, new List<int?>{ null, null, null });
        }
        
        [Fact]
        public void FindKeyIndexTests_Depth1OnlyRoot_ShouldBeCorrect()
        {
            //Arrange
            var tree = new aBST(1);
            tree.AddKey(2);
   
            //Act
            var idx = tree.FindKeyIndex(2);
            Assert.Equal(0, idx);
            
            idx = tree.FindKeyIndex(1);
            Assert.Equal(-1, idx);
            
            idx = tree.FindKeyIndex(3);
            Assert.Equal(-2, idx);

            AssertTree(tree, new List<int?>{ 2, null, null });
        }
        
        [Fact]
        public void FindKeyIndexTests_Depth1OnlyRootAndLeft_ShouldBeCorrect()
        {
            //Arrange
            var tree = new aBST(1);
            tree.AddKey(2);
            tree.AddKey(1);
   
            //Act
            var idx = tree.FindKeyIndex(2);
            Assert.Equal(0, idx);
            
            idx = tree.FindKeyIndex(1);
            Assert.Equal(1, idx);
            
            idx = tree.FindKeyIndex(3);
            Assert.Equal(-2, idx);

            AssertTree(tree, new List<int?>{ 2, 1, null });
        }
        
        [Fact]
        public void FindKeyIndexTests_Depth1ThreeElements_ShouldBeCorrect()
        {
            //Arrange
            var tree = new aBST(1);
            tree.AddKey(2);
            tree.AddKey(1);
            tree.AddKey(3);
   
            //Act
            var idx = tree.FindKeyIndex(2);
            Assert.Equal(0, idx);
            
            idx = tree.FindKeyIndex(1);
            Assert.Equal(1, idx);
            
            idx = tree.FindKeyIndex(3);
            Assert.Equal(2, idx);
            
            Assert.Null(tree.FindKeyIndex(5));
            Assert.Null(tree.FindKeyIndex(6));

            AssertTree(tree, new List<int?>{ 2, 1, 3 });
        }
        
        [Fact]
        public void FindKeyIndexTests_Depth2ThreeElements_ShouldBeCorrect()
        {
            //Arrange
            var tree = new aBST(2);
            tree.AddKey(2);
            tree.AddKey(1);
            tree.AddKey(3);
   
            //Act
            var idx = tree.FindKeyIndex(2);
            Assert.Equal(0, idx);
            
            idx = tree.FindKeyIndex(1);
            Assert.Equal(1, idx);
            
            idx = tree.FindKeyIndex(3);
            Assert.Equal(2, idx);
            
            Assert.Equal(-3, tree.FindKeyIndex(0));
            Assert.Equal(-3, tree.FindKeyIndex(-1));
            
            Assert.Equal(-6, tree.FindKeyIndex(5));
            Assert.Equal(-6, tree.FindKeyIndex(6));

            AssertTree(tree, new List<int?>{ 2, 1, 3, null, null, null, null });
        }
        
        [Fact]
        public void FindKeyIndexTests_Depth2FiveElements_ShouldBeCorrect()
        {
            //Arrange
            var tree = new aBST(2);
            tree.AddKey(8);
            tree.AddKey(3);
            tree.AddKey(10);
            tree.AddKey(11);
            tree.AddKey(2);

            //Act
            Assert.Equal(0, tree.FindKeyIndex(8));
            Assert.Equal(1, tree.FindKeyIndex(3));
            Assert.Equal(2, tree.FindKeyIndex(10));
            Assert.Equal(3, tree.FindKeyIndex(2));
            Assert.Equal(6, tree.FindKeyIndex(11));
            Assert.Equal(-4, tree.FindKeyIndex(4));
            Assert.Equal(-5, tree.FindKeyIndex(9));


            AssertTree(tree, new List<int?>{ 8, 3, 10, 2, null, null, 11 });
        }
        
        [Fact]
        public void FindKeyIndexTests_Depth2SevenElements_ShouldBeCorrect()
        {
            //Arrange
            var tree = new aBST(2);
            tree.AddKey(8);
            tree.AddKey(3);
            tree.AddKey(10);
            tree.AddKey(11);
            tree.AddKey(2);
            tree.AddKey(4);
            tree.AddKey(9);

            //Act
            Assert.Equal(0, tree.FindKeyIndex(8));
            Assert.Equal(1, tree.FindKeyIndex(3));
            Assert.Equal(2, tree.FindKeyIndex(10));
            Assert.Equal(3, tree.FindKeyIndex(2));
            Assert.Equal(6, tree.FindKeyIndex(11));
            Assert.Equal(4, tree.FindKeyIndex(4));
            Assert.Equal(5, tree.FindKeyIndex(9));
            Assert.Null(tree.FindKeyIndex(15));


            AssertTree(tree, new List<int?>{ 8, 3, 10, 2, 4, 9, 11 });
        }
    }
}