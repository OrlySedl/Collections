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

        public LinkedListNode<T> Insert(LinkedListNode<T> node, T data)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(data);
            
            return Insert(node, newNode);
        }

        public LinkedListNode<T> Insert(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            if (node == null)
            {
                newNode.Next = First;
                First = newNode;
                if (Count == 0)
                {
                    Last = newNode;
                }
            }
            else if (node == Last)
            {
                newNode.Next = null;
                Last.Next = newNode;
                Last = newNode;
            }
            else
            {
                LinkedListNode<T> p = First;
                while (p != node)
                {
                    p = p.Next;
                }
                newNode.Next = p.Next;
                p.Next = newNode;
            }
            Count++;
            return newNode;
        }
    }
}
