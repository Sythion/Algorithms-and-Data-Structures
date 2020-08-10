namespace Algorithms_and_Data_Structures.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using Algorithms_and_Data_Structures;

    public class BinaryTreeTests
    {
        [Fact]
        public void BinaryTree_CallRemoveOnEmpty_ReturnsFalse()
        {
            var binaryTree = new MyBinaryTree<int>();
            bool removed = binaryTree.Remove(2);
            Assert.False(removed, "An item could not be removed");
        }

        [Fact]
        public void BinaryTree_Contains_ReturnsFalse()
        {
            var binaryTree = new MyBinaryTree<int>();
            bool hasItem = binaryTree.Contains(2);
            Assert.False(hasItem, "An item was found");
        }

        [Fact]
        public void BinaryTree_Contains_ReturnsTrue()
        {
            var binaryTree = new MyBinaryTree<int>();
            binaryTree.Add(2);
            bool hasItem = binaryTree.Contains(2);
            Assert.True(hasItem, "An item could not be found");
        }

        [Fact]
        public void BinaryTree_InOrderEnumeration_ReturnsTrue()
        {
            var expectedList = new List<int>{1, 2, 3, 4, 5, 6, 7};
            var binaryTree = new MyBinaryTree<int>();
            binaryTree.Add(4);
            binaryTree.Add(2);
            binaryTree.Add(6);
            binaryTree.Add(1);
            binaryTree.Add(3);
            binaryTree.Add(5);
            binaryTree.Add(7);
            var list = binaryTree.Select(b => b).ToList();
            Assert.True(list.SequenceEqual(expectedList), "The list is not in order");
        }

        [Fact]
        public void BinaryTree_InOrderEnumeration_ReturnsFalse()
        {
            var expectedList = new List<int>{7, 1, 2, 3, 4, 5, 6};
            var binaryTree = new MyBinaryTree<int>();
            binaryTree.Add(4);
            binaryTree.Add(2);
            binaryTree.Add(6);
            binaryTree.Add(1);
            binaryTree.Add(3);
            binaryTree.Add(5);
            binaryTree.Add(7);
            var list = binaryTree.Select(b => b).ToList();
            Assert.False(list.SequenceEqual(expectedList), "The list is in order");
        }
    }
}
