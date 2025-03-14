using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace AlgorithmsDataStructures
{
    
    //microsoft reference
    class Deque<T>
    {
        private Stack<T> _head;
        private Queue<T> _tail;

        public Deque()
        {
            _head = new Stack<T>();
            _tail = new Queue<T>();
        }

        public void AddFront(T item)
        {
            _head.Push(item);
            _tail.Enqueue(item);
        }

        public void AddTail(T item)
        {
            var newHead = new Stack<T>();
            var newTail = new Queue<T>();
            newHead.Push(item);
            newTail.Enqueue(item);
            while (_tail.Count > 0)
            {
                var fromQueue = _tail.Dequeue();
                newHead.Push(fromQueue);
                newTail.Enqueue(fromQueue);
            }

            _head = newHead;
            _tail = newTail;
        }

        public T RemoveFront()
        {
            if (Size() == 0) return default(T);

            var item = _head.Pop();

            var newTail = new Queue<T>();
            for (int i = 0; i < _head.Count; i++)
            {
                var fromQueue = _tail.Dequeue();
                newTail.Enqueue(fromQueue);
            }
            
            _tail = newTail;
            
            return item;
        }

        public T RemoveTail()
        {
            if (Size() == 0) return default(T);
            
            var res = _tail.Dequeue();

            var newHead = new Stack<T>();
            var newTail = new Queue<T>();
            while (_tail.Count > 0)
            {
                var fromQueue = _tail.Dequeue();
                newHead.Push(fromQueue);
                newTail.Enqueue(fromQueue);
            }

            _head = newHead;
            _tail = newTail;
            
            return res;
        }

        public int Size()
        {
            return _head.Count;
        }
    }

}