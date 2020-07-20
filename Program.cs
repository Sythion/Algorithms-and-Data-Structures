using System;
using LLI = Algorithms_and_Data_Structures.LinkedListImpl;
using AI = Algorithms_and_Data_Structures.ArrayImpl;

namespace Algorithms_and_Data_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            // ExecuteSinglyLinkedList();
            // ExecuteDoublyLinkedList();
            // ExecuteQueueLinkedList();
            // ExecuteQueueArray();
            // ExecuteStackLinkedList();
            // ExecuteStackArray();
            // ExecutePriorityQueue();
            ExecuteBinaryTree();
        }

        public static void ExecuteBinaryTree()
        {
            var binaryTree = new MyBinaryTree<int>();
            binaryTree.Add(4);
            binaryTree.Add(2);
            binaryTree.Add(6);
            binaryTree.Add(1);
            binaryTree.Add(7);
        }

        public static void ExecuteSinglyLinkedList()
        {
            var myLinkedList = new LLI.MySinglyLinkedList<int>();
            myLinkedList.AddLast(new LLI.MySinglyLinkedListNode<int>(3));
            myLinkedList.AddLast(new LLI.MySinglyLinkedListNode<int>(5));
            myLinkedList.AddLast(new LLI.MySinglyLinkedListNode<int>(7));
            myLinkedList.PrintList();
            
            myLinkedList.Remove(9);
            myLinkedList.PrintList();
        }

        public static void ExecuteDoublyLinkedList()
        {
            var linkedList = new LLI.MyLinkedList<int>();
            linkedList.AddFirst(new LLI.MyLinkedListNode<int>(3));
            linkedList.AddFirst(new LLI.MyLinkedListNode<int>(5));
            linkedList.AddFirst(new LLI.MyLinkedListNode<int>(7));
            linkedList.PrintList();
            linkedList.Remove(5);
            linkedList.PrintList();
            Console.WriteLine(linkedList.Tail.Next);
        }

        public static void ExecuteQueueLinkedList()
        {
            var queue = new LLI.MyQueue<int>();
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

        public static void ExecuteQueueArray()
        {
            var queue = new AI.MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine(queue.size);
            Console.WriteLine(queue.Head);
            queue.Dequeue();
            Console.WriteLine(queue.size);
            Console.WriteLine(queue.Head);
            Console.WriteLine("list");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }        
        }

        public static void ExecuteStackLinkedList()
        {

        }

        public static void ExecuteStackArray()
        {
            var stack = new AI.MyStack<int>();
            stack.Push(3);
            foreach(var item in stack)
            {
                Console.WriteLine(item);
            }
            /*stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);
            stack.Push(7);
            stack.Push(8);
            //stack.Print();
            Console.WriteLine(stack.Pop());
            stack.Print();
            stack.Clear();
            stack.Print();*/
        }

        public static void ExecutePriorityQueue()
        {
            var queue = new LLI.MyPriorityQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine(queue.Count);
            Console.WriteLine(queue.Head);
            queue.Dequeue();
            Console.WriteLine(queue.Count);
            Console.WriteLine(queue.Head);
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
