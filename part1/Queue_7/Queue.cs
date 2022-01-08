using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Queue<T>
    {
        private List<T> _store;
        public Queue()
        {
            _store = new List<T>();
        }

        public void Enqueue(T item)
        {
            _store.Add(item);
        }

        public T Dequeue()
        {
            if (Size() == 0) return default(T);
            var index = 0;
            var item = _store[index];
            _store.RemoveAt(index);
            return item;
        }

        public int Size()
        {
            return _store.Count;
        }

    }
}