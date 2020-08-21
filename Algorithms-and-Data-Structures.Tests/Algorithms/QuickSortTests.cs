namespace Algorithms_and_Data_Structures.Tests
{
    using System;
    using System.Linq;
    using Algorithms_and_Data_Structures;
    using Xunit;

    /// <summary>
    /// Tests for the Quicksort class.
    /// </summary>
    public class QuickSortTests
    {
        /// <summary>
        /// Tests the LomutoPartition method using various inputs.
        /// </summary>
        /// <param name="data">The data to test.</param>
        /// <param name="expected">The expected data after partitioning.</param>
        /// <param name="expectedPivotIndex">The expected index of the pivot value.</param>
        [Theory]
        [InlineData(new int[] {3,7,8,5,2,1,9,5,4}, new int[] {3,2,1,4,7,8,9,5,5}, 3)]
        [InlineData(new int[] {8,7,6,5,4,3,2,1}, new int[] {1,7,6,5,4,3,2,8}, 0)]
        public void LomutoPartition_VariousData_ReturnsTrue(int[] data, int[] expected, int expectedPivotIndex)
        {
            var quickSort = new QuickSort();
            int finalPivotIndex = quickSort.LomutoPartition(data, 0, data.Length-1);

            Assert.True(data.SequenceEqual(expected), $"The partition method did not return the expected sequence. The expected result was {string.Join(',',expected)}. The actual result was {string.Join(',',data)}.");
            Assert.True(expectedPivotIndex == finalPivotIndex, $"The index of the final pivot position is incorrect. The expected was {expectedPivotIndex}, but instead it was {finalPivotIndex}");
        }

        /// <summary>
        /// Tests the HoarePartition method using various input.
        /// </summary>
        /// <param name="data">The data to test.</param>
        /// <param name="expected">The expected data after partitioning.</param>
        /// <param name="expectedPivotIndex">The expected index of the partitioned.</param>
        [Theory]
        [InlineData(new int[] {3,7,8,5,2,1,9,5,4}, new int[] {1,2,8,5,7,3,9,5,4}, 1)]
        [InlineData(new int[] {8,7,6,5,4,3,2,1}, new int[] {1,2,3,4,5,6,7,8}, 3)]
        public void HoarePartition_VariousData_ReturnsTrue(int[] data, int[] expected, int expectedPivotIndex)
        {
            var quickSort = new QuickSort();
            int finalPivotIndex = quickSort.HoarePartition(data, 0, data.Length-1);

            Assert.True(data.SequenceEqual(expected), $"The partition method did not return the expected sequence. The expected result was {string.Join(',',expected)}. The actual result was {string.Join(',',data)}.");
            Assert.True(expectedPivotIndex == finalPivotIndex, $"The index of the final pivot position is incorrect. The expected was {expectedPivotIndex}, but instead it was {finalPivotIndex}");
        }

        /// <summary>
        /// Tests the LomutoSort method.
        /// </summary>
        /// <param name="data">The data to test.</param>
        /// <param name="expected">The expected sorted data.</param>
        [Theory]
        [InlineData(new int[] {3,7,8,5,2,1,9,5,4}, new int[] {1,2,3,4,5,5,7,8,9})]
        [InlineData(new int[] {8,7,6,5,4,3,2,1}, new int[] {1,2,3,4,5,6,7,8})]
        public void LomutoSort_VariousData_ReturnsTrue(int[] data, int[] expected)
        {
            var quickSort = new QuickSort();
            quickSort.LomutoSort(data, 0, data.Length-1);

            Assert.True(data.SequenceEqual(expected), $"QuickSort did not sort the data correctly. The result was {string.Join(',', data)}, but the expected was {string.Join(',',expected)}");
        }

        /// <summary>
        /// Tests the HoareSort method.
        /// </summary>
        /// <param name="data">The data to test.</param>
        /// <param name="expected">The expected sorted data.</param>
        [Theory]
        [InlineData(new int[] {3,7,8,5,2,1,9,5,4}, new int[] {1,2,3,4,5,5,7,8,9})]
        [InlineData(new int[] {8,7,6,5,4,3,2,1}, new int[] {1,2,3,4,5,6,7,8})]
        public void HoareSort_VariousData_ReturnsTrue(int[] data, int[] expected)
        {
            var quickSort = new QuickSort();
            quickSort.HoareSort(data, 0, data.Length-1);

            Assert.True(data.SequenceEqual(expected), $"QuickSort did not sort the data correctly. The result was {string.Join(',', data)}, but the expected was {string.Join(',',expected)}");
        }
    }
}