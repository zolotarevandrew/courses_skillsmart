using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey;
        public T NodeValue;
        public BSTNode<T> Parent;
        public BSTNode<T> LeftChild;
        public BSTNode<T> RightChild;
	
        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }

        public void CopyValue(BSTNode<T> source)
        {
            NodeKey = source.NodeKey;
            NodeValue = source.NodeValue;
        }

        public bool IsLeaf
        {
            get
            {
                return LeftChild == null && RightChild == null;
            }
        }

        public bool OnlyLeft
        {
            get
            {
                return RightChild == null && LeftChild != null;
            }
        }
        
        public bool OnlyRight
        {
            get
            {
                return RightChild != null && LeftChild == null;
            }
        }

        public void RemoveFromParent()
        {
            var parent = Parent;
            if (parent.LeftChild == this)
            {
                parent.LeftChild = null;
            }
            else if (parent.RightChild == this)
            {
                parent.RightChild = null;
            }
        }
        
        public void SwapFromLeft()
        {
            CopyFrom(LeftChild);
        }

        public void SwapFromRight()
        {
            CopyFrom(RightChild);
        }
        
        void CopyFrom(BSTNode<T> source)
        {
            NodeKey = source.NodeKey;
            NodeValue = source.NodeValue;
            LeftChild = source.LeftChild;
            RightChild = source.RightChild;
        }
    }
    
    public class BSTFind<T>
    {
        public BSTNode<T> Node;
        public bool NodeHasKey;
        public bool ToLeft;
	
        public BSTFind() { Node = null; }
    }

    public class BST<T>
    {
        BSTNode<T> Root;
        private int _count;
	
        public BST(BSTNode<T> node)
        {
            Root = node;
            _count = Root != null ? 1 : 0;
        }
	
        public BSTFind<T> FindNodeByKey(int key)
        {
            return _count == 0 ? new BSTFind<T>() : FindNode(Root, Root.Parent, key, key < Root.NodeKey);
        }

        public bool AddKeyValue(int key, T val)
        {
            var find = FindNodeByKey(key);
            if (find.NodeHasKey) return false;

            var newNode = new BSTNode<T>(key, val, find.Node);
            
            if (find.Node == null)
            {
                Root = newNode;
                _count++;
                return true;
            }
            
            if (find.ToLeft)
            {
                find.Node.LeftChild = newNode;
            }
            else
            {
                find.Node.RightChild = newNode;
            }

            _count++;
            
            return true;
        }
	
        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            if (FromNode == null) return null;
            var node = FindMax ? FromNode.RightChild : FromNode.LeftChild;
            if (node == null) return FromNode;
            return FinMinMax(node, FindMax);
        }
	
        public bool DeleteNodeByKey(int key)
        {
            var find = FindNodeByKey(key);
            if (!find.NodeHasKey) return false;

            if (_count == 1)
            {
                Root = null;
                _count--;
                return true;
            }

            var node = find.Node;
            if (node.IsLeaf)
            {
                node.RemoveFromParent();
                _count--;
                return true;
            }

            if (node.OnlyLeft)
            {
                node.SwapFromLeft();
                _count--;
                return true;
            }
            
            if (node.OnlyRight)
            {
                node.SwapFromRight();
                _count--;
                return true;
            }

            var deleteNode = SearchForDelete(node.RightChild);
            if (deleteNode.IsLeaf)
            {
                node.CopyValue(deleteNode);
                deleteNode.RemoveFromParent();
            }
            else
            {
                node.CopyValue(deleteNode);
                deleteNode.SwapFromRight();
            }

            _count--;

            return true;
        }
        
        public List<BSTNode<T>> WideAllNodes()
        {
            if (Root == null) 
                return new List<BSTNode<T>>();
            
            var res = new List<BSTNode<T>>();
            var queue = new Queue<BSTNode<T>>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                res.Add(node);

                if (node.LeftChild != null) queue.Enqueue(node.LeftChild);
                if (node.RightChild != null) queue.Enqueue(node.RightChild);
            }

            return res;
        }
        
        public List<BSTNode<T>> DeepAllNodes(int order)
        {
            if (order < 0 || order > 2)
                throw new InvalidOperationException("order can be only 0, 1, 2");
            
            switch (order)
            {
                case 0:
                    return InOrder(Root);
                case 1:
                    return PostOrder(Root);
                default:
                    return PreOrder(Root);
            }
        }
        List<BSTNode<T>> InOrder(BSTNode<T> node)
        {
            if (node == null) 
                return new List<BSTNode<T>>();

            var result = new List<BSTNode<T>>();
            result.AddRange(InOrder(node.LeftChild));
            result.Add(node);
            result.AddRange(InOrder(node.RightChild));
            
            return result;
        }
        
        List<BSTNode<T>> PreOrder(BSTNode<T> node)
        {
            if (node == null) 
                return new List<BSTNode<T>>();

            var result = new List<BSTNode<T>>();
            result.Add(node);
            result.AddRange(PreOrder(node.LeftChild));
            result.AddRange(PreOrder(node.RightChild));
            
            return result;
        }
        
        List<BSTNode<T>> PostOrder(BSTNode<T> node)
        {
            if (node == null) 
                return new List<BSTNode<T>>();

            var result = new List<BSTNode<T>>();
            result.AddRange(PostOrder(node.LeftChild));
            result.AddRange(PostOrder(node.RightChild));
            result.Add(node);
            
            return result;
        }

        BSTNode<T> SearchForDelete(BSTNode<T> node)
        {
            if (node.IsLeaf)
            {
                return node;
            }

            if (node.OnlyRight)
            {
                return node;
            }

            return SearchForDelete(node.LeftChild);
        }

        public int Count()
        {
            return _count;
        }

        BSTFind<T> FindNode(BSTNode<T> node, BSTNode<T> parent, int key, bool left)
        {
            if (node == null)
            {
                return new BSTFind<T>
                {
                    NodeHasKey = false,
                    Node = parent,
                    ToLeft = left
                };
            }
            
            if (node.NodeKey == key)
            {
                return new BSTFind<T>
                {
                    NodeHasKey = true,
                    Node = node
                };
            }
            
            return key < node.NodeKey ? FindNode(node.LeftChild, node, key, true) : FindNode(node.RightChild, node, key, false);
        }
	
    }
}