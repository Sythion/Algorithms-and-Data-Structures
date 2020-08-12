namespace Algorithms_and_Data_Structures
{
    using System;
    using System.Linq;
    using Xunit; 

    /// <summary>
    /// Tests for the BubbleSort class.
    /// </summary>
    public class BubbleSortTests
    {
        /// <summary>
        /// Tests that the execute method sorts the data correctly.
        /// </summary>
        /// <param name="data">The data to sort.</param>
        [Theory]
        [InlineData(new int[] {3, 4, 4, 6, 5, 7, 8})]
        [InlineData(new int[] {9, 8, 7, 6, 5, 4, 3, 2, 1})]
        [InlineData(new int[] {})]
        public void Execute_VariousData_ReturnsTrue(int[] data)
        {
            var bubbleSort = new BubbleSort(data);
            int[] result = bubbleSort.Execute();
            Assert.True(result.SequenceEqual(data.OrderBy(d => d)), "The bubblesort data is not sorted.");
        }
    }
}