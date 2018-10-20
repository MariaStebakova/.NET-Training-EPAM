using NUnit.Framework;
using Operations;

namespace ArrayTransform.Tests
{
    [TestFixture]
    public class GCDFinderTests
    {
        [TestCase(100, 45, ExpectedResult = 5)]
        [TestCase(24, 42, ExpectedResult = 6)]
        [TestCase(2, 4, 8, ExpectedResult = 2)]
        [TestCase(24654, 25473, 954, ExpectedResult = 3)]
        [TestCase(3, 9, 21, 36, ExpectedResult = 3)]
        public int EuclidGcdAlgorithmTest(params int[] numbers)
            => GCDFinder.EuclidGcdAlgorithm(numbers);

        [TestCase(100, 45, ExpectedResult = 5)]
        [TestCase(24, 42, ExpectedResult = 6)]
        [TestCase(2, 4, 8, ExpectedResult = 2)]
        [TestCase(24654, 25473, 954, ExpectedResult = 3)]
        [TestCase(3, 9, 21, 36, ExpectedResult = 3)]
        public int BinaryGcdAlgorithmTest(params int[] numbers)
            => GCDFinder.BinaryGcdAlgorithm(numbers);
    }
}
