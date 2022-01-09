using System.Collections.Generic;
using AlgorithmsDataStructures2;
using Xunit;

namespace EvenTrees_8.Tests
{
    public class EvenTreesTests
    {
        [Fact]
        public void EvenTrees_TreeEmpty_ShouldReturnEmpty()
        {
            //Arrange
            var tree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));
            
            //Act
            var res = tree.EvenTrees();
            
            //Assert
            Assert.Equal(0, res.Count);
        }
        
        [Fact]
        public void EvenTrees_TreeHasOneNode_ShouldReturnEmpty()
        {
            //Arrange
            var tree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, tree.Root));
            
            //Act
            var res = tree.EvenTrees();
            
            //Assert
            Assert.Equal(0, res.Count);
        }
        
        [Fact]
        public void EvenTrees_TreeHasThreeNode_ShouldReturnEmpty()
        {
            //Arrange
            var tree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(2, tree.Root));
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(3, tree.Root));
            
            //Act
            var res = tree.EvenTrees();
            
            //Assert
            Assert.Equal(0, res.Count);
        }
        
        [Fact]
        public void EvenTrees_TreeHasTwoEvenTrees_ShouldReturnOneEdge()
        {
            //Arrange
            var tree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));

            var node1 = new SimpleTreeNode<int>(2, tree.Root);
            tree.AddChild(node1, new SimpleTreeNode<int>(5, node1));
            tree.AddChild(node1, new SimpleTreeNode<int>(7, node1));
            
            tree.AddChild(tree.Root, node1);

            var node2 = new SimpleTreeNode<int>(3, tree.Root);
            tree.AddChild(node2, new SimpleTreeNode<int>(4, node2));
            tree.AddChild(tree.Root, node2);
            
            //Act
            var res = tree.EvenTrees();
            
            //Assert
            AssertEvenNodes(res, new List<int> {1, 3});
        }
        
        [Fact]
        public void EvenTrees_TreeHasThreeEvenTrees_ShouldReturnTwoEdges()
        {
            //Arrange
            var tree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));

            var node1 = new SimpleTreeNode<int>(2, tree.Root);
            tree.AddChild(node1, new SimpleTreeNode<int>(5, node1));
            tree.AddChild(node1, new SimpleTreeNode<int>(7, node1));
            
            tree.AddChild(tree.Root, node1);

            var node2 = new SimpleTreeNode<int>(3, tree.Root);
            tree.AddChild(node2, new SimpleTreeNode<int>(4, node2));
            tree.AddChild(tree.Root, node2);

            var node3 = new SimpleTreeNode<int>(6, tree.Root);
            var node31 = new SimpleTreeNode<int>(8, node3);
            tree.AddChild(node31, new SimpleTreeNode<int>(9, node31));
            tree.AddChild(node31, new SimpleTreeNode<int>(10, node31));
            tree.AddChild(node3, node31);
            
            tree.AddChild(tree.Root, node3);
            
            //Act
            var res = tree.EvenTrees();
            
            //Assert
            AssertEvenNodes(res, new List<int> {1, 3, 1, 6});
        }
        
        [Fact]
        public void EvenTrees_TreeHasThreeEvenTreesAndFourSubtrees_ShouldReturnTwoEdges()
        {
            //Arrange
            var tree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));

            var node1 = new SimpleTreeNode<int>(2, tree.Root);
            tree.AddChild(node1, new SimpleTreeNode<int>(5, node1));
            tree.AddChild(node1, new SimpleTreeNode<int>(7, node1));
            
            tree.AddChild(tree.Root, node1);

            var node2 = new SimpleTreeNode<int>(3, tree.Root);
            tree.AddChild(node2, new SimpleTreeNode<int>(4, node2));
            tree.AddChild(tree.Root, node2);

            var node3 = new SimpleTreeNode<int>(6, tree.Root);
            var node31 = new SimpleTreeNode<int>(8, node3);
            tree.AddChild(node31, new SimpleTreeNode<int>(9, node31));
            tree.AddChild(node31, new SimpleTreeNode<int>(10, node31));
            tree.AddChild(node3, node31);
            
            
            
            tree.AddChild(tree.Root, node3);
            tree.AddChild(tree.Root, new SimpleTreeNode<int>(11, tree.Root));
            
            //Act
            var res = tree.EvenTrees();
            
            //Assert
            AssertEvenNodes(res, new List<int> {1, 3, 1, 6});
        }
        
        [Fact]
        public void EvenTrees_TreeHasFourEvenTreesAndFourSubtrees_ShouldReturnThreeEdges()
        {
            //Arrange
            var tree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));

            var node1 = new SimpleTreeNode<int>(2, tree.Root);
            tree.AddChild(node1, new SimpleTreeNode<int>(5, node1));
            tree.AddChild(node1, new SimpleTreeNode<int>(7, node1));
            
            tree.AddChild(tree.Root, node1);

            var node2 = new SimpleTreeNode<int>(3, tree.Root);
            tree.AddChild(node2, new SimpleTreeNode<int>(4, node2));
            tree.AddChild(tree.Root, node2);

            var node3 = new SimpleTreeNode<int>(6, tree.Root);
            var node31 = new SimpleTreeNode<int>(8, node3);
            tree.AddChild(node31, new SimpleTreeNode<int>(9, node31));
            tree.AddChild(node31, new SimpleTreeNode<int>(10, node31));
            tree.AddChild(node3, node31);
            
            
            
            tree.AddChild(tree.Root, node3);
            var node4 = new SimpleTreeNode<int>(11, tree.Root);
            tree.AddChild(node4, new SimpleTreeNode<int>(12, node4));
            tree.AddChild(tree.Root, node4);
            
            //Act
            var res = tree.EvenTrees();
            
            //Assert
            AssertEvenNodes(res, new List<int> {1, 3, 1, 6, 1, 11});
        }
        
        [Fact]
        public void EvenTrees_Tree2EvenTreesAndFourSubtrees_ShouldReturn2Edges()
        {
            //Arrange
            var tree = new SimpleTree<int>(new SimpleTreeNode<int>(1, null));

            var node1 = new SimpleTreeNode<int>(2, tree.Root);
            tree.AddChild(node1, new SimpleTreeNode<int>(5, node1));
            tree.AddChild(tree.Root, node1);

            var node2 = new SimpleTreeNode<int>(3, tree.Root);
            tree.AddChild(tree.Root, node2);

            var node3 = new SimpleTreeNode<int>(6, tree.Root);
            var node31 = new SimpleTreeNode<int>(8, node3);
            tree.AddChild(node31, new SimpleTreeNode<int>(9, node31));
            tree.AddChild(node3, node31);
            
            
            tree.AddChild(tree.Root, node3);
            var node4 = new SimpleTreeNode<int>(11, tree.Root);
            tree.AddChild(tree.Root, node4);
            
            //Act
            var res = tree.EvenTrees();
            
            //Assert
            AssertEvenNodes(res, new List<int> { 1, 2, 6, 8 });
        }

        void AssertEvenNodes<T>(List<T> evenNodes, List<T> expected)
        {
            Assert.Equal(expected.Count, evenNodes.Count);
            for (int i = 0; i < evenNodes.Count; i++)
            {
                Assert.Equal(evenNodes[i], expected[i]);
            }
        }
    }
}