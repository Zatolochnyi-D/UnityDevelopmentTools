using UnityEngine;

namespace DenZ.DevelopmentTools.Math
{
    public static class MathV
    {
        // TODO: This doesn't include check for c being on the same line with a and b.
        public static float InverseLerp(Vector3 a, Vector3 b, Vector3 c)
        {
            var top = c - a;
            var bottom = b - a;

            var ts = new Vector3(
                top.x != bottom.x ? top.x / bottom.x : 0f,
                top.y != bottom.y ? top.y / bottom.y : 0f,
                top.z != bottom.z ? top.z / bottom.z : 0f
            );

            var t = Mathf.Max(ts.x, ts.y, ts.z);

            return t;
        }
    }
}