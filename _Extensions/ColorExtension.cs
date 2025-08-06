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
            color.r = Option.ReadOrDefault(r, color.r);
            color.g = Option.ReadOrDefault(g, color.g);
            color.b = Option.ReadOrDefault(b, color.b);
            color.a = Option.ReadOrDefault(a, color.a);

            return color;
        }

        public static Color WithHsv(this Color color, Option<float> h = default, Option<float> s = default, Option<float> v = default)
        {
            Color.RGBToHSV(color, out var thisH, out var thisS, out var thisV);
            thisH = Option.ReadOrDefault(h, thisH);
            thisS = Option.ReadOrDefault(s, thisS);
            thisV = Option.ReadOrDefault(v, thisV);
            return Color.HSVToRGB(thisH, thisS, thisV);
        }
    }
}