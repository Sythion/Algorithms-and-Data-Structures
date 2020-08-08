namespace Algorithms_and_Data_Structures
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines a Hashtable Array that stores values from the HashTable class.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class MyHashTableArray<TKey, TValue> 
    {
        /// <summary>
        /// Backing store for hashtable values.
        /// </summary>
        MyHashTableArrayNode<TKey, TValue>[] array;

        /// <summary>
        /// Initializes a new instance of the MyHashTableArray class.
        /// </summary>
        /// <param name="capacity">The initial capacity of the array.</param>
        public MyHashTableArray(int capacity)
        {
            this.array = new MyHashTableArrayNode<TKey, TValue>[capacity];
            for (int i = 0; i < capacity; i++)
            {
                this.array[i] = new MyHashTableArrayNode<TKey, TValue>();
            }
        }

        /// <summary>
        /// Gets the capacity of the array.
        /// </summary>
        public int Capacity => this.array.Length;

        public bool TryGetValue(TKey key, out TValue value)
        {
            return this.array[this.GetIndex(key)].TryGetValue(key, out value);
        }

        /// <summary>
        /// Adds the provided item to the array.
        /// </summary>
        /// <param name="key">The key of the item.</param>
        /// <param name="value">The value of the item.</param>
        public void Add(TKey key, TValue value)
        {
            this.array[this.GetIndex(key)].Add(key, value);
        }

        /// <summary>
        /// Updates the provided item in the array.
        /// </summary>
        /// <param name="key">The key of the item.</param>
        /// <param name="value">The value of the item.</param>
        public void Update(TKey key, TValue value)
        {
            this.array[this.GetIndex(key)].Update(key, value);
        }

        /// <summary>
        /// Removes the provided item from the array.
        /// </summary>
        /// <param name="key">The key for the item to remove.</param>
        public bool Remove(TKey key)
        {
            bool removed = this.array[this.GetIndex(key)].Remove(key);
            return removed;
        }

        /// <summary>
        /// Clears the array.
        /// </summary>
        public void Clear()
        {
            foreach(var node in array)
            {
                node.Clear();
            }
        }

        /// <summary>
        /// Gets an enumerated list of keys.
        /// </summary>
        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach(var node in this.array)
                {
                    foreach(var key in node.Keys)
                    {
                        yield return key;
                    }
                }
            }
        }

        /// <summary>
        /// Gets an enumerated list of values.
        /// </summary>
        public IEnumerable<TValue> Values
        {
            get
            {
                foreach(var node in this.array)
                {
                    foreach(var value in node.Values)
                    {
                        yield return value;
                    }
                }
            }
        }

        /// <summary>
        /// Gets an enumerated list of items.
        /// </summary>
        /// <value></value>
        public IEnumerable<MyHashTableNodePair<TKey, TValue>> Items
        {
            get
            {
                foreach(var node in this.array)
                {
                    foreach(var item in node.Items)
                    {
                        yield return item;
                    }
                }
            }
        }

        // Maps a key to the array index based on hash code
        private int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % this.Capacity);
        }
    }
}