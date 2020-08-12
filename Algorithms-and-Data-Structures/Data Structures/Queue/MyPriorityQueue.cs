namespace Algorithms_and_Data_Structures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyPriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private LinkedList<T> list = new LinkedList<T>();

        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public T Head { get; set; }

        public void Clear()
        {
            list.Clear();
        }

        public void Enqueue(T item)
        {
            if (list.Count == 0)
            {
                list.AddLast(item);
            }
            else
            {
                var current = list.First;
                // Use IComparable for comparisons between generic items.  Less than 0 means that the item is less than current.
                // After this item will be larger than the current. Item will be null if it is the smallest item.
                while (current != null && item.CompareTo(current.Value) < 0)
                {
                    current = current.Next;
                }
                
                if (current == null)
                {
                    list.AddLast(item);
                }
                else
                {
                    list.AddBefore(current, item);
                }
            }

            this.Head = list.First.Value;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new Exception("The queue is empty");
            }
            var item = list.First.Value;
            list.RemoveFirst();
            this.Head = list.First.Value;
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}