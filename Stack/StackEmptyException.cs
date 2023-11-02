using System;

namespace Stack
{
    [Serializable]
    public class StackEmptyException : Exception
    {
        public StackEmptyException() : base("Stack is empty")
        {
        }
    }
}