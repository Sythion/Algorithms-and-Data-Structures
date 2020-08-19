namespace Algorithms_and_Data_Structures
{
    using System;

    public class QuickSort
    {
        public void Sort(int[] array, int low, int high)
        {
            if (low < high)
            {
                var p = this.HoarePartition(array, low, high);
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
                    this.Swap(ref array[i], ref array[j]);
                    i++;
                }
            }
            
            this.Swap(ref array[i], ref array[high]);
            return i;
        }

        public int HoarePartition(int[] array, int low, int high)
        {
            // 3,7,8,5,2,1,9,5,4
            // pivot = 4
            // i = -1
            // j = 9
            // 



            int pivot = (low + high)/2;
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
                this.Swap(ref array[i], ref array[j]);
            }
        }

        private void Swap(ref int value1, ref int value2)
        {
            var temp = value1;
            value1 = value2;
            value2 = temp;
        }
    }
}