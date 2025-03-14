using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    //microsoft reference - https://github.com/microsoft/referencesource/blob/master/mscorlib/system/collections/hashtable.cs
    //использует метод двойного хэширования, когда используются две совершенно разные хэш-функции h1() и h2(). Если слот k = h1(v) занят, тогда вычисляется h1(v) + i * h2(v) по модулю длины таблицы
    // The hashtable is created with an initial capacity of zero and a load factor of 1.0
    //
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
            Hashtable
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