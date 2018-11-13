using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /// <summary>
    /// Class that provides functionality for binary search
    /// </summary>
    /// <typeparam name="T">Expected type</typeparam>
    public class BinarySearchEngine
    {
        /// <summary>
        /// Method that returns position of <paramref name="value"/> in <paramref name="array"/> if such is exist.
        /// </summary>
        /// <typeparam name="T">Type of input data</typeparam>
        /// <param name="array">Needed array.</param>
        /// <param name="value">Needed value to search for.</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="array"/> or <paramref name="value"/> is equal to null. </exception>
        /// <returns>Position of <paramref name="value"/> in <paramref name="array"/> if such is exist</returns>
        public static int? BinarySearch<T>(T[] array, T value)
        {
            CheckInputArray(array, value);

            return Search(array, value, 0, array.Length, null);
        }

        /// <summary>
        /// Method that returns position of <paramref name="value"/> in <paramref name="array"/> if such is exist based on <paramref name="comparer"/>
        /// </summary>
        /// <typeparam name="T">Type of input data</typeparam>
        /// <param name="array">Needed array</param>
        /// <param name="value">Needed value to search for</param>
        /// <param name="comparer"><see cref="IComparer{T}"/> comparer</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="array"/> or <paramref name="value"/> is equal to null. </exception>
        /// <returns>Position of <paramref name="value"/> in <paramref name="array"/> if such is exist based on <paramref name="comparer"/></returns>
        public static int? BinarySearch<T>(T[] array, T value, IComparer<T> comparer)
        {
            CheckInputArray(array, value);

            return Search(array, value, 0, array.Length, comparer.Compare);
        }

        /// <summary>
        /// Method that returns position of <paramref name="value"/> in <paramref name="array"/> if such is exist based on <paramref name="comparison"/>
        /// </summary>
        /// <typeparam name="T">Type of input data</typeparam>
        /// <param name="array">Needed array</param>
        /// <param name="value">Needed value to search for</param>
        /// <param name="comparison"><see cref="Comparison{T}"/> comparer</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="array"/> or <paramref name="value"/> is equal to null. </exception>
        /// <returns>Position of <paramref name="value"/> in <paramref name="array"/> if such is exist based on <paramref name="comparison"/></returns>
        public static int? BinarySearch<T>(T[] array, T value, Comparison<T> comparison)
        {
            CheckInputArray(array, value);

            return Search(array, value, 0, array.Length, comparison);
        }

        /// <summary>
        /// Method that returns position of <paramref name="value"/> in <paramref name="array"/> if such is exist based on <paramref name="comparer"/>
        /// </summary>
        /// <typeparam name="T">Type of input data</typeparam>
        /// <param name="array">Needed array</param>
        /// <param name="value">Needed value to search for</param>
        /// <param name="startIndex">Beginning of starting searching</param>
        /// <param name="count">Number of elements of the array for searching in</param>
        /// <param name="comparer"><see cref="IComparer{T}"/> comparer</param>
        /// <returns>Position of <paramref name="value"/> in <paramref name="array"/> if such is exist based on <paramref name="comparer"/></returns>
        public static int? BinarySearch<T>(T[] array, T value, int startIndex, int count, IComparer<T> comparer)
        {
            CheckInputArray(array, value);

            return Search(array, value, 0, array.Length, comparer.Compare);
        }

        /// <summary>
        /// Method that returns position of <paramref name="value"/> in <paramref name="array"/> if such is exist based on <paramref name="comparison"/>
        /// </summary>
        /// <typeparam name="T">Type of input data</typeparam>
        /// <param name="array">Needed array</param>
        /// <param name="value">Needed value to search for</param>
        /// <param name="startIndex">Beginning of starting searching</param>
        /// <param name="count">Number of elements of the array for searching in</param>
        /// <param name="comparison"><see cref="Comparison{T}"/> comparer</param>
        /// <returns>Position of <paramref name="value"/> in <paramref name="array"/> if such is exist based on <paramref name="comparison"/></returns>
        public static int? Search<T>(T[] array, T value, int startIndex, int count, Comparison<T> comparison)
        {
            if (comparison == null)
                comparison = Comparer<T>.Default.Compare;

            int leftIndex = startIndex;
            int rightIndex = startIndex + count - 1;
            int middleIndex;

            while (leftIndex <= rightIndex)
            {
                middleIndex = (leftIndex + rightIndex) >> 1;

                if (comparison(array[middleIndex], value) == 0)
                {
                    return middleIndex;
                }

                if (comparison(array[middleIndex], value) < 0)
                {
                    leftIndex = middleIndex + 1;
                }
                else
                {
                    rightIndex = middleIndex - 1;
                }
            }

            return null;
        }

        private static void CheckInputArray<T>(T[] array, T value)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null or empty");

            if (ReferenceEquals(value, null))
                throw new ArgumentNullException($"{nameof(value)} can't be equal to null");
        }
    }
}
