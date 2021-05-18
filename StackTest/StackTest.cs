using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orsel.Collections;

namespace StackTest
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void Capacity_DefaultСreation_100()
        {
            int expected = 100;
            Stack<int> stack = new Stack<int>();

            Assert.AreEqual(expected, stack.Capacity);
        }

        [TestMethod]
        public void Capacity_CreationWithSize50_50()
        {
            int expected = 50;
            Stack<int> stack = new Stack<int>(expected);

            Assert.AreEqual(expected, stack.Capacity);
        }

        [TestMethod]
        public void Count_StackIsEmpty_0()
        {
            int expected = 0;
            Stack<int> stack = new Stack<int>();

            Assert.AreEqual(expected, stack.Count);
        }

        [TestMethod]
        public void Push_AddItemInStack_1_100()
        {
            int expectedCount = 1;
            int expectedCapacity = 100;
            Stack<int> stack = new Stack<int>();

            stack.Push(123);

            Assert.AreEqual(expectedCount, stack.Count);
            Assert.AreEqual(expectedCapacity, stack.Capacity);
        }

        [TestMethod]
        public void Push_StackResize_5_8_123()
        {
            int size = 4;
            int expected = 123;
            int expectedCount = 5;
            int expectedCapacity = 8;
            Stack<int> stack = new Stack<int>(size);

            for (int i = 0; i < size; i++)
            {
                stack.Push(i);
            }
            stack.Push(expected);

            Assert.AreEqual(expectedCount, stack.Count);
            Assert.AreEqual(expectedCapacity, stack.Capacity);
            Assert.AreEqual(expected, stack.Pop());
        }

        [TestMethod]
        public void Pop_GetItemWithDelete_123_0_100()
        {
            int expected = 123;
            int expectedCount = 0;
            int expectedCapacity = 100;

            Stack<int> stack = new Stack<int>();

            stack.Push(expected);

            Assert.AreEqual(expected, stack.Pop());
            Assert.AreEqual(expectedCount, stack.Count);
            Assert.AreEqual(expectedCapacity, stack.Capacity);
        }

        [TestMethod]
        public void Pop_StackIsEmpty_Throws()
        {
            Stack<int> stack = new Stack<int>();

            Assert.ThrowsException<System.InvalidOperationException>(() => stack.Pop());
        }

        [TestMethod]
        public void Peek_GetItemWithoutDelete_123_1_100()
        {
            int expected = 123;
            int expectedCount = 1;
            int expectedCapacity = 100;
            Stack<int> stack = new Stack<int>();

            stack.Push(expected);

            Assert.AreEqual(expected, stack.Peek());
            Assert.AreEqual(expectedCount, stack.Count);
            Assert.AreEqual(expectedCapacity, stack.Capacity);
        }

        [TestMethod]
        public void Peek_StackIsEmpty_Throws()
        {
            Stack<int> stack = new Stack<int>();

            Assert.ThrowsException<System.InvalidOperationException>(() => stack.Peek());
        }

        [TestMethod]
        public void Clear_CleaningStack_True_100()
        {
            int expectedCapacity = 100;
            Stack<int> stack = new Stack<int>();

            stack.Push(123);
            stack.Clear();

            Assert.IsTrue(stack.IsEmpty());
            Assert.AreEqual(expectedCapacity, stack.Capacity);
        }

        [TestMethod]
        public void IsEmpty_StackIsEmpty_True()
        {
            Stack<int> stack = new Stack<int>();

            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_StackWithElements_False()
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(123);

            Assert.IsFalse(stack.IsEmpty());
        }
    }
}
