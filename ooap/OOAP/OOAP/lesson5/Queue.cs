using System.Collections.Generic;

namespace OOAP.lesson5
{
    public abstract class Queue<T>
    {
        public const int NotCalled = 0;
        public const int Ok = 1;
        public const int FailEmpty = 2;

        //конструктор
        public Queue()
        {
            
        }
        
        //команды 
        
        //постусловие добавлен элемент в начало очереди
        public abstract void Enqueue(T item);
        
        //предусловие очередь не пуста
        //постусловие удален элемент из начала очереди
        public abstract void Dequeue();
        
        //запросы
        public abstract int Size { get; }
        
        //предусловие очередь не пуста
        //постусловие получен элемент из начала очереди
        public abstract T GetHead();
        
        public abstract int GetHeadStatus { get; }
        public abstract int DequeueStatus { get; }
    }

    public class QueueImpl<T> : Queue<T>
    {
        private int _getHeadStatus;
        private int _dequeueStatus;
        
        private List<T> _store;

        public QueueImpl()
        {
            _store = new List<T>();
            _getHeadStatus = NotCalled;
            _dequeueStatus = NotCalled;
        }
        
        public override void Enqueue(T item)
        {
            _store.Add(item);
        }

        public override void Dequeue()
        {
            if (Size == 0)
            {
                _dequeueStatus = FailEmpty;
                return;
            }
            
            _store.RemoveAt(0);
            _dequeueStatus = Ok;
        }

        public override int Size => _store.Count;
        public override T GetHead()
        {
            if (Size == 0)
            {
                _getHeadStatus = FailEmpty;
                return default;
            }

            _getHeadStatus = Ok;
            return _store[0];
        }

        public override int GetHeadStatus => _getHeadStatus;
        public override int DequeueStatus => _dequeueStatus;
    }

}