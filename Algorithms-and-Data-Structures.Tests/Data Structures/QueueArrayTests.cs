namespace Algorithms_and_Data_Structures.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using Algorithms_and_Data_Structures;

    /// <summary>
    /// Tests for the QueueArray class.
    /// </summary>
    public class QueueArrayTests
    {
        /// <summary>
        /// Tests the size and head properties after enqueue.
        /// </summary>
        /// <param name="data"></param>
        [Theory]
        [InlineData(new int[]{1,2,3})]
        public void Enqueue_NonEmptyData_ReturnsTrue(int[] data)
        {
            var queue = new MyQueueArray<int>();
            foreach(var item in data)
            {
                queue.Enqueue(item);
            }

            Assert.True(queue.Size == data.Length, "The size of the QueueArray is incorrect");
            Assert.True(queue.Head == data[0], "The head of the QueueArray is incorrect");
        }

        /// <summary>
        /// Tests the size and head after dequeue.
        /// </summary>
        /// <param name="data">The data to test.</param>
        [Theory]
        [InlineData(new int[] {1,2,3})]
        public void Dequeue_DataGreaterThanOneItem_ReturnsTrue(int[] data)
        {
            var queue = new MyQueueArray<int>();
            foreach(var item in data)
            {
                queue.Enqueue(item);
            }
            queue.Dequeue();

            Assert.True(queue.Size == data.Length-1, "The size is incorrect");
            Assert.True(queue.Head == data[1], "The head is incorrect");
        }
    }
}