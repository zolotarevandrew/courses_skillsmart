using AlgorithmsDataStructures2;
using Xunit;

namespace BinarySearchTree_2.Tests
{
    public partial class BSTTests
    {
        [Fact]
        public void AddKeyValueTests_EmptyTree_ShouldAdd()
        {
            //Arrange
            var tree = new BST<int>(null);
            
            //Act
            var findBefore = tree.FindNodeByKey(1);
            var res = tree.AddKeyValue(1, 2);
            
            //Assert
            Assert.False(findBefore.NodeHasKey);
            Assert.True(res);
            Assert.Equal(1, tree.Count());

            var find = tree.FindNodeByKey(1);
            Assert.NotNull(find.Node);
            Assert.Null(find.Node.Parent);
            Assert.Null(find.Node.LeftChild);
            Assert.Null(find.Node.RightChild);
            Assert.True(find.NodeHasKey);
        }
        
        [Fact]
        public void AddKeyValueTests_TwoElementsEmptyTree_ShouldAdd()
        {
            //Arrange
            var tree = new BST<int>(null);
            
            
            //Act
            Assert.False(tree.FindNodeByKey(1).NodeHasKey);
            var res = tree.AddKeyValue(1, 2);
            Assert.True(res);
            Assert.Equal(1, tree.Count());
            Assert.True(tree.FindNodeByKey(1).NodeHasKey);
            
            Assert.False(tree.FindNodeByKey(2).NodeHasKey);
            res = tree.AddKeyValue(2, 2);
            Assert.True(res);
            Assert.Equal(2, tree.Count());
            Assert.True(tree.FindNodeByKey(2).NodeHasKey);
        }
        
        [Fact]
        public void AddKeyValueTests_ThreeElements_ShouldAdd()
        {
            //Arrange
            var tree = new BST<int>(null);
            
            //Act
            var res = tree.AddKeyValue(1, 2);
            Assert.True(res);
            Assert.Equal(1, tree.Count());

            var find = tree.FindNodeByKey(1);
            Assert.NotNull(find.Node);
            Assert.Null(find.Node.Parent);
            Assert.Equal(2, find.Node.NodeValue);
            Assert.Equal(1, find.Node.NodeKey);
            Assert.Null(find.Node.LeftChild);
            Assert.Null(find.Node.RightChild);
            Assert.True(find.NodeHasKey);
            
            res = tree.AddKeyValue(2, 3);
            Assert.True(res);
            Assert.Equal(2, tree.Count());

            var right = tree.FindNodeByKey(2);
            Assert.NotNull(right.Node);
            Assert.Equal(find.Node, right.Node.Parent);
            Assert.Equal(3, right.Node.NodeValue);
            Assert.Equal(2, right.Node.NodeKey);
            Assert.Null(right.Node.LeftChild);
            Assert.Null(right.Node.RightChild);
            Assert.True(right.NodeHasKey);
            Assert.False(right.ToLeft);
            
            res = tree.AddKeyValue(0, 4);
            Assert.True(res);
            Assert.Equal(3, tree.Count());

            var left = tree.FindNodeByKey(0);
            Assert.NotNull(left.Node);
            Assert.Equal(find.Node, left.Node.Parent);
            Assert.Equal(4, left.Node.NodeValue);
            Assert.Equal(0, left.Node.NodeKey);
            Assert.Null(left.Node.LeftChild);
            Assert.Null(left.Node.RightChild);
            Assert.True(left.NodeHasKey);
            Assert.False(left.ToLeft);
            
            Assert.Equal(left.Node, find.Node.LeftChild);
            Assert.Equal(right.Node, find.Node.RightChild);
            
            
            res = tree.AddKeyValue(0, 4);
            Assert.False(res);
        }
        
        [Fact]
        public void AddKeyValueTests_ThreeElementsRootAdded_ShouldAdd()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(1, 2, null));
            
            //Act
            var find = tree.FindNodeByKey(1);
            
            var res = tree.AddKeyValue(2, 3);
            Assert.True(res);
            Assert.Equal(2, tree.Count());

            var right = tree.FindNodeByKey(2);
            Assert.NotNull(right.Node);
            Assert.Equal(find.Node, right.Node.Parent);
            Assert.Equal(3, right.Node.NodeValue);
            Assert.Equal(2, right.Node.NodeKey);
            Assert.Null(right.Node.LeftChild);
            Assert.Null(right.Node.RightChild);
            Assert.True(right.NodeHasKey);
            Assert.False(right.ToLeft);
            
            res = tree.AddKeyValue(0, 4);
            Assert.True(res);
            Assert.Equal(3, tree.Count());

            var left = tree.FindNodeByKey(0);
            Assert.NotNull(left.Node);
            Assert.Equal(find.Node, left.Node.Parent);
            Assert.Equal(4, left.Node.NodeValue);
            Assert.Equal(0, left.Node.NodeKey);
            Assert.Null(left.Node.LeftChild);
            Assert.Null(left.Node.RightChild);
            Assert.True(left.NodeHasKey);
            
            Assert.Equal(left.Node, find.Node.LeftChild);
            Assert.Equal(right.Node, find.Node.RightChild);
            
            
            res = tree.AddKeyValue(0, 4);
            Assert.False(res);
        }
        
        [Fact]
        public void AddKeyValueTests_TenElementsOnlyToRight_ShouldAdd()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(1, 2, null));
            
            //Act
            for (int i = 2; i <= 12; i++)
            {
                var foundNode = tree.FindNodeByKey(i);
                Assert.False(foundNode.NodeHasKey);
                tree.AddKeyValue(i, i * 2);
            }
            
            //Assert
            var node = tree.FindNodeByKey(1);
            Assert.NotNull(node.Node);
            
            Assert.Equal(12, tree.Count());
            
            for (int i = 2; i <= 12; i++)
            {
                var foundNode = tree.FindNodeByKey(i);
                Assert.NotNull(foundNode.Node);
                Assert.True(foundNode.NodeHasKey);
                Assert.Equal(i, foundNode.Node.NodeKey);
                Assert.Equal(i * 2, foundNode.Node.NodeValue);
            }
            
            node = tree.FindNodeByKey(25);
            Assert.NotNull(node.Node);
            Assert.Equal(12, node.Node.NodeKey);
            Assert.Equal(24, node.Node.NodeValue);
            Assert.Null(node.Node.LeftChild);
            Assert.Null(node.Node.RightChild);
            Assert.NotNull(node.Node.Parent);
            Assert.False(node.ToLeft);
        }
        
        [Fact]
        public void AddKeyValueTests_TenElementsOnlyToRight_ShouldNotAdd()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(1, 2, null));
            
            //Act
            for (int i = 2; i <= 12; i++)
            {
                var foundNode = tree.FindNodeByKey(i);
                Assert.False(foundNode.NodeHasKey);
                tree.AddKeyValue(i, i * 2);
            }
            
            //Assert
            var res = tree.AddKeyValue(12, 24);
            Assert.False(res);
        }
        
        [Fact]
        public void AddKeyValueTests_TenElementsLeftSubtree_ShouldAdd()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(250, 2, null));
            
            //Act
            for (int i = 2; i <= 12; i++)
            {
                var foundNode = tree.FindNodeByKey(i);
                Assert.False(foundNode.NodeHasKey);
                tree.AddKeyValue(i, i * 2);
            }
            
            //Assert
            var node = tree.FindNodeByKey(250);
            Assert.NotNull(node.Node);
            
            Assert.Equal(12, tree.Count());
            
            for (int i = 2; i <= 12; i++)
            {
                var foundNode = tree.FindNodeByKey(i);
                Assert.NotNull(foundNode.Node);
                Assert.True(foundNode.NodeHasKey);
                Assert.Equal(i, foundNode.Node.NodeKey);
                Assert.Equal(i * 2, foundNode.Node.NodeValue);
            }
            
            node = tree.FindNodeByKey(25);
            Assert.NotNull(node.Node);
            Assert.Equal(12, node.Node.NodeKey);
            Assert.Equal(24, node.Node.NodeValue);
            Assert.Null(node.Node.LeftChild);
            Assert.Null(node.Node.RightChild);
            Assert.NotNull(node.Node.Parent);
            Assert.False(node.ToLeft);
        }
        
        [Fact]
        public void AddKeyValueTests_TenElementsLeftSubtree_ShouldNotAdd()
        {
            //Arrange
            var tree = new BST<int>(new BSTNode<int>(250, 2, null));
            
            //Act
            for (int i = 2; i <= 12; i++)
            {
                tree.AddKeyValue(i, i * 2);
            }
            
            //Assert
            var res = tree.AddKeyValue(250, 2);
            Assert.False(res);
        }
    }
}