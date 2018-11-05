using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayLibrary
{
    public static class JaggedArraySortDelegateOnInterface
    {
        /// <summary>
        /// Static method for sorting jagged arrays in different ways using interface
        /// </summary>
        /// <param name="jaggedArray">Jagged array for sorting</param>
        /// <param name="comparer">Type of comparer</param>
        /// <exception cref="ArgumentNullException">Thrown if <param name="jaggedArray"/> or <param name="comparer"/> is equal to null</exception>
        /// <exception cref="ArgumentException">Thrown if <param name="jaggedArray"/> is empty</exception>
        private static void Sort(int[][] jaggedArray, IComparer<int[]> comparer)
        {
            CheckInputArguments(jaggedArray, comparer);

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = i + 1; j < jaggedArray.Length; j++)
                {
                    if (comparer.Compare(jaggedArray[i], jaggedArray[j]) > 0)
                    {
                        Swap(ref jaggedArray[i], ref jaggedArray[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Static method for sorting jagged arrays in different ways using delegate
        /// </summary>
        /// <param name="jaggedArray">Jagged array for sorting</param>
        /// <param name="comparison">Delegate representing method to compare</param>
        /// <exception cref="ArgumentNullException">Thrown if <param name="jaggedArray"/> or <param name="comparison"/> is equal to null</exception>
        /// <exception cref="ArgumentException">Thrown if <param name="jaggedArray"/> is empty</exception>
        public static void Sort(int[][] jaggedArray, Comparison<int[]> comparison)
        {
            CheckInputArguments(jaggedArray, comparison);

            Sort(jaggedArray, new ComparisonAdapter(comparison));
        }

        private class ComparisonAdapter: IComparer<int[]>
        {
            private readonly Comparison<int[]> _comparer;

            public ComparisonAdapter(Comparison<int[]> comparer)
            {
                _comparer = comparer;
            }

            public int Compare(int[] x, int[] y) => _comparer(x, y);
        }

        private static void Swap(ref int[] array1, ref int[] array2)
        {
            int[] temp = array1;
            array1 = array2;
            array2 = temp;
        }

        private static void CheckInputArguments(int[][] array, IComparer<int[]> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} can't be equal to null.");
            }

            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty.");
            }
        }

        private static void CheckInputArguments(int[][] array, Comparison<int[]> comparison)
        {
            if (comparison == null)
            {
                throw new ArgumentNullException($"{nameof(comparison)} can't be equal to null.");
            }

            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty.");
            }
        }
    }
}
