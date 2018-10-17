using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticOperations
{
    /// <summary>
    /// Class that allows to find next big Int32 value. 
    /// </summary>
    public static class NumberSearcher
    {
        /// <summary>
        /// Public method that finds the next Int32 number that contains digits of <param name="number"/>.
        /// </summary>
        /// <param name="number">Number which digits should be used to find the result.</param>
        /// <exception cref="ArgumentException">Throws when the number is less than 0.</exception>
        /// <returns>Int32 value that bigger than <param name="number"/> and contains <param name="number"/> digits.</returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} must be positive!");
            }

            if (number <= 11)
            {
                return -1;
            }

            if (number.Equals(int.MaxValue))
            {
                return number;
            }

            return FindNextNumber(number);
        }

        /// <summary>
        /// Private realization of "FindNextBiggerNumber()" method.
        /// </summary>
        /// <param name="number">Number which digits should be used to find the result.</param>
        /// <returns>Int32 value that bigger than <param name="number"/> and contains <param name="number"/> digits.</returns>
        private static int FindNextNumber(int number)
        {
            int[] digits = IntToArray(number);
            int index = FindIndex(digits);

            if (index == -1)
            {
                return -1;
            }
            
            Array.Sort(digits, index, digits.Length - index);

            return ArrayToInt(digits);
        }

        /// <summary>
        /// Convert Int32 value to int array.
        /// </summary>
        /// <param name="number">Number which digits should be converted to int[] array.</param>
        /// <returns>int array</returns>
        private static int[] IntToArray(int number)
        {
            int arrayLength = FindNumberCapacity(number);
            int[] array = new int[arrayLength];
            int i = 0;
            while (number > 0)
            {
                array[i] = number % 10;
                i++;
                number /= 10;
            }
            Array.Reverse(array);
            return array;
        }

        /// <summary>
        /// Convert array to int.
        /// </summary>
        /// <param name="array">int[] which should be used to get int value.</param>
        /// <exception cref="OverflowException">Throws when the int[] if bigger than int.MaxValue</exception>
        /// <returns>int value.</returns>
        private static int ArrayToInt(int[] array)
        {
            int result = 0;
            try
            {
                result = int.Parse(string.Join(string.Empty, array));
                return result;
            }
            catch (OverflowException e)
            {
                throw new OverflowException(e.Message);
            }
        }

        /// <summary>
        /// Gets the capacity of <param name="num"/> value.
        /// </summary>
        /// <param name="num">Number which value should be used to find int[] length.</param>
        /// <returns>Number length.</returns>
        private static int FindNumberCapacity(int num)
        {
            int capacity = 0;
            while (num > 0)
            {
                capacity++;
                num /= 10;
            }

            return capacity;
        }

        /// <summary>
        /// Find position in <param name="array"/> array from which  we should start transforming algorithm.
        /// </summary>
        /// <param name="array">int[] array which should be used to find the needed position.</param>
        /// <returns>Index of <param name="array"/> array.</returns>
        private static int FindIndex(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i - 1] < array[i])
                {
                    Swap(ref array[i], ref array[i - 1]);
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Swap values of two elements.
        /// </summary>
        /// <param name="a">First element need to swap.</param>
        /// <param name="b">Second element need to swap.</param>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
