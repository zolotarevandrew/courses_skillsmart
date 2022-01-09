using System.Collections.Generic;
using System.Linq;
using AlgorithmsDataStructures2;
using Xunit;

namespace SimpleTree_1.Tests
{
    public partial class SimpleTreeTests
    {
        [Fact]
        public void GetAllNodes_EmptyTree_ShouldReturnRoot()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);
            
            //Act
            var res = tree.GetAllNodes();
            
            //Assert
            AssetGetAll(res, 1, new List<int> { 5 });
        }
        
        [Fact]
        public void GetAllNodes_TwoEqualNodes_ShouldReturnList()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);
            
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, tree.Root));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, tree.Root));
            
            //Act
            var res = tree.GetAllNodes();
            
            //Assert
            AssetGetAll(res, 3, new List<int> { 5, 2, 2 });
        }
        
        [Fact]
        public void GetAllNodes_TwoNodes_ShouldReturnList()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);
            
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, tree.Root));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(3, tree.Root));
            
            //Act
            var res = tree.GetAllNodes();
            
            //Assert
            AssetGetAll(res, 3, new List<int> { 5, 2, 3 });
        }
        
        [Fact]
        public void GetAllNodes_TwoNodesOneWithSubtree_ShouldReturnList()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);

            var node1 = new SimpleTreeNode<int>(2, tree.Root);
            tree.AddChild(node1, new SimpleTreeNode<int>(4, node1));
            
            tree.AddChild(tree.Root,node1);
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(3, tree.Root));
            
            //Act
            var res = tree.GetAllNodes();
            
            //Assert
            AssetGetAll(res, 4, new List<int> { 5, 2, 4, 3 });
        }
        
        [Fact]
        public void GetAllNodes_TwoNodesWithSubtree_ShouldReturnList()
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
            var res = tree.GetAllNodes();
            
            //Assert
            AssetGetAll(res, 5, new List<int> { 5, 2, 4, 3, 6 });
        }
        
        [Fact]
        public void GetAllNodes_NodesWithSubtree_ShouldReturnList()
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
            var res = tree.GetAllNodes();
            
            //Assert
            AssetGetAll(res, 6, new List<int> { 5, 2, 4, 8, 3, 6 });
        }
        
        [Fact]
        public void GetAllNodes_FromExample_ShouldReturnList()
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
            var res = tree.GetAllNodes();
            
            //Assert
            AssetGetAll(res, 9, new List<int> { 9, 4, 3, 6, 5, 7, 17, 22, 20 });
            Assert.Equal(4, tree.LeafCount());
            Assert.Equal(9, tree.Count());

            foreach (var item in res)
            {
                Assert.Equal(1, tree.FindNodesByValue(item.NodeValue).Count);
            }
        }
        
        private static void AssetGetAll(List<SimpleTreeNode<int>> res, int count, List<int> equal)
        {
            Assert.Equal(count, res.Count);
            int idx = 0;
            foreach (var item in res)
            {
                Assert.Equal(equal[idx], item.NodeValue);
                idx++;
            }
        }
    }
}