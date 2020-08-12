namespace Algorithms_and_Data_Structures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// A node pair class for use with the MyHashTableArrayNode class.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class MyHashTableNodePair<TKey, TValue>
    {
#region Constructors
        /// <summary>
        /// Initializes a new instance of the MyHashTableNodePair class.
        /// </summary>
        /// <param name="key">The key of the node pair.</param>
        /// <param name="value">The value of the node pair.</param>
        public MyHashTableNodePair(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

#endregion

#region Properties
        /// <summary>
        /// Gets or sets the key of the pair.
        /// </summary>
        public TKey Key { get; set; }

        /// <summary>
        /// Gets or sets the 
        /// </summary>
        public TValue Value { get; set; }
#endregion
    }

}