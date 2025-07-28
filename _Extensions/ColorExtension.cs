using ThreeDent.DevelopmentTools.Options;
using UnityEngine;

namespace ThreeDent.DevelopmentTools.Extensions
{
    public static class ColorExtension
    {
        /// <summary>
        /// Changes color values on Color object and returns it.
        /// </summary>
        public static Color With(this Color color, Option<float> r = default, Option<float> g = default, Option<float> b = default, Option<float> a = default)
        {
            color.r = Option.DefaultWith(r, color.r);
            color.g = Option.DefaultWith(g, color.g);
            color.b = Option.DefaultWith(b, color.b);
            color.a = Option.DefaultWith(a, color.a);

            return color;
        }

        public static Color WithHsv(this Color color, Option<float> h = default, Option<float> s = default, Option<float> v = default)
        {
            Color.RGBToHSV(color, out var thisH, out var thisS, out var thisV);
            thisH = Option.DefaultWith(h, thisH);
            thisS = Option.DefaultWith(s, thisS);
            thisV = Option.DefaultWith(v, thisV);
            return Color.HSVToRGB(thisH, thisS, thisV);
        }
    }
}