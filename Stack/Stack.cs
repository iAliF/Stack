using System;

namespace Stack
{
    public class Stack<TType>
    {
        private const int DefaultMaxSize = 100;

        private readonly int _maxSize;
        private int _top = -1;
        private readonly TType[] _array;

        public int Count => IsEmpty() ? 0 : _top + 1;

        public Stack() : this(DefaultMaxSize)
        {
        }

        public Stack(int maxSize)
        {
            _maxSize = maxSize;
            _array = new TType[maxSize];
        }

        public bool IsEmpty() => _top == -1;

        public bool IsFull() => _top == _maxSize - 1;

        public void Push(TType item)
        {
            if (IsFull())
                throw new StackOverflowException();

            _array[++_top] = item;
        }

        public TType Pop()
        {
            if (IsEmpty())
                throw new StackEmptyException();

            return _array[_top--];
        }
        
        public void Clear()
        {
            _top = -1;
        }
    }
}