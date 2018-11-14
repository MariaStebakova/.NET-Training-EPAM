using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLibrary
{
    public class Queue<T> : IEnumerable<T>, IEnumerable
    {
        private int _capacity;
        private int _size;
        private int _head;
        private int _tail;

        private T[] _queueBase;

        private const int DEFAULT_CAPACITY = 4;

        /// <summary>
        /// Property for getting current queue items amount
        /// </summary>
        public int Count => _size;

        internal T[] QueueItems => _queueBase;

        /// <summary>
        /// Default <see cref="Queue{T}"/> ctor
        /// </summary>
        public Queue() : this(DEFAULT_CAPACITY) { }

        /// <summary>
        /// <see cref="Queue{T}"/> ctor based on <paramref name="capacity"/> value
        /// </summary>
        /// <param name="capacity">Needed capacity of queue</param>
        /// <exception cref="ArgumentException">Throw when <paramref name="capacity"/> is less than 1</exception>
        public Queue(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException($"{nameof(capacity)} can't be less than 1");

            _capacity = capacity;
            _size = 0;
            _head = 0;
            _tail = 0;

            _queueBase = new T[capacity];
        }

        /// <summary>
        /// <see cref="Queue{T}"/> ctor based on <paramref name="collection"/> collection
        /// </summary>
        /// <param name="collection">Collection for initializing</param>
        /// <exception cref="ArgumentException">Throw when <paramref name="collection"/> is equal to null of empty</exception>
        public Queue(IEnumerable<T> collection) : this(collection?.Count() ?? DEFAULT_CAPACITY)
        {
            if (collection == null)
                throw new ArgumentNullException($"{nameof(collection)} can't be equal to null!");

            if (collection.Count() == 0)
                throw new ArgumentException($"{nameof(collection)} can't be empty!");

            _capacity = collection.Count();

            IEnumerator<T> enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
                Enqueue(enumerator.Current);
        }

        /// <summary>
        /// Adds <paramref name="value"/> to the tail of the queue
        /// </summary>
        /// <param name="value">Item for adding</param>
        public void Enqueue(T value)
        {
            if (value == null)
                throw new ArgumentNullException($"{nameof(value)} can't be equal to null!");

            if (_size == _capacity)
                ResetCapacity();

            _queueBase[_tail] = value;
            _tail = (_tail + 1) % _queueBase.Length;
            _size++;
        }

        /// <summary>
        /// Removes and returns head from the queue
        /// </summary>
        /// <returns>Removed head</returns>
        /// <exception cref="InvalidOperationException">Throws when <see cref="_size"/> is equal to 0</exception>
        public T Dequeue()
        {
            if (_size == 0)
                throw new InvalidOperationException($"Can't do this operation because {Count} is equal to 0");

            T removedValue = _queueBase[_head];
            _queueBase[_head] = default(T);
            _head = (_head + 1) % Count;
            _size--;

            return removedValue;
        }

        /// <summary>
        /// Clears the queue
        /// </summary>
        public void Clear()
        {
            Array.Clear(_queueBase, 0, _queueBase.Length);

            _head = 0;
            _tail = 0;
            _size = 0;
        }

        /// <summary>
        /// Gets the head of the queue without removing it
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws when <see cref="_size"/> is equal to 0</exception>
        /// <returns>Head of the queue</returns>
        public T Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException($"Can't do this operation when {nameof(Count)} is equal to 0!");

            return _queueBase[_head];
        }

        /// <summary>
        /// Checks if queue contains <paramref name="value"/>
        /// </summary>
        /// <param name="value">Needed queue item</param>
        /// <returns>Boolean result based on existing <paramref name="value"/> in the queue</returns>
        public bool Contains(T value)
        {
            if (_size == 0)
                return false;

            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            for (int i = 0; i < _size; i++)
            {
                if (comparer.Equals(_queueBase[i], value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Return array representation of queue
        /// </summary>
        /// <returns>Array representation of queue</returns>
        public T[] ToArray()
        {
            T[] resultArray = new T[_size];

            for (int i = 0; i < Count; i++)
            {
                resultArray[i] = _queueBase[i];
            }

            return resultArray;
        }

        private void ResetCapacity()
        {
            int newCapacity = _capacity * 2;
            T[] newQueueBase = new T[newCapacity];

            if (_size > 0)
            {
                if (_head < _tail)
                    Array.Copy(_queueBase, _head, newQueueBase, 0, _size);
                else
                {
                    Array.Copy(_queueBase, _head, newQueueBase, 0, _queueBase.Length - _head);
                    Array.Copy(_queueBase, 0, newQueueBase, _queueBase.Length - _head, _tail);
                }
            }

            _queueBase = newQueueBase;
            _head = 0;
            _tail = (_size == _capacity) ? 0 : _size;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Structure representing enumerator of <see cref="Queue{T}"/>
        /// </summary>
        public struct QueueEnumerator : IEnumerator<T>, IEnumerator
        {
            private readonly Queue<T> queue;
            private int currentIndex;
            private T currentItem;

            public QueueEnumerator(Queue<T> queue)
            {
                this.queue = queue;
                currentIndex = -1;
                currentItem = default(T);
            }

            public void Dispose()
            {
                currentIndex = -1;
                currentItem = default(T);
            }

            public bool MoveNext()
            {
                currentIndex++;

                if (currentIndex == queue.Count)
                {
                    currentIndex = -1;
                    currentItem = default(T);
                    return false;
                }

                currentItem = queue.QueueItems[currentIndex];

                return true;
            }

            public void Reset()
            {
                currentIndex = -1;
                currentItem = default(T);
            }

            public T Current
            {
                get
                {
                    if (currentIndex == -1)
                        throw new InvalidOperationException("The iteration does not started or ended.");
                    
                    return currentItem;
                }
            }

            object IEnumerator.Current => Current;
        }
    }
}
