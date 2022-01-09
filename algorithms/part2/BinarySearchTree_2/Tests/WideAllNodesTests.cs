using System.Collections.Generic;
using AlgorithmsDataStructures2;
using Xunit;

namespace BinarySearchTree_2.Tests
{
    public partial class BSTTests
    {
        [Fact]
        public void WideAllNodes_EmptyTree_ShouldReturnEmptyList()
        {
            //Arrange
            var tree = new BST<int>(null);
            
            //Act
            var res = tree.WideAllNodes();
            
            //Assert
            AssertList(res, 0, new List<int>());
        }
        
        [Fact]
        public void WideAllNodes_OnlyRoot_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(1, 1, null));
            
            //Act
            var res = tree.WideAllNodes();
            
            //Assert
            AssertList(res, 1, new List<int>{ 1 });
        }
        
        [Fact]
        public void WideAllNodes_OnlyRootAndLeft_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(2, 2, null));
            tree.AddKeyValue(1, 1);
            
            //Act
            var res = tree.WideAllNodes();
            
            //Assert
            AssertList(res, 2, new List<int>{ 2, 1 });
        }
        
        [Fact]
        public void WideAllNodes_OnlyRootAndLeftRight_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(2, 2, null));
            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 3);
            
            //Act
            var res = tree.WideAllNodes();
            
            //Assert
            AssertList(res, 3, new List<int>{ 2, 1, 3 });
        }
        
        [Fact]
        public void WideAllNodes_FourElementsLeftSubtree_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(4, 4,null));
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 3);
            
            //Act
            var res = tree.WideAllNodes();
            
            //Assert
            AssertList(res, 4, new List<int>{ 4, 2, 1, 3 });
        }
        
        [Fact]
        public void WideAllNodes_FourElementsRightSubtree_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(1, 1, null));
            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(2, 2);
            
            //Act
            var res = tree.WideAllNodes();
            
            //Assert
            AssertList(res, 4, new List<int>{ 1, 3, 2, 4 });
        }
        
        [Fact]
        public void WideAllNodes_FourElementsLeftRightSubtree_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(2, 2, null));
            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(4, 4);
            
            //Act
            var res = tree.WideAllNodes();
            
            //Assert
            AssertList(res, 4, new List<int>{ 2, 1, 3, 4 });
        }
        
        [Fact]
        public void WideAllNodes_FiveElementsLeftSubtree_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(4, 4, null));
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(0, 0);
            
            //Act
            var res = tree.WideAllNodes();
            
            //Assert
            AssertList(res, 5, new List<int>{ 4, 2, 1, 3, 0 });
        }
        
        [Fact]
        public void WideAllNodes_FiveElementsRightSubtree_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(8, 8, null));
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(12, 12);
            tree.AddKeyValue(13, 13);
            tree.AddKeyValue(14, 14);
            
            //Act
            var res = tree.WideAllNodes();
            
            //Assert
            AssertList(res, 5, new List<int>{ 8, 4, 12, 13, 14 });
        }
        
        [Fact]
        public void WideAllNodes_SixElementsLeftRightSubtree_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(8, 8, null));
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(12, 12);
            tree.AddKeyValue(13, 13);
            tree.AddKeyValue(14, 14);
            
            //Act
            var res = tree.WideAllNodes();
            
            //Assert
            AssertList(res, 6, new List<int>{ 8, 4, 12, 2, 13, 14 });
        }
        
        [Fact]
        public void WideAllNodes_SevenElementsLeftRightSubtree_ShouldBeCorrect()
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
            var res = tree.WideAllNodes();
            
            //Assert
            AssertList(res, 7, new List<int>{ 8, 4, 12, 2, 6,  13, 14 });
        }
        
        [Fact]
        public void WideAllNodes_BigTreeLeftRightSubtree_ShouldBeCorrect()
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
            var res = tree.WideAllNodes();
            
            //Assert

            AssertList(res, 11, new List<int>{ 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7 });
        }

        static void AssertList<T>(List<BSTNode<T>> nodes, int count, List<int> values)
        {
            Assert.Equal(count, nodes.Count);
            for (int i = 0; i < count; i++)
            {
                Assert.Equal(values[i], nodes[i].NodeKey);
            }
        }
    }
}