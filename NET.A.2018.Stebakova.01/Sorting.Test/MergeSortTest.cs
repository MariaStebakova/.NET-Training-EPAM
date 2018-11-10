using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorting.Test
{
    [TestClass]
    public class MergeSortTest
    {
        [TestMethod]
        public void MergeSort_SmallArray()
        {
            int[] arr = { 6, 7, 8, 9, 1, 6, 4, 3, 2, 5, 9 };
            int[] expectedArray = { 1, 2, 3, 4, 5, 6, 6, 7, 8, 9, 9 };
            var comparison = Comparer<int>.Default;
            Sorting.MergeSort(arr, comparison.Compare);
            CollectionAssert.AreEqual(expectedArray, arr);
        }

        [TestMethod]
        public void MergeSort_LargeArray()
        {
            int length = 100000;
            int[] arr = new int[length];

            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                arr[i] = random.Next();
            }

            int[] expectedArray = new int[length];
            Array.Copy(arr, expectedArray, length);
            Array.Sort(expectedArray);

            var comparison = Comparer<int>.Default;
            Sorting.MergeSort(arr, comparison.Compare);
            CollectionAssert.AreEqual(expectedArray, arr);
        }

        [TestMethod]
        public void MergeSort_WithNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Sorting.MergeSort<int>(null));
        }


        [TestMethod]
        public void MergeSort_ArrayWithNullLength()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Sorting.MergeSort(new int[] { }));
        }
    }
}
