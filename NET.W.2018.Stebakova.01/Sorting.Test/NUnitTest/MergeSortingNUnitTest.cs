using System;
using NUnit.Framework;

namespace Sorting.Test.NUnitTest
{
    [TestFixture]
    public class MergeSortingNUnitTest
    {
        [TestCase(new int[] { 45, -2, 9, 60, 15, 1 }, ExpectedResult = new int[] { -2, 1, 9, 15, 45, 60 })]
        [TestCase(new int[] { 89, 7, 54 }, ExpectedResult = new int[] { 7, 54, 89 })]
        public int[] MergeSort_SmallArray(int[] array)
        {
            MergeSorting.MergeSort(array);
            return array;
        }

        [Test]
        public void MergeSort_WithNullArray()
        {
            Assert.Throws<ArgumentNullException>(() => MergeSorting.MergeSort(null));
        }
    }
}
