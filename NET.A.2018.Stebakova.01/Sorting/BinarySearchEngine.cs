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
    public class BinarySearchEngine<T>
    {
        /// <summary>
        /// Method that returns position of <paramref name="element"/> in <paramref name="array"/> if such is exist.
        /// </summary>
        /// <param name="array">Needed array.</param>
        /// <param name="value">Needed value to search for.</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="array"/> or <paramref name="element"/> is equal to null. </exception>
        /// <returns>Position of <paramref name="value"/> in <paramref name="array"/> if such is exist</returns>
        public static int? BinarySearch(T[] array, T value)
        {
            CheckInputArray(array, value);

            return Search(array, value, null);
        }

        /// <summary>
        /// Method that returns position of <paramref name="value"/> in <paramref name="array"/> if such is exist based on <paramref name="comparer"/>
        /// </summary>
        /// <param name="array">Needed array</param>
        /// <param name="value">Needed value to search for</param>
        /// <param name="comparer"><see cref="IComparer{T}"/> comparer</param>
        /// <exception cref="ArgumentNullException">Throws if <paramref name="array"/> or <paramref name="element"/> is equal to null. </exception>
        /// <returns>Position of <paramref name="value"/> in <paramref name="array"/> if such is exist based on <paramref name="comparer"/></returns>
        public static int? BinarySearch(T[] array, T value, IComparer<T> comparer)
        {
            CheckInputArray(array, value);

            return Search(array, value, comparer.Compare);
        }

        private static int? Search(T[] array, T value, Comparison<T> comparison)
        {
            if (comparison == null)
                comparison = Comparer<T>.Default.Compare;

            int leftIndex = 0;
            int rightIndex = array.Length - 1;
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

        private static void CheckInputArray(T[] array, T value)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null or empty");

            if (ReferenceEquals(value, null))
                throw new ArgumentNullException($"{nameof(value)} can't be equal to null");
        }
    }
}
