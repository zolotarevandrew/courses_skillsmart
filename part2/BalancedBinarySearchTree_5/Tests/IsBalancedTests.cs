using AlgorithmsDataStructures2;
using Xunit;

namespace BalancedBinarySearchTree_5.Tests
{
    public partial class BalancedBSTTests
    {
        [Fact]
        public void IsBalanced_8Elements_ShouldBeBalanced()
        {
            //Arrange
            var tree = new BalancedBST();
            
            //Act
            tree.GenerateTree(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            var isBalanced = tree.IsBalanced(tree.Root);
            
            //Assert
            Assert.True(isBalanced);
        }
        
        [Fact]
        public void IsBalanced_4Elements_ShouldBeBalanced()
        {
            //Arrange
            var tree = new BalancedBST();
            
            //Act
            tree.GenerateTree(new int[] { 1, 2, 3, 4 });
            var isBalanced = tree.IsBalanced(tree.Root);
            
            //Assert
            Assert.True(isBalanced);
        }
        
        [Fact]
        public void IsBalanced_4Elements_ShouldNotBeBalanced()
        {
            //Arrange
            var tree = new BalancedBST();
            
            //Act
            tree.Root = new BSTNode(0, null);
            tree.Root.LeftChild = new BSTNode(1, tree.Root);
            tree.Root.RightChild = new BSTNode(2, tree.Root);
            tree.Root.LeftChild.LeftChild = new BSTNode(1, tree.Root.LeftChild);
            tree.Root.LeftChild.LeftChild.LeftChild = new BSTNode(1, tree.Root.LeftChild.LeftChild);
            
            var isBalanced = tree.IsBalanced(tree.Root);
            
            //Assert
            Assert.False(isBalanced);
        }
        
        [Fact]
        public void IsBalanced_5Elements_ShouldNotBeBalanced()
        {
            //Arrange
            var tree = new BalancedBST();
            
            //Act
            tree.Root = new BSTNode(8, null);
            tree.Root.LeftChild = new BSTNode(4, tree.Root);
            tree.Root.RightChild = new BSTNode(10, tree.Root);
            tree.Root.LeftChild.LeftChild = new BSTNode(3, tree.Root.LeftChild);
            tree.Root.LeftChild.RightChild = new BSTNode(5, tree.Root.LeftChild);
            tree.Root.LeftChild.LeftChild.LeftChild = new BSTNode(2, tree.Root.LeftChild.LeftChild);

            var isBalanced = tree.IsBalanced(tree.Root);
            
            //Assert
            Assert.False(isBalanced);
        }
        
        [Fact]
        public void IsBalanced_4ElementsLeft_ShouldNotBeBalanced()
        {
            //Arrange
            var tree = new BalancedBST();
            
            //Act
            tree.Root = new BSTNode(0, null);
            tree.Root.LeftChild = new BSTNode(1, tree.Root);
            tree.Root.LeftChild.LeftChild = new BSTNode(1, tree.Root.LeftChild);
            tree.Root.LeftChild.LeftChild.LeftChild = new BSTNode(1, tree.Root.LeftChild.LeftChild);
            
            var isBalanced = tree.IsBalanced(tree.Root);
            
            //Assert
            Assert.False(isBalanced);
        }
        
        [Fact]
        public void IsBalanced_9Elements_ShouldNotBeBalanced()
        {
            //Arrange
            var tree = new BalancedBST();
            
            //Act
            tree.Root = new BSTNode(2, null);
            tree.Root.LeftChild = new BSTNode(7, tree.Root);
            tree.Root.RightChild = new BSTNode(5, tree.Root);
            tree.Root.LeftChild.LeftChild = new BSTNode(2, tree.Root.LeftChild);
            
            tree.Root.LeftChild.RightChild = new BSTNode(6, tree.Root.LeftChild);
            tree.Root.LeftChild.RightChild.LeftChild = new BSTNode(5, tree.Root.LeftChild.RightChild);
            tree.Root.LeftChild.RightChild.RightChild = new BSTNode(11, tree.Root.LeftChild.RightChild);
            
            tree.Root.RightChild.RightChild = new BSTNode(9, tree.Root.RightChild);
            tree.Root.RightChild.RightChild.LeftChild = new BSTNode(4, tree.Root.RightChild.RightChild);

            var isBalanced = tree.IsBalanced(tree.Root);
            
            //Assert
            Assert.False(isBalanced);
        }
        
        [Fact]
        public void IsBalanced_10Elements_ShouldBeBalanced()
        {
            //Arrange
            var tree = new BalancedBST();
            
            //Act
            tree.Root = new BSTNode(2, null);
            tree.Root.LeftChild = new BSTNode(7, tree.Root);
            tree.Root.RightChild = new BSTNode(5, tree.Root);
            tree.Root.LeftChild.LeftChild = new BSTNode(2, tree.Root.LeftChild);
            
            tree.Root.LeftChild.RightChild = new BSTNode(6, tree.Root.LeftChild);
            tree.Root.LeftChild.RightChild.LeftChild = new BSTNode(5, tree.Root.LeftChild.RightChild);
            tree.Root.LeftChild.RightChild.RightChild = new BSTNode(11, tree.Root.LeftChild.RightChild);
            
            tree.Root.RightChild.LeftChild = new BSTNode(4, tree.Root.RightChild);
            tree.Root.RightChild.RightChild = new BSTNode(9, tree.Root.RightChild);
            tree.Root.RightChild.RightChild.LeftChild = new BSTNode(4, tree.Root.RightChild.RightChild);

            var isBalanced = tree.IsBalanced(tree.Root);
            
            //Assert
            Assert.True(isBalanced);
        }
    }
}