using System;
using System.Collections.Generic;

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

        struct VertexWrapper<T>
        {
            public Vertex<T> Value { get; private set; }
            public int Idx { get; private set; }
            public VertexWrapper(Vertex<T> value, int idx)
            {
                Value = value;
                Idx = idx;
            }
        }
        
        public List<Vertex<T>> DepthFirstSearch(int VFrom, int VTo)
        {
            var stack = new Stack<VertexWrapper<T>>();
            
            ClearHits();
            
            stack.Push(new VertexWrapper<T>(vertex[VFrom], VFrom));

            while (stack.Count > 0)
            {
                var curV = stack.Peek();
                curV.Value.Hit = true;

                if (IsEdge(curV.Idx, VTo))
                {
                    vertex[VTo].Hit = true;
                    stack.Push(new VertexWrapper<T>(vertex[VTo], VTo));
                    break;
                }

                var adjacent = GetNotVisitedAdjacent(curV.Idx);
                if (adjacent == null)
                {
                    stack.Pop();
                    continue;
                }
                
                var curIdx = adjacent.Value;
                stack.Push(new VertexWrapper<T>(vertex[curIdx], curIdx));
            }

            var lst = new List<Vertex<T>>();
            while (stack.Count > 0)
            {
                lst.Insert(0, stack.Pop().Value);    
            }

            return lst;
        }

        int? GetNotVisitedAdjacent(int v)
        {
            for (int i = 0; i < max_vertex; i++)
            {
                if (IsEdge(v, i) && !vertex[i].Hit) return i;
            }

            return null;
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