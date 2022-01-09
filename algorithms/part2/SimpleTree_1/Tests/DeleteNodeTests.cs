using System.Linq;
using AlgorithmsDataStructures2;
using Xunit;

namespace SimpleTree_1.Tests
{
    public partial class SimpleTreeTests
    {
        [Fact]
        public void DeleteNode_NoChildren_ShouldBeCorrectTree()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(6, tree.Root));
            
            //Act
            
            tree.DeleteNode(tree.Root.Children[0]);
            
            //Assert
            
            Assert.Null(tree.Root.Children);
            Assert.Equal(1, tree.Count());
            Assert.Equal(1, tree.LeafCount());
        }
        
        [Fact]
        public void DeleteNode_WithChildren_ShouldBeCorrectTree()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);

            var addNode = new SimpleTreeNode<int>(6, tree.Root);
            tree.AddChild(addNode, new SimpleTreeNode<int>(5, addNode));
            tree.AddChild(addNode, new SimpleTreeNode<int>(6, addNode));
            
            tree.AddChild(tree.Root, addNode);
            
            //Act
            
            tree.DeleteNode(tree.Root.Children[0]);
            
            //Assert
            
            Assert.Null(tree.Root.Children);
            Assert.Equal(1, tree.Count());
            Assert.Equal(1, tree.LeafCount());
        }
        
        [Fact]
        public void DeleteNode_WithChildrenAndSubTree_ShouldBeCorrectTree()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);

            var addNode = new SimpleTreeNode<int>(6, tree.Root);
            tree.AddChild(addNode, new SimpleTreeNode<int>(5, addNode));

            var subNode = new SimpleTreeNode<int>(6, addNode);
            tree.AddChild(subNode, new SimpleTreeNode<int>(8, subNode));
            tree.AddChild(subNode, new SimpleTreeNode<int>(9, subNode));
            
            tree.AddChild(addNode, subNode);
            
            tree.AddChild(tree.Root, addNode);
            
            //Act
            
            tree.DeleteNode(tree.Root.Children[0]);
            
            //Assert
            
            Assert.Null(tree.Root.Children);
            Assert.Equal(1, tree.Count());
            Assert.Equal(1, tree.LeafCount());
        }
        
        [Fact]
        public void DeleteNode_SubTree_ShouldBeCorrectTree()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);

            var addNode = new SimpleTreeNode<int>(6, tree.Root);
            tree.AddChild(addNode, new SimpleTreeNode<int>(7, addNode));

            var subNode = new SimpleTreeNode<int>(10, addNode);
            tree.AddChild(subNode, new SimpleTreeNode<int>(8, subNode));
            tree.AddChild(subNode, new SimpleTreeNode<int>(9, subNode));
            
            tree.AddChild(addNode, subNode);
            
            tree.AddChild(tree.Root, addNode);
            
            //Act
            
            tree.DeleteNode(subNode);
            
            //Assert
            
            Assert.Equal(1, tree.Root.Children.Count);
            
            var rootCh = tree.Root.Children[0];
            Assert.Equal(6, rootCh.NodeValue);
            Assert.Equal(1, rootCh.Children.Count);
            Assert.Equal(7, rootCh.Children[0].NodeValue);
            
            Assert.Equal(3, tree.Count());
            Assert.Equal(1, tree.LeafCount());
        }
        
        [Fact]
        public void DeleteNode_DeleteThreeTimesFromRoot_ShouldBeCorrectTree()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);
            
            
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(8, tree.Root));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(9, tree.Root));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(10, tree.Root));
            
            //Act
            
            tree.DeleteNode(tree.Root.Children[0]);
            Assert.Equal(2, tree.Root.Children.Count);
            Assert.Equal(3, tree.Count());
            Assert.Equal(2, tree.LeafCount());
            
            tree.DeleteNode(tree.Root.Children[0]);
            Assert.Equal(1, tree.Root.Children.Count);
            Assert.Equal(2, tree.Count());
            Assert.Equal(1, tree.LeafCount());
            
            tree.DeleteNode(tree.Root.Children[0]);
            Assert.Null(tree.Root.Children);
            Assert.Equal(1, tree.Count());
            Assert.Equal(1, tree.LeafCount());
        }
    }
}