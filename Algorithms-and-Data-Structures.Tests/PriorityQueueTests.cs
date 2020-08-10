namespace Algorithms_and_Data_Structures.Tests
{
    using System;
    using Xunit;
    using Algorithms_and_Data_Structures.LinkedListImpl;

    public class PriorityQueueTests
    {
        [Fact]
        public void PriorityQueue_Enqueue_ReturnsTrue()
        {
            int expectedHead = 3;
            var queue = new MyPriorityQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Assert.True(queue.Count == 3, "The queue count was incorrect");
            Assert.True(queue.Head == expectedHead, $"The queue head should be {expectedHead}, but it was {queue.Head}");
        }

        [Fact]
        public void PriorityQueue_Dequeue_ReturnsTrue()
        {
            var queue = new MyPriorityQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue();
            Assert.True(queue.Count == 2, "The queue did not dequeue");
            Assert.True(queue.Head == 2, "The queue head was incorrect after dequeue");
        }
    }
}