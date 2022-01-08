using System.Linq;
using AlgorithmsDataStructures2;
using Xunit;

namespace SimpleTree_1.Tests
{
    public partial class SimpleTreeTests
    {
        [Fact]
        public void Add_EmptyTree_ShouldAddChild()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);
            
            //Act
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(6, tree.Root));
            
            //Assert
            Assert.NotNull(tree.Root);
            
            Assert.Equal(5, tree.Root.NodeValue);
            Assert.NotNull(tree.Root.Children);
            Assert.Equal(1, tree.Root.Children.Count);

            var children = tree.Root.Children[0];
            Assert.NotNull(children);
            Assert.Equal(6, children.NodeValue);
            Assert.Null(children.Children);

            Assert.Equal(2,tree.Count());
            Assert.Equal(1,tree.LeafCount());
        }
        
        [Fact]
        public void Add_EmptyTreeSetParentNodeNull_ShouldAddChild()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);
            
            //Act
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(6, tree.Root));
            
            //Assert
            Assert.NotNull(tree.Root);
            
            Assert.Equal(5, tree.Root.NodeValue);
            Assert.NotNull(tree.Root.Children);
            Assert.Equal(1, tree.Root.Children.Count);

            var children = tree.Root.Children[0];
            Assert.NotNull(children);
            Assert.Equal(6, children.NodeValue);
            Assert.Null(children.Children);

            Assert.Equal(2,tree.Count());
            Assert.Equal(1,tree.LeafCount());
        }
        
        [Fact]
        public void Add_FourNodes_ShouldAddChild()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);
            
            //Act
            var addNode = new SimpleTreeNode<int>(6, tree.Root);
            tree.AddChild(tree.Root, addNode);
            
            tree.AddChild(addNode, new SimpleTreeNode<int>(7, addNode));
            tree.AddChild(addNode, new SimpleTreeNode<int>(8, addNode));
            
            //Assert
            Assert.Equal(5, tree.Root.NodeValue);
            Assert.NotNull(tree.Root.Children);
            
            var children = tree.Root.Children[0];
            Assert.NotNull(children);
            Assert.Equal(6, children.NodeValue);
            Assert.NotNull(children.Children);
            Assert.Equal(2, children.Children.Count);
            Assert.Equal(7, children.Children[0].NodeValue);
            Assert.Equal(8, children.Children[1].NodeValue);

            Assert.Equal(4,tree.Count());
            Assert.Equal(2,tree.LeafCount());
        }
        
        [Fact]
        public void Add_SevenNodes_ShouldAddChild()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(9, null);
            var tree = new SimpleTree<int>(root);
            
            //Act
            var node1 = new SimpleTreeNode<int>(4, tree.Root);
            tree.AddChild(tree.Root, node1);
            
            var node2 = new SimpleTreeNode<int>(17, tree.Root);
            tree.AddChild(tree.Root, node2);
            
            tree.AddChild(node2, new SimpleTreeNode<int>(3, node2));
            tree.AddChild(node2, new SimpleTreeNode<int>(6, node2));
            
            tree.AddChild(node1, new SimpleTreeNode<int>(17, node1));
            tree.AddChild(node1, new SimpleTreeNode<int>(22, node1));

            //Assert
            Assert.Equal(9, tree.Root.NodeValue);
            var treeCh = tree.Root.Children;
            Assert.NotNull(treeCh);
            Assert.Equal(2, treeCh.Count);
            Assert.Equal(4, treeCh[0].NodeValue);
            Assert.Equal(17, treeCh[1].NodeValue);

            var ch1 = treeCh[0];
            Assert.NotNull(ch1.Children);
            Assert.Equal(2, ch1.Children.Count);
            Assert.Equal(17, ch1.Children[0].NodeValue);
            Assert.Equal(22, ch1.Children[1].NodeValue);
            
            var ch2 = treeCh[1];
            Assert.NotNull(ch2.Children);
            Assert.Equal(2, ch2.Children.Count);
            Assert.Equal(3, ch2.Children[0].NodeValue);
            Assert.Equal(6, ch2.Children[1].NodeValue);

            Assert.Equal(7,tree.Count());
            Assert.Equal(4,tree.LeafCount());
        }
    }
}