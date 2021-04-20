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
            FixedStack<int> stack = new FixedStack<int>();
            
            int expected = 100;
            int actual = stack.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Capacity_CreationWithSize50_50()
        {
            FixedStack<int> stack = new FixedStack<int>(50);

            int expected = 50;
            int actual = stack.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Count_0elements_0()
        {
            FixedStack<int> stack = new FixedStack<int>();

            int expected = 0;
            int actual = stack.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Count_Push10elements_10()
        {
            FixedStack<int> stack = new FixedStack<int>();
            for (int i = 0; i < 10; i++)
                stack.Push(i);

            int expected = 10;
            int actual = stack.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Top_1element_123()
        {
            FixedStack<int> stack = new FixedStack<int>();
            stack.Push(123);

            int expected = 123;
            int actual = stack.Top();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Top_StackIsEmpty_Throws()
        {
            // arrange
            FixedStack<int> stack = new FixedStack<int>();

            // act and assert
            Assert.ThrowsException<System.InvalidOperationException>(() => stack.Top());
        }

        [TestMethod]
        public void IsEmpty_0elements_True()
        {
            FixedStack<int> stack = new FixedStack<int>();

            bool result = stack.IsEmpty();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEmpty_1elements_False()
        {
            FixedStack<int> stack = new FixedStack<int>();
            stack.Push(10);

            bool result = stack.IsEmpty();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsFull_FilledStackOfSize4_True()
        {
            FixedStack<int> stack = new FixedStack<int>(4);
            for (int i = 0; i < 4; i++)
                stack.Push(i);

            bool result = stack.IsFull();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFull_0elements_False()
        {
            FixedStack<int> stack = new FixedStack<int>();

            bool result = stack.IsFull();

            Assert.IsFalse(result);
        }
    }
}
