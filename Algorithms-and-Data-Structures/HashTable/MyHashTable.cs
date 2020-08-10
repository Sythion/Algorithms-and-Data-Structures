namespace Algorithms_and_Data_Structures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyHashTable<TKey, TValue>
    {
        #region Fields

        private MyHashTableArray<TKey, TValue> array;

        private int maxItemsAtCurrentSize;

        /// <summary>
        /// The percentage capacity the array must be at before it is made larger.
        /// </summary>
        private const double fillFactor = .75;

        #endregion

        #region Constructors

        public MyHashTable(int initialCapacity)
        {
            if (initialCapacity < 1)
            {
                throw new ArgumentOutOfRangeException("The initial capacity must be a positive integer");
            }
            this.array = new MyHashTableArray<TKey, TValue>(initialCapacity);

            // Size to exceed before array grows
            this.maxItemsAtCurrentSize = (int)(initialCapacity * fillFactor) + 1;
        }

        #endregion

        #region Properties

        public int Count { get; private set;}

        #endregion

        #region Indexers

        public TValue this[TKey key]
        {
            get
            {
                TValue result;
                if (!this.array.TryGetValue(key, out result))
                {
                    throw new ArgumentException("The key does not exist in the hashtable");
                }
                return result;           
            }
        }

        #endregion

        #region Methods

        public void Add(TKey key, TValue value)
        {
            // Make array bigger
            if (this.Count >= this.maxItemsAtCurrentSize)
            {
                var newArray = new MyHashTableArray<TKey, TValue>(array.Capacity * 2);
                foreach(var item in this.array.Items)
                {
                    newArray.Add(item.Key, item.Value);
                }

                this.array = newArray;
                this.maxItemsAtCurrentSize = (int)(this.array.Capacity * fillFactor) + 1;
            }

            this.array.Add(key, value);
            this.Count++;
        }

        public bool Remove(TKey key)
        {
            bool removed = this.array.Remove(key);
            if (removed)
            {
                this.Count--;
            }
            return removed;
        }

        public void Clear()
        {
            this.array.Clear();
            this.Count = 0;
        }

        public void Update(TKey key, TValue value)
        {
            this.array.Update(key, value);
        }

        public IEnumerable<TKey> Keys 
        {
            get
            {
                foreach (var key in this.array.Keys)
                {
                    yield return key;
                }
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                foreach (var value in this.array.Values)
                {
                    yield return value;
                }
            }
        }

        public bool ContainsValue(TValue value)
        {
            bool result = false;
            foreach(var v in this.array.Values)
            {
                if (v.Equals(value))
                {
                    result = true;
                }
                break;
            }
            return result;
        }

        #endregion
    }
}