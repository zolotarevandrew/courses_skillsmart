using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures2
{
    public class Vertex<T>
    {
        public bool Hit;
        public T Value;
        public Vertex(T val)
        {
            Value = val;
            Hit = false;
        }
    }
  
    public class SimpleGraph<T>
    {
        public Vertex<T>[] vertex;
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
            vertex = new Vertex<T>[size];
            _vertexCount = 0;
        }
        
        public List<Vertex<T>> WeakVertices()
        {
            var res = new List<Vertex<T>>();
            for (int idx = 0; idx < max_vertex; idx++)
            {
                var curV = this.vertex[idx];
                if (curV == null) continue;

                if (!IsInTriangle(idx)) res.Add(curV);
            }
            return res;
        }

        public bool IsInTriangle(int checkV)
        {
            List<int> adjacents = new List<int>();
            for (int v = 0; v < max_vertex; v++)
            {
                if (IsEdge(checkV, v))
                {
                    adjacents.Add(v);   
                }
            }

            int shift = 1;
            for (int i = 0; i < adjacents.Count; i++)
            {
                for (int j = shift; j < adjacents.Count; j++)
                {
                    var adjFrom = adjacents[i];
                    var adjVTo = adjacents[j];
                    
                    bool isInCycle = adjFrom == adjVTo;
                    
                    if (IsEdge(adjFrom, adjVTo) && !isInCycle)
                    {
                        return true;
                    }
                }
                shift++;
            }

            return false;
        }

        public void AddVertex(T value)
        {
            if (_vertexCount == max_vertex)
                throw new InvalidOperationException("there is no free vertex");
            
            var found = vertex[_vertexCount];
            if (found == null)
            {
                vertex[_vertexCount] = new Vertex<T>(value);
            }
            else
            {
                for (int i = 0; i < max_vertex; i++)
                {
                    var item = vertex[i];
                    if (item == null)
                    {
                        vertex[i] = new Vertex<T>(value);
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
        
        private void ClearHits()
        {
            for (int i = 0; i < max_vertex; i++)
            {
                var v = vertex[i];
                if (v != null) v.Hit = false;
            }
        }
    }
}