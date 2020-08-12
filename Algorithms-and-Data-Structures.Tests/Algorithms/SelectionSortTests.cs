namespace Algorithms_and_Data_Structures.Tests
{
    using System;
    using System.Linq;
    using Algorithms_and_Data_Structures;
    using Xunit;

    /// <summary>
    /// Tests for the SelectionSort class.
    /// </summary>
    public class SelectionSortTests
    {
        /// <summary>
        /// Tests the execute method.
        /// </summary>
        /// <param name="data">The data to test.</param>
        [Theory]
        [InlineData(new int[]{3,8,2,1,5,4,6,7})]
        [InlineData(new int[]{9,8,7,6,5,4,3,2,1})]
        [InlineData(new int[]{2})]
        [InlineData(new int[]{})]
        public void Execute_VariousData_ReturnsTrue(int[] data)
        {
            var selectionSort = new SelectionSort(data);
            var result = selectionSort.Execute();

            Assert.True(result.SequenceEqual(data.OrderBy(d => d)), "The selection sort data was not ordered.");
        }
    }
}