using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayLibrary.Comparators
{
    public class ElementsSumComparator
    {
        public class ElementsSumIncreaseComparer : IComparer<int[]>
        {
            public int Compare(int[] firstArray, int[] secondArray)
            {
                if (firstArray == null)
                {
                    return 1;
                }

                if (secondArray == null)
                {
                    return -1;
                }

                if (firstArray.Sum() <= secondArray.Sum())
                {
                    return -1;
                }

                return 1;
            }
        }

        public class ElementsSumDecreaseComparer : IComparer<int[]>
        {
            public int Compare(int[] firstArray, int[] secondArray)
            {
                if (firstArray == null)
                {
                    return -1;
                }

                if (secondArray == null)
                {
                    return 1;
                }

                if (firstArray.Sum() >= secondArray.Sum())
                {
                    return -1;
                }

                return 1;
            }
        }
    }
}
