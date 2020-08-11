using System;

namespace Algorithms_and_Data_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            // ExecuteSinglyLinkedList();
            // ExecuteDoublyLinkedList();
            // ExecuteQueueLinkedList();
        }

        public static void ExecuteSinglyLinkedList()
        {
            var myLinkedList = new MySinglyLinkedList<int>();
            myLinkedList.AddLast(new MySinglyLinkedListNode<int>(3));
            myLinkedList.AddLast(new MySinglyLinkedListNode<int>(5));
            myLinkedList.AddLast(new MySinglyLinkedListNode<int>(7));
            myLinkedList.PrintList();
            
            myLinkedList.Remove(9);
            myLinkedList.PrintList();
        }

        public static void ExecuteDoublyLinkedList()
        {
            var linkedList = new MyLinkedList<int>();
            linkedList.AddFirst(new MyLinkedListNode<int>(3));
            linkedList.AddFirst(new MyLinkedListNode<int>(5));
            linkedList.AddFirst(new MyLinkedListNode<int>(7));
            linkedList.PrintList();
            linkedList.Remove(5);
            linkedList.PrintList();
            Console.WriteLine(linkedList.Tail.Next);
        }

        public static void ExecuteQueueLinkedList()
        {
            var queue = new MyQueueLinkedList<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine(queue.Count);
            Console.WriteLine(queue.Head);
            queue.Dequeue();
            Console.WriteLine(queue.Count);
            Console.WriteLine(queue.Head);
            foreach(var item in queue)
            {
                Console.WriteLine(item);
	        }
        }
    }
}
