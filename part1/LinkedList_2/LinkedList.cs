using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value) { 
            value = _value; 
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;
        public int count;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
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
            count++;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    nodes.Add(node);
                }
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            Node node = head;
            bool result = false;

            while (node != null)
            {
                if (node.value == _value)
                {
                    RemoveNode(node);
                    result = true;
                    break;
                }

                node = node.next;
            }
            return result;
        }

        public void RemoveAll(int _value)
        {
            Node node = head;

            while (node != null)
            {
                if (node.value == _value)
                {
                    RemoveNode(node);
                }
                
                node = node.next;
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public int Count()
        {
            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (_nodeAfter == null)
            {
                var oldHead = head;
                head = _nodeToInsert;
                head.next = oldHead;
                head.prev = null;
                if (oldHead == null) tail = head;
                else oldHead.prev = head;
                count++;
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

            count++;
        }
        
        public void InsertBeforeHead(Node _nodeToInsert)
        {
            InsertAfter(null, _nodeToInsert);
        }
        
        void RemoveNode(Node node)
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
                count--;
                return;
            }
                
            if (isInTail)
            {
                tail = nodePrev;
                tail.next = null;
                count--;
                return;
            }

            var oldNext = node.next;
            nodePrev.next = oldNext;
            oldNext.prev = nodePrev;
            
            count--;
        }

    }
}