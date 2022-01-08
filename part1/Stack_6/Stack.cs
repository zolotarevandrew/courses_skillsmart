using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        private LinkedList<T> _store;
        public Stack()
        {
            _store = new LinkedList<T>();
        }

        public int Size()
        {
            return _store.Count;
        }

        public T Pop()
        {
            if (Size() == 0) return default(T);
            T result = _store.First.Value;
            _store.RemoveFirst();
            return result;
        }
	  
        public void Push(T val)
        {
            _store.AddFirst(val);
        }

        public T Peek()
        {
            if (Size() == 0) return default(T);
            return _store.First.Value;
        }
    }

}