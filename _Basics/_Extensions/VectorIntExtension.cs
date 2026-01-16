using System.Runtime.CompilerServices;
using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class VectorIntExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int AsX0Z(this Vector2Int vector)
        {
            return new(vector.x, 0, vector.y);
        }
    }
}