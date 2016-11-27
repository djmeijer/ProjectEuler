using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Utilities
{
    /// <summary>
    ///   Minimum priority queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MinimumPriorityQueue<T>
    {
        private readonly Func<T, int> _getElementPriority;
        private readonly T[] _elements;
        private readonly Dictionary<T, int> _elementIndices;
        private int _currentQueueSize;

        /// <summary>
        ///   Initializes a new instance of the <see cref="MinimumPriorityQueue{T}" /> class.
        /// </summary>
        /// <param name="getElementPriority">The function to get the element priority.</param>
        /// <param name="maximumQueueSize">Maximum number of elements in the queue.</param>
        public MinimumPriorityQueue(Func<T, int> getElementPriority, int maximumQueueSize)
        {
            _getElementPriority = getElementPriority;
            _elementIndices = new Dictionary<T, int>();
            _elements = new T[maximumQueueSize];
            _currentQueueSize = 0;
        }

        /// <summary>
        ///   Inserts the specified element into the queue.
        /// </summary>
        /// <param name="element">The element.</param>
        public void Insert(T element)
        {
            _elements[_currentQueueSize] = element;
            _elementIndices.Add(element, _currentQueueSize);
            _currentQueueSize++;
            DecreaseElementPriority(element);
        }


        /// <summary>
        /// Minimums this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">There are no elements in the queue.</exception>
        public T Minimum()
        {
            if(!Any())
            {
              throw new Exception("There are no elements in the queue.");
            }
            return _elements[0];
        }

        /// <summary>
        /// Prints this queue to the console.
        /// </summary>
        public void Show()
        {
            StringBuilder heap = new StringBuilder();
            foreach(string element in _elements.Select(e => e.ToString()).Intersperse(","))
            {
              heap.Append(element);
            }
            Console.WriteLine(heap);
        }

        /// <summary>
        ///   Extracts the minimum element from the queue.
        /// </summary>
        /// <returns></returns>
        public T ExtractMinimum()
        {
            _currentQueueSize--;
            var minimum = _elements[0];
            _elements[0] = _elements[_currentQueueSize];
            _elementIndices[_elements[0]] = 0;
            MinHeapify(0);
            return minimum;
        }



        /// <summary>
        ///  Decreases the position of the given element to it's correct position in the queue.
        /// </summary>
        /// <param name="element">The element.</param>
        public void DecreaseElementPriority(T element)
        {
            int index = _elementIndices[element];
            int parentIndex = Parent(index);

            while(index > 0 && _getElementPriority(_elements[parentIndex]) > _getElementPriority(_elements[index]))
            {
                // Exchange with parent up the tree.
                T tmp = _elements[index];
                _elements[index] = _elements[parentIndex];
                _elements[parentIndex] = tmp;

                _elementIndices[_elements[parentIndex]] = parentIndex;
                _elementIndices[_elements[index]] = index;

                index = parentIndex;
                parentIndex = Parent(index);
            }
        }

        /// <summary>
        /// Test whether this queue has any elements.
        /// </summary>
        /// <returns></returns>
        public bool Any() => _currentQueueSize > 0;

        private void MinHeapify(int index)
        {
            int left = Left(index);
            int right = Right(index);
            int smallest;

            if(left <= _currentQueueSize && _getElementPriority(_elements[left]) < _getElementPriority(_elements[index]))
            {
                smallest = left;
            }
            else
            {
                smallest = index;
            }

            if(right <= _currentQueueSize && _getElementPriority(_elements[right]) < _getElementPriority(_elements[smallest]))
            {
                smallest = right;
            }

            if(smallest != index)
            {
                // Exchange.
                T tmp = _elements[index];
                _elements[index] = _elements[smallest];
                _elements[smallest] = tmp;

                _elementIndices[_elements[index]] = index;
                _elementIndices[_elements[smallest]] = smallest;

                MinHeapify(smallest);
            }
        }

        private static int Left(int i) => 2 * (i + 1) - 1;

        private static int Right(int i) => 2 * (i + 1);

        private static int Parent(int i) => (i + 1) / 2 - 1;
    }
}