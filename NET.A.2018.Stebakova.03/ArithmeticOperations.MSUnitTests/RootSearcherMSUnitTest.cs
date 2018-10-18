using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace ArithmeticOperations.MSUnitTests
{
    [TestClass]
    public class RootSearcherMSUnitTest
    {
        private TestContext _testContext;

        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }

        }

        [TestMethod]
        [DeploymentItem("D:\\Стажировка\\EPAM\\Tasks\\.NET-Training-EPAM\\NET.W.2018.Stebakova.03\\ArithmeticOperations.MSUnitTests\\UnitTestDS.xls")]
        [DataSource("MyExcelDataSource")]
        public void FindRootTest_IsCorrect()
        {
            double number = (double)_testContext.DataRow["number"];
            int power = (int)_testContext.DataRow["power"];
            double accuracy = (double)_testContext.DataRow["accuracy"];
            double expected = (double) _testContext.DataRow["expectedResult"];

            double actual = RootSearcher.FindNthRoot(number, power, accuracy);
            Assert.AreEqual(expected,actual);
        }
    }
}
