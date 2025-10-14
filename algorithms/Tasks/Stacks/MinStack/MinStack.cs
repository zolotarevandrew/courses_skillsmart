using System.Numerics;

namespace Tasks.Stacks.MinStack;

public sealed class MinStack<T>( IComparer<T>? comparer = null )
{
    private readonly List<(T val, T min)> _store = new();
    private readonly IComparer<T> _cmp = comparer ?? Comparer<T>.Default;

    public int Count => _store.Count;

    public void Push(T value)
    {
        T min = _store.Count == 0
            ? value
            : _cmp.Compare(value, _store[^1].min) <= 0 ? value : _store[^1].min;

        _store.Add((value, min));
    }

    public T Pop()
    {
        if (_store.Count == 0) throw new InvalidOperationException("Stack is empty");
        (T val, _) = _store[^1];
        _store.RemoveAt(_store.Count - 1);
        return val;
    }

    public T Peek()
    {
        if (_store.Count == 0) throw new InvalidOperationException("Stack is empty");
        return _store[^1].val;
    }

    public T GetMin()
    {
        if (_store.Count == 0) throw new InvalidOperationException("Stack is empty");
        return _store[^1].min;
    }
}

public class MinStackV2<T>( IComparer<T>? comparer = null )
{
    private class Node
    {
        public T Value;
        public T MinSoFar;
        public Node Next;

        public Node(T value, T minSoFar, Node? next)
        {
            Value = value;
            MinSoFar = minSoFar;
            Next = next;
        }
    }
    
    private readonly IComparer<T> _cmp = comparer ?? Comparer<T>.Default;
    private Node? _head;
    public int Count { get; private set; }

    public void Push( T value )
    {
        T min = _head == null
            ? value
            : _cmp.Compare( value, _head.MinSoFar ) <= 0
                ? value
                : _head.MinSoFar;
        _head = new Node(value, min, _head  );
    }

    public T Pop( )
    {
        if ( _head is null )
        {
            throw new InvalidOperationException("Stack is empty");
        }
        T v = _head.Value;
        _head = _head.Next;
        Count--;
        return v;
    }
    
    public T Peek()
    {
        if ( _head is null )
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return _head.Value;
    }
    
    public T GetMin()
    {
        if ( _head is null )
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return _head.MinSoFar;
    }
    
    
}