using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitOperation.Test
{
    [TestClass]
    public class InsertNumberTest
    {
        [TestMethod]
        public void InsertNumberTest_WithParameters_15_15_0_0()
        {
            int expected = 15;
            int actual = BitInserter.InsertNumber(15, 15, 0, 0);

            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void InsertNumberTest_WithParameters_8_15_0_0()
        {
            int expected = 9;
            int actual = BitInserter.InsertNumber(8, 15, 0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumberTest_WithParameters_8_15_3_8()
        {
            int expected = 120;
            int actual = BitInserter.InsertNumber(8, 15, 3, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumberTest_WithParameters_78_86_1_4()
        {
            int expected = 76;
            int actual = BitInserter.InsertNumber(78, 86, 1, 4);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumberTest_IndexIsNegative()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => BitInserter.InsertNumber(78, 86, -1, 4));
        }


        [TestMethod]
        public void InsertNumberTest_FirstIndMoreThanSecondInd()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => BitInserter.InsertNumber(78, 86, 4, 1));
        }

        [TestMethod]
        public void InsertNumberTest_IndexMoreThan31()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => BitInserter.InsertNumber(78, 86, 32, 4));
        }
    }
}
