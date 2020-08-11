namespace Algorithms_and_Data_Structures.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using Algorithms_and_Data_Structures;

    public class StackArrayTests
    {
        [Fact]
        public void StackArray_Enumerate_ReturnsTrue()
        {
            var stack = new MyStackArray<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            var list = stack.Select(s => s);
            Assert.True(list.SequenceEqual(new int[] {3,2,1}), "The sequence was incorrect");
        }

        [Fact]
        public void StackArray_Pop_ReturnsTrue()
        {
            var stack = new MyStackArray<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            var list = stack.Select(s => s);
            Assert.True(list.SequenceEqual(new int[] {1}), "The sequence was incorrect after Pop()");
        }

        [Fact]
        public void StackArray_EmptyStackPeek_ReturnsTrue()
        {
            var stack = new MyStackArray<int>();
            Assert.Throws<Exception>(() => stack.Peek());
        }

        [Fact]
        public void StackArray_EmptyStackPop_ReturnsTrue()
        {
            var stack = new MyStackArray<int>();
            Assert.Throws<Exception>(() => stack.Pop());
        }
    }
}