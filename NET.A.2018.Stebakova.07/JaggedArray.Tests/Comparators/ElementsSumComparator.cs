﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray.Tests.Comparators
{
    public class ElementsSumComparator
    {
        /// <summary>
        /// Class that describes comparer for increasing elements sum of two arrays
        /// </summary>
        public class ElementsSumIncreaseComparer : IComparer<int[]>
        {
            /// <summary>
            /// Method for comparing the sum of two arrays by increasing
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

                if (FindSum(firstArray) <= FindSum(secondArray))
                {
                    return -1;
                }

                return 1;
            }

            private int FindSum(int[] array)
            {
                int result = 0;

                foreach (int a in array)
                    result += a;

                return result;
            }
        }

        /// <summary>
        /// Class that describes comparer for decreasing elements sum of two arrays
        /// </summary>
        public class ElementsSumDecreaseComparer : IComparer<int[]>
        {
            /// <summary>
            /// Method for comparing the sum of two arrays by decreasing
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

                if (FindSum(firstArray) >= FindSum(secondArray))
                {
                    return -1;
                }

                return 1;
            }

            private int FindSum(int[] array)
            {
                int result = 0;

                foreach (int a in array)
                    result += a;

                return result;
            }
        }
    }
}
