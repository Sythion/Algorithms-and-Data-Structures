
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
            var tree = new MyAVLTree<int> {4, 2, 1, 3};
            Assert.True(tree.Root.LeftHeight == 2, "The left height is incorrect.");
            Assert.True(tree.Root.RightHeight == 0, "The right height is incorrect.");
            Assert.True(tree.Root.BalanceFactor == -2, "The balance factor is incorrect.");
        }

        [Fact]
        public void RightRotation_EmptyTree_ReturnsTrue()
        {
            var tree = new MyAVLTree<int>();
            Assert.Throws<Exception>(() => tree.RightRotation());
        }

        [Theory]
        [InlineData(new int[]{4,2,1,3}, new int[]{2,1,4,3})]
        [InlineData(new int[]{4}, new int[] {4})]
        [InlineData(new int[]{3,2,1}, new int[] {2,1,3})]
        public void RightRotation_DefaultInput_ReturnsTrue(int[] input, int[] expected)
        {
            var tree = new MyAVLTree<int>();
            tree.AddRange(input);
            tree.RightRotation();
            string result = string.Join(',', tree);
            Assert.True(tree.SequenceEqual(expected), $"The sequence was {result}");
        }

        [Theory]
        //[InlineData(new int[]{1,3,2,4}, new int[]{3,1,2,4})]
        //[InlineData(new int[]{4}, new int[] {4})]
        [InlineData(new int[]{3,2,1}, new int[] {2,1,3})]
        public void LeftRotation_DefaultInput_ReturnsTrue(int[] input, int[] expected)
        {
            var tree = new MyAVLTree<int>();
            tree.AddRange(input);
            tree.LeftRotation();
            string result = string.Join(',', tree);
            Assert.True(tree.SequenceEqual(expected), $"The sequence was {result}");
            /*Assert.True(tree.Root.Value == 3);
            Assert.True(tree.Root.Left.Value == 1);
            Assert.True(tree.Root.Left.Right.Value == 2);
            Assert.True(tree.Root.Right.Value == 4);*/
        }
    }
}