using AlgorithmsDataStructures2;
using Xunit;

namespace BinarySearchTree_2.Tests
{
    public partial class BSTTests
    {
        [Fact]
        public void FindMinMax_EmptyTree_ShouldReturnNull()
        {
            //Arrange
            var tree = new BST<int>(null);
            
            //Act
            var res = tree.FinMinMax(null, false);
            
            //Assert
            Assert.Null(res);
        }
        
        [Fact]
        public void FindMinMax_MaxOnlyRoot_ShouldReturnRoot()
        {
            //Arrange
            var root = new BSTNode<int>(1, 2, null);
            var tree = new BST<int>(root);
            
            //Act
            var res = tree.FinMinMax(root, true);
            
            //Assert
            Assert.NotNull(res);
            Assert.Equal(2, res.NodeValue);
            Assert.Equal(1, res.NodeKey);
        }
        
        [Fact]
        public void FindMinMax_MinOnlyRoot_ShouldReturnRoot()
        {
            //Arrange
            var root = new BSTNode<int>(1, 2, null);
            var tree = new BST<int>(root);
            
            //Act
            var res = tree.FinMinMax(root, false);
            
            //Assert
            Assert.NotNull(res);
            Assert.Equal(2, res.NodeValue);
            Assert.Equal(1, res.NodeKey);
        }
        
        [Fact]
        public void FindMinMax_MaxTenElementsOnlyToRight_ShouldReturnMax()
        {
            //Arrange
            var root = new BSTNode<int>(1, 2, null);
            var tree = new BST<int>(root);
            
            //Act
            for (int i = 2; i <= 12; i++)
            {
                tree.AddKeyValue(i, i * 2);
            }
            
            //Assert
            var res = tree.FinMinMax(root, true);
            Assert.NotNull(res);
            Assert.Equal(24, res.NodeValue);
            Assert.Equal(12, res.NodeKey);
        }
        
        [Fact]
        public void FindMinMax_MinTenElementsOnlyToRight_ShouldReturnRoot()
        {
            //Arrange
            var root = new BSTNode<int>(1, 2, null);
            var tree = new BST<int>(root);
            
            //Act
            for (int i = 2; i <= 12; i++)
            {
                tree.AddKeyValue(i, i * 2);
            }
            
            //Assert
            var res = tree.FinMinMax(root, false);
            Assert.NotNull(res);
            Assert.Equal(2, res.NodeValue);
            Assert.Equal(1, res.NodeKey);
        }
        
        [Fact]
        public void FindMinMax_MaxTenElementsOnlyToLeft_ShouldReturnMax()
        {
            //Arrange
            var root = new BSTNode<int>(2, 2, null);
            var tree = new BST<int>(root);
            
            //Act
            for (int i = 2; i <= 12; i++)
            {
                tree.AddKeyValue(i, i * 2);
            }
            
            //Assert
            var res = tree.FinMinMax(root, true);
            Assert.NotNull(res);
            Assert.Equal(24, res.NodeValue);
            Assert.Equal(12, res.NodeKey);
        }
        
        
        [Fact]
        public void FindMinMax_MaxTenElementsLeftAndRight_ShouldReturnMax()
        {
            //Arrange
            var root = new BSTNode<int>(6, 2, null);
            var tree = new BST<int>(root);
            
            //Act
            for (int i = 2; i <= 12; i++)
            {
                tree.AddKeyValue(i, i * 2);
            }
            
            //Assert
            var res = tree.FinMinMax(root, true);
            Assert.NotNull(res);
            Assert.Equal(24, res.NodeValue);
            Assert.Equal(12, res.NodeKey);
        }
        
        [Fact]
        public void FindMinMax_MinTenElementsLeftAndRight_ShouldReturnMin()
        {
            //Arrange
            var root = new BSTNode<int>(6, 2, null);
            var tree = new BST<int>(root);
            
            //Act
            for (int i = 2; i <= 12; i++)
            {
                tree.AddKeyValue(i, i * 2);
            }
            
            //Assert
            var res = tree.FinMinMax(root, false);
            Assert.NotNull(res);
            Assert.Equal(4, res.NodeValue);
            Assert.Equal(2, res.NodeKey);
        }
        
        [Fact]
        public void FindMinMax_MinTenElementsLeftAndRightFromSubtree_ShouldReturnMin()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(6, 2, null));
            
            //Act
            for (int i = 2; i <= 12; i++)
            {
                tree.AddKeyValue(i, i * 2);
            }
            
            //Assert
            var find = tree.FindNodeByKey(3);
            var res = tree.FinMinMax(find.Node, false);
            Assert.NotNull(res);
            Assert.Equal(6, res.NodeValue);
            Assert.Equal(3, res.NodeKey);
        }
        
        [Fact]
        public void FindMinMax_MinTenElementsLeftAndRightFromLeftSubtree_ShouldReturnMin()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(6, 2, null));
            
            //Act
            for (int i = 2; i <= 12; i++)
            {
                tree.AddKeyValue(i, i * 2);
            }
            
            //Assert
            var find = tree.FindNodeByKey(2);
            var res = tree.FinMinMax(find.Node, false);
            Assert.NotNull(res);
            Assert.Equal(4, res.NodeValue);
            Assert.Equal(2, res.NodeKey);
        }
        
        [Fact]
        public void FindMinMax_MaxTenElementsLeftAndRightFromSubtree_ShouldReturnMax()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(6, 2, null));
            
            //Act
            for (int i = 2; i <= 12; i++)
            {
                tree.AddKeyValue(i, i * 2);
            }
            
            //Assert
            var find = tree.FindNodeByKey(3);
            var res = tree.FinMinMax(find.Node, true);
            Assert.NotNull(res);
            Assert.Equal(10, res.NodeValue);
            Assert.Equal(5, res.NodeKey);
        }
    }
}