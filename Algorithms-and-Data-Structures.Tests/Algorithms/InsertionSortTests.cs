namespace Algorithms_and_Data_Structures.Tests
{
    using System;
    using System.Linq;
    using Algorithms_and_Data_Structures;
    using Xunit;

    /// <summary>
    /// Tests for the Insertion sort class.
    /// </summary>
    public class InsertionSortTests
    {
        /// <summary>
        /// Tests that the resulting data is properly sorted.
        /// </summary>
        /// <param name="data">The data to sort.</param>
        [Theory]
        [InlineData(new int[]{5,3,4,4,8,6,7})]
        [InlineData(new int[]{2})]
        [InlineData(new int[]{})]
        public void Execute_VariousData_ReturnsTrue(int[] data)
        {
            var insertionSort = new InsertionSort(data);
            var result = insertionSort.Execute();

            Assert.True(result.SequenceEqual(data.OrderBy(d => d)), "The insertion sort data is sorted.");
        }
    }
}