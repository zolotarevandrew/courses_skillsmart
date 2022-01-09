using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;
        public int count;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else              tail.next = _item;
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
        
        public List<Node> GetAll()
        {
            var res = new List<Node>();
            Node node = head;
            while (node != null)
            {
                res.Add(node);
                node = node.next;
            }

            return res;
        }

        public bool Remove(int _value)
        {
            Node node = head;
            Node prev = null;
            bool result = false;

            while (node != null)
            {
                if (node.value == _value)
                {
                    RemoveNode(node, prev);
                    result = true;
                    break;
                }

                prev = node;
                node = node.next;
            }
            return result;
        }

        public void RemoveAll(int _value)
        {
            Node node = head;
            Node prev = null;

            while (node != null)
            {
                if (node.value == _value)
                {
                    RemoveNode(node, prev);
                    
                    node = node.next;
                    continue;
                }

                prev = node;
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
                if (oldHead == null) tail = head;
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

            count++;
        }
        
        void RemoveNode(Node node, Node prev)
        {
            var nodePrev = prev;
            var nodeNext = node.next;
                
            var isInHead = nodePrev == null;
            var isInTail = nodeNext == null;

            if (isInHead)
            {
                var oldHead = head;
                var newHead = oldHead.next;
                head = newHead;
                if (head == null) tail = head;
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
                
            nodePrev.next = node.next;
            count--;
        }
    }
}