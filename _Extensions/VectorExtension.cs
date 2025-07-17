using UnityEngine;

namespace ThreeDent.DevelopmentTools.Extensions
{
    public static class VectorExtension
    {
        /// <summary>
        /// Changes specified values of vector and returns it.
        /// </summary>
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            vector.x = x ?? vector.x;
            vector.y = y ?? vector.y;
            vector.z = z ?? vector.z;
            return vector;
        }

        /// <summary>
        /// Changes specified values of vector and returns it.
        /// </summary>
        public static Vector2 With(this Vector2 vector, float? x = null, float? y = null)
        {
            vector.x = x ?? vector.x;
            vector.y = y ?? vector.y;
            return vector;
        }
    }
}