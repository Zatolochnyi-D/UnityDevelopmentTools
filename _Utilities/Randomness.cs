using UnityEngine;

// Extends UnityEngine.Random
public static class Randomness
{
    public static Vector2Int PointInSquare(int minX, int minY, int maxX, int maxY)
    {
        return new(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }
}