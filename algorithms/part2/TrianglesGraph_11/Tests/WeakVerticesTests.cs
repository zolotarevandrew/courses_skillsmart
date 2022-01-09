using AlgorithmsDataStructures2;
using Xunit;

namespace TrianglesGraph_11.Tests
{
    public class WeakVerticesTests
    {
        [Fact] 
        public void WeakVertices_ThreeNodesNoWaysGraph_ShouldReturnAllVertex()
        {
            var graph = new SimpleGraph<int>(3);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            

            var res = graph.WeakVertices();
            Assert.Equal(3, res.Count);
            Assert.Equal(1, res[0].Value);
            Assert.Equal(2, res[1].Value);
            Assert.Equal(3, res[2].Value);
        }
        
        [Fact]
        public void WeakVertices_ThreeNodesHasOneTriangle_ShouldReturnEmpty()
        {
            var graph = new SimpleGraph<int>(3);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            

            var res = graph.WeakVertices();
            Assert.Equal(0, res.Count);
        }
        
        [Fact]
        public void WeakVertices_ThreeNodesHasNoTriangle_ShouldReturnAllNodes()
        {
            var graph = new SimpleGraph<int>(3);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);


            var res = graph.WeakVertices();
            Assert.Equal(3, res.Count);
            Assert.Equal(1, res[0].Value);
            Assert.Equal(2, res[1].Value);
            Assert.Equal(3, res[2].Value);
        }
        
        [Fact]
        public void WeakVertices_FourNodesHasOneTriangleAndWeakNode_ShouldReturnNode()
        {
            var graph = new SimpleGraph<int>(4);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(0, 3);
            

            var res = graph.WeakVertices();
            Assert.Equal(1, res.Count);
            Assert.Equal(4, res[0].Value);
        }
        
        [Fact]
        public void WeakVertices_FourNodesHasTwoTriangleAndNoWeakNode_ShouldReturnEmpty()
        {
            var graph = new SimpleGraph<int>(4);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(0, 3);
            graph.AddEdge(3, 1);
            

            var res = graph.WeakVertices();
            Assert.Equal(0, res.Count);
        }
        
        [Fact]
        public void WeakVertices_FiveNodesHasTwoTrianglesAndWeakNode_ShouldReturnNode()
        {
            var graph = new SimpleGraph<int>(5);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(4, 2);
            

            var res = graph.WeakVertices();
            Assert.Equal(1, res.Count);
            Assert.Equal(4, res[0].Value);
        }
        
        [Fact]
        public void WeakVertices_SixNodesHasTwoTrianglesAndTwoWeakNodes_ShouldReturnNodes()
        {
            var graph = new SimpleGraph<int>(6);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(4, 2);
            graph.AddEdge(1, 5);
            

            var res = graph.WeakVertices();
            Assert.Equal(2, res.Count);
            Assert.Equal(4, res[0].Value);
            Assert.Equal(6, res[1].Value);
        }
        
        [Fact]
        public void WeakVertices_SevenNodesHasTwoTrianglesAndThreeWeakNodes_ShouldReturnNodes()
        {
            var graph = new SimpleGraph<int>(7);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            graph.AddVertex(7);
            
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(4, 2);
            graph.AddEdge(1, 5);
            graph.AddEdge(5, 6);
            

            var res = graph.WeakVertices();
            Assert.Equal(3, res.Count);
            Assert.Equal(4, res[0].Value);
            Assert.Equal(6, res[1].Value);
            Assert.Equal(7, res[2].Value);
        }
        
        [Fact]
        public void WeakVertices_EightNodesHasTwoTrianglesAndFourWeakNodes_ShouldReturnNodes()
        {
            var graph = new SimpleGraph<int>(8);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            graph.AddVertex(7);
            graph.AddVertex(8);
            
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 0);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(4, 2);
            graph.AddEdge(1, 5);
            graph.AddEdge(5, 6);
            graph.AddEdge(6, 7);
            

            var res = graph.WeakVertices();
            Assert.Equal(4, res.Count);
            Assert.Equal(4, res[0].Value);
            Assert.Equal(6, res[1].Value);
            Assert.Equal(7, res[2].Value);
            Assert.Equal(8, res[3].Value);
        }
        
        [Fact]
        public void WeakVertices_EightNodesHasThreeTrianglesAndOneWeakNode_ShouldReturnNode()
        {
            var graph = new SimpleGraph<int>(8);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            graph.AddVertex(7);
            graph.AddVertex(8);
            
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(4, 2);
            graph.AddEdge(1, 5);
            graph.AddEdge(5, 6);
            graph.AddEdge(6, 7);
            graph.AddEdge(7, 5);
            

            var res = graph.WeakVertices();
            Assert.Equal(1, res.Count);
            Assert.Equal(4, res[0].Value);
        }
        
        [Fact]
        public void WeakVertices_NineNodesHasThreeTrianglesAndTwoWeakNode_ShouldReturnNodes()
        {
            var graph = new SimpleGraph<int>(9);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            graph.AddVertex(7);
            graph.AddVertex(8);
            graph.AddVertex(9);
            
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(4, 2);
            graph.AddEdge(1, 5);
            graph.AddEdge(5, 6);
            graph.AddEdge(6, 7);
            graph.AddEdge(7, 5);
            graph.AddEdge(7, 8);
            

            var res = graph.WeakVertices();
            Assert.Equal(2, res.Count);
            Assert.Equal(4, res[0].Value);
            Assert.Equal(9, res[1].Value);
        }
        
        [Fact]
        public void WeakVertices_NineNodesHasFourTrianglesAndOneWeakNode_ShouldReturnNodes()
        {
            var graph = new SimpleGraph<int>(9);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            graph.AddVertex(7);
            graph.AddVertex(8);
            graph.AddVertex(9);

            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(4, 2);
            graph.AddEdge(1, 5);
            graph.AddEdge(5, 6);
            graph.AddEdge(6, 7);
            graph.AddEdge(7, 5);
            graph.AddEdge(7, 8);
            graph.AddEdge(8, 5);
            

            var res = graph.WeakVertices();
            Assert.Equal(1, res.Count);
            Assert.Equal(4, res[0].Value);
        }
        
        [Fact]
        public void WeakVertices_NineNodesHasFiveTrianglesNoWeakNodes_ShouldReturnEmpty()
        {
            var graph = new SimpleGraph<int>(9);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            graph.AddVertex(7);
            graph.AddVertex(8);
            graph.AddVertex(9);

            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(0, 3);
            graph.AddEdge(3, 1);
            graph.AddEdge(1, 4);
            graph.AddEdge(4, 2);
            graph.AddEdge(1, 5);
            graph.AddEdge(5, 6);
            graph.AddEdge(6, 7);
            graph.AddEdge(7, 5);
            graph.AddEdge(7, 8);
            graph.AddEdge(8, 5);
            

            var res = graph.WeakVertices();
            Assert.Equal(0, res.Count);
        }
    }
}