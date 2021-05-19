using System;

namespace Orsel.Collections
{
    public class LinkedList<T>
    {
        public LinkedListNode<T> First
        {
            get;
            private set;
        }

        public LinkedListNode<T> Last
        {
            get;
            private set;
        }

        public int Count
        {
            get;
            private set;
        }

        public LinkedList()
        {
            First = null;
            Last = null;
            Count = 0;
        }

        public void Insert(LinkedListNode<T> node, T data)
        {
            if(node == null)
            {
                First = new LinkedListNode<T>(data);
                Last = First;
            }
        }
    }
}
