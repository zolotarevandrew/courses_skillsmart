using System.Linq;
using AlgorithmsDataStructures2;
using Xunit;

namespace BalancedBinarySearchTree_5.Tests
{
    public partial class BalancedBSTTests
    {
        [Fact]
        public void GenerateTree_OneItem_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BalancedBST();
            
            //Act
            tree.GenerateTree(new int[] { 1 });
            
            //Assert
            Assert.True(tree.IsBalanced(tree.Root));
            var root = tree.Root;
            Assert.NotNull(root);
            Assert.Null(root.Parent);
            Assert.Null(root.LeftChild);
            Assert.Null(root.RightChild);
            Assert.Equal(1, root.NodeKey);
            Assert.Equal(0, root.Level);
        }
        
        [Fact]
        public void GenerateTree_TwoItems_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BalancedBST();
            
            //Act
            tree.GenerateTree(new int[] { 2, 1 });
            
            //Assert
            Assert.True(tree.IsBalanced(tree.Root));
            var root = tree.Root;
            Assert.NotNull(root);
            Assert.Null(root.Parent);
            Assert.NotNull(root.LeftChild);
            Assert.Null(root.RightChild);
            Assert.Equal(2, root.NodeKey);
            Assert.Equal(0, root.Level);
            
            var left = tree.Root.LeftChild;
            Assert.NotNull(left);
            Assert.Equal(root, left.Parent);
            Assert.Null(left.LeftChild);
            Assert.Null(left.RightChild);
            Assert.Equal(1, left.NodeKey);
            Assert.Equal(1, left.Level);
        }
        
        [Fact]
        public void GenerateTree_ThreeItems_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BalancedBST();
            
            //Act
            tree.GenerateTree(new int[] { 2, 1, 3 });
            
            //Assert
            Assert.True(tree.IsBalanced(tree.Root));
            var root = tree.Root;
            Assert.NotNull(root);
            Assert.Null(root.Parent);
            Assert.NotNull(root.LeftChild);
            Assert.NotNull(root.RightChild);
            Assert.Equal(2, root.NodeKey);
            Assert.Equal(0, root.Level);
            
            var left = tree.Root.LeftChild;
            Assert.NotNull(left);
            Assert.Equal(root, left.Parent);
            Assert.Null(left.LeftChild);
            Assert.Null(left.RightChild);
            Assert.Equal(1, left.NodeKey);
            Assert.Equal(1, left.Level);
            
            var right = tree.Root.RightChild;
            Assert.NotNull(right);
            Assert.Equal(root, right.Parent);
            Assert.Null(right.LeftChild);
            Assert.Null(right.RightChild);
            Assert.Equal(3, right.NodeKey);
            Assert.Equal(1, right.Level);
        }

        [Fact]
        public void GenerateTree_SevenItems_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BalancedBST();
            
            //Act
            tree.GenerateTree(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            
            //Assert
            Assert.True(tree.IsBalanced(tree.Root));
            var root = tree.Root;
            Assert.NotNull(root);
            Assert.NotNull(root.LeftChild);
            Assert.NotNull(root.RightChild);
            Assert.Null(root.Parent);
            Assert.Equal(0, root.Level);
            Assert.Equal(4, root.NodeKey);
            
            var rootLeft = root.LeftChild;
            Assert.NotNull(rootLeft);
            Assert.NotNull(rootLeft.LeftChild);
            Assert.NotNull(rootLeft.RightChild);
            Assert.Equal(root, rootLeft.Parent);
            Assert.Equal(1, rootLeft.Level);
            Assert.Equal(2, rootLeft.NodeKey);
            
            var leftRootLeft = rootLeft.LeftChild;
            Assert.NotNull(leftRootLeft);
            Assert.Null(leftRootLeft.LeftChild);
            Assert.Null(leftRootLeft.RightChild);
            Assert.Equal(rootLeft, leftRootLeft.Parent);
            Assert.Equal(2, leftRootLeft.Level);
            Assert.Equal(1, leftRootLeft.NodeKey);
            
            var rightRootLeft = rootLeft.RightChild;
            Assert.NotNull(rightRootLeft);
            Assert.Null(rightRootLeft.LeftChild);
            Assert.Null(rightRootLeft.RightChild);
            Assert.Equal(rootLeft, rightRootLeft.Parent);
            Assert.Equal(2, rightRootLeft.Level);
            Assert.Equal(3, rightRootLeft.NodeKey);
            
            
            var rootRight = root.RightChild;
            Assert.NotNull(rootRight);
            Assert.NotNull(rootRight.LeftChild);
            Assert.NotNull(rootRight.RightChild);
            Assert.Equal(root, rootRight.Parent);
            Assert.Equal(1, rootRight.Level);
            Assert.Equal(6, rootRight.NodeKey);
            
            var leftRootRight = rootRight.LeftChild;
            Assert.NotNull(leftRootRight);
            Assert.Null(leftRootRight.LeftChild);
            Assert.Null(leftRootRight.RightChild);
            Assert.Equal(rootRight, leftRootRight.Parent);
            Assert.Equal(2, leftRootRight.Level);
            Assert.Equal(5, leftRootRight.NodeKey);
            
            var rightRootRight = rootRight.RightChild;
            Assert.NotNull(rightRootRight);
            Assert.Null(rightRootRight.LeftChild);
            Assert.Null(rightRootRight.RightChild);
            Assert.Equal(rootRight, rightRootRight.Parent);
            Assert.Equal(2, rightRootRight.Level);
            Assert.Equal(7, rightRootRight.NodeKey);
        }
        
        [Fact]
        public void GenerateTree_5Items_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BalancedBST();
            
            //Act
            tree.GenerateTree(new int[] { 1, 2, 3, 4, 5});
            
            //Assert
            Assert.True(tree.IsBalanced(tree.Root));
            var root = tree.Root;
            Assert.NotNull(root);
            Assert.Equal(0, root.Level);
        }
        
        [Fact]
        public void GenerateTree_15Items_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BalancedBST();
            
            //Act
            tree.GenerateTree(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            
            //Assert
            Assert.True(tree.IsBalanced(tree.Root));
            var root = tree.Root;
            Assert.NotNull(root);
            Assert.Equal(0, root.Level);
        }

        [Fact]
        public void GenerateTree_31Items_ShouldBeCorrect()
        {
            //Arrange
            var tree = new BalancedBST();
            
            //Act
            tree.GenerateTree(Enumerable.Range(1, 32).ToArray());
            
            //Assert
            Assert.True(tree.IsBalanced(tree.Root));
            var root = tree.Root;
            Assert.NotNull(root);
            Assert.Equal(0, root.Level);
        }
        
        [Fact]
        public void GenerateTree_For31Items_ShouldBeCorrect()
        {
            var tree = new BalancedBST();
            for (int i = 1; i < 32; i++)
            {
                tree.GenerateTree(Enumerable.Range(1, i).ToArray());
                Assert.True(tree.IsBalanced(tree.Root));
                Assert.Equal(0, tree.Root.Level);
            }
        }
    }
}