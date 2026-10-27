using System.Runtime.CompilerServices;
using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class Vector2To3SwizzlingExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 AsXY0(this Vector2 vector) => new(vector.x, vector.y, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int AsXY0(this Vector2Int vector) => new(vector.x, vector.y, 0);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 AsX0Y(this Vector2 vector) => new(vector.x, 0f, vector.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int AsX0Y(this Vector2Int vector) => new(vector.x, 0, vector.y);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 AsY0X(this Vector2 vector) => new(vector.y, 0f, vector.x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int AsY0X(this Vector2Int vector) => new(vector.y, 0, vector.x);
    }
}