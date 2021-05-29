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

        public LinkedListNode Next(LinkedListNode node = null)
        {
            if (node == null)
            {
                return First;
            }
            else if (node == Last)
            {
                return null;
            }
            else
            {
                return node.Next;
            }
        }

        public LinkedListNode Search(int value)
        {
            for (LinkedListNode current = First; current != null; current = current.Next)
            {
                if (current.Value == value)
                {
                    return current;
                }
            }
            return null;
        }

        public LinkedListNode Insert(LinkedListNode node, int value)
        {
            LinkedListNode newNode = new LinkedListNode(value);
            
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

        public LinkedListNode Remove(int value)
        {
            LinkedListNode prev = First;
            for (LinkedListNode current = First; current != null; current = current.Next)
            {
                if (current.Value == value)
                {
                    prev.Next = current.Next;
                    return current;
                }
                prev = current;
            }
            return null;
        }

        public LinkedListNode Remove(LinkedListNode prevNode, LinkedListNode removeNode)
        {
            if (prevNode == null)
            {
                First = removeNode.Next;
            }
            else
            {
                prevNode.Next = removeNode.Next;
            }
            return removeNode;
        }
    }
}
