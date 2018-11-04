using System;
using System.Text;
using System.Collections.Generic;
using JaggedArray.Tests.Comparators;
using JaggedArrayLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using CollectionAssert = Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert;

namespace JaggedArray.Tests
{
    [TestFixture]
    public class SortDelegateOnInterfaceTest
    {
        [Test]
        public void SortDelegateOnInterface_ElementsSumComparerIncreasing()
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

            SortDelegateOnInterface.Sort(array, new ElementsSumComparator.ElementsSumIncreaseComparer());

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void SortDelegateOnInterface_ElementsSumComparerDecreasing()
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

            SortDelegateOnInterface.Sort(array, new ElementsSumComparator.ElementsSumDecreaseComparer());

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void SortDelegateOnInterface_MaxElementComparerIncreasing()
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

            SortDelegateOnInterface.Sort(array, new MaxElementComparator.MaxElementIncreaseComparer());

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void SortDelegateOnInterface_MaxElementComparerDecreasing()
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

            SortDelegateOnInterface.Sort(array, new MaxElementComparator.MaxElementDecreaseComparer());

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void SortDelegateOnInterface_MinElementComparerIncreasing()
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

            SortDelegateOnInterface.Sort(array, new MinElementComparator.MinElementIncreaseComparer());

            CollectionAssert.AreEqual(expected, array);
        }

        [Test]
        public void SortDelegateOnInterface_MinElementComparerDecreasing()
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

            SortDelegateOnInterface.Sort(array, new MinElementComparator.MinElementDecreaseComparer());

            CollectionAssert.AreEqual(expected, array);
        }
    }
}
