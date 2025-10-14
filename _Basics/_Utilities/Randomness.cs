using System.Runtime.CompilerServices;
using UnityEngine;

// Extends UnityEngine.Random
public static class Randomness
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2Int PointInSquare(int minXInclusive, int minYInclusive, int maxXExclusive, int maxYExclusive)
    {
        return new(Random.Range(minXInclusive, maxXExclusive), Random.Range(minYInclusive, maxYExclusive));
    }
}