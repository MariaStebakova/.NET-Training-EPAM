using System;
using System.Collections.Generic;
using System.Numerics;

namespace FibonacciLibrary
{
    /// <summary>
    /// Class providing logic for generating sequence of Fibonacci numbers
    /// </summary>
    public class Fibonacci
    {
        /// <summary>
        /// Generates the unput count of Fibonacci numbers
        /// </summary>
        /// <param name="numbersCount">The number of needed Fibonacci numbers to be generated</param>
        /// <returns>Sequence of Fibonacci numbers</returns>
        /// <exception cref="ArgumentException">Throws if <see cref="numbersCount"/> is less than 1</exception>
        public static IEnumerable<BigInteger> GenerateNumbers(int numbersCount)
        {
            if (numbersCount <= 0)
                throw new ArgumentException($"{nameof(numbersCount)} can't be less than 1");

            return GenerateFibonacciNumbers(numbersCount);
        }

        private static IEnumerable<BigInteger> GenerateFibonacciNumbers(int count)
        {
            BigInteger firstNumber = 0, secondNumber = 1, sum;
            for (int i = count; i > 0; i--)
            {
                yield return firstNumber;
                sum = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = sum;
            }
        }
    }
}
