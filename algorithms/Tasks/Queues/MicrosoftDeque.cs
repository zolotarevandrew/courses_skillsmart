using System.Diagnostics;

namespace Tasks.Queues;

internal sealed class MicrosoftDeque<T>
{
    private T[] _array = [];
    private int _head;
    private int _tail;
    private int _size;

    public int Count => _size;
    public bool IsEmpty => _size == 0;

    public void EnqueueTail( T item )
    {
        if ( _size == _array.Length )
        {
            Grow( );
        }

        _array[_tail] = item;
        if ( ++_tail == _array.Length )
        {
            _tail = 0;
        }

        _size++;
    }
    
    public T Head => _array[_head];
    public T Tail => _tail - 1 == -1 ? _array[^1] : _array[_tail - 1];

    public void EnqueueHead( T item )
    {
        if ( _size == _array.Length )
        {
            Grow( );
        }

        _head = ( _head == 0 ? _array.Length : _head ) - 1;
        _array[_head] = item;
        _size++;
    }

    public T DequeueHead( )
    {
        Debug.Assert( !IsEmpty );

        //head is always in array bound
        T item = _array[_head];
        _array[_head] = default!;

        //circular behaviour
        if ( ++_head == _array.Length )
        {
            _head = 0;
        }

        _size--;

        return item;
    }

    public T DequeueTail( )
    {
        Debug.Assert( !IsEmpty );

        //case when tail was moved to 0
        if ( --_tail == -1 )
        {
            _tail = _array.Length - 1;
        }

        //clearing tail
        T item = _array[_tail];
        _array[_tail] = default!;

        _size--;
        return item;
    }

    private void Grow( )
    {
        //then array is full tail and head should always be the same
        Debug.Assert( _size == _array.Length );
        Debug.Assert( _head == _tail );

        const int MinimumGrow = 4;

        int capacity = (int)( _array.Length * 2L );
        if ( capacity < _array.Length + MinimumGrow )
        {
            capacity = _array.Length + MinimumGrow;
        }

        T[] newArray = new T[capacity];

        //then head and tail in the 0, just copy the array
        if ( _head == 0 )
        {
            Array.Copy( _array, newArray, _size );
        }
        else
        {
            Array.Copy( _array, _head, newArray, 0, _array.Length - _head );
            Array.Copy( _array, 0, newArray, _array.Length - _head, _tail );
        }

        _array = newArray;
        _head = 0;
        _tail = _size;
    }
}