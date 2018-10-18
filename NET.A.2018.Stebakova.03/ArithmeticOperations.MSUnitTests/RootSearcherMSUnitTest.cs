using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace ArithmeticOperations.MSUnitTests
{
    [TestClass]
    public class RootSearcherMSUnitTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\UnitTestDS.csv",
             "UnitTestDS#csv", DataAccessMethod.Sequential), DeploymentItem("UnitTestDS.csv")]
        public void GetNthRoot_Test()
        {
            double number = double.Parse(TestContext.DataRow["number"].ToString());
            int power = int.Parse(TestContext.DataRow["power"].ToString());
            double accuracy = double.Parse(TestContext.DataRow["accuracy"].ToString());
            double expected = double.Parse(TestContext.DataRow["expectedResult"].ToString());
            double actual = RootSearcher.FindNthRoot(number, power, accuracy);
            Assert.AreEqual(actual, expected, accuracy);
        }

        [TestMethod]
        [DataRow(-0.01, 2, 0.0001)]
        [DataRow(0.001, -2, 0.0001)]
        [DataRow(0.01, 2, -1)]
        public void FindNthRootmethod_UncorrectData_ArgumentException(double number, int n, double eps)
        {
            Assert.ThrowsException<ArgumentException>(() => RootSearcher.FindNthRoot(number, n, eps));
        }
    }
}
