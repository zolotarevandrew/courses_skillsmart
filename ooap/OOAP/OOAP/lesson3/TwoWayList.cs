using System.Collections.Generic;

namespace OOAP.lesson3
{
    public abstract class ParentList<T>
    {

        //конструктор
        public ParentList()
        {
            
        }
        
        //команды
        
        /// предусловие, есть текущий элемент
        /// постусловие, текущий элемент указывает на начало списка
        public abstract void Head();
        
        /// предусловие, есть текущий элемент
        /// постусловие, текущий элемент указывает на конец списка
        public abstract void Tail();
        
        /// предусловие, есть следующий элемент
        /// постусловие, текущий элемент сдвинут на один вправо
        public abstract void Right();
        
        /// предусловие, есть текущий элемент
        /// постусловие, новый элемент добавлен после текущего (отработает даже если нет элементов)
        public abstract void PutRight(T value);
        
        /// предусловие, есть текущий элемент
        /// постусловие, новый элемент добавлен перед текущим
        public abstract void PutLeft(T value);
        
        /// постусловие, новый элемент добавлен в конец списка
        public abstract void AddInTail(T value);
        
        /// предусловие, есть текущий элемент
        /// постусловие, текущий элемент заменен на value
        public abstract void ReplaceCurrent(T value);
        
        /// предусловие, есть текущий элемент
        /// постусловие, удален текущий элемент 
        public abstract void RemoveCurrent();
        
        /// постусловие, в списке удалены все элементы со значением value 
        public abstract void RemoveAll(T value);
        
        /// постусловие: удалятся все значения
        public abstract void Clear();
        
        // постусловие: курсор установлен на следующий узел 
        public abstract void Find(T value);

        //запросы

        public abstract T CurrentValue();
        
        public abstract bool IsInHead { get; }
        public abstract bool IsInTail { get; }
        public abstract bool IsInValue { get; }
        
        public abstract int Size { get; }
        
        public abstract int HeadStatus { get; }
        public abstract int TailStatus { get; }
        public abstract int RightStatus { get; }
        public abstract int PutRightStatus { get; }
        public abstract int PutLeftStatus { get; }
        public abstract int RemoveCurrentStatus { get; }
        public abstract int ReplaceStatus { get; }
        public abstract int FindStatus { get; }
        public abstract int CurrentStatus { get; }
    }

    public class ParentListImpl<T> : ParentList<T>
    {
        private DummyNode<T> _dummyHead;
        private DummyNode<T> _dummyTail;
        private Node<T> _current;

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

        public ParentListImpl()
        {
            Clear();
        }

        public override void Head()
        {
            if (!IsInValue)
            {
                _headStatus = ListEmpty;
                return;
            }

            _headStatus = Ok;
            _current = _dummyHead;
        }

        public override void Tail()
        {
            if (!IsInValue)
            {
                _tailStatus = ListEmpty;
                return;
            }

            _tailStatus = Ok;
            _current = _dummyTail;
        }

        public override void Right()
        {
            if (!IsInValue)
            {
                _rightStatus = NoRightValue;
                return;
            }
            
            if (_current.next == null)
            {
                _rightStatus = NoRightValue;
                return;
            }

            _rightStatus = Ok;
            _current = _current.next;
        }

        public override void PutRight(T value)
        {
            if (!IsInValue)
            {
                _putRightStatus = ListEmpty;
                return;
            }

            InsertAfter(_current, new Node<T>(value));

            _putRightStatus = Ok;
        }

        public override void PutLeft(T value)
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

        public override void AddInTail(T value)
        {
            var _item = new Node<T>(value);
            var oldPrev = _dummyTail._prev;
            _dummyTail._prev = _item;
            _item._prev = oldPrev;
            _item._next = _dummyTail;
            oldPrev._next = _item;

            _count++;
        }

        public override void ReplaceCurrent(T value)
        {
            if (!IsInValue)
            {
                _replaceStatus = ListEmpty;
                return;
            }

            _current.value = value;
            _replaceStatus = Ok;
        }

        public override void RemoveCurrent()
        {
            if (!IsInValue)
            {
                _removeCurrentStatus = ListEmpty;
                return;
            }
            
            RemoveNode(_current);
            _removeCurrentStatus = Ok;
        }

        public override void RemoveAll(T value)
        {
            foreach (var node in Iterate(_dummyHead))
            {
                if (node.value.Equals(value))
                {
                    RemoveNode(node);
                }
            }
        }

        public override void Clear()
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

        public override void Find(T value)
        {
            if (!IsInValue)
            {
                _findStatus = ListEmpty;
                return;
            }
            
            foreach (var node in Iterate(_current))
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

        public override T CurrentValue()
        {
            if (!IsInValue)
            {
                _currentStatus = NotCalled;
                return default;
            }

            _currentStatus = Ok;
            
            return _current.value;
        }
        
        public override bool IsInHead => _current == _dummyHead;
        public override bool IsInTail => _current == _dummyHead;
        public override bool IsInValue => _current != null;
        public override int Size => _count;
        
        public override int HeadStatus => _headStatus;
        public override int TailStatus => _tailStatus;
        public override int RightStatus => _rightStatus;
        public override int PutRightStatus => _putRightStatus;
        public override int PutLeftStatus => _putLeftStatus;
        public override int RemoveCurrentStatus => _removeCurrentStatus;
        public override int ReplaceStatus => _replaceStatus;
        public override int FindStatus => _findStatus;
        public override int CurrentStatus => _currentStatus;
        
        
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
}