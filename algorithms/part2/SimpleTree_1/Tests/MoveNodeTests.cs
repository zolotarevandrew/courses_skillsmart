using System.Collections.Generic;
using System.Linq;
using AlgorithmsDataStructures2;
using Xunit;

namespace SimpleTree_1.Tests
{
    public partial class SimpleTreeTests
    {
        [Fact]
        public void MoveNode_MoveFromCurrentPlaceToCurrentPlace_ShouldMove()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);
            var node = new SimpleTreeNode<int>(6, tree.Root);
            tree.AddChild(tree.Root, node);
            
            //Act
            tree.MoveNode(node, tree.Root);
            
            //Assert
            Assert.Equal(5, tree.Root.NodeValue);
            var treeCh = tree.Root.Children;
            Assert.Equal(1, treeCh.Count);
            Assert.Equal(6, treeCh[0].NodeValue);
            Assert.Equal(2, tree.Count());
            Assert.Equal(1, tree.LeafCount());
            
            AssetNodeLevel(tree.GetAllNodes(), 2, new List<(int, int)> { (5, 1), (6, 2) });
        }
        
        [Fact]
        public void MoveNode_MoveFromSubtree_ShouldMove()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);
            
            var node = new SimpleTreeNode<int>(6, tree.Root);
            tree.AddChild(tree.Root, node);
            
            var node1 = new SimpleTreeNode<int>(7, node);
            tree.AddChild(node1, new SimpleTreeNode<int>(8, node1));
            tree.AddChild(node, node1);
            
            //Act
            tree.MoveNode(node1, tree.Root);
            
            //Assert
            Assert.Equal(5, tree.Root.NodeValue);
            var treeCh = tree.Root.Children;
            Assert.Equal(2, treeCh.Count);
            
            Assert.Equal(6, treeCh[0].NodeValue);
            Assert.Null(treeCh[0].Children);
            
            Assert.Equal(7, treeCh[1].NodeValue);
            Assert.Equal(1, treeCh[1].Children.Count);
            
            Assert.Equal(8, treeCh[1].Children[0].NodeValue);
            Assert.Null(treeCh[1].Children[0].Children);
            
            Assert.Equal(4, tree.Count());
            Assert.Equal(2, tree.LeafCount());
            
            AssetNodeLevel(tree.GetAllNodes(), 4, new List<(int, int)> { (5, 1), (6, 2), (7, 2), (8, 3) });
        }
    }
}