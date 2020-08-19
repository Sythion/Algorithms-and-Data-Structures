namespace Algorithms_and_Data_Structures
{
    using System;

    /// <summary>
    /// Quick sort implementation with choice of Lomuto or Hoare partition.
    /// Best-case, average-case, and worst-case will theoretically be N log N.
    /// Hoare partition will be more efficient than Lomuto's partition.
    /// </summary>
    public class QuickSort
    {
        /// <summary>
        /// Sort the items using the Lomuto method of partitioning.          
        /// Degrades to O(N^2) with already sorted data or data where all elements match.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <param name="low">The low index value.</param>
        /// <param name="high">The high index value.</param>
        public void LomutoSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                var p = this.LomutoPartition(array, low, high);
                this.LomutoSort(array, low, p-1);
                this.LomutoSort(array, p+1, high);
            }
        }

        /// <summary>
        /// Sort the items using Hoare method of partitioning.
        /// Should maintain N log N.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <param name="low">The low index of the array.</param>
        /// <param name="high">The high index of the array.</param>
        public void HoareSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                var p = this.HoarePartition(array, low, high);
                this.HoareSort(array, low, p);
                this.HoareSort(array, p+1, high);
            }
        }

        /// <summary>
        /// Uses Lomuto partitioning scheme. Uses the last item as the pivot.
        /// </summary>
        /// <param name="array">The array to partition.</param>
        /// <param name="low">The low value.</param>
        /// <param name="high">The high value.</param>
        /// <returns>Returns the final index of the pivot value.</returns>
        public int LomutoPartition(int[] array, int low, int high) // treat high as pivot
        {
            int pivot = array[high];

            // i represents the index of the last value found that was less than pivot.
            // i will represent the final position of the pivot value after the final swap.
            int i = low;
            for(int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    // swap
                    this.Swap(array, i, j);
                    i++;
                }
            }
            
            this.Swap(array, i, high);
            return i;
        }

        /// <summary>
        /// Uses the Hoare method of partitioning. This does not degrade to O(N^2) for sorted data or data with matching elements
        /// as long as the middle item is used as the pivot.
        /// </summary>
        /// <param name="array">The array to partition.</param>
        /// <param name="low">The low index.</param>
        /// <param name="high">The high index.</param>
        /// <returns>Returns the final index of the pivot value.</returns>
        public int HoarePartition(int[] array, int low, int high)
        {
            int pivot = array[(low + high)/2];
            int i = low - 1;
            int j = high + 1;
            while(true)
            {
                do
                {
                    i++;
                }
                while(array[i] < pivot);
                do
                {
                    j--;
                }
                while(array[j] > pivot);
                if (i >= j)
                {
                    return j;
                }
                this.Swap(array, i, j);
            }
        }

        /// <summary>
        /// Swaps the values at two indices in the provided array.
        /// </summary>
        /// <param name="array">The array for which to swap values.</param>
        /// <param name="i">An index of the array.</param>
        /// <param name="j">An index of the array.</param>
        private void Swap(int[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}