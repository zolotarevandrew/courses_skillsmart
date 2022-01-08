using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Vertex
    {
        public int Value;
        public Vertex(int val)
        {
            Value = val;
        }
    }
  
    public class SimpleGraph
    {
        public Vertex [] vertex;
        public int [,] m_adjacency;
        public int max_vertex;
        
        int _vertexCount;

        public int VertexCount
        {
            get
            {
                return _vertexCount;
            }
        }
	
        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int [size,size];
            vertex = new Vertex [size];
            _vertexCount = 0;
        }
	
        public void AddVertex(int value)
        {
            if (_vertexCount == max_vertex)
                throw new InvalidOperationException("there is no free vertex");
            
            var found = vertex[_vertexCount];
            if (found == null)
            {
                vertex[_vertexCount] = new Vertex(value);
            }
            else
            {
                for (int i = 0; i < max_vertex; i++)
                {
                    var item = vertex[i];
                    if (item == null)
                    {
                        vertex[i] = new Vertex(value);
                        break;
                    }
                }
            }

            _vertexCount++;

        }

        public void RemoveVertex(int v)
        {
            vertex[v] = default;

            for (int i = 0; i < max_vertex; i++)
            {
                RemoveEdge(v, i);
            }

            _vertexCount--;
        }
	
        public bool IsEdge(int v1, int v2)
        {
            return m_adjacency[v1, v2] == 1 && m_adjacency[v2, v1] == 1;
        }

        public bool HasEdges(int v)
        {
            for (int i = 0; i < max_vertex; i++)
            {
                if (IsEdge(v, i)) return true;
            }

            return false;
        }
	
        public void AddEdge(int v1, int v2)
        {
            m_adjacency[v1, v2] = 1;
            m_adjacency[v2, v1] = 1;
        }
	
        public void RemoveEdge(int v1, int v2)
        {
            m_adjacency[v1, v2] = 0;
            m_adjacency[v2, v1] = 0;
        }
    }
}