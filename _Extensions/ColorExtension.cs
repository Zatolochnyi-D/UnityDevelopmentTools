using UnityEngine;

namespace ThreeDent.DevelopmentTools.Extensions
{
    public static class ColorExtension
    {
        /// <summary>
        /// Changes color values on Color object and returns it.
        /// </summary>
        public static Color With(this Color color, float? r = null, float? g = null, float? b = null, float? a = null)
        {
            color.r = r ?? color.r;
            color.g = g ?? color.g;
            color.b = b ?? color.b;
            color.a = a ?? color.a;

            return color;
        }
    }
}