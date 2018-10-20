namespace Operations
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Static class for finding GCD of two and more numbers by different algorithms.
    /// </summary>
    public static class GCDFinder
    {
        /// <summary>
        /// Public method for finding GCD of two and more numbers by classic Euclid algorithm
        /// </summary>
        /// <param name="values">Array of numbers for finding GCD</param>
        /// <returns>GCD of input numbers</returns>
        public static int EuclidGcdAlgorithm(params int[] values)
        {
            CheckInputData(values);

            int gcd = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                gcd = EuclidGcd(gcd, values[i]);
            }

            return gcd;
        }

        /// <summary>
        /// Overloaded EuclidGcdAlgorithm with method execution time checking 
        /// </summary>
        /// <param name="time">Out parameter of the method execution time</param>
        /// <param name="values">Array of numbers for finding GCD</param>
        /// <returns>GCD of input numbers</returns>
        public static int EuclidGcdAlgorithm(out long time, params int[] values)
        {
            CheckInputData(values);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            int gcd = EuclidGcdAlgorithm(values);

            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;

            return gcd;
        }

        /// <summary>
        /// Public method for finding GCD of two and more numbers by Binary (Stein) algorithm
        /// </summary>
        /// <param name="values">Array of numbers for finding GCD</param>
        /// <returns>GCD of input numbers</returns>
        public static int BinaryGcdAlgorithm(params int[] values)
        {
            CheckInputData(values);

            int gcd = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                gcd = BinaryGcd(gcd, values[i]);
            }

            return gcd;
        }

        /// <summary>
        /// Overloaded BinaryGcdAlgorithm with method execution time checking 
        /// </summary>
        /// <param name="time">Out parameter of the method execution time</param>
        /// <param name="values">Array of numbers for finding GCD</param>
        /// <returns>GCD of input numbers</returns>
        public static int BinaryGcdAlgorithm(out long time, params int[] values)
        {
            CheckInputData(values);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            int gcd = BinaryGcdAlgorithm(values);

            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;

            return gcd;
        }

        private static int EuclidGcd(int firstValue, int secondValue)
        {
            while (firstValue != secondValue)
            {
                if (firstValue > secondValue)
                {
                    firstValue = firstValue - secondValue;
                }
                else
                {
                    secondValue = secondValue - firstValue;
                }
            }
            return firstValue;
        }


        private static int BinaryGcd(int firstValue, int secondValue)
        {
            if (firstValue == secondValue)
                return firstValue;

            if (firstValue == 0)
                return secondValue;

            if (secondValue == 0)
                return firstValue;

            if ((~firstValue & 1) != 0)
            {
                if ((secondValue & 1) != 0)
                    return BinaryGcd(firstValue >> 1, secondValue);
                else
                    return BinaryGcd(firstValue >> 1, secondValue >> 1) << 1;
            }

            if ((~secondValue & 1) != 0)
                return BinaryGcd(firstValue, secondValue >> 1);

            if (firstValue > secondValue)
                return BinaryGcd((firstValue - secondValue) >> 1, secondValue);

            return BinaryGcd((secondValue - firstValue) >> 1, firstValue);
        }

        private static void CheckInputData(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty");
            }
        }
    }
}
