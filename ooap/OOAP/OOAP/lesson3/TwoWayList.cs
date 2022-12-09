using System.Collections.Generic;

namespace OOAP.lesson3
{
    public class ParentList<T> 
    {
        protected DummyNode<T> _dummyHead;
        protected DummyNode<T> _dummyTail;
        protected Node<T> _current;

        public const int NotCalled = 0;
        public const int Ok = 1;
        public const int ListEmpty = 2;
        public const int NoRightValue = 3;
        public const int NotFound = 4;
        
        private int _headStatus;
        private int _tailStatus;
        private int _rightStatus;
        private int _putRightStatus;
        private int _putLeftStatus;
        private int _removeCurrentStatus;
        private int _replaceStatus;
        private int _findStatus;
        private int _currentStatus;

        private int _count;

        public ParentList()
        {
            Clear();
        }

        public void Head()
        {
            if (!IsInValue)
            {
                _headStatus = ListEmpty;
                return;
            }

            _headStatus = Ok;
            _current = _dummyHead;
        }

        public void Tail()
        {
            if (!IsInValue)
            {
                _tailStatus = ListEmpty;
                return;
            }

            _tailStatus = Ok;
            _current = _dummyTail;
        }

        public void Right()
        {
            if (!IsInValue)
            {
                _rightStatus = ListEmpty;
                return;
            }
            
            if (_current.next == null)
            {
                _rightStatus = NoRightValue;
                return;
            }
            
            _current = _current.next;
            _rightStatus = Ok;
        }

        public void PutRight(T value)
        {
            if (!IsInValue)
            {
                _putRightStatus = ListEmpty;
                return;
            }

            InsertAfter(_current, new Node<T>(value));

            _putRightStatus = Ok;
        }

        public void PutLeft(T value)
        {
            if (!IsInValue)
            {
                _putLeftStatus = ListEmpty;
                return;
            }

            var left = _current.prev ?? _dummyHead;
            InsertAfter(left, new Node<T>(value));
            
            _putLeftStatus = Ok;
        }

        public void AddInTail(T value)
        {
            var _item = new Node<T>(value);
            var oldPrev = _dummyTail._prev;
            _dummyTail._prev = _item;
            _item._prev = oldPrev;
            _item._next = _dummyTail;
            oldPrev._next = _item;

            _count++;
        }

        public void ReplaceCurrent(T value)
        {
            if (!IsInValue)
            {
                _replaceStatus = ListEmpty;
                return;
            }

            _current.value = value;
            _replaceStatus = Ok;
        }

        public void RemoveCurrent()
        {
            if (!IsInValue)
            {
                _removeCurrentStatus = ListEmpty;
                return;
            }
            
            RemoveNode(_current);
            _removeCurrentStatus = Ok;
        }

        public void RemoveAll(T value)
        {
            foreach (var node in Iterate(_dummyHead))
            {
                if (node.value.Equals(value))
                {
                    RemoveNode(node);
                }
            }
        }

        public virtual void Clear()
        {
            _dummyHead = new();
            _dummyTail = new();

            _dummyHead._next = _dummyTail;
            _dummyTail._prev = _dummyHead;

            _current = null;

            _count = 0;

            _headStatus = NotCalled;
            _tailStatus = NotCalled;
            _rightStatus = NotCalled;
            _putRightStatus = NotCalled;
            _putLeftStatus = NotCalled;
            _removeCurrentStatus = NotCalled;
            _replaceStatus = NotCalled;
            _findStatus = NotCalled;
            _currentStatus = NotCalled;
        }

        public void Find(T value)
        {
            if (!IsInValue)
            {
                _findStatus = ListEmpty;
                return;
            }

            var list = _current.next != null
                ? Iterate(_current.next)
                : new List<Node<T>>();
            
            foreach (var node in list)
            {
                if (node.value.Equals(value))
                {
                    _findStatus = Ok;
                    _current = node;
                    break;
                }
            }

            _findStatus = NotFound;
        }

        public T CurrentValue()
        {
            if (!IsInValue)
            {
                _currentStatus = NotCalled;
                return default;
            }

            _currentStatus = Ok;
            
            return _current.value;
        }
        
        public bool IsInHead => _current == _dummyHead;
        public bool IsInTail => _current == _dummyHead;
        public bool IsInValue => _current != null;
        public int Size => _count;
        
        public int HeadStatus => _headStatus;
        public int TailStatus => _tailStatus;
        public int RightStatus => _rightStatus;
        public int PutRightStatus => _putRightStatus;
        public int PutLeftStatus => _putLeftStatus;
        public int RemoveCurrentStatus => _removeCurrentStatus;
        public int ReplaceStatus => _replaceStatus;
        public int FindStatus => _findStatus;
        public int CurrentStatus => _currentStatus;
        
        
        void InsertAfter(Node<T> _nodeAfter, Node<T> _nodeToInsert)
        {
            var after = _nodeAfter ?? _dummyHead;
            var oldNext = after._next;
            after._next = _nodeToInsert;
            _nodeToInsert._next = oldNext;
            oldNext._prev = _nodeToInsert;
            _nodeToInsert._prev = after;

            _count++;
        }
        
        void RemoveNode(Node<T> node)
        {
            var nodePrev = node._prev;
            var oldNext = node._next;
            nodePrev._next = oldNext;
            oldNext._prev = nodePrev;
        }
        
        IEnumerable<Node<T>> Iterate(Node<T> start)
        {
            var node = start;
            while (node != null)
            {
                yield return node;
                node = node.next;
            }
        }
        
        protected class Node<TValue>
        {
            public TValue value;
        
            public Node<TValue> _next;
            public Node<TValue> _prev;

            public Node<TValue> prev
            {
                get
                {
                    if (_prev is DummyNode<TValue>) return null;
                    return _prev;
                }
            }
        
            public Node<TValue> next
            {
                get
                {
                    if (_next is DummyNode<TValue>) return null;
                    return _next;
                }
            }

            public Node(TValue v) { 
                value = v; 
                _next = null;
                _prev = null;
            }
        }
        
        protected class DummyNode<TValue> : Node<TValue>
        {
            public DummyNode() : base(default)
            {
            
            }
        }
    }
    
    public class LinkedList<T> : ParentList<T>
    {
        
    }
    
    public class TwoWayList<T> : ParentList<T>
    {
        public const int NoLeftValue = 5;
        
        private int _leftStatus;

        public TwoWayList() : base()
        {
        }
        
        public void Left()
        {
            if (!IsInValue)
            {
                _leftStatus = ListEmpty;
                return;
            }
            
            if (_current.prev == null)
            {
                _leftStatus = NoLeftValue;
                return;
            }

            _current = _current._prev;

            _leftStatus = Ok;
        }

        public int LeftStatus => _leftStatus;

        public override void Clear()
        {
            base.Clear();
            _leftStatus = NotCalled;
        }
    }
}