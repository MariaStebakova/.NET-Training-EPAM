namespace Operations
{
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Static class that implements extension of System.Double.
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Private field for storage of the size of long.
        /// </summary>
        private static int bitsInLong = 64;

        /// <summary>
        /// Public class for converting double value to its binary representation according standard IEEE754.
        /// </summary>
        /// <param name="number">Double value for converting.</param>
        /// <returns>String of bits.</returns>
        public static string ConvertToIEEE(double number)
        {
            DoubleToLong doubleInLong = new DoubleToLong(number);
            long bits = doubleInLong.Long;
            StringBuilder resultString = new StringBuilder();
            for (int i = 0; i < bitsInLong; i++)
            {
                if ((bits & 1) == 1)
                {
                    resultString.Insert(0, "1");
                }
                else
                {
                    resultString.Insert(0, "0");
                }

                bits >>= 1;
            }

            return resultString.ToString();
        }

        /// <summary>
        /// Private struct that helps with translating double to long.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLong
        {
            [FieldOffset(0)]
            public long Long;

            [FieldOffset(0)]
            private readonly double _double;

            public DoubleToLong(double value) : this()
            {
                _double = value;
            }
        }
    }
}
