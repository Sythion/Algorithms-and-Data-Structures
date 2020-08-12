namespace Algorithms_and_Data_Structures.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using Algorithms_and_Data_Structures;

    /// <summary>
    /// Tests for the MyStackLinkedList class.
    /// </summary>
    public class StackLinkedListTests
    {
        /// <summary>
        /// Tests that the enumeration returns the items in reverse order than how they were pushed.
        /// </summary>
        /// <param name="data">The data to test.</param>
        [Theory]
        [InlineData(new int[]{1,2,3})]
        [InlineData(new int[] {2})]
        [InlineData(new int[]{})]
        public void Enumerate_VariousData_ReturnsTrue(int[] data)
        {
            var stack = new MyStackLinkedList<int>();
            foreach(var item in data)
            {
                stack.Push(item);
            }

            Assert.True(stack.SequenceEqual(data.OrderByDescending(d => d)), "The sequence was incorrect");
        }

        /// <summary>
        /// Tests that the data is correct after popping an item off the stack.
        /// </summary>
        /// <param name="data">The data to test.</param>
        [Theory]
        [InlineData(new int[]{1,2})]
        public void Pop_NonEmptyData_ReturnsTrue(int[] data)
        {
            var stack = new MyStackLinkedList<int>();
            foreach(var item in data)
            {
                stack.Push(item);
            }
            stack.Pop();
            Assert.True(stack.SequenceEqual(data.Take(data.Length - 1)), "The sequence was incorrect after Pop()");
        }

        /// <summary>
        /// Tests that peeking an empty stack returns an exception.
        /// </summary>
        [Fact]
        public void Peek_EmptyStack_ReturnsTrue()
        {
            var stack = new MyStackLinkedList<int>();
            Assert.Throws<Exception>(() => stack.Peek());
        }

        /// <summary>
        /// Tests that popping an empty stack returns an exception. 
        /// </summary>
        [Fact]
        public void StackArray_EmptyStackPop_ReturnsTrue()
        {
            var stack = new MyStackLinkedList<int>();
            Assert.Throws<Exception>(() => stack.Pop());
        }
    }
}