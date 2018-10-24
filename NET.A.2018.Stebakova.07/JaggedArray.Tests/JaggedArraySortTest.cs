using System;
using JaggedArrayLibrary;
using JaggedArrayLibrary.Comparators;
using NUnit.Framework;

namespace JaggedArray.Tests
{
    [TestFixture]
    public class JaggedArraySortTest
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

            JaggedArraySort.Sort(array, new ElementsSumComparator.ElementsSumIncreaseComparer());

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

            JaggedArraySort.Sort(array, new ElementsSumComparator.ElementsSumDecreaseComparer());

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

            JaggedArraySort.Sort(array, new MaxElementComparator.MaxElementIncreaseComparer());

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

            JaggedArraySort.Sort(array, new MaxElementComparator.MaxElementDecreaseComparer());

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

            JaggedArraySort.Sort(array, new MinElementComparator.MinElementIncreaseComparer());

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

            JaggedArraySort.Sort(array, new MinElementComparator.MinElementDecreaseComparer());

            CollectionAssert.AreEqual(expected, array);
        }
    }
}
