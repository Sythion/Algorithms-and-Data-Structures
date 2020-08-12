namespace Algorithms_and_Data_Structures
{
    using System;

    /// <summary>
    /// Implementation of InsertionSort algorithm.
    /// Linear sorting algorithm.
    /// Worst-case and Average-case execution time is N^2.
    /// Best-case execution time approaches N.
    /// Space complexity is O(N).
    /// </summary>
    public class InsertionSort
    {
        /// <summary>
        /// The array to sort.
        /// </summary>
        public int[] array;

        /// <summary>
        /// Initializes a new instance of the InsertionSort class.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public InsertionSort(int[] array)
        {
            this.array = array;
        }

        /// <summary>
        /// Starts the insertion sort on the array.
        /// </summary>
        /// <returns>Returns a sorted array.</returns>
        public int[] Execute()
        {
            for(int i = 1; i < this.array.Length; i++)
            {
                // All numbers before current number (i) are sorted so compare with them.
                for(int j = 0; j < i; j++)
                {
                    if (this.array[i] < this.array[j])
                    {
                        int temp = this.array[j];
                        this.array[j] = this.array[i];
                        this.array[i] = temp;
                    }
                }
            }

            return this.array;
        }
    }
}