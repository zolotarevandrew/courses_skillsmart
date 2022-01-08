using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class HashTable
    {
        public int size;
        public int step;
        public string [] slots;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for(int i=0; i<size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            var hash = value.GetHashCode();
            var res = hash % size;
            return Math.Abs(res);
        }

        public int SeekSlot(string value)
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
            return -1;
        }

        public int Put(string value)
        {
            int idx = SeekSlot(value);
            if (idx == -1) return idx;
            
            slots[idx] = value;
            return idx;
        }

        public int Find(string value)
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
    }
 
}