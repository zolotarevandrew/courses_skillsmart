using System;

namespace OOAP.lesson8
{
    public abstract class NativeDictionary<T>
    {
        public const int NotCalled = 0;
        public const int Ok = 1;
        public const int FailNotFound = 2;
        
        //конструктор, допустим пока что заставим вводить размер..
        public NativeDictionary(int size)
        {
            
        }

        //команды
        
        
        //постусловие элемент добавлен в словарь
        public abstract void Put(string key, T value);
        
        //запросы

        //предусловие элемент найден
        //предусловие элемент 
        public abstract T Get(string key);
        public abstract bool ContainsKey(string key);
        
        public abstract int GetStatus { get; }
    }
    
    public class NativeDictionaryImpl<T> : NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;

        private int _getStatus;
        
        int step = 1;

        public NativeDictionaryImpl(int size) : base(size)
        {
            slots = new string[size];
            values = new T[size];

            _getStatus = NotCalled;
        }

        public override bool ContainsKey(string key)
        {
            return SeekSlot(key) >= 0;
        }

        public override void Put(string key, T value)
        {
            int idx = SeekEmptySlot(key);
            slots[idx] = key;
            values[idx] = value;
        }

        public override T Get(string key)
        {
            int idx = SeekSlot(key);
            if (idx == -1)
            {
                _getStatus = FailNotFound;
                return default(T);
            }

            _getStatus = Ok;
            return values[idx];
        }
        
        int HashFun(string key)
        {
            var hash = key.GetHashCode();
            var res = hash % size;
            return Math.Abs(res);
        }
        
        int SeekSlot(string value)
        {
            int idx = HashFun(value);
            if (slots[idx] == value) return idx;

            for (int curIdx = idx + step; curIdx < size; curIdx += step)
            {
                if (slots[curIdx] == value) return curIdx;
            }
            for (int curIdx = 0; curIdx < idx; curIdx += step)
            {
                if (slots[curIdx] == value) return curIdx;
            }
            return -1;
        }
        
        int SeekEmptySlot(string value)
        {
            int idx = HashFun(value);
            if (slots[idx] == null) return idx;

            for (int curIdx = idx + step; curIdx < size; curIdx += step)
            {
                if (slots[curIdx] == null) return curIdx;
            }
            for (int curIdx = 0; curIdx < idx; curIdx += step)
            {
                if (slots[curIdx] == null) return curIdx;
            }
            return idx;
        }

        public override int GetStatus => _getStatus;
    } 
}