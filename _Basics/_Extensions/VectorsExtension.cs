using System.Runtime.CompilerServices;
using DenZ.DevelopmentTools.Options;
using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class VectorsExtension
    {
        #region Deconstruction
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Deconstruct(this Vector2 vector, out float x, out float y)
        {
            x = vector.x;
            y = vector.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Deconstruct(this Vector3 vector, out float x, out float y, out float z)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Deconstruct(this Vector2Int vector, out int x, out int y)
        {
            x = vector.x;
            y = vector.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Deconstruct(this Vector3Int vector, out int x, out int y, out int z)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }
        #endregion


        #region Inline replacing
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 With(this Vector3 vector, Option<float> x = default, Option<float> y = default, Option<float> z = default)
        {
            vector.x = x.ReadOrDefault(vector.x);
            vector.y = y.ReadOrDefault(vector.y);
            vector.z = z.ReadOrDefault(vector.z);
            return vector;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 With(this Vector2 vector, Option<float> x = default, Option<float> y = default)
        {
            vector.x = x.ReadOrDefault(vector.x);
            vector.y = y.ReadOrDefault(vector.y);
            return vector;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int With(this Vector3Int vector, Option<int> x = default, Option<int> y = default, Option<int> z = default)
        {
            vector.x = x.ReadOrDefault(vector.x);
            vector.y = y.ReadOrDefault(vector.y);
            vector.z = z.ReadOrDefault(vector.z);
            return vector;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int With(this Vector2Int vector, Option<int> x = default, Option<int> y = default)
        {
            vector.x = x.ReadOrDefault(vector.x);
            vector.y = y.ReadOrDefault(vector.y);
            return vector;
        }
        #endregion


        #region Inline modification
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 WithOffset(this Vector3 vector, float x = 0f, float y = 0f, float z = 0f)
        {
            vector.x += x;
            vector.y += y;
            vector.z += z;
            return vector;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 WithOffset(this Vector2 vector, float x = 0f, float y = 0f)
        {
            vector.x += x;
            vector.y += y;
            return vector;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int WithOffset(this Vector3Int vector, int x = 0, int y = 0, int z = 0)
        {
            vector.x += x;
            vector.y += y;
            vector.z += z;
            return vector;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int WithOffset(this Vector2Int vector, int x = 0, int y = 0)
        {
            vector.x += x;
            vector.y += y;
            return vector;
        }
        #endregion


        #region Swizzling 2D to 3D
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 AsX0Y(this Vector2 vector)
        {
            return new(vector.x, 0f, vector.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 AsY0X(this Vector2 vector)
        {
            return new(vector.y, 0f, vector.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int AsX0Y(this Vector2Int vector)
        {
            return new(vector.x, 0, vector.y);
        }
        #endregion


        #region Swizzling 3D to 2D
        public static Vector2 AsXZ(this Vector3 vector)
        {
            return new(vector.x, vector.z);
        }

        public static Vector2 AsXY(this Vector3 vector)
        {
            return new(vector.x, vector.y);
        }

        public static Vector2 AsYZ(this Vector3 vector)
        {
            return new(vector.y, vector.z);
        }

        public static Vector2 AsZY(this Vector3 vector)
        {
            return new(vector.z, vector.y);
        }
        #endregion
    }
}