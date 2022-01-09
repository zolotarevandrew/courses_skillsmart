using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue { get; private set; }
        public int Level { get; private set; }
        public SimpleTreeNode<T> Parent { get; private set; }
        public List<SimpleTreeNode<T>> Children;
	
        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = null;
        }

        public void SetParent(SimpleTreeNode<T> parent)
        {
            Parent = parent;
            Level = parent == null ? 1 : parent.Level + 1;
            RefillChildLevels();
        }

        void RefillChildLevels()
        {
            FillLevel(this, Level);
        }
        
        void FillLevel(SimpleTreeNode<T> node, int level)
        {
            node.Level = level;
            foreach (var item in node.Children ?? new List<SimpleTreeNode<T>>())
            {
                FillLevel(item, level + 1);
            }
        }
    }
	
    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root;

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
            Root.SetParent(null);
        }
        
        public List<T> EvenTrees()
        {
            var res = new List<T>();
            if (Root == null) return res;
            
            Dictionary<SimpleTreeNode<T>, bool> visited = new Dictionary<SimpleTreeNode<T>, bool>();
            Traverse(Root, visited, res);
            return res;
        }

        int Traverse(SimpleTreeNode<T> node, Dictionary<SimpleTreeNode<T>, bool> visited, List<T> fill)
        {
            int count = 0;
            visited[node] = true;
            foreach (var children in node.Children ?? new List<SimpleTreeNode<T>>())
            {
                if (visited.ContainsKey(children)) 
                    continue;

                int subtreeCount = Traverse(children, visited, fill);
                if (subtreeCount % 2 == 0)
                {
                    fill.Add(node.NodeValue);
                    fill.Add(children.NodeValue);
                    continue;
                }
                count += subtreeCount;
            }

            return count + 1;
        }
	
        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            if (NewChild == null) 
                throw new ArgumentNullException("NewChild");

            if (ParentNode == null) 
                throw new ArgumentNullException("ParentNode");

            NewChild.SetParent(ParentNode);

            ParentNode.Children ??= new List<SimpleTreeNode<T>>();
            ParentNode.Children.Add(NewChild);
        }

        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)
        {
            if (NodeToDelete == null) 
                throw new ArgumentNullException("NodeToDelete");
            if (NodeToDelete.Children != null)
            {
                NodeToDelete.Children.Clear();
            }
            
            DeleteNodeFromParent(NodeToDelete);
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            return GetNodes(Root);
        }

        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            return GetNodesByValue(Root, val);
        }
        
        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            if (NewParent == null)
                throw new ArgumentNullException("NewParent");
            
            DeleteNodeFromParent(OriginalNode);
            AddChild(NewParent, OriginalNode);
        }
        
        void DeleteNodeFromParent(SimpleTreeNode<T> node)
        {
            if (node.Parent.Children == null) return;

            var parentNodes = node.Parent.Children;
            if (parentNodes.IndexOf(node) >= 0)
            {
                parentNodes.Remove(node);
                if (parentNodes.Count == 0)
                {
                    node.Parent.Children = null;
                }
            }
        }
   
        public int Count()
        {
            var all = GetAllNodes();
            return all.Count;
        }

        public int LeafCount()
        {
            var all = GetAllNodes();
            int cnt = 0;
            foreach (var item in all)
            {
                if (item.Children == null) cnt++;
            }

            return cnt;
        }
        
        List<SimpleTreeNode<T>> GetNodes(SimpleTreeNode<T> node)
        {
            var res = new List<SimpleTreeNode<T>>();
            res.Add(node);
            
            foreach (var item in node.Children ?? new List<SimpleTreeNode<T>>())
            {
                res.AddRange(GetNodes(item));
            }
            return res;
        }
        
        List<SimpleTreeNode<T>> GetNodesByValue(SimpleTreeNode<T> node, T value)
        {
            var res = new List<SimpleTreeNode<T>>();
            
            if (node.NodeValue.Equals(value)) res.Add(node);
            
            foreach (var item in node.Children ?? new List<SimpleTreeNode<T>>())
            {
                res.AddRange(GetNodesByValue(item, value));
            }
            return res;
        }
    }
}