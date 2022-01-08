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
        
        struct VertexWrapper<T>
        {
            public Vertex<T> Value { get; private set; }
            public int Idx { get; private set; }
            public List<Vertex<T>> Path { get; private set; }
            public VertexWrapper(Vertex<T> value, int idx)
            {
                Value = value;
                Idx = idx;
                Path = new List<Vertex<T>>();
            }
        }

        public List<Vertex<T>> BreadthFirstSearch(int VFrom, int VTo)
        {
            ClearHits();

            var queue = new Queue<VertexWrapper<T>>();
            var item = new VertexWrapper<T>(vertex[VFrom], VFrom);
            item.Value.Hit = true;
            item.Path.Add(item.Value);
            queue.Enqueue(item);

            var path = new List<Vertex<T>>();
            while (queue.Count > 0)
            {
                var curV = queue.Dequeue();
                for (int i = 0; i < max_vertex; i++)
                {
                    if (!IsEdge(curV.Idx, i)) continue;

                    if (i == VTo)
                    {
                        path.AddRange(curV.Path);
                        path.Add(vertex[VTo]);
                        return path;
                    }

                    if (vertex[i].Hit) continue;
                    
                    vertex[i].Hit = true;
                    var wrapper = new VertexWrapper<T>(vertex[i], i);
                    wrapper.Path.AddRange(curV.Path);
                    wrapper.Path.Add(wrapper.Value);
                    queue.Enqueue(wrapper);
                }
            }

            return new List<Vertex<T>>();
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