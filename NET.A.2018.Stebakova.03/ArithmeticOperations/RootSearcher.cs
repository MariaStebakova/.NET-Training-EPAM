using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticOperations
{
    /// <summary>
    /// Class that allows to find Nth power root of double number with some accuracy.
    /// </summary>
    public static class RootSearcher
    {
        /// <summary>
        /// Public method that finds Nth root of the number.
        /// </summary>
        /// <param name="number">Number, which root we need to find.</param>
        /// <param name="power">Root degree.</param>
        /// <param name="accuracy">Accuracy of measurement.</param>
        /// <exception cref="ArgumentException">Throws when the accuracy isn't contains value in range (0,1) or power isn't positive.</exception>
        /// <returns>Nth root in form of real number.</returns>
        public static double FindNthRoot(double number, int power, double accuracy)
        {
            if (accuracy <= 0 || accuracy >= 1)
            {
                throw new ArgumentException($"{nameof(accuracy)} must contains value in range: (0, 1).");
            }

            if (power % 2 == 0 && number < 0)
            {
                throw new ArgumentException($"{nameof(number)} will get invalid value through the current operation.");
            }

            if (power <= 0)
            {
                throw new ArgumentException($"{nameof(power)} must be positive.");
            }

            if (power == 1)
            {
                return number;
            }

            return FindRoot(number, power, accuracy);
        }

        /// <summary>
        /// Private realization of FindNthRoot algorithm.
        /// </summary>
        /// <param name="number">Number, which root we need to find.</param>
        /// <param name="power">Root degree.</param>
        /// <param name="accuracy">Accuracy of measurement.</param>
        /// <returns>Nth root in form of real number.</returns>
        private static double FindRoot(double number, int power, double accuracy)
        {
            double current = number;
            double previous = 0;
            do
            {
                previous = current;
                current = 1.0 / power * ((power - 1) * current + number / Math.Pow(current, power - 1));
            } while (Math.Abs(previous - current) >= accuracy);

            return current;
        }
    }
}
