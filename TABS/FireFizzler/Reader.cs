using System;
using System.Collections;
using System.Collections.Generic;

namespace FireFizzler
{
    public sealed class Reader<T> : IDisposable, IEnumerable<T>
    {
        IEnumerator<T> _enumerator;
        Stack<T> _buffer;

        /// <summary>
        /// Initialize a new <see cref="Reader{T}"/> with a base
        /// <see cref="IEnumerable{T}"/> object.
        /// </summary>
        public Reader(IEnumerable<T> e) :
            this(e?.GetEnumerator())
        { }

        /// <summary>
        /// Initialize a new <see cref="Reader{T}"/> with a base
        /// <see cref="IEnumerator{T}"/> object.
        /// </summary>
        public Reader(IEnumerator<T> e)
        {
            _enumerator = e ?? throw new ArgumentNullException(nameof(e));
            _buffer = new Stack<T>();
            RealRead();
        }

        /// <summary>
        /// Indicates whether there is, at least, one value waiting to be read or not.
        /// </summary>
        public bool HasMore
        {
            get
            {
                EnsureAlive();
                return _buffer.Count > 0;
            }
        }

        /// <summary>
        /// Pushes back a new value that will be returned on the next read.
        /// </summary>
        public void Unread(T value)
        {
            EnsureAlive();
            _buffer.Push(value);
        }

        /// <summary>
        /// Reads and returns the next value.
        /// </summary>
        public T Read()
        {
            if (!HasMore)
                throw new InvalidOperationException();

            var value = _buffer.Pop();

            if (_buffer.Count == 0)
                RealRead();

            return value;
        }

        /// <summary>
        /// Peeks the next value waiting to be read.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if there is no value waiting to be read.
        /// </exception>
        public T Peek()
        {
            if (!HasMore)
                throw new InvalidOperationException();

            return _buffer.Peek();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Returns an enumerator that iterates through the remaining
        /// values to be read.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            EnsureAlive();
            return GetEnumeratorImpl();
        }

        IEnumerator<T> GetEnumeratorImpl()
        {
            while (HasMore)
                yield return Read();
        }

        void RealRead()
        {
            EnsureAlive();

            if (_enumerator.MoveNext())
                Unread(_enumerator.Current);
        }

        /// <summary>
        /// Disposes the enumerator used to initialize this object
        /// if that enumerator supports <see cref="IDisposable"/>.
        /// </summary>
        public void Close() => Dispose();

        void IDisposable.Dispose() => Dispose();

        void Dispose()
        {
            if (_enumerator == null)
                return;
            _enumerator.Dispose();
            _enumerator = null;
            _buffer = null;
        }

        void EnsureAlive()
        {
            if (_enumerator == null)
                throw new ObjectDisposedException(GetType().Name);
        }
    }
}
