using System.Collections.Generic;
using System.Linq;
using AlgorithmsDataStructures2;
using Xunit;

namespace SimpleTree_1.Tests
{
    public partial class SimpleTreeTests
    {
        [Fact]
        public void FindNodesByValue_EmptyTree_ShouldReturnRoot()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);
            
            //Act
            var res = tree.FindNodesByValue(5);
            
            //Assert
            AssertFind(res, 1, 5);
        }

        [Fact]
        public void FindNodesByValue_FourNodes_ShouldReturnEmptyList()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);
            
            var addNode = new SimpleTreeNode<int>(6, tree.Root);
            tree.AddChild(tree.Root, addNode);
            
            tree.AddChild(addNode, new SimpleTreeNode<int>(7, addNode));
            tree.AddChild(addNode, new SimpleTreeNode<int>(8, addNode));
            
            //Act
            var find = tree.FindNodesByValue(15);
            
            //Assert

            AssertFind(find, 0, 15);
        }
        
        [Fact]
        public void FindNodesByValue_FourNodes_ShouldFindNode()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(5, null);
            var tree = new SimpleTree<int>(root);
            var addNode = new SimpleTreeNode<int>(6, tree.Root);
            tree.AddChild(tree.Root, addNode);
            
            tree.AddChild(addNode, new SimpleTreeNode<int>(7, addNode));
            tree.AddChild(addNode, new SimpleTreeNode<int>(8, addNode));

            //Act
            var find = tree.FindNodesByValue(5);
            //Assert
            
            AssertFind(find, 1, 5);
        }
        
        [Fact]
        public void FindNodesByValue_SevenNodes_ShouldFindNode()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(9, null);
            var tree = new SimpleTree<int>(root);
            var node1 = new SimpleTreeNode<int>(4, tree.Root);
            tree.AddChild(tree.Root, node1);
            
            var node2 = new SimpleTreeNode<int>(17, tree.Root);
            tree.AddChild(tree.Root, node2);
            
            tree.AddChild(node2, new SimpleTreeNode<int>(3, node2));
            tree.AddChild(node2, new SimpleTreeNode<int>(6, node2));
            
            tree.AddChild(node1, new SimpleTreeNode<int>(17, node1));
            tree.AddChild(node1, new SimpleTreeNode<int>(17, node1));
            
            //Act
            var found = tree.FindNodesByValue(17);

            //Assert
            AssertFind(found, 3, 17);
        }
        
        [Fact]
        public void FindNodesByValue_SevenNodes_ShouldReturnEmptyList()
        {
            //Arrange
            var root = new SimpleTreeNode<int>(9, null);
            var tree = new SimpleTree<int>(root);
            var node1 = new SimpleTreeNode<int>(4, tree.Root);
            tree.AddChild(tree.Root, node1);
            
            var node2 = new SimpleTreeNode<int>(17, tree.Root);
            tree.AddChild(tree.Root, node2);
            
            tree.AddChild(node2, new SimpleTreeNode<int>(3, node2));
            tree.AddChild(node2, new SimpleTreeNode<int>(6, node2));
            
            tree.AddChild(node1, new SimpleTreeNode<int>(17, node1));
            tree.AddChild(node1, new SimpleTreeNode<int>(22, node1));
            
            //Act
            var found = tree.FindNodesByValue(33);

            //Assert
            AssertFind(found, 0, 33);
        }
        
        private static void AssertFind(List<SimpleTreeNode<int>> res, int count, int value)
        {
            Assert.Equal(count, res.Count);
            foreach (var item in res)
            {
                Assert.Equal(value, item.NodeValue);
            }
        }
    }
}