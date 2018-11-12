using System;
using System.Collections.Generic;
using Filter.Test.Predicates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Operations.ArrayTransformation;

namespace Filter.Test
{
    [TestFixture]
    public class TransformerExtensionTests
    {
        [TestCase(new int[] { 2, 3, 6, 5, 7, 11, 36, 13, 17, 48, 19, 23, 29 },
            ExpectedResult = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 })]
        public IEnumerable<int> FilterTest_IntPrimePredicate(int[] numbers)
        {
            IntPredicate.IntPrimePredicate predicate = new IntPredicate.IntPrimePredicate();
            return Operations.ArrayTransformation.ArrayTransform.Filter(numbers, predicate.IsMatch);
        }

        [TestCase(new int[] { 2, 3, 6, 5, 7, 11, 36, 13, 17, 48, 19, 23, 29 },
            ExpectedResult = new int[] { 2, 6, 36, 48 })]
        public IEnumerable<int> FilterTest_IntEvenPredicate(int[] numbers)
        {
            IntPredicate.IntEvenPredicate predicate = new IntPredicate.IntEvenPredicate();
            return Operations.ArrayTransformation.ArrayTransform.Filter(numbers, predicate.IsMatch);
        }

        [TestCase(new int[] { 2, 3, 6, 5, 7, 11, 36, 13, 17, 48, 19, 23, 29 },
            ExpectedResult = new int[] { 2, 6, 36, 48 })]
        public IEnumerable<int> FilterTest_IntEvenIPredicate(int[] numbers)
        {
            IntPredicate.IntEvenPredicate predicate = new IntPredicate.IntEvenPredicate();
            return Operations.ArrayTransformation.ArrayTransform.Filter(numbers, predicate);
        }

        [TestCase(new string[] { "test", "test1", "tes1", "test2", "test3" }, 
            ExpectedResult = new string[] { "test1", "test2", "test3" })]
        public IEnumerable<string> FilterTest_StringHasFiveCharsPredicate(string[] strings)
        {
            StringPredicate.StringHasFiveCharsPredicate predicate = new StringPredicate.StringHasFiveCharsPredicate();
            return Operations.ArrayTransformation.ArrayTransform.Filter(strings, predicate.IsMatch);
        }

        [TestCase(new string[] { "Mtest", "Mtest1", "tes1", "Mtest2", "test3" },
            ExpectedResult = new string[] { "Mtest", "Mtest1", "Mtest2" })]
        public IEnumerable<string> FilterTest_StringStartsWithMPredicate(string[] strings)
        {
            StringPredicate.StringStartsWithMPredicate predicate = new StringPredicate.StringStartsWithMPredicate();
            return Operations.ArrayTransformation.ArrayTransform.Filter(strings, predicate.IsMatch);
        }
    }
}
