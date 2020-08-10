using System;
using Xunit;
using Algorithms_and_Data_Structures;

namespace Algorithms_and_Data_Structures.Tests
{
    public class HashTableTests
    {
        [Fact]
        public void HashTable_CallRemoveOnEmptyList_ReturnsTrue()
        {
            var hashTable = new MyHashTable<int, string>(1000);
            bool removed = hashTable.Remove(2);
            Assert.False(removed, "An item was removed");
        }

        [Fact]
        public void HashTable_AddAndRemoveValues_ReturnsTrue()
        {
            var hashTable = new MyHashTable<int, string>(1000);
            hashTable.Add(1, "Jane");
            hashTable.Add(2, "Henry");
            hashTable.Remove(2);

            Assert.True(hashTable.Count == 1, "The hashtable did not have the correct count");
        }

        [Fact]
        public void HashTable_AddValues_ReturnsTrue()
        {
            var hashTable = new MyHashTable<int, string>(1000);
            hashTable.Add(1, "Jane");
            hashTable.Add(2, "Henry");

            Assert.True(hashTable.Count == 2, "The hashtable did not have the correct count");
        }

        [Fact]
        public void HashTable_ContainsValue_ReturnsTrue()
        {
            var hashTable = new MyHashTable<int, string>(1000);
            hashTable.Add(1, "Jane");

            Assert.True(hashTable.ContainsValue("Jane"), "The hashtable did not have the correct value");
        }

        [Fact]
        public void HashTable_ContainsValue_ReturnsFalse()
        {
            var hashTable = new MyHashTable<int, string>(1000);
            hashTable.Add(1, "Jane");

            Assert.False(hashTable.ContainsValue("Tim"), "The hashtable did not have the correct value");
        }
    }
}
