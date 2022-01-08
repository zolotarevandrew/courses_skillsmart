using System;

namespace NativeCache_16
{
    public class NativeCache<T>
    {
        public int size;
        public String [] slots;
        public T [] values;
        public int [] hits;
        int _count;
        public Func<string, int> hashFun;

        private int step = 1;

        public NativeCache(int sz)
        {
            size = sz;
            slots = new string[sz];
            values = new T[sz];
            hits = new int[sz];
            _count = 0;

            hashFun = (key) =>
            {
                uint res = (uint) key.GetHashCode() % (uint) size;
                return (int) res;
            };
        }

        public T Get(string key)
        {
            var hashIdx = SeekSlot(key);
            if (hashIdx < 0) return default;
            
            hits[hashIdx] += 1;
            return values[hashIdx];
        }

        public void Set(string key, T value)
        {
            bool isFull = _count == size;
            if (isFull)
            {
                RemoveByMinimumHitsElement();
            }
            
            var idx = SeekEmptySlot(key);
            slots[idx] = key;
            values[idx] = value;
            hits[idx] = 0;
            _count++;
        }

        public int HashIdx(string key)
        {
            return hashFun(key);
        }
        
        int SeekEmptySlot(string value)
        {
            int idx = HashIdx(value);
            if (slots[idx] == null) return idx;

            for (int curIdx = idx + step; curIdx < size; curIdx += step)
            {
                if (slots[curIdx] == null) return curIdx;
            }
            for (int curIdx = 0; curIdx < idx; curIdx += step)
            {
                if (slots[curIdx] == null) return curIdx;
            }
            return -1;
        }
        
        int SeekSlot(string value)
        {
            int idx = HashIdx(value);
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
        
        void RemoveByMinimumHitsElement()
        {
            int min = Int32.MaxValue;
            int minIdx = 0;
            for (int i = 0; i < size; i++)
            {
                var item = hits[i];
                if (item == 0) continue;

                if (item < min)
                {
                    min = item;
                    minIdx = i;
                }
            }

            slots[minIdx] = null;
            values[minIdx] = default;
            hits[minIdx] = 0;
            _count--;
        }
    }
}