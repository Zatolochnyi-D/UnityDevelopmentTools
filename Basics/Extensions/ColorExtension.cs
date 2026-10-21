using System.Runtime.CompilerServices;
using DenZ.DevelopmentTools.Options;
using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class ColorExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color With(this Color color, Option<float> r = default, Option<float> g = default, Option<float> b = default, Option<float> a = default)
        {
            return new(
                color.r = r.ReadOrDefaultTo(color.r),
                color.g = g.ReadOrDefaultTo(color.g),
                color.b = b.ReadOrDefaultTo(color.b),
                color.a = a.ReadOrDefaultTo(color.a)
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color WithHsv(this Color color, Option<float> h = default, Option<float> s = default, Option<float> v = default)
        {
            Color.RGBToHSV(color, out var thisH, out var thisS, out var thisV);
            return Color.HSVToRGB(
                h.ReadOrDefaultTo(thisH),
                s.ReadOrDefaultTo(thisS),
                v.ReadOrDefaultTo(thisV)
            );
        }
    }
}