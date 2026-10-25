using System.Runtime.CompilerServices;
using UnityEngine;

namespace DenZ.DevelopmentTools.Utilities
{
    // Extends UnityEngine.Random
    public static class Randomness
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int PointInSquare(int minXInclusive, int minYInclusive, int maxXExclusive, int maxYExclusive)
        {
            return new(UnityEngine.Random.Range(minXInclusive, maxXExclusive), UnityEngine.Random.Range(minYInclusive, maxYExclusive));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 PointInSquare(float minXInclusive, float minYInclusive, float maxXInclusive, float maxYInclusive)
        {
            return new(UnityEngine.Random.Range(minXInclusive, maxXInclusive), UnityEngine.Random.Range(minYInclusive, maxYInclusive));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 PointBetweenTwoRadii(float innerRadius, float outerRadius)
        {
            var phi = UnityEngine.Random.Range(0f, 2f * Mathf.PI);
            var ro = UnityEngine.Random.Range(innerRadius, outerRadius);
            return new(ro * Mathf.Cos(phi), ro * Mathf.Sin(phi));
        }
    }
}