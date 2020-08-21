namespace Algorithms_and_Data_Structures.Tests
{
    using System;
    using System.Linq;
    using Xunit;

    /// <summary>
    /// Tests for the MergeSort class.
    /// </summary>
    public class MergeSortTests
    {
        /// <summary>
        /// Tests the sort method using various data. Expects a true result.
        /// </summary>
        /// <param name="data">The data to test.</param>
        [Theory]
        [InlineData(new int[] {3,8,2,1,5,4,6,7})]
        [InlineData(new int[] {7,6,5,4,3,2,1})]
        [InlineData(new int[] {2})]
        [InlineData(new int[] {})]
        public void Sort_VariousData_ReturnsTrue(int[] data)
        {
            var mergeSort = new MergeSort();
            var actual = mergeSort.Sort(data);

            var expected = data.OrderBy(d => d);
            Assert.True(actual.SequenceEqual(expected), $"The merge sort did not sort the items. Expected: {string.Join(',', expected)}; Actual: {string.Join(',', actual)}");
        }

        /// <summary>
        /// Tests that MergeAndSort can merge and sort two arrays.
        /// </summary>
        [Fact]
        public void MergeAndSort_TwoArrays_ReturnsTrue()
        {
            var mergeSort = new MergeSort();
            var array1 = new int[] { 2, 4, 6 };
            var array2 = new int[] {1, 3, 5};
            var result = mergeSort.MergeAndSort(array1, array2, 6);

            Assert.True(result.SequenceEqual(new int[] {1,2,3,4,5,6}), "The arrays were not sorted.");
        }
    }
}