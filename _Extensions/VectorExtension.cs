using ThreeDent.DevelopmentTools.Options;
using UnityEngine;

namespace ThreeDent.DevelopmentTools.Extensions
{
    public static class VectorExtension
    {
        public static void Deconstruct(this Vector2 vector, out float x, out float y)
        {
            x = vector.x;
            y = vector.y;
        }

        public static void Deconstruct(this Vector3 vector, out float x, out float y, out float z)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }

        public static Vector3 With(this Vector3 vector, Option<float> x = default, Option<float> y = default, Option<float> z = default)
        {
            vector.x = x.ReadOrDefault(vector.x);
            vector.y = y.ReadOrDefault(vector.y);
            vector.z = z.ReadOrDefault(vector.z);
            return vector;
        }

        public static Vector2 With(this Vector2 vector, Option<float> x = default, Option<float> y = default)
        {
            vector.x = x.ReadOrDefault(vector.x);
            vector.y = y.ReadOrDefault(vector.y);
            return vector;
        }
    }
}