namespace Sorting
{
    using System;

    /// <summary>
    /// Static class that provides merge and quick sorting method.
    /// </summary>
    public static class Sorting
    {
        /// <summary>
        /// Static method for implementing merge sort for the input array.
        /// </summary>
        /// <param name="array">The array for sorting.</param>
        /// <exception cref="ArgumentNullException">Throws when the array is equal to null or empty.</exception>
        public static void MergeSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be empty.");
            }

            MergeSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Static method that provides merge sorting the part of array lying between leftBorder and rightBorder indexes.
        /// </summary>
        /// <param name="array">The array for sorting</param>
        /// <param name="leftBorder">Index of the first element of the array.</param>
        /// <param name="rightBorder">Index of the last element of the array.</param>
        /// <exception cref="ArgumentException">Throws when the start of the array more than the end.</exception>
        public static void MergeSort(int[] array, int leftBorder, int rightBorder)
        {
            if (leftBorder > rightBorder)
            {
                throw new ArgumentException($"{nameof(leftBorder)} can't be more or equal to the {nameof(rightBorder)}");
            }

            if (leftBorder < rightBorder)
            {
                int middle = (leftBorder + rightBorder) / 2;
                MergeSort(array, leftBorder, middle);
                MergeSort(array, middle + 1, rightBorder);
                Merge(array, leftBorder, middle, rightBorder);
            }
        }

        /// <summary>
        /// Static method that merges two sorted array into the general resulting array.
        /// </summary>
        /// <param name="array">Array, that is divided in two arrays to be merged.</param>
        /// <param name="leftBorder">Index of the first element in the first array.</param>
        /// <param name="middle">Index of the last element in the first array.</param>
        /// <param name="rightBorder">Index of the last element in the second array.</param>
        public static void Merge(int[] array, int leftBorder, int middle, int rightBorder)
        {
            int firstIndex = leftBorder;
            int secondIndex = middle + 1;
            int tempArrayIndex = 0;

            int[] tempArray = new int[rightBorder - leftBorder + 1];

            while (firstIndex <= middle && secondIndex <= rightBorder)
            {
                if (array[firstIndex] < array[secondIndex])
                {
                    tempArray[tempArrayIndex] = array[firstIndex];
                    firstIndex++;
                }
                else
                {
                    tempArray[tempArrayIndex] = array[secondIndex];
                    secondIndex++;
                }

                tempArrayIndex++;
            }

            while (firstIndex <= middle)
            {
                tempArray[tempArrayIndex] = array[firstIndex];
                tempArrayIndex++;
                firstIndex++;
            }

            while (secondIndex <= rightBorder)
            {
                tempArray[tempArrayIndex] = array[secondIndex];
                tempArrayIndex++;
                secondIndex++;
            }

            for (tempArrayIndex = 0; tempArrayIndex < rightBorder - leftBorder + 1; tempArrayIndex++)
            {
                array[leftBorder + tempArrayIndex] = tempArray[tempArrayIndex];
            } 

            Array.Clear(tempArray, 0, tempArrayIndex);
        }

        /// <summary>
        /// Static method for implementing quick sort for the input array.
        /// </summary>
        /// <param name="array">The array for sorting.</param>
        /// <exception cref="ArgumentNullException">Throws when the array is equal to null or empty.</exception>
        public static void QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be empty.");
            }

            QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Static method that provides quick sorting the part of array lying between leftBorder and rightBorder indexes.
        /// </summary>
        /// <param name="array">The array for sorting</param>
        /// <param name="leftBorder">Index of the first element of the array.</param>
        /// <param name="rightBorder">Index of the last element of the array.</param>
        /// <exception cref="ArgumentException">Throws when the start of the array more than the end.</exception>
        public static void QuickSort(int[] array, int leftBorder, int rightBorder)
        {
            if (leftBorder >= rightBorder)
            {
                throw new ArgumentException($"{nameof(leftBorder)} can't be more or equal to the {nameof(rightBorder)}");
            }

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