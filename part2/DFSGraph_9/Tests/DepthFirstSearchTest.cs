using AlgorithmsDataStructures2;
using Xunit;

namespace DFSGraph_9.Tests
{
    public class DepthFirstSearchTest
    {
        [Fact]
        public void DepthFirstSearch_OneVertexNoWay_ShouldReturnEmpty()
        {
            //Arrange
            var graph = new SimpleGraph<int>(3);
            graph.AddVertex(1);
            
            //Act
            var search = graph.DepthFirstSearch(0, 0);

            //Assert
            Assert.Equal(0, search.Count);
        }
        
        [Fact]
        public void DepthFirstSearch_OneVertexWay_ShouldReturnWay()
        {
            //Arrange
            var graph = new SimpleGraph<int>(3);
            graph.AddVertex(1);
            graph.AddEdge(0, 0);
            
            //Act
            var search = graph.DepthFirstSearch(0, 0);

            //Assert
            Assert.Equal(2, search.Count);
            Assert.Equal(1, search[0].Value);
            Assert.Equal(1, search[1].Value);
        }
        
        [Fact]
        public void DepthFirstSearch_TwoVertexNoWay_ShouldReturnEmpty()
        {
            //Arrange
            var graph = new SimpleGraph<int>(3);
            graph.AddVertex(1);
            graph.AddVertex(2);
            
            //Act
            var search = graph.DepthFirstSearch(0, 1);

            //Assert
            Assert.Equal(0, search.Count);
        }
        
        [Fact]
        public void DepthFirstSearch_TwoVertexHasWay_ShouldReturnWay()
        {
            //Arrange
            var graph = new SimpleGraph<int>(3);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddEdge(0, 1);
            
            //Act
            var search = graph.DepthFirstSearch(0, 1);

            //Assert
            Assert.Equal(2, search.Count);
            Assert.Equal(1, search[0].Value);
            Assert.Equal(2, search[1].Value);
        }
        
        [Fact]
        public void DepthFirstSearch_ThreeVertexNoWay_ShouldReturnNoWay()
        {
            //Arrange
            var graph = new SimpleGraph<int>(3);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddEdge(0, 1);
            
            //Act
            var search = graph.DepthFirstSearch(0, 2);

            //Assert
            Assert.Equal(0, search.Count);
        }
        
        [Fact]
        public void DepthFirstSearch_ThreeVertexHasWay_ShouldReturnWay()
        {
            //Arrange
            var graph = new SimpleGraph<int>(3);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            
            //Act
            var search = graph.DepthFirstSearch(0, 2);

            //Assert
            Assert.Equal(3, search.Count);
            Assert.Equal(1, search[0].Value);
            Assert.Equal(2, search[1].Value);
            Assert.Equal(3, search[2].Value);
        }
        
        [Fact]
        public void DepthFirstSearch_FourVertexNoWay_ShouldReturnNoWay()
        {
            //Arrange
            var graph = new SimpleGraph<int>(4);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(0, 2);
            
            //Act
            var search = graph.DepthFirstSearch(0, 3);

            //Assert
            Assert.Equal(0, search.Count);
        }
        
        [Fact]
        public void DepthFirstSearch_FourVertexHasWay_ShouldReturnWay()
        {
            //Arrange
            var graph = new SimpleGraph<int>(4);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            
            //Act
            var search = graph.DepthFirstSearch(0, 3);
            Assert.Equal(4, search.Count);
            Assert.Equal(1, search[0].Value);
            Assert.Equal(2, search[1].Value);
            Assert.Equal(3, search[2].Value);
            Assert.Equal(4, search[3].Value);
        }
        
        [Fact]
        public void DepthFirstSearch_FiveVertexHasWay_ShouldReturnNotWay()
        {
            //Arrange
            var graph = new SimpleGraph<int>(5);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 4);
            graph.AddEdge(4, 3);
            
            //Act
            var search = graph.DepthFirstSearch(3, 1);
            Assert.Equal(4, search.Count);
            Assert.Equal(4, search[0].Value);
            Assert.Equal(5, search[1].Value);
            Assert.Equal(3, search[2].Value);
            Assert.Equal(2, search[3].Value);
        }
        
        [Fact]
        public void DepthFirstSearch_FiveVertexWithCyclicEdgeHasWay_ShouldReturnNotWay()
        {
            //Arrange
            var graph = new SimpleGraph<int>(5);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 1);
            graph.AddEdge(2, 4);
            graph.AddEdge(4, 3);
            
            //Act
            var search = graph.DepthFirstSearch(3, 1);
            Assert.Equal(4, search.Count);
            Assert.Equal(4, search[0].Value);
            Assert.Equal(5, search[1].Value);
            Assert.Equal(3, search[2].Value);
            Assert.Equal(2, search[3].Value);
        }
        
        [Fact]
        public void DepthFirstSearch_FiveVertexWithCyclicEdge_ShouldReturnWay()
        {
            //Arrange
            var graph = new SimpleGraph<int>(5);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 1);
            graph.AddEdge(2, 4);
            graph.AddEdge(4, 3);
            
            //Act
            var search = graph.DepthFirstSearch(0, 3);
            Assert.Equal(5, search.Count);
            Assert.Equal(1, search[0].Value);
            Assert.Equal(2, search[1].Value);
            Assert.Equal(3, search[2].Value);
            Assert.Equal(5, search[3].Value);
            Assert.Equal(4, search[4].Value);
        }
        
        [Fact]
        public void DepthFirstSearch_SixVertex_ShouldReturnWay()
        {
            //Arrange
            var graph = new SimpleGraph<int>(6);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 1);
            graph.AddEdge(2, 4);
            graph.AddEdge(4, 3);
            graph.AddEdge(0, 5);
            
            //Act
            var search = graph.DepthFirstSearch(5, 2);
            Assert.Equal(4, search.Count);
            Assert.Equal(6, search[0].Value);
            Assert.Equal(1, search[1].Value);
            Assert.Equal(2, search[2].Value);
            Assert.Equal(3, search[3].Value);
        }
    }
}