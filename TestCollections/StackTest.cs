using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orsel.Collections;

namespace TestCollections
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void Ctor_EmptyStackСreation()
        {
            int expectedCapacity = 0;
            int expectedCount = 0;

            Stack<int> stack = new();

            Assert.AreEqual(expectedCapacity, stack.Capacity);
            Assert.AreEqual(expectedCount, stack.Count);
        }

        [TestMethod]
        public void Ctor_CreationWithSize10()
        {
            int expectedCapacity = 10;
            int expectedCount = 0;

            Stack<int> stack = new(expectedCapacity);

            Assert.AreEqual(expectedCapacity, stack.Capacity);
            Assert.AreEqual(expectedCount, stack.Count);
        }

        [TestMethod]
        public void CtorThrows_СreationWithNegativeSize()
        {
            Stack<int> stack;

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => stack = new(-1));
        }

        [TestMethod]
        public void PushStackResize_AddItemsInEmptyStack()
        {
            int expectedCount = 3;
            int expectedCapacity = 4;

            Stack<int> stack = new();
            for (int i = 0; i < expectedCount; i++)
            {
                stack.Push(i);
            }

            Assert.AreEqual(expectedCount, stack.Count);
            Assert.AreEqual(expectedCapacity, stack.Capacity);
        }

        [TestMethod]
        public void PushStackResize_AddItemsInStack()
        {
            int expectedCount = 9;
            int expectedCapacity = 10;

            Stack<int> stack = new(expectedCapacity);
            for (int i = 0; i < expectedCount; i++)
            {
                stack.Push(i);
            }

            Assert.AreEqual(expectedCount, stack.Count);
            Assert.AreEqual(expectedCapacity, stack.Capacity);
        }

        [TestMethod]
        public void Pop_GetItemWithDelete()
        {
            int expected = 123;
            int expectedCount = 0;
            int expectedCapacity = 4;

            Stack<int> stack = new();
            stack.Push(expected);

            Assert.AreEqual(expected, stack.Pop());
            Assert.AreEqual(expectedCount, stack.Count);
            Assert.AreEqual(expectedCapacity, stack.Capacity);
        }

        [TestMethod]
        public void PopThrows_StackIsEmpty()
        {
            Stack<int> stack = new();

            Assert.ThrowsException<System.InvalidOperationException>(() => stack.Pop());
        }

        [TestMethod]
        public void Peek_GetItemWithoutDelete()
        {
            int expected = 123;
            int expectedCount = 1;
            int expectedCapacity = 4;

            Stack<int> stack = new();
            stack.Push(expected);

            Assert.AreEqual(expected, stack.Peek());
            Assert.AreEqual(expectedCount, stack.Count);
            Assert.AreEqual(expectedCapacity, stack.Capacity);
        }

        [TestMethod]
        public void PeekThrows_StackIsEmpty()
        {
            Stack<int> stack = new();

            Assert.ThrowsException<System.InvalidOperationException>(() => stack.Peek());
        }

        [TestMethod]
        public void Clear_CleaningStack()
        {
            int expectedCapacity = 4;
            int expectedCount = 0;
            Stack<int> stack = new();

            stack.Push(123);
            stack.Clear();

            Assert.IsTrue(stack.IsEmpty());
            Assert.AreEqual(expectedCapacity, stack.Capacity);
            Assert.AreEqual(expectedCount, stack.Count);
        }

        [TestMethod]
        public void IsEmpty_StackIsEmpty()
        {
            Stack<int> stack = new();

            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_StackWithElements()
        {
            Stack<int> stack = new();
            stack.Push(123);

            Assert.IsFalse(stack.IsEmpty());
        }
    }
}
