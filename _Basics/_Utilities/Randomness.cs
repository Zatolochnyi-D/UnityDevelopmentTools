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
            return new(Random.Range(minXInclusive, maxXExclusive), Random.Range(minYInclusive, maxYExclusive));
        }
    }
}