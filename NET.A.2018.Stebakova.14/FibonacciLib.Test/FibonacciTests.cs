using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using FibonacciLibrary;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace FibonacciLib.Test
{
    [TestFixture]
    public class FibonacciTests
    {
        [TestCase(4, ExpectedResult = "0, 1, 1, 2")]
        [TestCase(10, ExpectedResult = "0, 1, 1, 2, 3, 5, 8, 13, 21, 34")]
        [TestCase(15, ExpectedResult = "0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377")]
        [TestCase(18, ExpectedResult = "0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597")]
        [TestCase(41, ExpectedResult = "0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, " +
                                       "2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, " +
                                       "514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, " +
                                       "39088169, 63245986, 102334155")]
        public string GenerateNumbersTest(int count)
        {
            StringBuilder str = new StringBuilder();

            IEnumerable<BigInteger> numbers = Fibonacci.GenerateNumbers(count);
            foreach (var number in numbers)
            {
                str.Append(number);
                str.Append(", ");
            }

            str.Remove(str.Length - 2, 2);
            return str.ToString();
        }

        [Test]
        public void GenetareNumbersTest_WithException() =>
            Assert.ThrowsException<ArgumentException>(() => Fibonacci.GenerateNumbers(0));
    }
}
