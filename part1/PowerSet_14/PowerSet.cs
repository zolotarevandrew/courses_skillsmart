using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public static class PowerSetConsts
    {
        public const int MaxSize = 20000;
    }

    public class PowerSet<T>
    {
        class Slot
        {
            public LinkedList<T> Items { get; set; } = new LinkedList<T>();
        }
        
        private int _count;
        private Slot[] _slots;

        public PowerSet()
        {
            _slots = new Slot[PowerSetConsts.MaxSize];
            _count = 0;
        }

        public int Size()
        {
            return _count;
        }

        public void Put(T value)
        {
            var hashIdx = GetHashIdx(value);
            var slot = _slots[hashIdx];
            if (slot == null)
            {
                var newSlot = new Slot();
                newSlot.Items.AddLast(value);
                _slots[hashIdx] = newSlot;
                _count++;
            }
            else
            {
                var buckets = slot.Items;
                var node = buckets.First;
                while (node != null)
                {
                    if (node.Value.Equals(value))
                    {
                        return;
                    }
                        
                    node = node.Next;
                }

                slot.Items.AddLast(value);
                _count++;
            }
        }

        public bool Get(T value)
        {
            var hashIdx = GetHashIdx(value);
            var slot = _slots[hashIdx];
            if (slot == null) return false;
            
            var buckets = slot.Items;
            var node = buckets.First;
            while (node != null)
            {
                if (node.Value.Equals(value)) return true;
                node = node.Next;
            }

            return false;
        }

        public bool Remove(T value)
        {
            var hashIdx = GetHashIdx(value);
            var slot = _slots[hashIdx];
            
            if (slot == null) return false;
            
            var buckets = slot.Items;
            var node = buckets.First;
            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    buckets.Remove(node);
                    _count--;
                    return true;
                }
                node = node.Next;
            }

            return false;
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            var res = new PowerSet<T>();
            
            for (int i = 0; i < set2._slots.Length; i++)
            {
                var slot = set2._slots[i];
                if (slot != null)
                {
                    foreach (var item in slot.Items)
                    {
                        var found = Get(item);
                        if (found) res.Put(item);
                    }
                }
            }
            for (int i = 0; i < _slots.Length; i++)
            {
                var slot = _slots[i];
                if (slot != null)
                {
                    foreach (var item in slot.Items)
                    {
                        var found = set2.Get(item);
                        if (found) res.Put(item);
                    }
                }
            }
            return res;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            var res = new PowerSet<T>();
            for (int i = 0; i < set2._slots.Length; i++)
            {
                var slot = set2._slots[i];
                if (slot != null)
                {
                    foreach (var item in slot.Items)
                    {
                        res.Put(item);
                    }
                }
            }
            for (int i = 0; i < _slots.Length; i++)
            {
                var slot = _slots[i];
                if (slot != null)
                {
                    foreach (var item in slot.Items)
                    {
                        res.Put(item);
                    }
                }
            }
            return res;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            var res = new PowerSet<T>();
            
            for (int i = 0; i < _slots.Length; i++)
            {
                var slot = _slots[i];
                if (slot != null)
                {
                    foreach (var item in slot.Items)
                    {
                        var found = set2.Get(item);
                        if (!found) res.Put(item);
                    }
                }
            }
            return res;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            var res = new PowerSet<T>();
            for (int i = 0; i < set2._slots.Length; i++)
            {
                var slot = set2._slots[i];
                if (slot != null)
                {
                    foreach (var item in slot.Items)
                    {
                        var found = Get(item);
                        if (found) res.Put(item);
                    }
                }
            }
            return res.Size() == set2.Size();
        }
        
        int GetHashIdx(T key)
        {
            var hash = key.GetHashCode();
            var res = hash % PowerSetConsts.MaxSize;
            return Math.Abs(res);
        }
    }
}