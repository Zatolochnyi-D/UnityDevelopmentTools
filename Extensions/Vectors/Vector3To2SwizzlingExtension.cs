using System.Runtime.CompilerServices;
using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class Vector3To2SwizzlingExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 AsXZ(this Vector3 vector) => new(vector.x, vector.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int AsXZ(this Vector3Int vector) => new(vector.x, vector.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 AsXY(this Vector3 vector) => new(vector.x, vector.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int AsXY(this Vector3Int vector) => new(vector.x, vector.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 AsYZ(this Vector3 vector) => new(vector.y, vector.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int AsYZ(this Vector3Int vector) => new(vector.y, vector.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 AsZY(this Vector3 vector) => new(vector.z, vector.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int AsZY(this Vector3Int vector) => new(vector.z, vector.y);
    }
}