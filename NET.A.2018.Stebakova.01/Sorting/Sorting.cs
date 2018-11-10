using System.Collections;
using System.Collections.Generic;

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
        /// <param name="comparison">Delegate that performs the comparison of two value.</param>
        /// <exception cref="ArgumentNullException">Throws when the array is equal to null or empty.</exception>
        public static void MergeSort<T>(T[] array, Comparison<T> comparison)
        {
            CheckInputArray(array);

            MergeSort(array, 0, array.Length - 1, comparison);
        }

        /// <summary>
        /// Static method for implementing merge sort for the input array according to default comparer delegate.
        /// </summary>
        /// <param name="array">The array for sorting.</param>
        /// <exception cref="ArgumentNullException">Throws when the array is equal to null or empty.</exception>
        public static void MergeSort<T>(T[] array)
        {
            CheckInputArray(array);

            var comparison = Comparer<T>.Default;
            MergeSort(array, 0, array.Length - 1, comparison.Compare);
        }

        /// <summary>
        /// Static method that provides merge sorting the part of array lying between leftBorder and rightBorder indexes.
        /// </summary>
        /// <param name="array">The array for sorting</param>
        /// <param name="leftBorder">Index of the first element of the array.</param>
        /// <param name="rightBorder">Index of the last element of the array.</param>
        /// <param name="comparison">Delegate that performs the comparison of two value.</param>
        /// <exception cref="ArgumentException">Throws when the start of the array more than the end.</exception>
        /// <exception cref="ArgumentNullException">Throws when the array is equal to null or empty.</exception>
        public static void MergeSort<T>(T[] array, int leftBorder, int rightBorder, Comparison<T> comparison)
        {
            CheckInputArray(array);

            if (leftBorder > rightBorder)
            {
                throw new ArgumentException($"{nameof(leftBorder)} can't be more or equal to the {nameof(rightBorder)}");
            }

            if (leftBorder < rightBorder)
            {
                int middle = (leftBorder + rightBorder) / 2;
                MergeSort(array, leftBorder, middle, comparison);
                MergeSort(array, middle + 1, rightBorder, comparison);
                Merge(array, leftBorder, middle, rightBorder, comparison);
            }
        }

        /// <summary>
        /// Static method that merges two sorted array into the general resulting array.
        /// </summary>
        /// <param name="array">Array, that is divided in two arrays to be merged.</param>
        /// <param name="leftBorder">Index of the first element in the first array.</param>
        /// <param name="middle">Index of the last element in the first array.</param>
        /// <param name="rightBorder">Index of the last element in the second array.</param>
        /// <param name="comparison">Delegate that performs the comparison of two value.</param>
        public static void Merge<T>(T[] array, int leftBorder, int middle, int rightBorder, Comparison<T> comparison)
        {
            int firstIndex = leftBorder;
            int secondIndex = middle + 1;
            int tempArrayIndex = 0;

            T[] tempArray = new T[rightBorder - leftBorder + 1];

            while (firstIndex <= middle && secondIndex <= rightBorder)
            {
                if (comparison(array[firstIndex], array[secondIndex]) < 0)
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
        /// Static method for implementing quick sort for the input array according default comparer delegate.
        /// </summary>
        /// <param name="array">The array for sorting.</param>
        /// <exception cref="ArgumentNullException">Throws when the array is equal to null or empty.</exception>
        public static void QuickSort<T>(T[] array)
        {
            CheckInputArray(array);

            var comparer = Comparer<T>.Default;
            QuickSort(array, 0, array.Length - 1, comparer.Compare);
        }

        /// <summary>
        /// Static method for implementing quick sort for the input array.
        /// </summary>
        /// <param name="array">The array for sorting.</param>
        /// <param name="comparison">Delegate that performs the comparison of two value.</param>
        /// <exception cref="ArgumentNullException">Throws when the array is equal to null or empty.</exception>
        public static void QuickSort<T>(T[] array, Comparison<T> comparison)
        {
            CheckInputArray(array);

            QuickSort(array, 0, array.Length - 1, comparison);
        }

        /// <summary>
        /// Static method that provides quick sorting the part of array lying between leftBorder and rightBorder indexes.
        /// </summary>
        /// <param name="array">The array for sorting</param>
        /// <param name="leftBorder">Index of the first element of the array.</param>
        /// <param name="rightBorder">Index of the last element of the array.</param>
        /// <param name="comparison">Delegate that performs the comparison of two value.</param>
        /// <exception cref="ArgumentException">Throws when the start of the array more than the end.</exception>
        public static void QuickSort<T>(T[] array, int leftBorder, int rightBorder, Comparison<T> comparison)
        {
            CheckInputArray(array);

            if (leftBorder >= rightBorder)
            {
                throw new ArgumentException($"{nameof(leftBorder)} can't be more or equal to the {nameof(rightBorder)}");
            }

            int i = leftBorder;
            int j = rightBorder;

            int separatorIndex = (leftBorder + rightBorder) / 2;
            T separator = array[separatorIndex];

            do
            {
                while (comparison(array[i], separator) < 0)
                {
                    i++;
                }

                while (comparison(array[j], separator) > 0)
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
                QuickSort(array, i, rightBorder, comparison);
            }

            if (j > leftBorder)
            {
                QuickSort(array, leftBorder, j, comparison);
            }
        }

        /// <summary>
        /// Static private method for swapping positions of two input elements.
        /// </summary>
        /// <param name="first">First element to be swapped.</param>
        /// <param name="second">Second element to be swapped.</param>
        private static void Swap<T>(ref T first, ref T second)
        {
            T temp;

            temp = first;
            first = second;
            second = temp;
        }

        private static void CheckInputArray<T>(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be empty.");
            }
        }
    }
}