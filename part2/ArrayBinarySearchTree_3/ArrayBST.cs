using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    
    public class aBST
    {
        public int?[] Tree;
        private int _count;
        public aBST(int depth)
        {
            int tree_size = (int)(Math.Pow(2, depth + 1) - 1);
            Tree = new int?[tree_size];
            for(int i=0; i < tree_size; i++) Tree[i] = null;

            _count = 0;
        }
	
        public int? FindKeyIndex(int key)
        {
            return FindNodeByIdx(0, key);
        }
	
        public int AddKey(int key)
        {
            var idx = FindKeyIndex(key);
            if (idx == null) return -1;
            if (idx == 0)
            {
                if (_count == 0)
                {
                    Tree[0] = key;
                    _count++;    
                }
                return 0;
            }
            if (idx > 0) return idx.Value;

            var insertIdx = idx.Value * -1;
            Tree[insertIdx] = key;

            _count++;
            return insertIdx;
        }

        int? FindNodeByIdx(int nodeIdx, int key)
        {
            if (nodeIdx >= Tree.Length) return null;
            
            var nodeValue = Tree[nodeIdx];
            if (nodeValue == null) return nodeIdx * -1;
            if (nodeValue == key) return nodeIdx;
            
            var leftIdx = 2 * nodeIdx + 1; 
            var rightIdx = 2 * nodeIdx + 2;
            
            return key < nodeValue 
                ? FindNodeByIdx(leftIdx, key) 
                : FindNodeByIdx(rightIdx, key);
        }
    }
}

