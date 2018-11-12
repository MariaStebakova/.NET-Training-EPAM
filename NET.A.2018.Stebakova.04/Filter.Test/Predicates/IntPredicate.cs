using ArrayTransform.ArrayTransformation;

namespace Filter.Test.Predicates
{
    public static class IntPredicate
    {
        private static bool IntIsPrime(int number)
        {
            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IntIsEven(int number)
        {
            if (number == 0)
            {
                return false;
            }

            return number % 2 == 0 ? true : false;
        }

        public class IntPrimePredicate: IPredicate<int>
        {
            public bool IsMatch(int source)
            {
                return IntIsPrime(source);
            }
        }

        public class IntEvenPredicate: IPredicate<int>
        {
            public bool IsMatch(int source)
            {
                return IntIsEven(source);
            }
        }
    }
}
