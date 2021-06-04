using System;

namespace Orsel.Collections
{
    public class Queue
    {
        private int[] array;
        private const int defaultCapacity = 100;
        private int first;
        private int last;

        public int Capacity
        {
            get
            {
                return array.Length;
            }

            set
            {
                int[] tempArray = new int[value];
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

        
        public Queue(int capacity = defaultCapacity)
        {
            array = new int[capacity];
        }

        public void Enqueue(int item)
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

        public int Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Очередь пуста.");
            }

            int item = array[first];
            Count--;

            int tmp = first + 1;
            if (tmp == array.Length)
            {
                tmp = 0;
            }
            first = tmp;

            return item;
        }
    }
}
