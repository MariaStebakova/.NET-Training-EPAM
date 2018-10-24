using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayLibrary
{
    public static class JaggedArraySort
    {
        public static void Sort(int[][] jaggedArray, IComparer<int[]> comparer)
        {
            CheckInputArguments(jaggedArray, comparer);

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = i + 1; j < jaggedArray.Length; j++)
                {
                    if (comparer.Compare(jaggedArray[i], jaggedArray[j]) > 0)
                    {
                        Swap(ref jaggedArray[i], ref jaggedArray[j]);
                    }
                }
            }
        }

        private static void Swap(ref int[] array1, ref int[] array2)
        {
            int[] temp = array1;
            array1 = array2;
            array2 = temp;
        }

        private static void CheckInputArguments(int[][] array, IComparer<int[]> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} can't be equal to null.");
            }

            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty.");
            }
        }
    }
}
