namespace Algorithms_and_Data_Structures
{
    using System;

    /// <summary>
    /// Implementation of the selection sort algorithm.
    /// Linear sorting algorithm.
    /// The worst-case, average-case and best-case time complexity is N^2.
    /// The space complexity is O(N).
    /// This algorithm is comparison heavy but not swap heavy.
    /// </summary>
    public class SelectionSort
    {
        /// <summary>
        /// Backing store for selection sort data.
        /// </summary>
        private int[] array;

        /// <summary>
        /// Initializes a new intance of the SelectionSort class.
        /// </summary>
        /// <param name="array">The data to sort.</param>
        public SelectionSort(int[] array)
        {
            this.array = array;
        }

        /// <summary>
        /// Sorts the array.
        /// </summary>
        /// <returns>Returns a sorted array.</returns>
        public int[] Execute()
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                // Get smallest number
                int smallest = this.array[i];
                for(int j = 1; j < this.array.Length; j++)
                {
                    if (this.array[j] < smallest)
                    {
                        smallest = array[j];
                    }
                }
                int temp = this.array[i];
                this.array[i] = smallest;
                this.array[i+1] = temp;
            }
            return this.array;
        }
    }
}