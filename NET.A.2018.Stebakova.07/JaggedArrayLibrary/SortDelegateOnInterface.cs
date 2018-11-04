using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayLibrary
{
    /// <summary>
    /// Static class for sorting jagged arrays.
    /// </summary>
    public static class SortDelegateOnInterface
    {
        /// <summary>
        /// Static method for sorting jagged array using interface on the base of delegate.
        /// </summary>
        /// <param name="array">Jagged array for sorting.</param>
        /// <param name="comparer">Type of comparer</param>
        public static void Sort(int[][] array, IComparer<int[]> comparer)
        {
            JaggedArraySort.Sort(array, comparer.Compare);
        }
    }
}
