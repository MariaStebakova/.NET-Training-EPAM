using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray.Tests.Comparators
{
    public class MinElementComparator
    {
        /// <summary>
        /// Class that describes comparer for increasing minimum elements of two arrays
        /// </summary>
        public class MinElementIncreaseComparer : IComparer<int[]>
        {
            /// <summary>
            /// Method for comparing the minimum elements of two arrays by increasing
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

                if (FindMin(firstArray) < FindMin(secondArray))
                {
                    return -1;
                }

                return 1;
            }

            private int FindMin(int[] array)
            {
                int minValue = int.MaxValue;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < minValue && array[i] != int.MaxValue)
                    {
                        minValue = array[i];
                    }
                }

                return minValue;
            }
        }

        /// <summary>
        /// Class that describes comparer for decreasing minimum elements of two arrays
        /// </summary>
        public class MinElementDecreaseComparer : IComparer<int[]>
        {
            /// <summary>
            /// Method for comparing the minimum elements of two arrays by decreasing
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

                if (FindMin(firstArray) > FindMin(secondArray))
                {
                    return -1;
                }

                return 1;
            }

            private int FindMin(int[] array)
            {
                int minValue = int.MaxValue;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < minValue && array[i] != int.MaxValue)
                    {
                        minValue = array[i];
                    }
                }

                return minValue;
            }
        }
    }
}
