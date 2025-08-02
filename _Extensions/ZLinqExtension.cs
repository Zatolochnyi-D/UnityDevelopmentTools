using System;
using System.Collections.Generic;
using ZLinq;

namespace ThreeDent.DevelopmentTools.Extensions
{
    public static class ZLinqExtension
    {
        public static IEnumerable<T> AsEnumerable<TEnumerator, T>(this ValueEnumerable<TEnumerator, T> collection) where TEnumerator : struct, IValueEnumerator<T>
        {
            foreach (var value in collection)
                yield return value;
        }

        public static void ForEach<TEnumerator, T>(this ValueEnumerable<TEnumerator, T> collection, Action<T> action) where TEnumerator : struct, IValueEnumerator<T>
        {
            foreach (var element in collection)
                action(element);
        }
    }
}