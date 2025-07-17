using System;
using System.Collections.Generic;

namespace ThreeDent.DevelopmentTools.Extensions
{
    public static class LinqExtension
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var element in collection)
                action(element);
        }
    }
}
