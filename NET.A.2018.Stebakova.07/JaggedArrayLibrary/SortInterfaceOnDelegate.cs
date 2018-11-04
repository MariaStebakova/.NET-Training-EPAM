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
    public static class SortInterfaceOnDelegate
    {
        /// <summary>
        /// Delegate for sorting method
        /// </summary>
        /// <param name="array">Jagged array for sorting.</param>
        /// <param name="comparer">Type of comparer</param>
        public delegate void SortMethodDelegate(int[][] array, IComparer<int[]> comparer);

        /// <summary>
        /// Static method for sorting jagged array using delegate on the base of interface.
        /// </summary>
        /// <param name="array">Jagged array for sorting.</param>
        /// <param name="comparer">Type of comparer</param>
        /// <param name="sortMethod">Method that impelemnts sorting for given array according to given comparer.</param>
        public static void Sort(int[][] array, IComparer<int[]> comparer, SortMethodDelegate sortMethod)
        {
            sortMethod(array, comparer);
        }
    }
}
