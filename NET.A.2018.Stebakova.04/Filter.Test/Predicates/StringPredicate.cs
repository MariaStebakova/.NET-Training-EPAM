using ArrayTransform.ArrayTransformation;

namespace Filter.Test.Predicates
{
    public static class StringPredicate
    {
        private static bool StringHasFiveChars(string str)
        {
            return str.Length == 5;
        }

        private static bool StringStartsWithM(string str)
        {
            return str.StartsWith("M");
        }

        public class StringHasFiveCharsPredicate: IPredicate<string>
        {
            public bool IsMatch(string source)
            {
                return StringHasFiveChars(source);
            }
        }

        public class StringStartsWithMPredicate: IPredicate<string>
        {
            public bool IsMatch(string source)
            {
                return StringStartsWithM(source);
            }
        }
    }
}
