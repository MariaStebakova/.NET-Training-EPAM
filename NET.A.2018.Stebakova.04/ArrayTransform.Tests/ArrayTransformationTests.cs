using System;
using System.Collections.Generic;
using ArrayTransform.ArrayTransformation;
using NUnit.Framework;

namespace Operations.Tests
{
    [TestFixture]
    public class ArrayTransformationTests
    {
        [TestCase(new double[] {-23.809, 0.295, 15.17},
            ExpectedResult = new string[]
                {"minus two three point eight zero nine", "zero point two nine five", "one five point one seven"})]
        [TestCase(new double[] { 0.321, 65.7 },
            ExpectedResult = new string[]
                {"zero point three two one", "six five point seven"})]
        public IEnumerable<string> TransformToWordsTest_WithCorrectArrays_WithInterface(IEnumerable<double> doubles)
            => ArrayTransformation.ArrayTransform.Transform(doubles, new Transformers.TransformerToWords());
       
        [TestCase(new double[] { -255.255, 255.255, 4294967295.0 },
            ExpectedResult = new string[]
                {"1100000001101111111010000010100011110101110000101000111101011100",
                    "0100000001101111111010000010100011110101110000101000111101011100",
                    "0100000111101111111111111111111111111111111000000000000000000000" })]
        public IEnumerable<string> TransformToIEEETest_WithCorrectArrays_WithDelegate_WithInterface(IEnumerable<double> doubles)
            => ArrayTransformation.ArrayTransform.Transform(doubles, new Transformers.TranformerToIEEE());

        [TestCase(new double[] {-23.809, 0.295, 15.17},
            ExpectedResult = new string[]
                {"minus two three point eight zero nine", "zero point two nine five", "one five point one seven"})]
        [TestCase(new double[] {0.321, 65.7},
            ExpectedResult = new string[]
                {"zero point three two one", "six five point seven"})]
        public IEnumerable<string> TransformToWordsTest_WithCorrectArrays_WithDelegate(IEnumerable<double> doubles)
        {
            string Transformer(double number) => new Transformers.TransformerToWords().Transform(number);
            return ArrayTransformation.ArrayTransform.Transform(doubles, Transformer);
        }

        [TestCase(new double[] { -255.255, 255.255, 4294967295.0 },
            ExpectedResult = new string[]
            {"1100000001101111111010000010100011110101110000101000111101011100",
                "0100000001101111111010000010100011110101110000101000111101011100",
                "0100000111101111111111111111111111111111111000000000000000000000" })]
        public IEnumerable<string> TransformToIEEETest_WithCorrectArrays_WithDelegate(IEnumerable<double> doubles)
        {
            string Transformer(double number) => new Transformers.TranformerToIEEE().Transform(number);
            return ArrayTransformation.ArrayTransform.Transform(doubles, Transformer);
        }
    }
}