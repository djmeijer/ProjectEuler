using System.Collections.Generic;

namespace ProjectEuler.Utilities
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Intersperse<T>(this IEnumerable<T> items, T separator)
        {
            var first = true;
            foreach (var item in items)
            {
                if (first)
                    first = false;
                else
                    yield return separator;
                yield return item;
            }
        }
    }
}