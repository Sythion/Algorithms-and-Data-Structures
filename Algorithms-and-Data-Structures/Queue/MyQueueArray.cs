namespace Algorithms_and_Data_Structures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// A queue class that uses an array as its backing store.
    /// </summary>
    /// <typeparam name="T">A generic type.</typeparam>
    public class MyQueueArray<T> : IEnumerable<T>
    {
        #region Fields

        /// <summary>
        /// The backing store for the queue.
        /// </summary>
        private T[] array = new T[0];

        #endregion

        #region Properties
        
        /// <summary>
        /// Gets the size of the queue.
        /// </summary>
        public int Size {get; private set; }

        /// <summary>
        /// Gets the first item in the queue.
        /// </summary>
        public T Head { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Clears the queue.
        /// </summary>
        public void Clear()
        {
            array = new T[0];
            this.Size = 0;
        }

        /// <summary>
        /// Adds an item to the queue.
        /// </summary>
        /// <param name="item">The item to add to the queue.</param>
        public void Enqueue(T item)
        {
            // count same length as array, need to increase
            if (this.Size == array.Length)
            {
                this.array = array.Length == 0 ? new T[4] : new T[array.Length * 2];
            }
            
            array[this.Size] = item;
            this.Size++;
            this.Head = array[0];
        }

        /// <summary>
        /// Removes an item from the queue.
        /// </summary>
        /// <returns>Returns the removed item.</returns>
        public T Dequeue()
        {
            if (this.Size == 0)
            {
                throw new Exception("The queue is empty");
            }

            var item = array[0];
            for(int i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i+1];
            }
            
            this.Head = array[0];
            this.Size--;
            return item;
        }

        /// <summary>
        /// Returns an iteration of the queue.
        /// </summary>
        /// <returns>Returns an iteration of the queue.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < Size; i++)
            {
                yield return this.array[i];
            }
        }

        /// <summary>
        /// Returns an iteration of the queue.
        /// </summary>
        /// <returns>Returns an iteration of the queue.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return array.GetEnumerator();
        }

        #endregion
    }
}