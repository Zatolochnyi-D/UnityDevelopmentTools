using System;

namespace ThreeDent.DevelopmentTools.Extensions
{
    public static class ComparableExtension
    {
        public static bool IsLowerThan<T>(this IComparable<T> comparable, T other)
        {
            return comparable.CompareTo(other) == -1;
        }

        public static bool IsTheSameAs<T>(this IComparable<T> comparable, T other)
        {
            return comparable.CompareTo(other) == 0;
        }

        public static bool IsGreaterThan<T>(this IComparable<T> comparable, T other)
        {
            return comparable.CompareTo(other) == 1;
        }
    }
}