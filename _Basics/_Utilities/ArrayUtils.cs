using System;

namespace ThreeDent.DevelopmentTools.Utilities
{
    public static class ArrayUtils
    {
        public static T[] Init<T>(int length, Func<int, T> factory)
        {
            var array = new T[length];
            for (int i = 0; i < length; i++)
                array[i] = factory(i);
            return array;
        }

        public static T[] Init<T>(int length, Func<T> factory)
        {
            return Init(length, (_) => factory());
        }

        public static T[] Init<T>(int length, T value)
        {
            return Init(length, () => value);
        }

        public static T[,] Init<T>(int width, int height, Func<T> factory)
        {
            var matrix = new T[height, width];
            for (var y = 0; y < height; y++)
                for (var x = 0; x < width; x++)
                    matrix[y, x] = factory();
            return matrix;
        }

        public static T[,] Init<T>(int width, int height, T value)
        {
            return Init(width, height, () => value);
        }
    }
}