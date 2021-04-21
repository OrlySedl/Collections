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
            int size = 50;
            FixedStack<int> stack = new FixedStack<int>(size);

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
        public void Count_PushElementsInStack_1_2()
        {
            int[] expected = { 1, 2 };
            int[] actual = new int[2];
            FixedStack<int> stack = new FixedStack<int>();

            for (int i = 0; i < actual.Length; i++)
            {
                stack.Push(i+1);
                actual[i] = stack.Count;
            }

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void Count_PopElementsFromStack_1_0()
        {
            int[] expected = { 1, 0 };
            int[] actual = new int[2];
            FixedStack<int> stack = new FixedStack<int>();

            stack.Push(1);
            actual[0] = stack.Count;
            stack.Pop();
            actual[1] = stack.Count;

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void Push_StackIsFull_Throws()
        {
            int size = 0;
            FixedStack<int> stack = new FixedStack<int>(size);

            Assert.ThrowsException<System.InvalidOperationException>(() => stack.Push(1));
        }

        [TestMethod]
        public void Pop_StackIsEmpty_Throws()
        {
            FixedStack<int> stack = new FixedStack<int>();

            Assert.ThrowsException<System.InvalidOperationException>(() => stack.Pop());
        }

        [TestMethod]
        public void Pop_GetItemWithDelete_1_0()
        {
            int expected = 1;
            int expectedCount = 0;
            FixedStack<int> stack = new FixedStack<int>();
            
            stack.Push(1);

            Assert.AreEqual(expected, stack.Pop());
            Assert.AreEqual(expectedCount, stack.Count);
        }

        [TestMethod]
        public void Top_GetItemWithoutDelete_1_1()
        {
            int expected = 1;
            int expectedCount = 1;
            FixedStack<int> stack = new FixedStack<int>();
            
            stack.Push(1);

            Assert.AreEqual(expected, stack.Top());
            Assert.AreEqual(expectedCount, stack.Count);
        }

        [TestMethod]
        public void Top_StackIsEmpty_Throws()
        {
            FixedStack<int> stack = new FixedStack<int>();

            Assert.ThrowsException<System.InvalidOperationException>(() => stack.Top());
        }

        [TestMethod]
        public void Clear_CleaningStack_True()
        {
            FixedStack<int> stack = new FixedStack<int>();
            
            stack.Push(1);
            stack.Clear();

            Assert.IsTrue(stack.IsEmpty());
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
            
            stack.Push(1);

            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void IsFull_StackIsFull_True()
        {
            FixedStack<int> stack = new FixedStack<int>(1);
            
            stack.Push(1);

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
