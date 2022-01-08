using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    class Deque<T>
    {
        private LinkedList<T> _store;

        public Deque()
        {
            _store = new LinkedList<T>();
        }

        public void AddFront(T item)
        {
            _store.AddFirst(item);
        }

        public void AddTail(T item)
        {
            _store.AddLast(item);
        }

        public T RemoveFront()
        {
            if (Size() == 0) return default(T);
            var first = _store.First;
            _store.RemoveFirst();
            return first.Value;
        }

        public T RemoveTail()
        {
            if (Size() == 0) return default(T);
            
            var last = _store.Last;
            _store.RemoveLast();
            return last.Value;
        }

        public int Size()
        {
            return _store.Count;
        }
    }

}