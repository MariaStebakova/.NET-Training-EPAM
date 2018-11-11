using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterLib
{
    public static class TransformerExtension
    {
        public static TSource[] Filter<TSource>(this TSource[] source, Predicate<TSource> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} can't be equal to null!");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} can't be equal to null!");
            }

            return source.FilterInner(predicate);
        }

        private static TSource[] FilterInner<TSource>(this TSource[] source, Predicate<TSource> predicate)
        {
            List<TSource> result = new List<TSource>();

            foreach (var s in source)
            {
                if (predicate(s))
                    result.Add(s);
            }

            return result.ToArray();
        }
    }
}
