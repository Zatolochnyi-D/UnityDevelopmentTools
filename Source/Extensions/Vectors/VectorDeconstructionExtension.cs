using System.Runtime.CompilerServices;
using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    // 100% coverage (covers all the vectors in use so far).
    public static class VectorDeconstructionExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Deconstruct(this Vector2 vector, out float x, out float y) => (x, y) = (vector.x, vector.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Deconstruct(this Vector2Int vector, out int x, out int y) => (x, y) = (vector.x, vector.y);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Deconstruct(this Vector3 vector, out float x, out float y, out float z) => (x, y, z) = (vector.x, vector.y, vector.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Deconstruct(this Vector3Int vector, out int x, out int y, out int z) => (x, y, z) = (vector.x, vector.y, vector.z);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Deconstruct(this Vector4 vector, out float x, out float y, out float z, out float w) => (x, y, z, w) = (vector.x, vector.y, vector.z, vector.w);
    }
}
