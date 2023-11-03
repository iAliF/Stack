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
    }
}