using ThreeDent.DevelopmentTools.Options;
using UnityEngine;

namespace ThreeDent.DevelopmentTools.Extensions
{
    public static class VectorExtension
    {
        /// <summary>
        /// Changes specified values of vector and returns it.
        /// </summary>
        public static Vector3 With(this Vector3 vector, Option<float> x = default, Option<float> y = default, Option<float> z = default)
        {
            vector.x = Option.ReadOrDefault(x, vector.x);
            vector.y = Option.ReadOrDefault(y, vector.y);
            vector.z = Option.ReadOrDefault(z, vector.z);
            return vector;
        }

        /// <summary>
        /// Changes specified values of vector and returns it.
        /// </summary>
        public static Vector2 With(this Vector2 vector, Option<float> x = default, Option<float> y = default)
        {
            vector.x = Option.ReadOrDefault(x, vector.x);
            vector.y = Option.ReadOrDefault(y, vector.y);
            return vector;
        }
    }
}