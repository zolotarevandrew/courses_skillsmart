namespace OOAP.lesson6
{


    public class Queue<T> : ParentQueue<T>
    {
        
    }

    public class Deque<T> : ParentQueue<T>
    {
        private int _getTailStatus;
        private int _dequeueTailStatus;

        public Deque() : base()
        {
            _getTailStatus = NotCalled;
            _dequeueTailStatus = NotCalled;
        }
        
        //постусловие добавлен элемент в начало очереди
        public void EnqueueHead(T item)
        {
            _store.AddFirst(item);
        }
        
        //предусловие очередь не пуста
        //постусловие удален элемент из конца очереди
        public void DequeueTail()
        {
            if (Size == 0)
            {
                _dequeueTailStatus = FailEmpty;
                return;
            }
            
            _store.RemoveLast();
            _dequeueTailStatus = Ok;
        }
        
        //предусловие очередь не пуста
        //постусловие получен элемент из конца очереди
        public T GetTail()
        {
            if (Size == 0)
            {
                _getTailStatus = FailEmpty;
                return default;
            }

            _getTailStatus = Ok;
            return _store.Last.Value;
        }

        public int GetTailStatus => _getTailStatus;
        public int DequeueTailStatus => _dequeueTailStatus;
    }

    public class ParentQueue<T>
    {
        public const int NotCalled = 0;
        public const int Ok = 1;
        public const int FailEmpty = 2;
        
        private int _getHeadStatus;
        private int _dequeueHeadStatus;
        
        protected System.Collections.Generic.LinkedList<T> _store;
        
        public ParentQueue()
        {
            _store = new System.Collections.Generic.LinkedList<T>();
            _getHeadStatus = NotCalled;
            _dequeueHeadStatus = NotCalled;
        }
        
        //постусловие добавлен элемент в конец очереди
        public void EnqueueTail(T item)
        {
            _store.AddLast(item);
        }

        //предусловие очередь не пуста
        //постусловие удален элемент из начала очереди
        public void DequeueHead()
        {
            if (Size == 0)
            {
                _dequeueHeadStatus = FailEmpty;
                return;
            }
            
            _store.RemoveFirst();
            _dequeueHeadStatus = Ok;
        }

        public int Size => _store.Count;
        
        //предусловие очередь не пуста
        //постусловие получен элемент из начала очереди
        public T GetHead()
        {
            if (Size == 0)
            {
                _getHeadStatus = FailEmpty;
                return default;
            }

            _getHeadStatus = Ok;
            return _store.First.Value;
        }

        public int GetHeadStatus => _getHeadStatus;
        public int DequeueHeadStatus => _dequeueHeadStatus;
    }
}