using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orsel;

namespace StackTest
{
    [TestClass]
    public class FixedStackTest
    {
        [TestMethod]
        public void Capacity_Default—reation_100()
        {
            int expected = 100;
            FixedStack<int> stack = new FixedStack<int>();

            Assert.AreEqual(expected, stack.Capacity);
        }

        [TestMethod]
        public void Capacity_CreationWithSize50_50()
        {
            int expected = 50;
            FixedStack<int> stack = new FixedStack<int>(expected);

            Assert.AreEqual(expected, stack.Capacity);
        }

        [TestMethod]
        public void Count_StackIsEmpty_0()
        {
            int expected = 0;
            FixedStack<int> stack = new FixedStack<int>();

            Assert.AreEqual(expected, stack.Count);
        }

        [TestMethod]
        public void Push_AddItemInStack_1_100()
        {
            int expectedCount = 1;
            int expectedCapacity = 100;
            FixedStack<int> stack = new FixedStack<int>();

            stack.Push(123);

            Assert.AreEqual(expectedCount, stack.Count);
            Assert.AreEqual(expectedCapacity, stack.Capacity);
        }

        [TestMethod]
        public void Push_StackIsFull_Throws()
        {
            int size = 0;
            FixedStack<int> stack = new FixedStack<int>(size);

            Assert.ThrowsException<System.InvalidOperationException>(() => stack.Push(123));
        }

        [TestMethod]
        public void Pop_GetItemWithDelete_123_0_100()
        {
            int expected = 123;
            int expectedCount = 0;
            int expectedCapacity = 100;

            FixedStack<int> stack = new FixedStack<int>();
            
            stack.Push(expected);

            Assert.AreEqual(expected, stack.Pop());
            Assert.AreEqual(expectedCount, stack.Count);
            Assert.AreEqual(expectedCapacity, stack.Capacity);
        }

        [TestMethod]
        public void Pop_StackIsEmpty_Throws()
        {
            FixedStack<int> stack = new FixedStack<int>();

            Assert.ThrowsException<System.InvalidOperationException>(() => stack.Pop());
        }

        [TestMethod]
        public void Peek_GetItemWithoutDelete_123_1_100()
        {
            int expected = 123;
            int expectedCount = 1;
            int expectedCapacity = 100;
            FixedStack<int> stack = new FixedStack<int>();
            
            stack.Push(expected);

            Assert.AreEqual(expected, stack.Peek());
            Assert.AreEqual(expectedCount, stack.Count);
            Assert.AreEqual(expectedCapacity, stack.Capacity);    
        }

        [TestMethod]
        public void Peek_StackIsEmpty_Throws()
        {
            FixedStack<int> stack = new FixedStack<int>();

            Assert.ThrowsException<System.InvalidOperationException>(() => stack.Peek());
        }

        [TestMethod]
        public void Clear_CleaningStack_True_100()
        {
            int expectedCapacity = 100;
            FixedStack<int> stack = new FixedStack<int>();
            
            stack.Push(123);
            stack.Clear();

            Assert.IsTrue(stack.IsEmpty());
            Assert.AreEqual(expectedCapacity, stack.Capacity);
        }

        [TestMethod]
        public void IsEmpty_StackIsEmpty_True()
        {
            FixedStack<int> stack = new FixedStack<int>();

            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_StackWithElements_False()
        {
            FixedStack<int> stack = new FixedStack<int>();
            
            stack.Push(123);

            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void IsFull_StackIsFull_True()
        {
            int size = 1;
            FixedStack<int> stack = new FixedStack<int>(size);
            
            stack.Push(123);

            Assert.IsTrue(stack.IsFull());
        }

        [TestMethod]
        public void IsFull_StackIsEmpty_False()
        {
            FixedStack<int> stack = new FixedStack<int>();

            Assert.IsFalse(stack.IsFull());
        }
    }
}
