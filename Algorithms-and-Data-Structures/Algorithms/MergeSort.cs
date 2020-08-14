namespace Algorithms_and_Data_Structures
{
    using System;

    /// <summary>
    /// Implementation of MergeSort.
    /// This is a constant divide-and-conquer algorithm.
    /// Its best, average, and worse-case are all N log N.
    /// The complexiy when it is doing comparisons in MergeAndSort is O(N).
    /// The complexity when it is breaking apart the array is O(log N).
    /// Because MergeAndSort is happening at each level of each item, that is where O(N log N) comes form.
    /// Its space complexity should be O(N).
    /// </summary>
    public class MergeSort
    {
        /// <summary>
        /// Starts the MergeSort process.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <returns>Returns a sorted array.</returns>
        public int[] Sort(int[] array)
        {
            return this.SplitRecur(array);           
        }

        /// <summary>
        /// Recursive method for splitting an array and sorting their subarrays.
        /// </summary>
        /// <param name="array">The array to split and sort.</param>
        /// <returns>Returns a sorted array.</returns>
        public int[] SplitRecur(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }
            else
            {
                int middle = array.Length/2;
                return this.MergeAndSort(
                    this.SplitRecur(array[0..middle]),  
                    this.SplitRecur(array[middle..array.Length]), 
                    array.Length);
            }

        }

        /// <summary>
        /// Merge and sort two arrays into one larger array.
        /// </summary>
        /// <param name="array1">The first array to merge and sort.</param>
        /// <param name="array2">The second array to merge and sort</param>
        /// <param name=""></param>
        /// <returns>Returns a sorted array.</returns>
        public int[] MergeAndSort(int[] array1, int[] array2, int size)
        {
            int i = 0;
            int j = 0;
            int[] result = new int[size];
            for(int k = 0; k < size; k++)
            {
                if (j == array2.Length)
                {
                    result[k] = array1[i];
                    i++;
                }
                else if (i == array1.Length)
                {
                    result[k] = array2[j];
                    j++;
                }
                else
                {
                    if (array1[i] < array2[j])
                    {
                        result[k] = array1[i];
                        i++;
                    }
                    else
                    {
                        result[k] = array2[j];
                        j++;
                    }
                }
            }
            return result;
            
        }
    }
}