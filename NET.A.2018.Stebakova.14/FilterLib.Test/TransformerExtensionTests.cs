using System;
using FilterLib.Test.Predicates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace FilterLib.Test
{
    [TestFixture]
    public class TransformerExtensionTests
    {
        [TestCase(new int[] { 2, 3, 6, 5, 7, 11, 36, 13, 17, 48, 19, 23, 29 }, 
            ExpectedResult = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29})]
        public int[] FilterTest_IntPrimePredicate(int[] numbers)
        {
            IntPredicate.IntPrimePredicate predicate = new IntPredicate.IntPrimePredicate();
            return TransformerExtension.Filter(numbers, predicate.IsMatch);
        }

        [TestCase(new int[] { 2, 3, 6, 5, 7, 11, 36, 13, 17, 48, 19, 23, 29 },
            ExpectedResult = new int[] { 2, 6, 36, 48 })]
        public int[] FilterTest_IntEvenPredicate(int[] numbers)
        {
            IntPredicate.IntEvenPredicate predicate = new IntPredicate.IntEvenPredicate();
            return TransformerExtension.Filter(numbers, predicate.IsMatch);
        }

        [TestCase(new string[] { "test", "test1", "tes1", "test2", "test3" }, 
            ExpectedResult = new string[] { "test1", "test2", "test3" })]
        public string[] FilterTest_StringHasFiveCharsPredicate(string[] strings)
        {
            StringPredicate.StringHasFiveCharsPredicate predicate = new StringPredicate.StringHasFiveCharsPredicate();
            return TransformerExtension.Filter(strings, predicate.IsMatch);
        }

        [TestCase(new string[] { "Mtest", "Mtest1", "tes1", "Mtest2", "test3" },
            ExpectedResult = new string[] { "Mtest", "Mtest1", "Mtest2" })]
        public string[] FilterTest_StringStartsWithMPredicate(string[] strings)
        {
            StringPredicate.StringStartsWithMPredicate predicate = new StringPredicate.StringStartsWithMPredicate();
            return TransformerExtension.Filter(strings, predicate.IsMatch);
        }
    }
}
