using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        private List<T> _store;
        public Stack()
        {
            _store = new List<T>();
        }

        public int Size()
        {
            return _store.Count;
        }

        public T Pop()
        {
            if (Size() == 0) return default(T);
            var index = _store.Count - 1;
            T result = _store[index];
            _store.RemoveAt(index);
            return result;
        }
	  
        public void Push(T val)
        {
            _store.Add(val);
        }

        public T Peek()
        {
            if (Size() == 0) return default(T);
            var index = _store.Count - 1;
            return _store[index];
        }
    }

}