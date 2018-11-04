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
    public class SortInterfaceOnDelegateTest
    {
        [Test]
        public void SortInterfaceOnDelegate_ElementsSumComparerIncreasing()
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

            SortInterfaceOnDelegate.Sort(array, new ElementsSumComparator.ElementsSumIncreaseComparer(), JaggedArraySort.Sort);

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void SortInterfaceOnDelegate_ElementsSumComparerDecreasing()
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

            SortInterfaceOnDelegate.Sort(array, new ElementsSumComparator.ElementsSumDecreaseComparer(), JaggedArraySort.Sort);

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void SortInterfaceOnDelegate_MaxElementComparerIncreasing()
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

            SortInterfaceOnDelegate.Sort(array, new MaxElementComparator.MaxElementIncreaseComparer(), JaggedArraySort.Sort);

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void SortInterfaceOnDelegate_MaxElementComparerDecreasing()
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

            SortInterfaceOnDelegate.Sort(array, new MaxElementComparator.MaxElementDecreaseComparer(), JaggedArraySort.Sort);

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void SortInterfaceOnDelegate_MinElementComparerIncreasing()
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

            SortInterfaceOnDelegate.Sort(array, new MinElementComparator.MinElementIncreaseComparer(), JaggedArraySort.Sort);

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void SortInterfaceOnDelegate_MinElementComparerDecreasing()
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

            SortInterfaceOnDelegate.Sort(array, new MinElementComparator.MinElementDecreaseComparer(), JaggedArraySort.Sort);

            CollectionAssert.AreEqual(expected, array);
        }
    }
}
