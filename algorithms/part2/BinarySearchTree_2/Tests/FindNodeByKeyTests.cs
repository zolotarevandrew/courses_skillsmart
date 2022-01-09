using AlgorithmsDataStructures2;
using Xunit;

namespace BinarySearchTree_2.Tests
{
    public partial class BSTTests
    {
        [Fact]
        public void FindNodeByKey_EmptyTree_ShouldReturnNull()
        {
            //Arrange
            var tree = new BST<int>(null);
            
            //Act
            var res = tree.FindNodeByKey(1);
            
            //Assert
            Assert.Null(res.Node);
            Assert.Equal(0, tree.Count());
        }
        
        [Fact]
        public void FindNodeByKey_OnlyRootAndKeyEqualsRoot_ShouldReturnRoot()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(1, 2, null));
            
            //Act
            var res = tree.FindNodeByKey(1);
            
            //Assert
            Assert.NotNull(res.Node);
            
            Assert.Equal(1, res.Node.NodeKey);
            Assert.Equal(2, res.Node.NodeValue);
            Assert.Null(res.Node.Parent);
            Assert.Null(res.Node.LeftChild);
            Assert.Null(res.Node.RightChild);
            
            Assert.False(res.ToLeft);
            Assert.True(res.NodeHasKey);
            Assert.Equal(1, tree.Count());
        }
        
        [Fact]
        public void FindNodeByKey_OnlyRootAndKeyLessThanRoot_ShouldReturnLeft()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(1, 2, null));
            
            //Act
            var res = tree.FindNodeByKey(0);
            
            //Assert
            Assert.NotNull(res.Node);
            
            Assert.Equal(1, res.Node.NodeKey);
            Assert.Equal(2, res.Node.NodeValue);
            Assert.Null(res.Node.Parent);
            Assert.Null(res.Node.LeftChild);
            Assert.Null(res.Node.RightChild);
            
            Assert.True(res.ToLeft);
            Assert.False(res.NodeHasKey);
            Assert.Equal(1, tree.Count());
        }
        
        [Fact]
        public void FindNodeByKey_OnlyRootAndKeyGreaterRoot_ShouldReturnRight()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(1, 2, null));
            
            //Act
            var res = tree.FindNodeByKey(2);
            
            //Assert
            Assert.NotNull(res.Node);
            
            Assert.Equal(1, res.Node.NodeKey);
            Assert.Equal(2, res.Node.NodeValue);
            Assert.Null(res.Node.Parent);
            Assert.Null(res.Node.LeftChild);
            Assert.Null(res.Node.RightChild);
            
            Assert.False(res.ToLeft);
            Assert.False(res.NodeHasKey);
            Assert.Equal(1, tree.Count());
        }

        [Fact] 
        public void FindNodeByKey_OnlyRightElements_ShouldReturnLeft()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(1, 2, null));
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(5, 5);
            
            //Act
            var res = tree.FindNodeByKey(0);
            
            //Assert
            Assert.NotNull(res.Node);
            
            Assert.Equal(1, res.Node.NodeKey);
            Assert.Equal(2, res.Node.NodeValue);
            Assert.Null(res.Node.Parent);
            Assert.Null(res.Node.LeftChild);
            Assert.NotNull(res.Node.RightChild);
            
            Assert.True(res.ToLeft);
            Assert.False(res.NodeHasKey);
            Assert.Equal(5, tree.Count());
        }
        
        [Fact] 
        public void FindNodeByKey_OnlyRightElements_ShouldReturnRight()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(1, 2, null));
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(5, 5);
            
            //Act
            var res = tree.FindNodeByKey(6);
            
            //Assert
            Assert.NotNull(res.Node);
            
            Assert.Equal(5, res.Node.NodeKey);
            Assert.Equal(5, res.Node.NodeValue);
            Assert.NotNull(res.Node.Parent);
            Assert.Null(res.Node.LeftChild);
            Assert.Null(res.Node.RightChild);
            
            Assert.False(res.ToLeft);
            Assert.False(res.NodeHasKey);
            Assert.Equal(5, tree.Count());
        }
        
        [Fact] 
        public void FindNodeByKey_OnlyRightElements_ShouldFindNode()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(1, 2, null));
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(5, 5);
            
            //Act
            var res = tree.FindNodeByKey(4);
            
            //Assert
            Assert.NotNull(res.Node);
            
            Assert.Equal(4, res.Node.NodeKey);
            Assert.Equal(4, res.Node.NodeValue);
            Assert.NotNull(res.Node.Parent);
            Assert.Null(res.Node.LeftChild);
            Assert.NotNull(res.Node.RightChild);
            
            Assert.False(res.ToLeft);
            Assert.True(res.NodeHasKey);
            Assert.Equal(5, tree.Count());
        }
        
        [Fact] 
        public void FindNodeByKey_OnlyLeftElements_ShouldReturnLeft()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(8, 2, null));
            tree.AddKeyValue(7, 2);
            tree.AddKeyValue(6, 3);
            tree.AddKeyValue(5, 4);
            tree.AddKeyValue(4, 5);
            
            //Act
            var res = tree.FindNodeByKey(3);
            
            //Assert
            Assert.NotNull(res.Node);
            
            Assert.Equal(4, res.Node.NodeKey);
            Assert.Equal(5, res.Node.NodeValue);
            Assert.NotNull(res.Node.Parent);
            Assert.Null(res.Node.LeftChild);
            Assert.Null(res.Node.RightChild);
            
            Assert.True(res.ToLeft);
            Assert.False(res.NodeHasKey);
            Assert.Equal(5, tree.Count());
        }
        
        [Fact] 
        public void FindNodeByKey_OnlyLeftElements_ShouldFindKey()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(8, 2, null));
            tree.AddKeyValue(7, 2);
            tree.AddKeyValue(6, 3);
            tree.AddKeyValue(5, 4);
            tree.AddKeyValue(4, 5);
            
            //Act
            var res = tree.FindNodeByKey(6);
            
            //Assert
            Assert.NotNull(res.Node);
            
            Assert.Equal(6, res.Node.NodeKey);
            Assert.Equal(3, res.Node.NodeValue);
            Assert.NotNull(res.Node.Parent);
            Assert.NotNull(res.Node.LeftChild);
            Assert.Null(res.Node.RightChild);
            
            Assert.False(res.ToLeft);
            Assert.True(res.NodeHasKey);
            Assert.Equal(5, tree.Count());
        }
        
        [Fact] 
        public void FindNodeByKey_OnlyLeftElements_ShouldReturnRight()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(8, 2, null));
            tree.AddKeyValue(7, 2);
            tree.AddKeyValue(6, 3);
            tree.AddKeyValue(5, 4);
            tree.AddKeyValue(4, 5);
            
            //Act
            var res = tree.FindNodeByKey(9);
            
            //Assert
            Assert.NotNull(res.Node);
            
            Assert.Equal(8, res.Node.NodeKey);
            Assert.Equal(2, res.Node.NodeValue);
            Assert.Null(res.Node.Parent);
            Assert.NotNull(res.Node.LeftChild);
            Assert.Null(res.Node.RightChild);
            
            Assert.False(res.ToLeft);
            Assert.False(res.NodeHasKey);
            Assert.Equal(5, tree.Count());
        }
        
        [Fact] 
        public void FindNodeByKey_LeftAndRightElements_ShouldReturnLeft()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(4, 2, null));
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(5, 4);
            tree.AddKeyValue(6, 5);
            
            //Act
            var res = tree.FindNodeByKey(1);
            
            //Assert
            Assert.NotNull(res.Node);
            
            Assert.Equal(2, res.Node.NodeKey);
            Assert.Equal(2, res.Node.NodeValue);
            Assert.NotNull(res.Node.Parent);
            Assert.Null(res.Node.LeftChild);
            Assert.NotNull(res.Node.RightChild);
            
            Assert.True(res.ToLeft);
            Assert.False(res.NodeHasKey);
            Assert.Equal(5, tree.Count());
        }
        
        [Fact] 
        public void FindNodeByKey_LeftAndRightElements_ShouldReturnRight()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(4, 2, null));
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(5, 4);
            tree.AddKeyValue(6, 5);
            
            //Act
            var res = tree.FindNodeByKey(7);
            
            //Assert
            Assert.NotNull(res.Node);
            
            Assert.Equal(6, res.Node.NodeKey);
            Assert.Equal(5, res.Node.NodeValue);
            Assert.NotNull(res.Node.Parent);
            Assert.Null(res.Node.LeftChild);
            Assert.Null(res.Node.RightChild);
            
            Assert.False(res.ToLeft);
            Assert.False(res.NodeHasKey);
            Assert.Equal(5, tree.Count());
        }
        
        [Fact] 
        public void FindNodeByKey_LeftAndRightElements_ShouldFoundKey()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(4, 2, null));
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(5, 4);
            tree.AddKeyValue(6, 5);
            
            //Act
            var res = tree.FindNodeByKey(2);
            
            //Assert
            Assert.NotNull(res.Node);
            
            Assert.Equal(2, res.Node.NodeKey);
            Assert.Equal(2, res.Node.NodeValue);
            Assert.NotNull(res.Node.Parent);
            Assert.Null(res.Node.LeftChild);
            Assert.NotNull(res.Node.RightChild);
            Assert.False(res.ToLeft);
            Assert.True(res.NodeHasKey);
            Assert.Equal(5, tree.Count());
        }
    }
}