using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class LinqExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        public static void ForEach<T>(this IEnumerable<T> collection, Action<int, T> action)
        {
            foreach (var (i, element) in collection.Zip(Enumerable.Range(0, collection.Count()), (el, i) => (i, el)))
                action(i, element);
        }

        public static IEnumerable<T> Unfold<T>(this T[,] matrix)
        {
            for (int y = 0; y < matrix.GetLength(1); y++)
                for (int x = 0; x < matrix.GetLength(0); x++)
                    yield return matrix[x, y];
        }
    }
}