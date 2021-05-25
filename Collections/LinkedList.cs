using System;

namespace Orsel.Collections
{
    public class LinkedList
    {
        public LinkedListNode First
        {
            get;
            private set;
        }

        public LinkedListNode Last
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

        public LinkedListNode Insert(LinkedListNode node, int data)
        {
            LinkedListNode newNode = new LinkedListNode(data);
            
            return Insert(node, newNode);
        }

        public LinkedListNode Insert(LinkedListNode node, LinkedListNode newNode)
        {
            if (node == null)
            {
                newNode.Next = First;
                if (First == null)
                {
                    Last = newNode;
                }
                First = newNode;
            }
            else if (node == Last)
            {
                newNode.Next = null;
                Last.Next = newNode;
                Last = newNode;
            }
            else
            {
                LinkedListNode p = First;
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

        public void Remove(int value)
        {
            for (LinkedListNode current = First; current != null; current = current.Next)
            {
                if (current.Value == value)
                {
                    //return true;
                }
            }
        }
    }
}
