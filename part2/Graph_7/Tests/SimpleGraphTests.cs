using System;
using AlgorithmsDataStructures2;
using Xunit;

namespace Graph_7.Tests
{
    public class SimpleGraphTests
    {
        [Fact]
        public void AddVertex_EmptyGraph_ShouldAdd()
        {
            //Arrange
            var graph = new SimpleGraph(3);
            
            //Act
            graph.AddVertex(11);
            
            //Assert
            Assert.Equal(1, graph.VertexCount);
            Assert.Equal(11, graph.vertex[0].Value);
            Assert.False(graph.HasEdges(0));
        }
        
        [Fact]
        public void AddVertex_MoreThanSize_ShouldThrowException()
        {
            //Arrange
            var graph = new SimpleGraph(3);
            
            //Act
            graph.AddVertex(11);
            graph.AddVertex(12);
            graph.AddVertex(13);
            Assert.Throws<InvalidOperationException>(() => graph.AddVertex(16));
        }
        
        [Fact]
        public void AddVertexAndRemove_ShouldNotThrowException()
        {
            //Arrange
            var graph = new SimpleGraph(3);
            
            //Act
            graph.AddVertex(11);
            graph.AddVertex(12);
            graph.AddVertex(13);
            
            graph.RemoveVertex(1);
            graph.AddVertex(12);
            
            graph.RemoveVertex(0);
            graph.RemoveVertex(1);
            graph.RemoveVertex(2);
            
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
        }
        
        [Fact]
        public void AddEdge_TwoVertexAndEdges_ShouldHaveEdges()
        {
            //Arrange
            var graph = new SimpleGraph(3);
            graph.AddVertex(11);
            graph.AddVertex(12);
            
            Assert.Equal(2, graph.VertexCount);
            Assert.Equal(11, graph.vertex[0].Value);
            Assert.Equal(12, graph.vertex[1].Value);
            
            Assert.False(graph.HasEdges(0));
            Assert.False(graph.HasEdges(1));
            Assert.False(graph.IsEdge(0, 1));
            Assert.False(graph.IsEdge(1, 0));
            
            //Act
            graph.AddEdge(0, 1);

            //Assert
            Assert.True(graph.IsEdge(0, 1));
            Assert.True(graph.IsEdge(1, 0));
            Assert.True(graph.HasEdges(0));
            Assert.True(graph.HasEdges(1));
        }
        
        [Fact]
        public void IsEdge_ThreeVertexAndEdges_ShouldHaveEdges()
        {
            //Arrange
            var graph = new SimpleGraph(3);
            graph.AddVertex(11);
            graph.AddVertex(12);
            graph.AddVertex(13);
            
            Assert.Equal(3, graph.VertexCount);
            Assert.Equal(11, graph.vertex[0].Value);
            Assert.Equal(12, graph.vertex[1].Value);
            Assert.Equal(13, graph.vertex[2].Value);
            
            Assert.False(graph.HasEdges(0));
            Assert.False(graph.HasEdges(1));
            Assert.False(graph.HasEdges(2));
            
            //Act
            graph.AddEdge(0, 1);

            //Assert
            Assert.True(graph.IsEdge(0, 1));
            Assert.True(graph.IsEdge(1, 0));
            
            Assert.False(graph.IsEdge(2, 0));
            Assert.False(graph.IsEdge(0, 2));
            
            Assert.False(graph.IsEdge(2, 1));
            Assert.False(graph.IsEdge(1, 2));
            
            Assert.True(graph.HasEdges(0));
            Assert.True(graph.HasEdges(1));
            Assert.False(graph.HasEdges(2));
        }
        
        [Fact]
        public void RemoveEdge_ThreeVertexAndEdges_ShouldHaveEdges()
        {
            //Arrange
            var graph = new SimpleGraph(3);
            graph.AddVertex(11);
            graph.AddVertex(12);
            graph.AddVertex(13);

            //Act
            graph.AddEdge(0, 1);
            Assert.True(graph.IsEdge(0, 1));
            Assert.True(graph.IsEdge(1, 0));
            
            graph.RemoveEdge(0, 1);

            //Assert
            Assert.False(graph.IsEdge(0, 1));
            Assert.False(graph.IsEdge(1, 0));
            
            Assert.False(graph.IsEdge(2, 0));
            Assert.False(graph.IsEdge(0, 2));
            
            Assert.False(graph.IsEdge(2, 1));
            Assert.False(graph.IsEdge(1, 2));
            
            Assert.False(graph.HasEdges(0));
            Assert.False(graph.HasEdges(1));
            Assert.False(graph.HasEdges(2));
        }
        
        [Fact]
        public void RemoveVertex_ThreeVertexAndEdges_ShouldHaveEdges()
        {
            //Arrange
            var graph = new SimpleGraph(3);
            graph.AddVertex(11);
            graph.AddVertex(12);
            graph.AddVertex(13);

            //Act
            graph.AddEdge(0, 1);
            
            Assert.True(graph.IsEdge(0, 1));
            Assert.True(graph.IsEdge(1, 0));
            Assert.True(graph.HasEdges(0));
            
            graph.RemoveVertex(0);

            //Assert
            Assert.False(graph.IsEdge(0, 1));
            Assert.False(graph.IsEdge(1, 0));
            
            Assert.False(graph.IsEdge(2, 0));
            Assert.False(graph.IsEdge(0, 2));
            
            Assert.False(graph.IsEdge(2, 1));
            Assert.False(graph.IsEdge(1, 2));
            
            Assert.False(graph.HasEdges(0));
            Assert.False(graph.HasEdges(1));
            Assert.False(graph.HasEdges(2));
            
            Assert.Equal(2, graph.VertexCount);
            Assert.Null(graph.vertex[0]);
            Assert.Equal(12, graph.vertex[1].Value);
            Assert.Equal(13, graph.vertex[2].Value);
        }
    }
}