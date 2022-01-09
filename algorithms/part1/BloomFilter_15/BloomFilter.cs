using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class Bit32Array
    {
        private int _value;
        public int Length => 32;
        public Bit32Array()
        {
            _value = 0;
        }

        public void Set(int bit, bool value)
        {
            int mask = 1 << bit;
            if (value)
                _value |= mask;
            else
                _value &= ~mask;
        }

        public bool Get(int bit)
        {
            return ((_value >> bit) & 1) != 0;
        }
    }
    
    public class BloomFilter
    {
        public int filter_len;
        public Bit32Array bitArray;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            bitArray = new Bit32Array();
        }

        public int Hash1(string str1)
        {
            int res = 0;
            int random = 17;
            for(int i=0; i< str1.Length; i++)
            {
                int code = (int)str1[i];
                res = (res * random + code) % bitArray.Length;
            }
            return res;
        }
        
        public int Hash2(string str1)
        {
            int res = 0;
            int random = 223;
            for(int i=0; i< str1.Length; i++)
            {
                int code = (int)str1[i];
                res = (res * random + code) % bitArray.Length;
            }
            return res;
        }

        public void Add(string str1)
        {
            var hash1Idx = Hash1(str1);
            bitArray.Set(hash1Idx, true);
            
            var hash2dx = Hash2(str1);
            bitArray.Set(hash2dx, true);
        }

        public bool IsValue(string str1)
        {
            var hash1Idx = Hash1(str1);
            if (!bitArray.Get(hash1Idx)) return false;
            
            var hash2dx = Hash2(str1);
            if (!bitArray.Get(hash2dx)) return false;

            return true;
        }
    }
}