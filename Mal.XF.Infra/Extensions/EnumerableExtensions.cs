using System.Collections.Generic;
using System.Linq;

namespace Mal.XF.Infra.Extensions
{
    public static class EnumerableExtensions
    {
        public static IReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> source)
        {
            return source.ToArray();
        }

        public static IReadOnlyList<T> ToReadOnlyList<T>(this IEnumerable<T> source)
        {
            return source.ToArray();
        }

        public static int GetIndex<T>(this IEnumerable<T> source, T searchItem)
        {
            var index = -1;

            foreach (var item in source)
            {
                index++;
                if (item.Equals(searchItem))
                    return index;
            }

            return -1;
        }
    }
}
