using System.Runtime.CompilerServices;
using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class VectorInlineOffsetExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 WithOffset(this Vector2 vector, float x = 0f, float y = 0f)
        {
            return new(
                vector.x + x,
                vector.y + y
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int WithOffset(this Vector2Int vector, int x = 0, int y = 0)
        {
            return new(
                vector.x + x,
                vector.y + y
            );
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 WithOffset(this Vector3 vector, float x = 0f, float y = 0f, float z = 0f)
        {
            return new(
                vector.x + x,
                vector.y + y,
                vector.z + z
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int WithOffset(this Vector3Int vector, int x = 0, int y = 0, int z = 0)
        {
            return new(
                vector.x + x,
                vector.y + y,
                vector.z + z
            );
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 WithOffset(this Vector4 vector, float x = 0f, float y = 0f, float z = 0f, float w = 0f)
        {
            return new(
                vector.x + x,
                vector.y + y,
                vector.z + z,
                vector.w + w
            );
        }
    }
}