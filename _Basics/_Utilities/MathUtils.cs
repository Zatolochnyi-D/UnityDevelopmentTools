using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DenZ.DevelopmentTools.Utilities
{
    public static class MathUtils
    {
        public static List<int> SeparateDigits(int number)
        {
            List<int> leftovers = new();
            while (true)
            {
                int leftover = number % 10;
                leftovers.Add(leftover);
                if (number == leftover)
                    break;
                number /= 10;
            }
            leftovers.Reverse();
            return leftovers;
        }

        public static float MapRange(float value, float fromMin = 0f, float fromMax = 1f, float toMin = 0f, float toMax = 1f)
        {
            // TODO: Those lerp interpolations assume t in [0;1] range, what is not necessary the case. Fix.
            return Mathf.Lerp(toMin, toMax, Mathf.InverseLerp(fromMin, fromMax, value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool InsideRectangle(Vector2Int point, int width, int height)
        {
            if (point.x < 0 || point.x >= width)
                return false;
            if (point.y < 0 || point.y >= height)
                return false;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool InsideRectangle(Vector2 point, float width, float height)
        {
            if (point.x < 0f || point.x > width)
        
                return false;
            if (point.y < 0f || point.y > height)
                return false;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LerpRadianAngle(float a, float b, float t)
        {
            return Mathf.LerpAngle(a * Mathf.Rad2Deg, b * Mathf.Rad2Deg, t) * Mathf.Deg2Rad;
        }
    }
}