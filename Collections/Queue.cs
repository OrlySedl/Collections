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
                if (!IsEmpty())
                {
                    if (first < last)
                    {
                        Array.Copy(array, first, tempArray, 0, Count);
                    }
                    else
                    {
                        Array.Copy(array, first, tempArray, 0, array.Length - first);
                        Array.Copy(array, 0, tempArray, array.Length - first, last);
                    }
                }
                array = tempArray;
                first = 0;
                last = Count;
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
            if (IsFull())
            {
                Capacity = Capacity == 0 ? defaultCapacity : Capacity * 2;
            }

            array[last++] = item;
            if (last == Capacity)
            {
                last = 0;
            }
            Count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Очередь пуста.");
            }

            T item = array[first];
            array[first++] = default!;
            if (first == Capacity)
            {
                first = 0;
            }
            Count--;

            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
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
