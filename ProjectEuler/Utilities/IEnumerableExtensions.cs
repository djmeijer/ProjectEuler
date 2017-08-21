using System.Collections.Generic;

namespace ProjectEuler.Utilities
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Intersperse<T>(this IEnumerable<T> items, T separator)
        {
            bool first = true;
            foreach(T item in items)
            {
                if(first)
                {
                   first = false;
                }
                else
                {
                    yield return separator;
                }
                yield return item;
            }
        }
    }
}