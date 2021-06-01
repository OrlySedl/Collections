using System;

namespace Orsel.Collections
{
    public class Queue
    {
        private int[] array;
        private const int defaultCapacity = 100;

        public int Capacity
        {
            get
            {
                return array.Length;
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
    }
}
