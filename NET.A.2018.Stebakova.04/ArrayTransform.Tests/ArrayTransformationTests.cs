using System;
using NUnit.Framework;

namespace Operations.Tests
{
    [TestFixture]
    public class ArrayTransformationTests
    {
        [TestCase(new double[] {-23.809, 0.295, 15.17},
            ExpectedResult = new string[]
                {"minus two three point eight zero nine", "zero point two nine five", "one five point one seven"})]
        [TestCase(new double[] { 0.321, 65.7 },
            ExpectedResult = new string[]
                {"zero point three two one", "six five point seven"})]
        public string[] TransformToWordsTest_WithCorrectArrays(double[] doubles)
            => ArrayTransform.TransformToWords(doubles);

        [Test]
        public void TransformToWordsTest_WithNullArray()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayTransform.TransformToWords(null));
        }

        [Test]
        public void TransformToWordsTest_WithEmptyArray()
        {
            Assert.Throws<ArgumentException>(() => ArrayTransform.TransformToWords(new double[] {}));
        }

    }
}
