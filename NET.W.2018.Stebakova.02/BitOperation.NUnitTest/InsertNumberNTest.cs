using System;
using NUnit.Framework;

namespace BitOperation.NUnitTest
{
    [TestFixture]
    public class InsertNumberNTest
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(78, 86, 1, 4, ExpectedResult = 76)]
        public int InsertNumberNTest_WithParameters(int firstNum, int secondNum, int firstInd, int secondInd)
            => BitInserter.InsertNumber(firstNum, secondNum, firstInd, secondInd);

        [Test]
        public void InsertNumberNTest_FirstIndMoreThanSecondInd()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BitInserter.InsertNumber(8, 15, 2, 0));
        }

        [Test]
        public void InsertNumberNTest_IndexIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BitInserter.InsertNumber(8, 15, -1, 0));
        }

        [Test]
        public void InsertNumberNTest_IndexMoreThan31()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BitInserter.InsertNumber(8, 15, 32, 0));
        }
    }
}
