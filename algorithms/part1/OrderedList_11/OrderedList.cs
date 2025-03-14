using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    //microsoft reference - https://github.com/microsoft/referencesource/blob/master/System/compmod/system/collections/generic/sortedlist.cs
    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;
        private int _count;

        public OrderedList(bool asc)
        {
            Clear(asc);
        }

        public int Compare(T v1, T v2)
        {
            if(typeof(T) == typeof(String))
            {
                var str1 = v1.ToString().Trim();
                var str2 = v2.ToString().Trim();
                return str1.CompareTo(str2);
            }
            else
            {
                var val1 = Convert.ToInt32(v1);
                var val2 = Convert.ToInt32(v2);
                if (val1 < val2) return -1;
                if (val1 == val2) return 0;
                return 1;
            }
        }

        public void Add(T value)
        {
            var insertNode = new Node<T>(value);
            if (head == null)
            {
                InsertAfter(head, insertNode);
                return;
            }

            int headCompare = Compare(value, head.value);
            bool isBeforeOrInHead = _ascending 
                ? headCompare <= 0
                : headCompare >= 0;
            if (isBeforeOrInHead)
            {
                InsertBeforeHead(insertNode);
                return;
            }

            int tailCompare = Compare(value, tail.value);
            bool isAfterOrInTail = _ascending 
                ? tailCompare >= 0
                : tailCompare <= 0;
            if (isAfterOrInTail)
            {
                AddInTail(insertNode);
                return;
            }
            
            Node<T> node = head;
            while (node != null)
            {
                int compare = Compare(value, node.value);
                bool canInsert = _ascending
                    ? compare <= 0
                    : compare >= 0;
                if (canInsert)
                {
                    InsertAfter(node.prev, insertNode);
                    break;
                }
                node = node.next;
            }
        }

        public Node<T> Find(T val)
        {
            if (_count == 0) return null;
            if (IsOutOfRange(val)) return null;

            Node<T> node = head;

            while (node != null)
            {
                var compareResult = Compare(val, node.value);
                if (compareResult == 0) return node;
                node = node.next;
            }
            
            return null;
        }

        bool IsOutOfRange(T val)
        {
            var node = head;
            int nodeCompare = Compare(val, node.value);
            bool isOutRange = _ascending 
                ? nodeCompare == -1
                : nodeCompare == 1;

            if (isOutRange) return true;
            
            node = tail;
            nodeCompare = Compare(val, node.value);
            isOutRange = _ascending 
                ? nodeCompare == 1
                : nodeCompare == -1;
            if (isOutRange) return true;
            return false;
        }

        public void Delete(T val)
        {
            Node<T> node = head;
            while (node != null)
            {
                if (Compare(node.value, val) == 0)
                {
                    RemoveNode(node);
                    break;
                }

                node = node.next;
            }
        }

        public void Clear(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
            _count = 0;
        }

        public int Count()
        {
            return _count;
        }

        public List<Node<T>> GetAll()
        {
            List<Node<T>> r = new();
            Node<T> node = head;
            while(node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
        }
        
        void RemoveNode(Node<T> node)
        {
            var nodePrev = node.prev;
            var nodeNext = node.next;
                
            var isInHead = nodePrev == null;
            var isInTail = nodeNext == null;

            if (isInHead)
            {
                var oldHead = head;
                var newHead = oldHead.next;
                head = newHead;
                if (head == null) tail = head;
                else head.prev = null;
                _count--;
                return;
            }
                
            if (isInTail)
            {
                tail = nodePrev;
                tail.next = null;
                _count--;
                return;
            }

            var oldNext = node.next;
            nodePrev.next = oldNext;
            oldNext.prev = nodePrev;
            
            _count--;
        }
        
        void InsertAfter(Node<T> _nodeAfter, Node<T> _nodeToInsert)
        {
            if (_nodeAfter == null)
            {
                var oldHead = head;
                head = _nodeToInsert;
                head.next = oldHead;
                head.prev = null;
                if (oldHead == null) tail = head;
                else oldHead.prev = head;
                _count++;
                return;
            }

            if (_nodeAfter == tail)
            {
                AddInTail(_nodeToInsert);
                return;
            }

            var oldNext = _nodeAfter.next;
            _nodeAfter.next = _nodeToInsert;
            _nodeToInsert.next = oldNext;
            oldNext.prev = _nodeToInsert;
            _nodeToInsert.prev = _nodeAfter;

            _count++;
        }
        
        void InsertBeforeHead(Node<T> _nodeToInsert)
        {
            InsertAfter(null, _nodeToInsert);
        }
        
        void AddInTail(Node<T> _item)
        {
            if (head == null) {
                head = _item;
                head.next = null;
                head.prev = null;
            } else {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
            _count++;
        }
    }
 
}