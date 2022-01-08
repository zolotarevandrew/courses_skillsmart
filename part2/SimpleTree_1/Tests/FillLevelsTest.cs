using System.Collections.Generic;
using AlgorithmsDataStructures2;
using Xunit;

namespace SimpleTree_1.Tests
{
    public partial class SimpleTreeTests
    {
        [Fact]
        public void FillLevels_EmptyTree_ShouldReturnRoot()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);
            
            //Act
            
            //Assert
            AssetNodeLevel(tree.GetAllNodes(), 1, new List<(int, int)> { (5, 1) });
        }
        
        [Fact]
        public void FillLevels_TwoEqualNodes_ShouldReturnList()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);
            
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, tree.Root));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, tree.Root));
            
            //Act
            
            //Assert
            AssetNodeLevel(tree.GetAllNodes(), 3, new List<(int, int)> { (5, 1), (2, 2), (2, 2) });
        }
        
        [Fact]
        public void FillLevels_TwoNodes_ShouldReturnList()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);
            
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, tree.Root));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(3, tree.Root));
            
            //Act
            
            //Assert
            AssetNodeLevel(tree.GetAllNodes(), 3, new List<(int, int)> { (5, 1), (2, 2), (3, 2) });
        }
        
        [Fact]
        public void FillLevels_TwoNodesOneWithSubtree_ShouldReturnList()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);

            var node1 = new SimpleTreeNode<int>(2, tree.Root);
            tree.AddChild(node1, new SimpleTreeNode<int>(4, node1));
            
            tree.AddChild(tree.Root,node1);
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(3, tree.Root));
            
            //Act
            
            //Assert
            AssetNodeLevel(tree.GetAllNodes(), 4, new List<(int, int)> { (5, 1), (2, 2), (4, 3), (3, 2) });
        }
        
        [Fact]
        public void FillLevels_TwoNodesWithSubtree_ShouldReturnList()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);

            var node1 = new SimpleTreeNode<int>(2, tree.Root);
            tree.AddChild(node1, new SimpleTreeNode<int>(4, node1));
            
            tree.AddChild(tree.Root,node1);

            var node2 = new SimpleTreeNode<int>(3, tree.Root);
            tree.AddChild(node2, new SimpleTreeNode<int>(6, node2));
            tree.AddChild(tree.Root, node2);
            
            //Act

            //Assert
            AssetNodeLevel(tree.GetAllNodes(), 5, new List<(int, int)> { (5, 1), (2, 2), (4, 3), (3, 2), (6, 3) });
        }
        
        [Fact]
        public void FillLevels_NodesWithSubtree_ShouldReturnList()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);

            var node1 = new SimpleTreeNode<int>(2, tree.Root);
            var subNode1 = new SimpleTreeNode<int>(4, node1);
            tree.AddChild(subNode1 , new SimpleTreeNode<int>(8, subNode1));
            tree.AddChild(node1, subNode1);
            
            tree.AddChild(tree.Root,node1);

            var node2 = new SimpleTreeNode<int>(3, tree.Root);
            tree.AddChild(node2, new SimpleTreeNode<int>(6, node2));
            tree.AddChild(tree.Root, node2);
            
            //Act
            
            //Assert
            AssetNodeLevel(tree.GetAllNodes(), 6, new List<(int, int)> { (5, 1), (2, 2), (4, 3), (8, 4), (3, 2), (6, 3) });
        }
        
        [Fact]
        public void FillLevels_FromExample_ShouldReturnList()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(9, null);
            var tree = new SimpleTree<int>(root);

            var node1 = new SimpleTreeNode<int>(4, tree.Root);
            var subsubNode1 = new SimpleTreeNode<int>(6, node1);
            tree.AddChild(subsubNode1, new SimpleTreeNode<int>(5, subsubNode1));
            tree.AddChild(subsubNode1, new SimpleTreeNode<int>(7, subsubNode1));
            tree.AddChild(node1, new SimpleTreeNode<int>(3, node1));
            tree.AddChild(node1, subsubNode1);
            
            tree.AddChild(tree.Root,node1);

            var node2 = new SimpleTreeNode<int>(17, tree.Root);
            var subNode2 = new SimpleTreeNode<int>(22, node2);
            tree.AddChild(subNode2, new SimpleTreeNode<int>(20, subNode2));
            tree.AddChild(node2, subNode2);
            tree.AddChild(tree.Root, node2);
            
            //Act
            
            //Assert
            AssetNodeLevel(tree.GetAllNodes(), 9, new List<(int, int)> { (9, 1), (4, 2), (3, 3), (6, 3), (5, 4), (7, 4), (17, 2), (22, 3), (20, 4) });
        }
        
        public static void AssetNodeLevel(List<SimpleTreeNode<int>> res, int count, List<(int, int)> equal)
        {
            Assert.Equal(count, res.Count);
            int idx = 0;
            foreach (var item in res)
            {
                Assert.Equal(equal[idx].Item1, item.NodeValue);
                Assert.Equal(equal[idx].Item2, item.Level);
                idx++;
            }
        }
    }
}