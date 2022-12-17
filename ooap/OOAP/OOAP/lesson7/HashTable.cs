using System;

namespace OOAP.lesson7
{
    public abstract class HashTable<T>
    {
        public const int NotCalled = 0;
        public const int Ok = 1;
        public const int FailNotFound = 2;
        public const int FailSizeExcedeed = 3;
        public const int FailCantPut = 4;

        //конструктор
        public HashTable(int maxSize)
        {
            
        }
        
        //Команды
        
        //Предусловие таблица не заполнена
        //Предусловие элемент удалось добавить в таблицу
        //Постусловие элемент добавлен в таблицу
        public abstract void PutValue(T value);
        
        //Запросы
        
        //Предусловие элемент найден
        public abstract void FindValue(T value);
        
        public abstract int Size { get; }
        public abstract int FindValueStatus { get; }
        public abstract int PutValueStatus { get; }
    }

    public class HashTableImpl<T> : HashTable<T>
    {
        private int _size;
        private int _maxSize;
        private int _step;
        
        private int _findValueStatus;
        private int _putValueStatus;

        private T[] _slots;
        
        public HashTableImpl(int maxSize) : base(maxSize)
        {
            _maxSize = maxSize;
            _step = 1;
            
            _slots = new T[maxSize];
            _findValueStatus = NotCalled;
            _putValueStatus = NotCalled;
            _size = 0;
        }
        
        public override void PutValue(T value)
        {
            if (_size == _maxSize)
            {
                _putValueStatus = FailSizeExcedeed;
                return;
            }

            var idx = SeekSlot(value);
            if (idx == -1)
            {
                _putValueStatus = FailCantPut;
                return;
            }

            _slots[idx] = value; 
            _putValueStatus = Ok;
        }

        public override void FindValue(T value)
        {
            var found = SeekSlot(value);
            if (found == -1)
            {
                _findValueStatus = FailNotFound;
                return;
            }

            _findValueStatus = Ok;
        }

        public override int Size => _size;
        public override int FindValueStatus => _findValueStatus;
        public override int PutValueStatus => _putValueStatus;
        
        int FindIndex(T value)
        {
            var hash = value.GetHashCode();
            var res = hash % _size;
            return Math.Abs(res);
        }
        
        int SeekSlot(T value)
        {
            int idx = FindIndex(value);
            if (_slots[idx] == null) return idx;

            for (int curIdx = idx + _step; curIdx < _size; curIdx += _step)
            {
                if (_slots[curIdx] == null) return curIdx;
            }
            for (int curIdx = 0; curIdx < idx; curIdx += _step)
            {
                if (_slots[curIdx] == null) return curIdx;
            }
            return -1;
        }

    }
}