using AlgorithmsDataStructures2;
using Xunit;

namespace BFSGraph_10.Tests
{
    public class BreadthFirstSearchTest
    {
        [Fact]
        public void BreadthFirstSearch_OneVertexNoWay_ShouldReturnEmpty()
        {
            //Arrange
            var graph = new SimpleGraph<int>(3);
            graph.AddVertex(1);
            
            //Act
            var search = graph.BreadthFirstSearch(0, 0);

            //Assert
            Assert.Equal(0, search.Count);
        }
        
        [Fact]
        public void BreadthFirstSearch_OneVertexWay_ShouldReturnWay()
        {
            //Arrange
            var graph = new SimpleGraph<int>(3);
            graph.AddVertex(1);
            graph.AddEdge(0, 0);
            
            //Act
            var search = graph.BreadthFirstSearch(0, 0);

            //Assert
            Assert.Equal(2, search.Count);
            Assert.Equal(1, search[0].Value);
            Assert.Equal(1, search[1].Value);
        }
        
        [Fact]
        public void BreadthFirstSearch_TwoVertexNoWay_ShouldReturnEmpty()
        {
            //Arrange
            var graph = new SimpleGraph<int>(3);
            graph.AddVertex(1);
            graph.AddVertex(2);
            
            //Act
            var search = graph.BreadthFirstSearch(0, 1);

            //Assert
            Assert.Equal(0, search.Count);
        }
        
        [Fact]
        public void BreadthFirstSearch_TwoVertexHasWay_ShouldReturnWay()
        {
            //Arrange
            var graph = new SimpleGraph<int>(3);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddEdge(0, 1);
            
            //Act
            var search = graph.BreadthFirstSearch(0, 1);

            //Assert
            Assert.Equal(2, search.Count);
            Assert.Equal(1, search[0].Value);
            Assert.Equal(2, search[1].Value);
        }
        
        [Fact]
        public void BreadthFirstSearch_ThreeVertexNoWay_ShouldReturnNoWay()
        {
            //Arrange
            var graph = new SimpleGraph<int>(3);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddEdge(0, 1);
            
            //Act
            var search = graph.BreadthFirstSearch(0, 2);

            //Assert
            Assert.Equal(0, search.Count);
        }
        
        [Fact]
        public void BreadthFirstSearch_ThreeVertexHasWay_ShouldReturnWay()
        {
            //Arrange
            var graph = new SimpleGraph<int>(3);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            
            //Act
            var search = graph.BreadthFirstSearch(0, 2);

            //Assert
            Assert.Equal(3, search.Count);
            Assert.Equal(1, search[0].Value);
            Assert.Equal(2, search[1].Value);
            Assert.Equal(3, search[2].Value);
        }
        
        [Fact]
        public void BreadthFirstSearch_FourVertexNoWay_ShouldReturnNoWay()
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
            var search = graph.BreadthFirstSearch(0, 3);

            //Assert
            Assert.Equal(0, search.Count);
        }
        
        [Fact]
        public void BreadthFirstSearch_FourVertexHasWay_ShouldReturnWay()
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
            var search = graph.BreadthFirstSearch(0, 3);
            Assert.Equal(4, search.Count);
            Assert.Equal(1, search[0].Value);
            Assert.Equal(2, search[1].Value);
            Assert.Equal(3, search[2].Value);
            Assert.Equal(4, search[3].Value);
        }
        
        [Fact]
        public void BreadthFirstSearch_FiveVertexHasWay_ShouldReturnNotWay()
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
            var search = graph.BreadthFirstSearch(3, 1);
            Assert.Equal(4, search.Count);
            Assert.Equal(4, search[0].Value);
            Assert.Equal(5, search[1].Value);
            Assert.Equal(3, search[2].Value);
            Assert.Equal(2, search[3].Value);
        }
        
        [Fact]
        public void BreadthFirstSearch_FiveVertexWithCyclicEdgeHasWay_ShouldReturnNotWay()
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
            var search = graph.BreadthFirstSearch(3, 1);
            Assert.Equal(4, search.Count);
            Assert.Equal(4, search[0].Value);
            Assert.Equal(5, search[1].Value);
            Assert.Equal(3, search[2].Value);
            Assert.Equal(2, search[3].Value);
        }
        
        [Fact]
        public void BreadthFirstSearch_FiveVertexWithCyclicEdge_ShouldReturnWay()
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
            var search = graph.BreadthFirstSearch(0, 3);
            Assert.Equal(5, search.Count);
            Assert.Equal(1, search[0].Value);
            Assert.Equal(2, search[1].Value);
            Assert.Equal(3, search[2].Value);
            Assert.Equal(5, search[3].Value);
            Assert.Equal(4, search[4].Value);
        }
        
        [Fact]
        public void BreadthFirstSearch_SixVertex5To2_ShouldReturnWay()
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
            var search = graph.BreadthFirstSearch(5, 2);
            Assert.Equal(4, search.Count);
            Assert.Equal(6, search[0].Value);
            Assert.Equal(1, search[1].Value);
            Assert.Equal(2, search[2].Value);
            Assert.Equal(3, search[3].Value);
        }
        
        [Fact]
        public void BreadthFirstSearch_SixVertex5To2HasShortestWay_ShouldReturnWay()
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
            graph.AddEdge(1, 5);
            graph.AddEdge(2, 4);
            graph.AddEdge(4, 3);
            graph.AddEdge(0, 5);
            
            //Act
            var search = graph.BreadthFirstSearch(5, 2);
            Assert.Equal(3, search.Count);
            Assert.Equal(6, search[0].Value);
            Assert.Equal(2, search[1].Value);
            Assert.Equal(3, search[2].Value);
        }
        
        [Fact]
        public void BreadthFirstSearch_SixVertex0To4HasShortestWay_ShouldReturnWay()
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
            graph.AddEdge(1, 5);
            graph.AddEdge(2, 4);
            graph.AddEdge(4, 3);
            graph.AddEdge(0, 5);
            graph.AddEdge(0, 2);
            
            //Act
            var search = graph.BreadthFirstSearch(0, 4);
            Assert.Equal(3, search.Count);
            Assert.Equal(1, search[0].Value);
            Assert.Equal(3, search[1].Value);
            Assert.Equal(5, search[2].Value);
        }
        
        [Fact]
        public void BreadthFirstSearch_SixVertexNoWay_ShouldReturnNoWay()
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
            graph.AddEdge(0, 5);
            graph.AddEdge(1, 5);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 4);

            //Act
            var search = graph.BreadthFirstSearch(0, 3);
            Assert.Equal(0, search.Count);
        }
    }
}