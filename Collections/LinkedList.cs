using System;

namespace Orsel.Collections
{
    public class NodeLinkedList<T>
    {
        public T Data;
        public NodeLinkedList<T> Next;

        public NodeLinkedList(T data, NodeLinkedList<T> nextNode = null)
        {
            Data = data;
            Next = nextNode;
        }
    }

    public class LinkedList
    {
    }
}
