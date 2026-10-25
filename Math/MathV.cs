using System.Runtime.CompilerServices;
using UnityEngine;

namespace DenZ.DevelopmentTools.Math
{
    public static class MathV
    {
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
    }
}