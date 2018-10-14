namespace BitOperation
{
    using System;

    /// <summary>
    /// Static class for inserting bits.
    /// </summary>
    public static class BitInserter
    {
        /// <summary>
        /// The highest count of bits in the integer number.
        /// </summary>
        private const int NumberLength = 31;

        /// <summary>
        /// Static method that provides inserting part of one integer number to another.
        /// </summary>
        /// <param name="firstNumber">The receiving integer value.</param>
        /// <param name="secondNumber">The inserting integer value.</param>
        /// <param name="firstIndex">Right border of inserting part.</param>
        /// <param name="secondIndex">Left border of inserting part.</param>
        /// <returns>Integer value as the result of insertion.</returns>
        public static int InsertNumber(int firstNumber, int secondNumber, int firstIndex, int secondIndex)
        {
            if (firstIndex > secondIndex)
            {
                throw new ArgumentOutOfRangeException("Second index must be more than second index");
            }

            if (secondIndex < 0 || firstIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Indexes must be positive numbers");
            }

            if (firstIndex > NumberLength || secondIndex > NumberLength)
            {
                throw new ArgumentOutOfRangeException("Indexes can't be more than 31");
            }

            return BitsInsertion(firstNumber, secondNumber, firstIndex, secondIndex);
        }

        /// <summary>
        /// Static private method that provides inserting part of one integer number to another.
        /// </summary>
        /// <param name="firstNumber">The receiving integer value.</param>
        /// <param name="secondNumber">The inserting integer value.</param>
        /// <param name="firstIndex">Right border of inserting part.</param>
        /// <param name="secondIndex">Left border of inserting part.</param>
        /// <returns>Integer value as the result of insertion.</returns>
        private static int BitsInsertion(int firstNumber, int secondNumber, int firstIndex, int secondIndex)
        {
            int insertionPartLength = secondIndex - firstIndex + 1;

            int mask = (int.MaxValue >> (NumberLength - insertionPartLength)) << firstIndex;

            firstNumber = ~mask & firstNumber;
            secondNumber = mask & (secondNumber << firstIndex);

            int resultNumber = firstNumber | secondNumber;
            return resultNumber;
        }
    }
}
