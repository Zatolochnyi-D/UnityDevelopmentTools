using DenZ.DevelopmentTools.Options;
using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class ColorExtension
    {
        public static Color With(this Color color, Option<float> r = default, Option<float> g = default, Option<float> b = default, Option<float> a = default)
        {
            color.r = r.ReadOrDefault(color.r);
            color.g = g.ReadOrDefault(color.g);
            color.b = b.ReadOrDefault(color.b);
            color.a = a.ReadOrDefault(color.a);
            return color;
        }

        public static Color WithHsv(this Color color, Option<float> h = default, Option<float> s = default, Option<float> v = default)
        {
            Color.RGBToHSV(color, out var thisH, out var thisS, out var thisV);
            thisH = h.ReadOrDefault(thisH);
            thisS = s.ReadOrDefault(thisS);
            thisV = v.ReadOrDefault(thisV);
            return Color.HSVToRGB(thisH, thisS, thisV);
        }
    }
}