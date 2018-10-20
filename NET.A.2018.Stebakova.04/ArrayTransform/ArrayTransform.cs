namespace Operations
{
    using System;
    using System.Text;

    /// <summary>
    /// Static class for transforming the double array into its verbal representation.
    /// </summary>
    public static class ArrayTransform
    {
        /// <summary>
        /// Public method for transforming the double array into its verbal representation.
        /// </summary>
        /// <param name="array">Array of double numbers.</param>
        /// <returns>Array of strings.</returns>
        /// <exception cref="ArgumentNullException">Is thrown if the <param name="array"/> is equal to null.</exception>
        /// <exception cref="ArgumentException">Is thrown if the <param name="array"/> is empty.</exception>
        public static string[] TransformToWords(double[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty");
            }

            return WordTransfrom(array);
        }

        /// <summary>
        /// Private realization of the TransformToWords algorithm.
        /// </summary>
        /// <param name="doubles">Array of double numbers.</param>
        /// <returns>Array of strings.</returns>
        private static string[] WordTransfrom(double[] doubles)
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            string[] resWordArray = new string[doubles.Length];
            StringBuilder words = new StringBuilder();
            StringBuilder stringNum = new StringBuilder();
            int count = 0;

            for (int i = 0; i < doubles.Length; i++)
            {
                stringNum.Append(Convert.ToString(doubles[i]));

                for (int k = 0; k<stringNum.Length; k++)
                {
                    if (stringNum[k] == '-')
                    {
                        words.Append("minus ");
                    }

                    if (stringNum[k] == ',')
                    {
                        words.Append("point ");
                    }
                        
                    for (int j = 0; j < digits.Length; j++)
                    {
                        string ch = j.ToString();
                        if (stringNum[k] == ch[0])
                        {
                            words.Append(digits[j] + " ");
                            break;
                        }        
                    }
                }

                words.Remove(words.Length - 1, 1);
                resWordArray[count] = words.ToString();
                count++;
                words.Clear();
                stringNum.Clear();
            }

            return resWordArray;
        }
    }
}
