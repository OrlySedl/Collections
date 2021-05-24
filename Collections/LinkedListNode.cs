using System;

namespace Orsel.Collections
{
    public class LinkedListNode
    {
        public int Value;
        public LinkedListNode Next;

        public LinkedListNode(int value, LinkedListNode node = null)
        {
            Value = value;
            Next = node;
        }
    }
}
