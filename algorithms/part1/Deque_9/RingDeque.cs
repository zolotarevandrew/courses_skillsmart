using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Deque_9;

    public class Deque<T>
    {
        private const int DefaultCapacity = 4;

        private static readonly T[] EmptyBuffer = new T[0];

        private int _version;

        /// <summary>
        /// Ring buffer that holds the items.
        /// </summary>
        private T[] _buffer;

        /// <summary>
        /// The offset used to calculate the position of the leftmost item in the buffer.
        /// </summary>
        private int _leftIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="Deque{T}"/> class.
        /// </summary>
        public Deque()
        {
            _buffer = EmptyBuffer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Deque{T}"/> class with the specified capacity.
        /// </summary>
        /// <param name="capacity">The deque's initial capacity.</param>
        /// <exception cref="ArgumentOutOfRangeException">Capacity cannot be less than 0.</exception>
        public Deque(int capacity)
        {
            if(capacity < 0)
                throw new ArgumentOutOfRangeException("capacity", "capacity was less than zero.");

            _buffer = capacity == 0 ? EmptyBuffer : new T[capacity];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Deque{T}"/> class that contains elements copied from the specified collection.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the deque.</param>
        public Deque(IEnumerable<T> collection)
        {
            if(collection == null)
                throw new ArgumentNullException("collection");

            InitializeFromCollection(collection);
        }

        private void InitializeFromCollection(IEnumerable<T> enumerable)
        {
            var collection = enumerable as ICollection<T> ?? enumerable.ToArray();

            var count = collection.Count;

            //initialize buffer
            if (count == 0)
                _buffer = EmptyBuffer;
            else
            {
                _buffer = new T[count];
                collection.CopyTo(_buffer, 0);
                Count = count;
            }
        }

        /// <summary>
        /// Adds an item to the right end of the <see cref="Deque{T}"/>.
        /// </summary>
        /// <param name="item">The item to be added to the <see cref="Deque{T}"/>.</param>
        public void PushRight(T item)
        {
            EnsureCapacity(Count + 1);
            Count ++;
            Right = item;

            _version++;
        }

        /// <summary>
        /// Adds an item to the left end of the <see cref="Deque{T}"/>.
        /// </summary>
        /// <param name="item">The item to be added to the <see cref="Deque{T}"/>.</param>
        public void PushLeft(T item)
        {
            EnsureCapacity(Count + 1);
            
            LeftIndex --;
            Count++;
            Left = item;
        }

        /// <summary>
        /// Attempts to remove and return an item from the right end of the <see cref="Deque{T}"/>.
        /// </summary>
        /// <returns>The rightmost item.</returns>
        /// <exception cref="InvalidOperationException">The deque is empty.</exception>
        public T PopRight()
        {
            if (IsEmpty)
                throw new InvalidOperationException("The deque is empty");

            //retrieve rightmost item and clean buffer slot
            var right = Right;
            Right = default(T);

            //dec count
            Count--;
            return right;
        }

        /// <summary>
        /// Attempts to remove and return an item from the left end of the <see cref="Deque{T}"/>.
        /// </summary>
        /// <returns>The leftmost item.</returns>
        /// <exception cref="InvalidOperationException">The deque is empty.</exception>
        public T PopLeft()
        {
            if (IsEmpty)
                throw new InvalidOperationException("The deque is empty");
            
            var left = Left;
            Left = default(T);
            
            LeftIndex++;
            Count--;

            return left;
        }

        /// <summary>
        /// Attempts to return the rightmost item of the <see cref="Deque{T}"/> 
        /// without removing it.
        /// </summary>
        /// <returns>The rightmost item.</returns>
        /// <exception cref="InvalidOperationException">The deque is empty.</exception>
        public T PeekRight()
        {
            if (IsEmpty)
                throw new InvalidOperationException("The deque is empty");

            //retrieve rightmost item
            return Right;
        }

        /// <summary>
        /// Attempts to return the leftmost item of the <see cref="Deque{T}"/> 
        /// without removing it.
        /// </summary>
        /// <returns>The leftmost item.</returns>
        /// <exception cref="InvalidOperationException">The deque is empty.</exception>
        public T PeekLeft()
        {
            if (IsEmpty)
                throw new InvalidOperationException("The deque is empty");

            //retrieve leftmost item
            return Left;
        }
        
        public void Clear()
        {
            //clear the ring buffer to allow the GC to reclaim the references
            if (LoopsAround)
            {
                //clear both halves
                Array.Clear(_buffer, LeftIndex, Capacity - LeftIndex);
                Array.Clear(_buffer, 0, LeftIndex + (Count - Capacity));
            }
            else //clear the whole array
                Array.Clear(_buffer, LeftIndex, Count);

            Count = 0;
            LeftIndex = 0;
            _version++;
        }

        /// <summary> 
        /// Ensures that the capacity of this list is at least the given minimum
        /// value. If the currect capacity of the list is less than min, the
        /// capacity is increased to twice the current capacity or to min,
        /// whichever is larger.
        /// </summary>
        /// <param name="min">The minimum capacity required.</param>
        private void EnsureCapacity(int min)
        {
            if (Capacity < min)
            {
                var newCapacity = Capacity == 0 ? DefaultCapacity : Capacity*2;
                newCapacity = Math.Max(newCapacity, min);
                Capacity = newCapacity;
            }
        }
        
        static int Mod(int a, int n)
        {
            if (n == 0)
                throw new ArgumentOutOfRangeException("n", "(a mod 0) is undefined.");

            //puts a in the [-n+1, n-1] range (for n > 0) using the remainder operator
            //or [n+1, -n-1] for n < 0.
            int remainder = a%n;

            //if the remainder is less than zero, add n to put it in the [0, n-1] range if n is positive
            //if the remainder is greater than zero, add n to put it in the [n+1, 0] range if n is negative
            if ((n > 0 && remainder < 0) || (n < 0 && remainder > 0))
                return remainder + n;
            return remainder;
        }
        
        public int Count { get; private set; }
        
        public bool IsEmpty
        {
            get { return Count == 0; }
        }
        
        public int Capacity
        {
            get { return _buffer.Length; }
            set
            {
                if (value < Count)
                    throw new ArgumentOutOfRangeException("value", "capacity was less than the current size.");

                if (value == Capacity)
                    return;

                T[] newBuffer = new T[value];

                CopyTo(newBuffer, 0);

                LeftIndex = 0;
                _buffer = newBuffer;
            }
        }
        
        private void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array");

            if (array.Rank != 1)
                throw new ArgumentException("Only single dimensional arrays are supported for the requested action.");

            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex", "Index was less than the array's lower bound.");

            if (arrayIndex >= array.Length)
                throw new ArgumentOutOfRangeException("arrayIndex", "Index was greater than the array's upper bound.");

            if (Count == 0)
                return;

            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("Destination array was not long enough");
            
            try
            {
                //if the elements are stored sequentially (i.e., left+count doesn't "wrap around" the array's boundary),
                //copy the array as a whole
                if (!LoopsAround)
                {
                    Array.Copy(_buffer, LeftIndex, array, arrayIndex, Count);
                }
                else
                {
                    //copy both halves to a new array
                    Array.Copy(_buffer, LeftIndex, array, arrayIndex, Capacity - LeftIndex);
                    Array.Copy(_buffer, 0, array, arrayIndex + Capacity - LeftIndex, LeftIndex + (Count - Capacity));
                }
            }
            catch (ArrayTypeMismatchException)
            {
                throw new ArgumentException("Target array type is not compatible with the type of items in the collection.");
            }
        }
        
        private bool LoopsAround => Count > (Capacity - LeftIndex);

        public T this[int index]
        {
            get => _buffer[VirtualIndexToBufferIndex(index)];
            set => _buffer[VirtualIndexToBufferIndex(index)] = value;
        }
        
        private int VirtualIndexToBufferIndex(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException("index", "Index was out of range. Must be non-negative and less than the size of the collection.");

            //Apply LeftIndex offset and modular arithmetic
            return CalcIndex(LeftIndex + index);
        }

        private int LeftIndex
        {
            get { return _leftIndex; }
            set { _leftIndex = CalcIndex(value); }
        }
        
        /// <summary>
        /// Uses modular arithmetic to calculate the correct ring buffer index for a given (possibly out-of-bounds) index.
        /// If <paramref name="position"/> is over the array's upper boundary, the returned index "wraps/loops around" the upper boundary.
        /// </summary>
        /// <param name="position">The possibly out-of-bounds index.</param>
        /// <returns>The ring buffer index.</returns>
        private int CalcIndex(int position)
        {
            //put 'position' in the range [0, Capacity-1] using modular arithmetic
            if ( Capacity != 0 )
                return Mod( position, Capacity );

            //if capacity is 0, _leftIndex must always be 0
            Debug.Assert(_leftIndex == 0);

            return 0;
        }

        private T Left
        {
            get { return this[0]; }
            set { this[0] = value; }
        }

        private T Right
        {
            get { return this[Count - 1]; }
            set { this[Count - 1] = value; }
        }
    }