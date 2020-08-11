namespace Algorithms_and_Data_Structures.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using Algorithms_and_Data_Structures;

    public class QueueArrayTests
    {
        [Fact]
        public void Enqueue_Enqueue_ReturnsTrue()
        {
            var queue = new MyQueueArray<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.True(queue.Size == 3, "The size is incorrect");
            Assert.True(queue.Head == 1, "The head is incorrect");
        }

        [Fact]
        public void Enqueue_Dequeue_ReturnsTrue()
        {
            var queue = new MyQueueArray<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue();

            Assert.True(queue.Size == 2, "The size is incorrect");
            Assert.True(queue.Head == 2, "The head is incorrect");
        }
    }
}