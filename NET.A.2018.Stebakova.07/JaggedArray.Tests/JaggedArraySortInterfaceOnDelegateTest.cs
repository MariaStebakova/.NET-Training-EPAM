using System;
using JaggedArrayLibrary;
using JaggedArray.Tests.Comparators;
using NUnit.Framework;

namespace JaggedArray.Tests
{
    [TestFixture]
    public class JaggedArraySortInterfaceOnDelegateTest
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

            JaggedArraySortInterfaceOnDelegate.Sort(array, new ElementsSumComparator.ElementsSumIncreaseComparer());

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

            JaggedArraySortInterfaceOnDelegate.Sort(array, new ElementsSumComparator.ElementsSumIncreaseComparer());

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

            JaggedArraySortInterfaceOnDelegate.Sort(array, new ElementsSumComparator.ElementsSumDecreaseComparer());

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

            JaggedArraySortInterfaceOnDelegate.Sort(array, new MaxElementComparator.MaxElementIncreaseComparer());

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

            JaggedArraySortInterfaceOnDelegate.Sort(array, new MaxElementComparator.MaxElementDecreaseComparer());

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

            JaggedArraySortInterfaceOnDelegate.Sort(array, new MinElementComparator.MinElementIncreaseComparer());

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

            JaggedArraySortInterfaceOnDelegate.Sort(array, new MinElementComparator.MinElementDecreaseComparer());

            CollectionAssert.AreEqual(expected, array);
        }
    }
}
