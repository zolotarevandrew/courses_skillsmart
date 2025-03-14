using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    //microsoft reference - https://github.com/microsoft/referencesource/blob/master/mscorlib/system/collections/generic/dictionary.cs
    public class NativeDictionary<T>
    {
        public int size;
        public string [] slots;
        public T [] values;
        
        int step = 1;

        public NativeDictionary(int sz)
        {
            size = sz;
            Dictionary<string ,int>
            slots = new string[size];
            values = new T[size];
        }

        public int HashFun(string key)
        {
            var hash = key.GetHashCode();
            var res = hash % size;
            return Math.Abs(res);
        }

        public bool IsKey(string key)
        {
            return SeekSlot(key) >= 0;
        }

        public void Put(string key, T value)
        {
            int idx = SeekEmptySlot(key);
            slots[idx] = key;
            values[idx] = value;
        }

        public T Get(string key)
        {
            int idx = SeekSlot(key);
            if (idx == -1) return default(T);
            return values[idx];
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
    } 
}