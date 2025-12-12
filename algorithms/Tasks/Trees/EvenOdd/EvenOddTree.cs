using System.Numerics;

namespace Tasks.Trees.EvenOdd;

public class EvenOddTree
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
    }
    /*
     * A binary tree is "even-odd" if it satisfied the following conditions:
     * Even-indexed levels contain odd numbers in strictly increasing order from left to right
     * Odd-indexed levels contain even numbers in strictly decreasing order from left to right
     */

    enum LevelState
    {
        Odd = 1,
        Even = 2
    }

    struct Option<T>
    {
        public T? Value { get; init; }
        public bool HasValue { get; init; }

        public Option( )
        {
            HasValue = false;
        }

        public Option(T value )
        {
            Value = value;
            HasValue = true;
        }
    }
    public static bool Run( TreeNode<int> tree )
    {
        Queue<TreeNode<int>> queue = new Queue<TreeNode<int>>();
        queue.Enqueue( tree );

        LevelState state = LevelState.Even;
        while ( queue.Count > 0 )
        {
            int size = queue.Count;
            Option<int> prevValue = new ( );
            for ( int i = 0; i < size; i++ )
            {
                TreeNode<int> node = queue.Dequeue();
                int curValue = node.Value;

                if ( state == LevelState.Even && prevValue.HasValue )
                {
                    bool isStrictlyDecreasing = prevValue.Value! > curValue && curValue % 2 != 0;
                    if ( !isStrictlyDecreasing ) return false;
                }

                if ( state == LevelState.Odd && prevValue.HasValue )
                {
                    bool isStrictlyIncreasing = curValue > prevValue.Value! && curValue % 2 == 0;
                    if ( !isStrictlyIncreasing ) return false;
                }

                if ( node.Left != null )
                {
                    queue.Enqueue( node.Left );
                }

                if ( node.Right != null )
                {
                    queue.Enqueue( node.Right );
                }

                prevValue = new Option<int>( curValue );
            }

            state = state == LevelState.Even 
                ? LevelState.Odd 
                : LevelState.Even;
        }
        
        return true;
    }
}