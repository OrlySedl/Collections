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
            int stackSize = -1;

            Stack<int> stack;

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => stack = new(stackSize));
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
            int expectedItem = 123;
            int expectedCount = 0;
            int expectedCapacity = 4;

            Stack<int> stack = new();
            stack.Push(expectedItem);

            Assert.AreEqual(expectedItem, stack.Pop());
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
            int expectedItem = 123;
            int expectedCount = 1;
            int expectedCapacity = 4;

            Stack<int> stack = new();
            stack.Push(expectedItem);

            Assert.AreEqual(expectedItem, stack.Peek());
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
        public void TrimExcess_ReducingStackCapacity()
        {
            int stackSize = 100;
            int expectedCapacity = 10;

            Stack<int> stack = new(stackSize);
            for (int i = 0; i < expectedCapacity; i++)
            {
                stack.Push(i);
            }
            stack.TrimExcess();

            Assert.AreEqual(expectedCapacity, stack.Count);
            Assert.AreEqual(expectedCapacity, stack.Capacity);
        }

        [TestMethod]
        public void TrimExcess_PreviousStackCapacity()
        {
            int stackSize = 100;
            int expectedCapacity = 90;

            Stack<int> stack = new(stackSize);
            for (int i = 0; i < expectedCapacity; i++)
            {
                stack.Push(i);
            }
            stack.TrimExcess();

            Assert.AreEqual(expectedCapacity, stack.Count);
            Assert.AreNotEqual(expectedCapacity, stack.Capacity);
        }

        [TestMethod]
        public void Clear_CleaningStack()
        {
            int expectedCapacity = 4;
            int expectedCount = 0;
            int item = 123;

            Stack<int> stack = new();
            stack.Push(item);
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
            int item = 123;

            Stack<int> stack = new();
            stack.Push(item);

            Assert.IsFalse(stack.IsEmpty());
        }
    }
}
