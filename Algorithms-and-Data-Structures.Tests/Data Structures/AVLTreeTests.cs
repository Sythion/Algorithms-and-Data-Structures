
namespace Algorithms_and_Data_Structures.Tests
{
    using System;
    using System.Linq;
    using Xunit;

    public class AVLTreeTests
    {
        [Fact]
        public void TreeProperties_DefaultInput_ReturnsTrue()
        {
            var tree = new MyAVLTree<int>(false) {4, 2, 1, 3};
            Assert.True(tree.Root.LeftHeight == 2, "The left height is incorrect.");
            Assert.True(tree.Root.RightHeight == 0, "The right height is incorrect.");
            Assert.True(tree.Root.BalanceFactor == -2, "The balance factor is incorrect.");
        }

        [Theory]
        [InlineData(new int[]{4,2,1,3}, new int[]{2,1,4,3})]
        [InlineData(new int[]{4}, new int[] {4})]
        [InlineData(new int[]{3,2,1}, new int[] {2,1,3})]
        [InlineData(new int[]{3,1,2}, new int[]{1,3,2})]
        public void RightRotation_DefaultInput_ReturnsTrue(int[] input, int[] expected)
        {
            var tree = new MyAVLTree<int>(false);
            tree.AddRange(input);
            tree.Root.RightRotation();
            string result = string.Join(',', tree);
            Assert.True(tree.SequenceEqual(expected), $"The sequence was {result}");
        }

        [Theory]
        [InlineData(new int[]{1,3,2,4}, new int[]{3,1,2,4})]
        [InlineData(new int[]{4}, new int[] {4})]
        [InlineData(new int[]{3,4,5}, new int[]{4,3,5})]
        public void LeftRotation_DefaultInput_ReturnsTrue(int[] input, int[] expected)
        {
            var tree = new MyAVLTree<int>(false);
            tree.AddRange(input);
            tree.Root.LeftRotation();
            string result = string.Join(',', tree);
            Assert.True(tree.SequenceEqual(expected), $"The sequence was {result}");
        }

        [Theory]
        [InlineData(new int[]{3,1,2}, new int[]{2,1,3})]
        public void RightLeftRotation_DefaultInput_ReturnsTrue(int[] input, int[] expected)
        {
            var tree = new MyAVLTree<int>(false);
            tree.AddRange(input);
            tree.Root.RightLeftRotation();
            string result = string.Join(',', tree);
            Assert.True(tree.SequenceEqual(expected), $"The sequence was {result}");
        }

        [Theory]
        [InlineData(new int[]{3,1,2}, new int[]{2,1,3})]
        public void LeftRightRotation_DefaultInput_ReturnsTrue(int[] input, int[] expected)
        {
            var tree = new MyAVLTree<int>(false);
            tree.AddRange(input);
            tree.Root.LeftRightRotation();
            string result = string.Join(',', tree);
            Assert.True(tree.SequenceEqual(expected), $"The sequence was {result}");
        }

        [Fact]
        public void Add_BalanceDataWhenAdding_ReturnsTrue()
        {
            var tree = new MyAVLTree<int>(true);

            tree.AddRange(new int[]{5,4,3,2,1});
            var expected = new int[]{4,2,1,3,5};
            var actual = string.Join(',', tree);
            Assert.True(tree.SequenceEqual(expected), $"The expected sequence was {string.Join(',', expected)}, but the actual was {actual}");
        }

        [Fact]
        public void Remove_BalanceDataWhenRemoving_ReturnsTrue()
        {
            var tree = new MyAVLTree<int>(false);
            tree.AddRange(new int[]{5,3,7,2,4,6,8});
            tree.AutoBalance = true;
            tree.Remove(7);
            tree.Remove(4);
            tree.Remove(6);
            tree.Remove(8);
            Assert.True(tree.SequenceEqual(new int[]{3,2,5}));
        }

        [Fact]
        public void AddAndRemove_AutoBalancing_ReturnsTrue()
        {
            var tree = new MyAVLTree<int>(true);
            tree.AddRange(new int[]{8,7,6,5,4,3,2,1});
            var expected1 = new int[]{5,3,2,1,4,7,6,8};
            Assert.True(tree.SequenceEqual(expected1), $"{string.Join(",", tree)}");
            tree.Remove(7);
            tree.Remove(4);
            tree.Remove(6);
            tree.Remove(8);
            var expected2 = new int[] {2,1,3,5};
            Assert.True(tree.SequenceEqual(expected2), $"The expected sequence was {expected2}, but the actual was {string.Join(',', tree)}");
        }
    }
}