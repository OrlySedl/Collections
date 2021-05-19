using System;

namespace Orsel.Collections
{
    public class LinkedListNode<T>
    {
        public T Value;
        public LinkedListNode<T> Next;

        public LinkedListNode(T value, LinkedListNode<T> node = null)
        {
            Value = value;
            Next = node;
        }
    }
}
