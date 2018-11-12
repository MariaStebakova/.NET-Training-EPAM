using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operations;

namespace ArrayTransform.ArrayTransformation
{
    public class Transformers
    {
        public class TransformerToWords : ITransformer<double, string>
        {
            public string Transform(double doubles)
            {
                string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

                StringBuilder words = new StringBuilder();
                StringBuilder stringNum = new StringBuilder();


                stringNum.Append(Convert.ToString(doubles));

                for (int k = 0; k < stringNum.Length; k++)
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
                stringNum.Clear();

                return words.ToString();
            }

        }

        public class TranformerToIEEE : ITransformer<double, string>
        {
            public string Transform(double number)
            {
                return DoubleExtension.ConvertToIEEE(number);
            }
        }
    }
}
