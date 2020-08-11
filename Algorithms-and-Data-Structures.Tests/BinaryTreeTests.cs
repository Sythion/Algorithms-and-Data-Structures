namespace Algorithms_and_Data_Structures.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using Algorithms_and_Data_Structures;

    public class BinaryTreeTests
    {
        [Theory]
        [InlineData(2)]
        public void BinaryTree_CallRemoveOnEmpty_ReturnsFalse(int item)
        {
            var binaryTree = new MyBinaryTree<int>();
            bool removed = binaryTree.Remove(item);
            Assert.False(removed, "An item could not be removed");
        }

        [Theory]
        [InlineData(2)]
        public void BinaryTree_Contains_ReturnsFalse(int item)
        {
            var binaryTree = new MyBinaryTree<int>();
            bool hasItem = binaryTree.Contains(item);
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

        [Theory]
        [InlineData(new int[]{1, 2, 3, 4, 5, 6, 7})]
        public void BinaryTree_InOrderEnumeration_ReturnsTrue(int[] expected)
        {
            var binaryTree = new MyBinaryTree<int>();
            binaryTree.Add(4);
            binaryTree.Add(2);
            binaryTree.Add(6);
            binaryTree.Add(1);
            binaryTree.Add(3);
            binaryTree.Add(5);
            binaryTree.Add(7);
            var list = binaryTree.Select(b => b).ToList();
            Assert.True(list.SequenceEqual(expected.ToList()), "The list is not in order");
        }

        [Theory]
        [InlineData(new int[]{7, 1, 2, 3, 4, 5, 6})]
        public void BinaryTree_InOrderEnumeration_ReturnsFalse(int[] expected)
        {
            var binaryTree = new MyBinaryTree<int>();
            binaryTree.Add(4);
            binaryTree.Add(2);
            binaryTree.Add(6);
            binaryTree.Add(1);
            binaryTree.Add(3);
            binaryTree.Add(5);
            binaryTree.Add(7);
            var list = binaryTree.Select(b => b).ToList();
            Assert.False(list.SequenceEqual(expected.ToList()), "The list is in order");
        }
    }
}
