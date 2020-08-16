namespace Algorithms_and_Data_Structures
{
    using System;

    public class QuickSort
    {
        public void Sort(int[] array, int low, int high)
        {
            if (low < high)
            {
                var p = this.Partition(array, low, high);
                this.Sort(array, 0, p-1);
                this.Sort(array, p+1, high);
            }
        }

        /// <summary>
        /// Uses Lomuto partitioning scheme.
        /// </summary>
        /// <param name="array">The array to partition.</param>
        /// <param name="low">The low value.</param>
        /// <param name="high">The high value.</param>
        /// <returns>Returns the final position of the pivot value.</returns>
        public int Partition(int[] array, int low, int high) // treat high as pivot
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
                    this.Swap(ref array[i], ref array[j]);
                    i++;
                }
            }
            
            this.Swap(ref array[i], ref array[high]);
            return i;
        }

        private void Swap(ref int value1, ref int value2)
        {
            var temp = value1;
            value1 = value2;
            value2 = temp;
        }
    }
}