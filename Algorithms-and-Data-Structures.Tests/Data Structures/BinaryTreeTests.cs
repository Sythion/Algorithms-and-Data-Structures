namespace Algorithms_and_Data_Structures.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using Algorithms_and_Data_Structures;

    /// <summary>
    /// Tests for the MyBinaryTree class.
    /// </summary>
    public class BinaryTreeTests
    {
        /// <summary>
        /// Tests that calling Remove on an empty set will return that no item has been removed.
        /// </summary>
        [Fact]
        public void BinaryTree_CallRemoveOnEmpty_ReturnsFalse()
        {
            var binaryTree = new MyBinaryTree<int>();
            bool removed = binaryTree.Remove(2);
            Assert.False(removed, "An item could not be removed");
        }

        /// <summary>
        /// Tests that calling Contains on empty empty tree will return that no item has been removed.
        /// </summary>
        [Fact]
        public void BinaryTree_Contains_ReturnsFalse()
        {
            var binaryTree = new MyBinaryTree<int>();
            bool hasItem = binaryTree.Contains(2);
            Assert.False(hasItem, "An item was found");
        }
        
        /// <summary>
        /// Tests that Contains will find the correct item in the tree.
        /// </summary>
        [Fact]
        public void BinaryTree_Contains_ReturnsTrue()
        {
            var binaryTree = new MyBinaryTree<int>();
            binaryTree.Add(2);
            bool hasItem = binaryTree.Contains(2);
            Assert.True(hasItem, "An item could not be found");
        }

        /// <summary>
        /// Tests that enumerating the tree returns an in-order enumeration.
        /// </summary>
        /// <param name="expected"></param>
        [Theory]
        [InlineData(new int[]{4,2,6,1,3,5,7})]
        public void BinaryTree_InOrderEnumeration_ReturnsTrue(int[] data)
        {
            var binaryTree = new MyBinaryTree<int>();
            foreach(var item in data)
            {
                binaryTree.Add(item);
            }
            Assert.True(binaryTree.SequenceEqual(data.OrderBy(d => d)), "The binary tree does not enumerate in order");
        }
    }
}
