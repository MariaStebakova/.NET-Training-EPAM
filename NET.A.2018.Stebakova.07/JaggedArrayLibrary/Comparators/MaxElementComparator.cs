using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayLibrary.Comparators
{
    public class MaxElementComparator
    {
        /// <summary>
        /// Class that describes comparer for increasing maximum elements of two arrays
        /// </summary>
        public class MaxElementIncreaseComparer : IComparer<int[]>
        {
            /// <summary>
            /// Method for comparing the maximum elements of two arrays by increasing
            /// </summary>
            /// <param name="firstArray">First array to compare</param>
            /// <param name="secondArray">SecondArray to compare</param>
            /// <returns>Integer value as a result of comparison</returns>
            public int Compare(int[] firstArray, int[] secondArray)
            {
                if (firstArray == null)
                {
                    return 1;
                }

                if (secondArray == null)
                {
                    return -1;
                }

                if (firstArray.Max() < secondArray.Max())
                {
                    return -1;
                }

                return 1;
            }
        }

        /// <summary>
        /// Class that describes comparer for decreasing maximum elements of two arrays
        /// </summary>
        public class MaxElementDecreaseComparer : IComparer<int[]>
        {
            /// <summary>
            /// Method for comparing the maximum elements of two arrays by decreasing
            /// </summary>
            /// <param name="firstArray">First array to compare</param>
            /// <param name="secondArray">SecondArray to compare</param>
            /// <returns>Integer value as a result of comparison</returns>
            public int Compare(int[] firstArray, int[] secondArray)
            {
                if (firstArray == null)
                {
                    return -1;
                }

                if (secondArray == null)
                {
                    return 1;
                }

                if (firstArray.Max() > secondArray.Max())
                {
                    return -1;
                }

                return 1;
            }
        }
    }
}
