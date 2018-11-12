using System.Collections.Generic;
using System;
using ArrayTransform.ArrayTransformation;

namespace Operations.ArrayTransformation
{
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
        public delegate TResult Transformer<in TSource, out TResult>(TSource number);

        /// <summary>
        /// Public method for transforming the double array somehow.
        /// </summary>
        /// <param name="array">Array of double numbers.</param>
        /// <param name="transformer">Type of transforming.</param>
        /// <returns>Array of strings.</returns>
        /// <exception cref="ArgumentNullException">Is thrown if the <param name="array"/> is equal to null.</exception>
        /// <exception cref="ArgumentException">Is thrown if the <param name="array"/> is empty.</exception>
        public static IEnumerable<TResult> Transform<TSource, TResult>(IEnumerable<TSource> array, ITransformer<TSource, TResult> transformer)
        {
           return Transform<TSource, TResult>(array, transformer.Transform);
        }

        /// <summary>
        /// Public method for transforming the double array somehow.
        /// </summary>
        /// <param name="array">Array of double numbers.</param>
        /// <param name="transformer">Method performing transforming.</param>
        /// <returns>Array of strings.</returns>
        /// <exception cref="ArgumentNullException">Is thrown if the <param name="array"/> is equal to null.</exception>
        /// <exception cref="ArgumentException">Is thrown if the <param name="array"/> is empty.</exception>
        public static IEnumerable<TResult> Transform<TSource, TResult>(IEnumerable<TSource> array, Transformer<TSource, TResult> transformer)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null");
            }
            
            foreach (var a in array)
            {
                yield return transformer(a);
            }
        }

        /// <summary>
        /// Static method for filtering the input values
        /// </summary>
        /// <typeparam name="TSource">Type of input and output values</typeparam>
        /// <param name="source">Values to filter</param>
        /// <param name="predicate">Class for filtering</param>
        /// <returns>Filtered values</returns>
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, IPredicate<TSource> predicate)
        {
            return source.Filter(predicate.IsMatch);
        }


        /// <summary>
        /// Static method for filtering the input values
        /// </summary>
        /// <typeparam name="TSource">Type of input and output values</typeparam>
        /// <param name="source">Values to filter</param>
        /// <param name="predicate">Method of filtering</param>
        /// <returns>Filtered values</returns>
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} can't be equal to null!");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} can't be equal to null!");
            }

            return source.FilterInner(predicate);
        }

        private static IEnumerable<TSource> FilterInner<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            List<TSource> result = new List<TSource>();

            foreach (var s in source)
            {
                if (predicate(s))
                    result.Add(s);
            }

            return result.ToArray();
        }
    }
}
