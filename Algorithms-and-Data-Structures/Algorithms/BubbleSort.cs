namespace Algorithms_and_Data_Structures
{
    /// <summary>
    /// Implementation of BubbleSort algorithm.  
    /// Linear sorting algorithm.
    /// This performs at worst or average case n^2 time.
    /// Best case is N time for sorted or almost-sorted data.
    /// Space complexity is O(N).
    /// </summary>
    public class BubbleSort
    {
        /// <summary>
        /// Backing store for sorting.
        /// </summary>
        private int[] array;

        /// <summary>
        /// Initializes a new instance of the BubbleSort class.
        /// </summary>
        /// <param name="array">The array of values to sort.</param>
        public BubbleSort(int[] array)
        {
            this.array = array;
        }

        /// <summary>
        /// Starts the sort.
        /// </summary>
        /// <returns>Returns the sorted array.</returns>
        public int[] Execute()
        {
            bool swapPerformed;
            do
            {
                swapPerformed = false;
                for(int i = 0; i < this.array.Length - 1; i ++)
                {
                    if (this.array[i] > this.array[i+1])
                    {
                        int temp = this.array[i+1];
                        this.array[i+1] = this.array[i];
                        this.array[i] = temp;
                        swapPerformed = true;
                    }
                }
            }
            while(swapPerformed);
            return this.array;
        }
    }
}