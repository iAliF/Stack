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

        [Test]
        public void ClearTest()
        {
            for (int i = 1; i <= MaxSize; i++)
            {
                _stack.Push(i);
            }

            Assert.AreEqual(_stack.Count, MaxSize);
            _stack.Clear();
            Assert.AreEqual(_stack.Count, 0);
        }

        [Test]
        public void ContainsTest()
        {
            _stack.Push(1);
            Assert.IsTrue(_stack.Contains(1));

            _stack.Push(2);
            Assert.IsTrue(_stack.Contains(2));

            _stack.Pop();
            Assert.IsFalse(_stack.Contains(2));

            _stack.Pop();
            Assert.IsFalse(_stack.Contains(1));
        }

        [Test]
        public void ToArrayTest()
        {
            var array = new[] { 1, 2, 3, 4, 5 };

            for (int i = 1; i <= 6; i++)
            {
                _stack.Push(i);
            }

            _stack.Pop();

            Assert.AreEqual(_stack.ToArray(), array);

            _stack.Clear();
            Assert.AreEqual(_stack.ToArray(), new int[] { });
        }

        private void PushToArray(int size, Action<int> callback = null)
        {
            /*
             * Fills array with *size* numbers
             * callback will be called after each item has been pushed to stack with the index parameter
             */

            for (var i = 1; i <= size; i++)
            {
                _stack.Push(i);

                if (callback != null)
                    callback(i);
            }
        }
    }
}