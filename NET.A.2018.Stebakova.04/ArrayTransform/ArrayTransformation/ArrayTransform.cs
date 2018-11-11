using ArrayTransform.ArrayTransformation;

namespace Operations.ArrayTransformation
{
    using System;
    using System.Text;

    /// <summary>
    /// Static class for transforming the double array into its verbal or binary representation.
    /// </summary>
    public static class ArrayTransform
    {
        /// <summary>
        /// Transforms number to its string representation.
        /// </summary>
        /// <param name="number">Double number.</param>
        /// <returns>Number in string representation.</returns>
        public delegate string Transformer(double number);

        /// <summary>
        /// Public method for transforming the double array somehow.
        /// </summary>
        /// <param name="array">Array of double numbers.</param>
        /// <param name="transformer">Type of transforming.</param>
        /// <returns>Array of strings.</returns>
        /// <exception cref="ArgumentNullException">Is thrown if the <param name="array"/> is equal to null.</exception>
        /// <exception cref="ArgumentException">Is thrown if the <param name="array"/> is empty.</exception>
        public static string[] Transform(double[] array, ITransformer transformer)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty");
            }

            string[] resWordArray = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                resWordArray[i] += transformer.Transform(array[i]);
            }

            return resWordArray;
        }

        /// <summary>
        /// Public method for transforming the double array somehow.
        /// </summary>
        /// <param name="array">Array of double numbers.</param>
        /// <param name="transformer">Method performing transforming.</param>
        /// <returns>Array of strings.</returns>
        /// <exception cref="ArgumentNullException">Is thrown if the <param name="array"/> is equal to null.</exception>
        /// <exception cref="ArgumentException">Is thrown if the <param name="array"/> is empty.</exception>
        public static string[] Transform(double[] array, Transformer transformer)
        {
           return Transform(array, new TransformerAdapter(transformer));
        }

        private class TransformerAdapter : ITransformer
        {
            private readonly Transformer _transformer;

            public TransformerAdapter(Transformer transformer)
            {
                _transformer = transformer;
            }

            public string Transform(double number) => _transformer(number);
        }
    }
}
