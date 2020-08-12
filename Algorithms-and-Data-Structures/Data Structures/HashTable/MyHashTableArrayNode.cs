namespace Algorithms_and_Data_Structures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Holds a list of node pairs to keep track of items located in the same position.
    /// </summary>
    /// <typeparam name="TKey">The key of the item.</typeparam>
    /// <typeparam name="TValue">The value of the item.</typeparam>
    public class MyHashTableArrayNode<TKey, TValue>
    {
#region Fields
        /// <summary>
        /// Backing store for multiple items at the same node.
        /// </summary>
        private LinkedList<MyHashTableNodePair<TKey, TValue>> list;

#endregion

#region Constructors

        public MyHashTableArrayNode()
        {
            this.list = new LinkedList<MyHashTableNodePair<TKey, TValue>>();
        }

#endregion

#region Methods

    /// <summary>
    /// Adds a key/value pair to the node.
    /// </summary>
    /// <param name="key">The key of the node pair.</param>
    /// <param name="value">The value of the node pair.</param>
    public void Add(TKey key, TValue value)
    {
        if (this.list == null)
        {
            this.list = new LinkedList<MyHashTableNodePair<TKey, TValue>>();
        }
        else
        {
            // Don't allow duplicate keys
            foreach(var item in list)
            {
                if (item.Key.Equals(key))
                {
                    throw new ArgumentException("The key already exists in this node");
                }
            }

            list.AddFirst(new MyHashTableNodePair<TKey, TValue>(key, value));
        }

    }

        public bool TryGetValue(TKey key, out TValue value)
        {
            bool hasValue = false;
            value = default(TValue);
            if (this.list != null)
            {
                foreach (var item in this.list)
                {
                    if (item.Key.Equals(key))
                    {
                        value = item.Value;
                        hasValue = true;
                        break;
                    }
                }
            }
            return hasValue;
        }

        /// <summary>
        /// Removes an item from the array.
        /// </summary>
        /// <param name="key">The key of the item to remove.</param>
        /// <returns>Returns a value indicating whether the item was removed or not.</returns>
        public bool Remove(TKey key)
    {
        bool removed = false;
        if (this.list != null)
        {
            var current = this.list.First;
            while (current != null)
            {
                if (current.Value.Key.Equals(key))
                {
                    this.list.Remove(current);
                    removed = true;
                    break;
                }
                current = current.Next;
            }
        }
        return removed;
    }

    /// <summary>
    /// Clears the array of data.
    /// </summary>
    public void Clear()
    {
        if (this.list != null)
        {
            this.list.Clear();
        }
    }

    /// <summary>
    /// Updates the provided key/value pair.
    /// </summary>
    /// <param name="key">The key of the item to update.</param>
    /// <param name="value">The new value of the item to update.</param>
    public void Update(TKey key, TValue value)
    {
        bool updated = false;
        if (this.list != null)
        {
            foreach(var item in this.list)
            {
                if (item.Key.Equals(key))
                {
                    item.Value = value;
                    updated = true;
                    break;
                }
            }
        }
        if (!updated)
        {
            throw new ArgumentException("Key not found in collection");
        }
    }

    /// <summary>
    /// Returns an enumerated list of keys.
    /// </summary>
    /// <value></value>
    public IEnumerable<TKey> Keys
    {
        get
        {
            foreach(var item in this.list)
            {
                yield return item.Key;
            }
        }
    }

    /// <summary>
    /// Returns an enumerated list of values.
    /// </summary>
    /// <value></value>
    public IEnumerable<TValue> Values 
    {
        get
        {
            foreach(var item in this.list)
            {
                yield return item.Value;
            }
        }
    }

    /// <summary>
    /// Returns an enumerated list of items.
    /// </summary>
    /// <value></value>
    public IEnumerable<MyHashTableNodePair<TKey, TValue>> Items
    {
        get
        {
            foreach(var item in this.list)
            {
                yield return item;
            }
        }
    }

#endregion
    }

}