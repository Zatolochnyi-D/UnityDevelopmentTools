using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DenZ.DevelopmentTools.Math
{
    public static class MathS
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



        /// <summary>
        /// Linear interpolation with t unclamped.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LerpClamped(float a, float b, float t)
        {
            return Lerp(a, b, Mathf.Clamp01(t));
        }



        /// <summary>
        /// Inverse linear interpolation with t unclamped.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float InverseLerp(float a, float b, float c)
        {
            return a != b ? (c - a) / (b - a) : 0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float InverseLerpClamped(float a, float b, float c)
        {
            return Mathf.Clamp01(InverseLerp(a, b, c));
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MapRange(float value, float fromMin = 0f, float fromMax = 1f, float toMin = 0f, float toMax = 1f)
        {
            return Lerp(toMin, toMax, InverseLerp(fromMin, fromMax, value));
        }

        public static float MapRangeClamped(float value, float fromMin = 0f, float fromMax = 1f, float toMin = 0f, float toMax = 1f)
        {
            return Lerp(toMin, toMax, InverseLerpClamped(fromMin, fromMax, value));
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