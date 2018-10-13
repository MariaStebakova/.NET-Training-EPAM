namespace Sorting
{
    using System;

    /// <summary>
    /// Static class that provides quick sorting method.
    /// </summary>
    public class QuickSorting
    {
        /// <summary>
        /// Static method for implementing quick sort for the input array.
        /// </summary>
        /// <param name="array">The array for sorting.</param>
        /// <exception cref="ArgumentNullException">Throws when the array is equal to null or empty.</exception>
        public static void QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array can't be equal to null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentNullException("Array can't be empty.");
            }

            QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Static method that provides quick sorting the part of array lying between leftBorder and rightBorder indexes.
        /// </summary>
        /// <param name="array">The array for sorting</param>
        /// <param name="leftBorder">Index of the first element of the array.</param>
        /// <param name="rightBorder">Index of the last element of the array.</param>
        public static void QuickSort(int[] array, int leftBorder, int rightBorder)
        {
            int i = leftBorder;
            int j = rightBorder;

            int separatorIndex = (leftBorder + rightBorder) / 2;
            int separator = array[separatorIndex];

            do 
            {
                while (array[i] < separator)
                {
                    i++;
                }

                while (array[j] > separator)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(ref array[i], ref array[j]);
                    i++;
                    j--;
                }
            }
            while (i <= j);

            if (i < rightBorder)
            {
                QuickSort(array, i, rightBorder);
            }

            if (j > leftBorder)
            {
                QuickSort(array, leftBorder, j);
            }
        }

        /// <summary>
        /// Static private method for swapping positions of two input elements.
        /// </summary>
        /// <param name="first">First element to be swapped.</param>
        /// <param name="second">Second element to be swapped.</param>
        private static void Swap(ref int first, ref int second)
        {
            int temp;

            temp = first;
            first = second;
            second = temp;
        }
    }
}
