using System.Runtime.CompilerServices;
using DenZ.DevelopmentTools.Options;
using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class VectorInlineReplacementExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 With(this Vector2 vector, Option<float> x = default, Option<float> y = default)
        {
            return new(
                x.ReadOrDefaultTo(vector.x),
                y.ReadOrDefaultTo(vector.y)
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int With(this Vector2Int vector, Option<int> x = default, Option<int> y = default)
        {
            return new(
                x.ReadOrDefaultTo(vector.x),
                y.ReadOrDefaultTo(vector.y)
            );
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 With(this Vector3 vector, Option<float> x = default, Option<float> y = default, Option<float> z = default)
        {
            return new(
                x.ReadOrDefaultTo(vector.x),
                y.ReadOrDefaultTo(vector.y),
                z.ReadOrDefaultTo(vector.z)
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3Int With(this Vector3Int vector, Option<int> x = default, Option<int> y = default, Option<int> z = default)
        {
            return new(
                x.ReadOrDefaultTo(vector.x),
                y.ReadOrDefaultTo(vector.y),
                z.ReadOrDefaultTo(vector.z)
            );
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector4 With(this Vector4 vector, Option<float> x = default, Option<float> y = default, Option<float> z = default, Option<float> w = default)
        {
            return new(
                x.ReadOrDefaultTo(vector.x),
                y.ReadOrDefaultTo(vector.y),
                z.ReadOrDefaultTo(vector.z),
                w.ReadOrDefaultTo(vector.w)
            );
        }
    }
}