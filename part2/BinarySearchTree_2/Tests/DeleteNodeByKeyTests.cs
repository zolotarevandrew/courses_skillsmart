using AlgorithmsDataStructures2;
using Xunit;

namespace BinarySearchTree_2.Tests
{
    public partial class BSTTests
    {
        [Fact]
        public void DeleteNodeByKey_EmptyTree_ShouldReturnFalse()
        {
            //Arrange
            var tree = new BST<int>(null);
            
            //Act
            Assert.False(tree.FindNodeByKey(1).NodeHasKey);
            var res = tree.DeleteNodeByKey(1);
            
            //Assert
            Assert.False(res);
            Assert.Equal(0, tree.Count());
            Assert.False(tree.FindNodeByKey(1).NodeHasKey);
        }
        
        [Fact]
        public void DeleteNodeByKey_OnlyRoot_ShouldReturnTrue()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(1, 2, null));
            
            //Act
            Assert.True(tree.FindNodeByKey(1).NodeHasKey);
            var res = tree.DeleteNodeByKey(1);
            
            //Assert
            Assert.True(res);
            Assert.Equal(0, tree.Count());
            Assert.False(tree.FindNodeByKey(1).NodeHasKey);
        }
        
        [Fact]
        public void DeleteNodeByKey_OnlyRootWithLeft_ShouldReturnTrue()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(2, 2, null));
            tree.AddKeyValue(1, 1);
            
            //Act
            Assert.True(tree.FindNodeByKey(1).NodeHasKey);
            Assert.True(tree.FindNodeByKey(2).NodeHasKey);
            
            var res = tree.DeleteNodeByKey(1);
            
            //Assert
            Assert.True(res);
            Assert.Equal(1, tree.Count());

            var root = tree.FindNodeByKey(2);
            Assert.True(root.NodeHasKey);
            Assert.Null(root.Node.LeftChild);
            Assert.Null(root.Node.RightChild);
            Assert.False(tree.FindNodeByKey(1).NodeHasKey);
        }
        
        [Fact]
        public void DeleteNodeByKey_OnlyRootWithLeftSubtreeRemoveLeftMiddle_ShouldReturnTrue()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(3, 3, null));
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(1, 1);
            
            //Act
            Assert.True(tree.FindNodeByKey(1).NodeHasKey);
            Assert.True(tree.FindNodeByKey(2).NodeHasKey);
            Assert.True(tree.FindNodeByKey(3).NodeHasKey);
            
            var res = tree.DeleteNodeByKey(2);
            
            //Assert
            Assert.False(tree.FindNodeByKey(2).NodeHasKey);
            Assert.True(res);
            
            Assert.Equal(2, tree.Count());
            
            var root = tree.FindNodeByKey(3);
            var left = tree.FindNodeByKey(1);
            Assert.True(root.NodeHasKey);
            Assert.Equal(root.Node.LeftChild, left.Node);
            Assert.Null(root.Node.RightChild);
            Assert.Equal(root.Node.LeftChild.Parent, root.Node);
            
            Assert.True(left.NodeHasKey);
        }
        
        [Fact]
        public void DeleteNodeByKey_OnlyRootWithLeftSubtreeRemoveRightMiddle_ShouldReturnTrue()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(4, 4, null));
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(3, 3);
            
            //Act
            Assert.True(tree.FindNodeByKey(4).NodeHasKey);
            Assert.True(tree.FindNodeByKey(2).NodeHasKey);
            Assert.True(tree.FindNodeByKey(3).NodeHasKey);
            
            var res = tree.DeleteNodeByKey(2);
            
            //Assert
            Assert.False(tree.FindNodeByKey(2).NodeHasKey);
            Assert.True(res);
            
            Assert.Equal(2, tree.Count());
            
            var root = tree.FindNodeByKey(4);
            var left = tree.FindNodeByKey(3);
            Assert.True(root.NodeHasKey);
            Assert.Equal(root.Node.LeftChild, left.Node);
            Assert.Null(root.Node.RightChild);
            Assert.Equal(root.Node.LeftChild.Parent, root.Node);
            
            Assert.True(left.NodeHasKey);
        }
        
        [Fact]
        public void DeleteNodeByKey_OnlyRootWithLeftSubtreeRemoveLeftLast_ShouldReturnTrue()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(3, 3, null));
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(1, 1);
            
            //Act
            Assert.True(tree.FindNodeByKey(1).NodeHasKey);
            Assert.True(tree.FindNodeByKey(2).NodeHasKey);
            Assert.True(tree.FindNodeByKey(3).NodeHasKey);
            
            var res = tree.DeleteNodeByKey(1);
            
            //Assert
            Assert.True(res);
            Assert.False(tree.FindNodeByKey(1).NodeHasKey);
            
            Assert.Equal(2, tree.Count());
            
            var root = tree.FindNodeByKey(3);
            var left = tree.FindNodeByKey(2);
            Assert.True(root.NodeHasKey);
            Assert.Equal(root.Node.LeftChild, left.Node);
            Assert.Null(root.Node.RightChild);
            Assert.Equal(root.Node.LeftChild.Parent, root.Node);
            
            Assert.True(left.NodeHasKey);
        }
        
        [Fact]
        public void DeleteNodeByKey_RootWithLeftAndRight_ShouldReturnTrue()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(8, 8, null));
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(12, 12);
            
            //Act
            Assert.True(tree.FindNodeByKey(8).NodeHasKey);
            Assert.True(tree.FindNodeByKey(4).NodeHasKey);
            Assert.True(tree.FindNodeByKey(12).NodeHasKey);
            
            var res = tree.DeleteNodeByKey(8);
            
            //Assert
            Assert.True(res);
            Assert.False(tree.FindNodeByKey(8).NodeHasKey);
            
            Assert.Equal(2, tree.Count());
            
            var root = tree.FindNodeByKey(12);
            Assert.True(root.NodeHasKey);
            
            var left = tree.FindNodeByKey(4);
            Assert.True(left.NodeHasKey);
            
            Assert.Equal(root.Node.LeftChild, left.Node);
            Assert.Null(root.Node.RightChild);
            Assert.Equal(root.Node.LeftChild.Parent, root.Node);
        }
        
        [Fact]
        public void DeleteNodeByKey_RootWithLeftSubtreeLeafAndRight_ShouldReturnTrue()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(8, 8, null));
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(6, 6);
            tree.AddKeyValue(12, 12);
            
            //Act
            Assert.True(tree.FindNodeByKey(8).NodeHasKey);
            Assert.True(tree.FindNodeByKey(4).NodeHasKey);
            Assert.True(tree.FindNodeByKey(12).NodeHasKey);
            Assert.True(tree.FindNodeByKey(2).NodeHasKey);
            Assert.True(tree.FindNodeByKey(6).NodeHasKey);
            
            var res = tree.DeleteNodeByKey(4);
            
            //Assert
            Assert.True(res);
            Assert.False(tree.FindNodeByKey(4).NodeHasKey);
            
            Assert.Equal(4, tree.Count());
            Assert.True(tree.FindNodeByKey(8).NodeHasKey);
            Assert.True(tree.FindNodeByKey(12).NodeHasKey);
            Assert.True(tree.FindNodeByKey(2).NodeHasKey);
            Assert.True(tree.FindNodeByKey(6).NodeHasKey);
        }
        
        [Fact]
        public void DeleteNodeByKey_RootWithLeftSubtreeRightAndRight_ShouldReturnTrue()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(8, 8, null));
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(6, 6);
            tree.AddKeyValue(7, 7);
            tree.AddKeyValue(12, 12);
            
            //Act
            Assert.True(tree.FindNodeByKey(8).NodeHasKey);
            Assert.True(tree.FindNodeByKey(4).NodeHasKey);
            Assert.True(tree.FindNodeByKey(12).NodeHasKey);
            Assert.True(tree.FindNodeByKey(2).NodeHasKey);
            Assert.True(tree.FindNodeByKey(6).NodeHasKey);
            Assert.True(tree.FindNodeByKey(7).NodeHasKey);
            
            var res = tree.DeleteNodeByKey(4);
            
            //Assert
            Assert.True(res);
            Assert.False(tree.FindNodeByKey(4).NodeHasKey);
            
            Assert.Equal(5, tree.Count());
            
            Assert.True(tree.FindNodeByKey(12).NodeHasKey);
            Assert.True(tree.FindNodeByKey(2).NodeHasKey);
            Assert.True(tree.FindNodeByKey(6).NodeHasKey);
            Assert.True(tree.FindNodeByKey(7).NodeHasKey);

            var root = tree.FindNodeByKey(8);
            Assert.True(root.NodeHasKey);
        }
        
        [Fact]
        public void DeleteNodeByKey_RootWithLeftSubtreeLeftAndRight_ShouldReturnTrue()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(8, 8, null));
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(6, 6);
            tree.AddKeyValue(5, 5);
            tree.AddKeyValue(7, 7);
            tree.AddKeyValue(12, 12);
            
            //Act
            Assert.True(tree.FindNodeByKey(8).NodeHasKey);
            Assert.True(tree.FindNodeByKey(4).NodeHasKey);
            Assert.True(tree.FindNodeByKey(12).NodeHasKey);
            Assert.True(tree.FindNodeByKey(2).NodeHasKey);
            Assert.True(tree.FindNodeByKey(6).NodeHasKey);
            Assert.True(tree.FindNodeByKey(7).NodeHasKey);
            
            var res = tree.DeleteNodeByKey(4);
            
            //Assert
            Assert.True(res);
            Assert.False(tree.FindNodeByKey(4).NodeHasKey);
            
            Assert.Equal(6, tree.Count());
            
            Assert.True(tree.FindNodeByKey(12).NodeHasKey);
            Assert.True(tree.FindNodeByKey(2).NodeHasKey);
            Assert.True(tree.FindNodeByKey(6).NodeHasKey);
            Assert.True(tree.FindNodeByKey(5).NodeHasKey);
            Assert.True(tree.FindNodeByKey(7).NodeHasKey);

            var root = tree.FindNodeByKey(8);
            Assert.True(root.NodeHasKey);
        }
        
        [Fact]
        public void DeleteNodeByKey_AddMillionElementsAndRemoveAll_ShouldReturnTrue()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(5000, 5000, null));

            for (int i = 1; i < 10000; i++)
            {
                tree.AddKeyValue(i, i);
            }

            //Act
            for (int i = 1; i < 10000; i++)
            {
                tree.DeleteNodeByKey(i);
            }
            Assert.Equal(0, tree.Count());
        }
    }
}