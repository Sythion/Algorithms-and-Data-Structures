namespace Algorithms_and_Data_Structures.ArrayImpl
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyQueue<T> : IEnumerable<T>
    {
        private T[] array = new T[0];
        
        public int size;

        public T Head { get; set; }

        public void Clear()
        {
            array = new T[0];
            this.size = 0;
        }

        public void Enqueue(T item)
        {
            // count same length as array, need to increase
            if (this.size == array.Length)
            {
                this.array = array.Length == 0 ? new T[4] : new T[array.Length * 2];
            }
            
            array[this.size] = item;
            this.size++;
            this.Head = array[0];
        }

        public T Dequeue()
        {
            if (this.size == 0)
            {
                throw new Exception("The queue is empty");
            }

            var item = array[0];
            for(int i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i+1];
            }
            
            this.Head = array[0];
            this.size--;
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            //return array.GetEnumerator();
            for(int i = 0; i < size; i++)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return array.GetEnumerator();
        }
    }
}