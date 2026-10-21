using DenZ.DevelopmentTools.Options;
using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class ColorExtension
    {
        public static Color With(this Color color, Option<float> r = default, Option<float> g = default, Option<float> b = default, Option<float> a = default)
        {
            color.r = r.ReadOrDefaultTo(color.r);
            color.g = g.ReadOrDefaultTo(color.g);
            color.b = b.ReadOrDefaultTo(color.b);
            color.a = a.ReadOrDefaultTo(color.a);
            return color;
        }

        public static Color WithHsv(this Color color, Option<float> h = default, Option<float> s = default, Option<float> v = default)
        {
            Color.RGBToHSV(color, out var thisH, out var thisS, out var thisV);
            thisH = h.ReadOrDefaultTo(thisH);
            thisS = s.ReadOrDefaultTo(thisS);
            thisV = v.ReadOrDefaultTo(thisV);
            return Color.HSVToRGB(thisH, thisS, thisV);
        }
    }
}