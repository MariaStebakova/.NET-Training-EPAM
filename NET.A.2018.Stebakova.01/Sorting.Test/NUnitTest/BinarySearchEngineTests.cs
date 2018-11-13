using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace Sorting.Test.NUnitTest
{
    [TestFixture]
    public class BinarySearchEngineTests
    {
        [TestCase(new int[] {1, 3, 5, 7, 9, 10, 15}, 5, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 3, 5, 7, 9, 10, 15 }, 15, ExpectedResult = 6)]
        [TestCase(new int[] { 1, 3, 5, 7, 9, 10, 15 }, 2, ExpectedResult = null)]
        public int? BinarySearchTest(int[] array, int value)
            => BinarySearchEngine.BinarySearch(array, value);

        [Test]
        public void BinarySearchTest_WithNullArray()
            => Assert.Throws<ArgumentNullException>(() => BinarySearchEngine.BinarySearch(null, 4));

        [Test]
        public void BinarySearchTest_WithNullValue()
            => Assert.Throws<ArgumentNullException>(() => BinarySearchEngine.BinarySearch(new string[] {"1", "2", "4"}, null));
    }
}
