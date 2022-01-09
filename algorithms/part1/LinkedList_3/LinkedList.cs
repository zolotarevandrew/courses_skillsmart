using System.Collections.Generic;

namespace LinkedList_3
{
    
    public class Node
    {
        public int value;
        
        internal Node _next;
        internal Node _prev;

        public Node prev
        {
            get
            {
                if (_prev is DummyNode) return null;
                return _prev;
            }
        }
        
        public Node next
        {
            get
            {
                if (_next is DummyNode) return null;
                return _next;
            }
        }

        public Node(int _value) { 
            value = _value; 
            _next = null;
            _prev = null;
        }
    }

    public class DummyNode : Node
    {
        public DummyNode() : base(-1)
        {
            
        }
    }

    public class LinkedList3
    {
        DummyNode _dummyHead;
        DummyNode _dummyTail;

        public Node head => _dummyHead.next;
        public Node tail => _dummyTail.prev;

        public int count;

        public LinkedList3()
        {
            Clear();
        }

        public void AddInTail(Node _item)
        {
            var oldPrev = _dummyTail._prev;
            _dummyTail._prev = _item;
            _item._prev = oldPrev;
            _item._next = _dummyTail;
            oldPrev._next = _item;

            count++;
        }

        public Node Find(int _value)
        {
            foreach (var node in Iterate())
            {
                if (node.value == _value)
                {
                    return node;
                }
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            foreach (var node in Iterate())
            {
                if (node.value == _value)
                {
                    nodes.Add(node);
                }
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            bool result = false;
            foreach (var node in Iterate())
            {
                if (node.value == _value)
                {
                    RemoveNode(node);
                    result = true;
                    break;
                }
            }
            
            return result;
        }

        public void RemoveAll(int _value)
        {
            foreach (var node in Iterate())
            {
                if (node.value == _value)
                {
                    RemoveNode(node);
                }
            }
        }

        public void Clear()
        {
            _dummyHead = new();
            _dummyTail = new();

            _dummyHead._next = _dummyTail;
            _dummyTail._prev = _dummyHead;

            count = 0;
        }

        public int Count()
        {
            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            var after = _nodeAfter ?? _dummyHead;
            var oldNext = after._next;
            after._next = _nodeToInsert;
            _nodeToInsert._next = oldNext;
            oldNext._prev = _nodeToInsert;
            _nodeToInsert._prev = after;

            count++;
        }

        void RemoveNode(Node node)
        {
            var nodePrev = node._prev;
            var oldNext = node._next;
            nodePrev._next = oldNext;
            oldNext._prev = nodePrev;
            
            count--;
        }
        
        public IEnumerable<Node> Iterate()
        {
            Node node = head;
            while (node != null)
            {
                yield return node;
                node = node.next;
            }
        }

    }
}