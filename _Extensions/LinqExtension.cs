using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreeDent.DevelopmentTools.Extensions
{
    public static class LinqExtension
    {
        public static IEnumerable<T> Clone<T>(this IEnumerable<T> collection)
        {
            return collection.ToArray();
        }

        public static bool Contains<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
                if (predicate(item))
                    return true;
            return false;
        }

        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> collection, Func<TSource, TKey> selector) where TKey : IComparable<TKey>
        {
            if (collection.Count() == 0)
                throw new InvalidOperationException("Given collection is empty.");
            TSource minElement = collection.First();
            TKey minKey = selector(minElement);
            foreach (var item in collection.Skip(1))
            {
                var newKey = selector(item);
                if (newKey.IsLowerThan(minKey))
                {
                    minKey = newKey;
                    minElement = item;
                }
            }
            return minElement;
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var element in collection)
                action(element);
        }
    }
}