using System;
using NUnit.Framework;
using Stack;

namespace StackTests
{
    [TestFixture]
    public class Tests
    {
        private Stack<int> _stack;
        private const int MaxSize = 10;

        [SetUp]
        public void Init()
        {
            _stack = new Stack<int>(MaxSize);
        }

        [Test]
        public void CountTest()
        {
            Assert.AreEqual(_stack.Count, 0);

            for (int i = 1; i <= MaxSize; i++)
            {
                _stack.Push(i);
                Assert.AreEqual(_stack.Count, i);
            }

            Assert.AreEqual(_stack.Count, MaxSize);
        }

        [Test]
        public void IsEmptyTest()
        {
            Assert.IsTrue(_stack.IsEmpty());
            _stack.Push(1);
            _stack.Pop();
            Assert.IsTrue(_stack.IsEmpty());
        }

        [Test]
        public void IsFullTest()
        {
            for (int i = 1; i <= MaxSize; i++)
            {
                _stack.Push(i);
            }

            Assert.AreEqual(_stack.IsFull(), true);
        }

        [Test]
        public void PushPopTest()
        {
            var item = 5;
            _stack.Push(item);
            Assert.AreEqual(_stack.Pop(), item);
        }
    }
}