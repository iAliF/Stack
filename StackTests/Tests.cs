﻿using System;
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

            PushToArray(
                MaxSize,
                i => Assert.AreEqual(_stack.Count, i)
            );

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
            PushToArray(MaxSize);

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
            PushToArray(MaxSize);
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

            PushToArray(6);

            _stack.Pop();
            Assert.AreEqual(_stack.ToArray(), array);

            _stack.Clear();
            Assert.AreEqual(_stack.ToArray(), new int[] { });
        }

        [Test]
        public void StackOverFlowTest()
        {
            PushToArray(MaxSize);
            Assert.Throws<StackOverflowException>(() =>
            {
                _stack.Push(11);
            });
        }
        
        [Test]
        public void StackEmptyTest()
        {
            Assert.Throws<StackEmptyException>(() =>
            {
                _stack.Pop();
            });
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

                callback?.Invoke(i);
            }
        }
    }
}