using System;

namespace Orsel.Collections
{
    public class Queue<T>
    {
        private T[] array;
        private int first;
        private int last;

        private const int defaultCapacity = 4;  

        public int Capacity
        {
            get
            {
                return array.Length;
            }

            set
            {
                T[] tempArray = new T[value];
                Array.Copy(array, first, tempArray, last, Count);    
                Array.Copy(array, tempArray, Count);
                array = tempArray;
            }
        }

        public int Count
        {
            get;
            private set;
        }

        public Queue()
        {
            array = Array.Empty<T>();
        }

        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Емкость очереди не может быть отрицательной.");
            }
            array = new T[capacity];
        }

        private bool IsFull()
        {
            return Count == Capacity;
        }

        public void Enqueue(T item)
        {
            array[last] = item;
            Count++;

            int tmp = last + 1;
            if (tmp == array.Length)
            {
                tmp = 0;
            }
            last = tmp;
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Очередь пуста.");
            }

            T item = array[first];
            Count--;

            int tmp = first + 1;
            if (tmp == array.Length)
            {
                tmp = 0;
            }
            first = tmp;

            return item;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Очередь пуста");
            }

            return array[first];
        }

        public void Clear()
        {
            if (!IsEmpty())
            {
                if (first < last)
                {
                    Array.Clear(array, first, Count);
                }
                else
                {
                    Array.Clear(array, first, array.Length - first);
                    Array.Clear(array, 0, last);
                }
                Count = 0;
            }
            first = 0;
            last = 0;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }
    }
}
