namespace Algorithms_and_Data_Structures
{
    using System;
    using System.Linq;
    using Algorithms_and_Data_Structures;
    using Xunit;

    public class QuickSortTests
    {
        [Theory]
        [InlineData(new int[] {3,7,8,5,2,1,9,5,4}, new int[] {3,2,1,4,7,8,9,5,5}, 3)]
        [InlineData(new int[] {8,7,6,5,4,3,2,1}, new int[] {1,7,6,5,4,3,2,8}, 0)]
        public void Partition_VariousData_ReturnsTrue(int[] data, int[] expected, int expectedPivotIndex)
        {
            var quickSort = new QuickSort();
            int finalPivotIndex = quickSort.Partition(data, 0, data.Length-1);

            Assert.True(data.SequenceEqual(expected), $"The partition method did not return the expected sequence. The expected result was {string.Join(',',expected)}. The actual result was {string.Join(',',data)}.");
            Assert.True(expectedPivotIndex == finalPivotIndex, $"The index of the final pivot position is incorrect. The expected was {expectedPivotIndex}, but instead it was {finalPivotIndex}");
        }

        [Theory]
        [InlineData(new int[] {3,7,8,5,2,1,9,5,4}, new int[] {1,2,3,4,5,5,7,8,9})]
        [InlineData(new int[] {8,7,6,5,4,3,2,1}, new int[] {1,2,3,4,5,6,7,8})]
        public void Sort_VariousData_ReturnsTrue(int[] data, int[] expected)
        {
            var quickSort = new QuickSort();
            quickSort.Sort(data, 0, data.Length-1);

            Assert.True(data.SequenceEqual(expected), $"QuickSort did not sort the data correctly. The result was {string.Join(',', data)}, but the expected was {string.Join(',',expected)}");
        }
    }
}