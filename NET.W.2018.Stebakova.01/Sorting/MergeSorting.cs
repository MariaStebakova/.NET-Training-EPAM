namespace Sorting
{
    using System;

    /// <summary>
    /// Static class that provides merge sorting method.
    /// </summary>
    public class MergeSorting
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
                throw new ArgumentNullException("Array can't be equal to null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentNullException("Array can't be empty.");
            }

            MergeSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Static method that provides merge sorting the part of array lying between leftBorder and rightBorder indexes.
        /// </summary>
        /// <param name="array">The array for sorting</param>
        /// <param name="leftBorder">Index of the first element of the array.</param>
        /// <param name="rightBorder">Index of the last element of the array.</param>
        public static void MergeSort(int[] array, int leftBorder, int rightBorder)
        {
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
        /// <param name="arr">Array, that is divided in two arrays to be merged.</param>
        /// <param name="lb">Index of the first element in the first array.</param>
        /// <param name="middle">Index of the last element in the first array.</param>
        /// <param name="rb">Index of the last element in the second array.</param>
        public static void Merge(int[] arr, int lb, int middle, int rb)
        {
            int firstIndex = lb;
            int secondIndex = middle + 1;
            int tempArrayIndex = 0;

            int[] tempArray = new int[rb - lb + 1];

            while (firstIndex <= middle && secondIndex <= rb)
            {
                if (arr[firstIndex] < arr[secondIndex])
                {
                    tempArray[tempArrayIndex] = arr[firstIndex];
                    firstIndex++;
                }
                else
                {
                    tempArray[tempArrayIndex] = arr[secondIndex];
                    secondIndex++;
                }

                tempArrayIndex++;
            }

            while (firstIndex <= middle)
            {
                tempArray[tempArrayIndex] = arr[firstIndex];
                tempArrayIndex++;
                firstIndex++;
            }

            while (secondIndex <= rb)
            {
                tempArray[tempArrayIndex] = arr[secondIndex];
                tempArrayIndex++;
                secondIndex++;
            }

            for (tempArrayIndex = 0; tempArrayIndex < rb - lb + 1; tempArrayIndex++)
            {
                arr[lb + tempArrayIndex] = tempArray[tempArrayIndex];
            } 

            Array.Clear(tempArray, 0, tempArrayIndex);
        }
    }
}