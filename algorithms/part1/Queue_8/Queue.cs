using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Queue<T>
    {
        private Stack<T> _stack1;
        private Stack<T> _stack2;
        public Queue()
        {
            _stack1 = new Stack<T>();
            _stack2 = new Stack<T>();
        }

        public void Enqueue(T item)
        {
            _stack1.Push(item);
        }

        public T Dequeue()
        {
            if (_stack2.Count == 0)
            {
                if (_stack1.Count == 0) return default(T);
                while (_stack1.Count > 0)
                {
                    _stack2.Push(_stack1.Pop());
                }
            }

            return _stack2.Pop();
        }

        public int Size()
        {
            return _stack1.Count + _stack2.Count;
        }
    }
}