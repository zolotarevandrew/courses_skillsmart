using System.Collections.Generic;
using AlgorithmsDataStructures2;
using Xunit;

namespace BinarySearchTree_2.Tests
{
    public partial class BSTTests
    {
        [Fact]
        public void DeepAllNodesPostOrder_EmptyTree_ShouldReturnEmptyList()
        {
            //Arrange
            var tree = new BST<int>(null);
            
            //Act
            var res = tree.DeepAllNodes(1);
            
            //Assert
            AssertList(res, 0, new List<int>());
        }
        
        [Fact]
        public void DeepAllNodesPostOrder_OnlyRoot_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(1, 1, null));
            
            //Act
            var res = tree.DeepAllNodes(1);
            
            //Assert
            AssertList(res, 1, new List<int>{ 1 });
        }
        
        [Fact]
        public void DeepAllNodesPostOrder_OnlyRootAndLeft_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(2, 2, null));
            tree.AddKeyValue(1, 1);
            
            //Act
            var res = tree.DeepAllNodes(1);
            
            //Assert
            AssertList(res, 2, new List<int>{ 1, 2 });
        }
        
        [Fact]
        public void DeepAllNodesPostOrder_OnlyRootAndLeftRight_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(2, 2, null));
            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 3);
            
            //Act
            var res = tree.DeepAllNodes(1);
            
            //Assert
            AssertList(res, 3, new List<int>{ 1, 3, 2 });
        }
        
        [Fact]
        public void DeepAllNodesPostOrder_FourElementsLeftSubtree_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(4, 4, null));
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 3);
            
            //Act
            var res = tree.DeepAllNodes(1);
            
            //Assert
            AssertList(res, 4, new List<int>{ 1, 3, 2, 4 });
        }
        
        [Fact]
        public void DeepAllNodesPostOrder_FourElementsRightSubtree_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(1, 1, null));
            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(2, 2);
            
            //Act
            var res = tree.DeepAllNodes(1);
            
            //Assert
            AssertList(res, 4, new List<int>{ 2, 4, 3, 1 });
        }
        
        [Fact]
        public void DeepAllNodesPostOrder_FourElementsLeftRightSubtree_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(2, 2, null));
            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(4, 4);
            
            //Act
            var res = tree.DeepAllNodes(1);
            
            //Assert
            AssertList(res, 4, new List<int>{ 1, 4, 3, 2 });
        }
        
        [Fact]
        public void DeepAllNodesPostOrder_FiveElementsLeftSubtree_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(4, 4, null));
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(0, 0);
            
            //Act
            var res = tree.DeepAllNodes(1);
            
            //Assert
            AssertList(res, 5, new List<int>{ 0, 1, 3, 2, 4 });
        }
        
        [Fact]
        public void DeepAllNodesPostOrder_FiveElementsRightSubtree_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(8, 8, null));
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(12, 12);
            tree.AddKeyValue(13, 13);
            tree.AddKeyValue(14, 14);
            
            //Act
            var res = tree.DeepAllNodes(1);
            
            //Assert
            AssertList(res, 5, new List<int>{ 4, 14, 13, 12, 8 });
        }
        
        [Fact]
        public void DeepAllNodesPostOrder_SixElementsLeftRightSubtree_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(8, 8, null));
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(12, 12);
            tree.AddKeyValue(13, 13);
            tree.AddKeyValue(14, 14);
            
            //Act
            var res = tree.DeepAllNodes(1);
            
            //Assert
            AssertList(res, 6, new List<int>{ 2, 4, 14, 13, 12, 8 });
        }
        
        [Fact]
        public void DeepAllNodesPostOrder_SevenElementsLeftRightSubtree_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(8, 8, null));
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(6, 6);
            tree.AddKeyValue(12, 12);
            tree.AddKeyValue(13, 13);
            tree.AddKeyValue(14, 14);
            
            //Act
            var res = tree.DeepAllNodes(1);
            
            //Assert
            AssertList(res, 7, new List<int>{ 2, 6, 4, 14, 13, 12, 8 });
        }
        
        [Fact]
        public void DeepAllNodesPostOrder_BigTreeLeftRightSubtree_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(8, 8, null));
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(12, 12);
            
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(6, 6);
            
            tree.AddKeyValue(10, 10);
            tree.AddKeyValue(14, 14);
            
            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 3);
            
            tree.AddKeyValue(5, 5);
            tree.AddKeyValue(7, 7);
            
            
            //Act
            var res = tree.DeepAllNodes(1);
            
            //Assert

            AssertList(res, 11, new List<int>{ 1, 3, 2, 5, 7, 6, 4, 10, 14, 12, 8 });
        }
    }
}