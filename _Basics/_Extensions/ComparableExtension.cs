using System;
using System.Runtime.CompilerServices;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class ComparableExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLowerThan<T>(this IComparable<T> comparable, T other)
        {
            return comparable.CompareTo(other) == -1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsTheSameAs<T>(this IComparable<T> comparable, T other)
        {
            return comparable.CompareTo(other) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGreaterThan<T>(this IComparable<T> comparable, T other)
        {
            return comparable.CompareTo(other) == 1;
        }
    }
}