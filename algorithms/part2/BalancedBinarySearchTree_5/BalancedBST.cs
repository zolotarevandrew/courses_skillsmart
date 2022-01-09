using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public struct BSTRange
    {
        private int _start;
        private int _end;
        private int _count;
        private int _middle;
        public BSTRange(int start, int end)
        {
            _start = start;
            _end = end;
            _count = (_end - _start) + 1;
            int middleByCount = _count / 2;
            _middle = _start + middleByCount;
        }

        bool IsInRange(int start, int end)
        {
            if (start > _end) return false;
            if (end < _start) return false;
            return true;
        }

        public int Middle => _middle;
        public int Count => _count;
        
        public BSTRange? Left
        {
            get
            {
                var start = _start;
                var end = _middle - 1;
                if (!IsInRange(start, end)) return null;
                return new BSTRange(start, end);
            }
        }
        
        public BSTRange? Right
        {
            get
            {
                var start = _middle + 1;
                var end = _end;
                if (!IsInRange(start, end)) return null;
                return new BSTRange(start, end);
            }
        }
    }
    
    public class BSTNode
    {
        public int NodeKey;
        public BSTNode Parent;
        public BSTNode LeftChild;
        public BSTNode RightChild;	
        public int     Level;
	
        public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    public class BalancedBST
    {
        public BSTNode Root;
	
        public BalancedBST() 
        { 
            Root = null;
        }
		
        public void GenerateTree(int[] a)
        {
            if (a.Length == 0)
            {
                Root = null;
                return;
            }
            
            Array.Sort(a);

            var range = new BSTRange(0, a.Length - 1);
            Root = BuildTree(a, null, range);
        }

        BSTNode BuildTree(int[] source, BSTNode parent, BSTRange range)
        {
            var key = source[range.Middle];
            var newNode = new BSTNode(key, parent)
            {
                Level = parent == null ? 0 : parent.Level + 1
            };

            if (range.Left != null) newNode.LeftChild = BuildTree(source, newNode, range.Left.Value);
            if (range.Right != null) newNode.RightChild = BuildTree(source, newNode, range.Right.Value);

            return newNode;
        }

        public bool IsBalanced(BSTNode root_node)
        {
            if (root_node == null) return true;

            var leftHeight = GetHeight(root_node.LeftChild);
            var rightHeight = GetHeight(root_node.RightChild);

            bool isLeftBalanced = IsBalanced(root_node.LeftChild);
            bool isRightBalanced = IsBalanced(root_node.RightChild);
            
            return Math.Abs(leftHeight - rightHeight) <= 1 && isLeftBalanced && isRightBalanced;
        }
        
        public int GetHeight(BSTNode node)
        {
            if (node == null) return 0;

            var leftHeight = GetHeight(node.LeftChild);
            var rightHeight = GetHeight(node.RightChild);
            
            return 1 + Math.Max(leftHeight, rightHeight);
        }
    }
}