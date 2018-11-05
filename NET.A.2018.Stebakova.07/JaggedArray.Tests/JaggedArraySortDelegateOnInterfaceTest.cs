using System;
using System.Text;
using System.Collections.Generic;
using JaggedArray.Tests.Comparators;
using JaggedArrayLibrary;
using NUnit.Framework;
using CollectionAssert = Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert;

namespace JaggedArray.Tests
{
    [TestFixture]
    public class JaggedArraySortDelegateOnInterfaceTest
    {
        [Test]
        public void JaggedArraySort_ElementsSumComparerIncreasing()
        {
            int[][] array =
            {
                new int[] { 9, 5, 4, 3, 2 },
                new int[] { 1, 6, 5 },
                new int[] { 4, 3, 0, 2 },
                new int[] { 1, 1 }
            };

            int[][] expected =
            {
                new int[] { 1, 1 },
                new int[] { 4, 3, 0, 2 },
                new int[] { 1, 6, 5 },
                new int[] { 9, 5, 4, 3, 2 }
            };

            int Comparison(int[] lhs, int[] rhs) =>
                new ElementsSumComparator.ElementsSumIncreaseComparer().Compare(lhs, rhs);

            JaggedArraySortDelegateOnInterface.Sort(array, Comparison);

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void JaggedArraySort_ElementsSumComparerIncreasing_WithNull()
        {
            int[][] array =
            {
                new int[] { 9, 5, 4, 3, 2 },
                new int[] { 1, 6, 5 },
                new int[] { 4, 3, 0, 2 },
                null
            };

            int[][] expected =
            {
                new int[] { 4, 3, 0, 2 },
                new int[] { 1, 6, 5 },
                new int[] { 9, 5, 4, 3, 2 },
                null
            };

            int Comparison(int[] lhs, int[] rhs) =>
                new ElementsSumComparator.ElementsSumIncreaseComparer().Compare(lhs, rhs);

            JaggedArraySortDelegateOnInterface.Sort(array, Comparison);

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void JaggedArraySort_ElementsSumComparerDecreasing()
        {
            int[][] array =
            {
                new int[] { 9, 5, 4, 3, 2 },
                new int[] { 1, 6, 5 },
                new int[] { 4, 3, 0, 2 },
                new int[] { 1, 1 }
            };

            int[][] expected =
            {
                new int[] { 9, 5, 4, 3, 2 },
                new int[] { 1, 6, 5 },
                new int[] { 4, 3, 0, 2 },
                new int[] { 1, 1 }
            };

            int Comparison(int[] lhs, int[] rhs) =>
                new ElementsSumComparator.ElementsSumDecreaseComparer().Compare(lhs, rhs);

            JaggedArraySortDelegateOnInterface.Sort(array, Comparison);

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void JaggedArraySort_MaxElementComparerIncreasing()
        {
            int[][] array =
            {
                new int[] { 9, 5, 4, 3, 2 },
                new int[] { 1, 6, 5 },
                new int[] { 4, 3, 0, 2 },
                new int[] { 1, 1 }
            };

            int[][] expected =
            {
                new int[] { 1, 1 },
                new int[] { 4, 3, 0, 2 },
                new int[] { 1, 6, 5 },
                new int[] { 9, 5, 4, 3, 2 }
            };

            int Comparison(int[] lhs, int[] rhs) =>
                new MaxElementComparator.MaxElementIncreaseComparer().Compare(lhs, rhs);

            JaggedArraySortDelegateOnInterface.Sort(array, Comparison);

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void JaggedArraySort_MaxElementComparerDecreasing()
        {
            int[][] array =
            {
                new int[] { 9, 5, 4, 3, 2 },
                new int[] { 1, 6, 5 },
                new int[] { 4, 3, 0, 2 },
                new int[] { 1, 1 }
            };

            int[][] expected =
            {
                new int[] { 9, 5, 4, 3, 2 },
                new int[] { 1, 6, 5 },
                new int[] { 4, 3, 0, 2 },
                new int[] { 1, 1 }
            };

            int Comparison(int[] lhs, int[] rhs) =>
                new MaxElementComparator.MaxElementDecreaseComparer().Compare(lhs, rhs);

            JaggedArraySortDelegateOnInterface.Sort(array, Comparison);

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void JaggedArraySort_MinElementComparerIncreasing()
        {
            int[][] array =
            {
                new int[] { 9, 5, 4, 3, 2 },
                new int[] { 1, 6, 5 },
                new int[] { 4, 3, 0, 2 },
                new int[] { 1, 1 }
            };

            int[][] expected =
            {
                new int[] { 4, 3, 0, 2 },
                new int[] { 1, 1 },
                new int[] { 1, 6, 5 },
                new int[] { 9, 5, 4, 3, 2 }
            };

            int Comparison(int[] lhs, int[] rhs) =>
                new MinElementComparator.MinElementIncreaseComparer().Compare(lhs, rhs);

            JaggedArraySortDelegateOnInterface.Sort(array, Comparison);

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void JaggedArraySort_MinElementComparerDecreasing()
        {
            int[][] array =
            {
                new int[] { 9, 5, 4, 3, 2 },
                new int[] { 1, 6, 5 },
                new int[] { 4, 3, 0, 2 },
                new int[] { 1, 1 }
            };

            int[][] expected =
            {
                new int[] { 9, 5, 4, 3, 2 },
                new int[] { 1, 1 },
                new int[] { 1, 6, 5 },
                new int[] { 4, 3, 0, 2 }
            };

            int Comparison(int[] lhs, int[] rhs) =>
                new MinElementComparator.MinElementDecreaseComparer().Compare(lhs, rhs);

            JaggedArraySortDelegateOnInterface.Sort(array, Comparison);

            CollectionAssert.AreEqual(expected, array);
        }
    }
}
