using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayLibrary.Comparators
{
    public class MaxElementComparator
    {
        public class MaxElementIncreaseComparer : IComparer<int[]>
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

                if (firstArray.Max() < secondArray.Max())
                {
                    return -1;
                }

                return 1;
            }
        }

        public class MaxElementDecreaseComparer : IComparer<int[]>
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

                if (firstArray.Max() > secondArray.Max())
                {
                    return -1;
                }

                return 1;
            }
        }
    }
}
