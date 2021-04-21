using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orsel;

namespace StackTest
{
    [TestClass]
    public class ArrayStackTest
    {
        [TestMethod]
        public void Capacity_DefaultСreation_100()
        {
            int expected = 100;
            ArrayStack<int> stack = new ArrayStack<int>();

            Assert.AreEqual(expected, stack.Capacity);
        }

        [TestMethod]
        public void Capacity_CreationWithSize50_50()
        {
            int expected = 50;
            int size = 50;
            ArrayStack<int> stack = new ArrayStack<int>(size);

            Assert.AreEqual(expected, stack.Capacity);
        }
    }
}
