using System.Runtime.CompilerServices;
using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class LayerMaskExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this int objectLayer, LayerMask layerMask) => (layerMask & (1 << objectLayer)) == 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this int objectLayer, LayerMask layerMask) => !objectLayer.NotIn(layerMask);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this LayerMask layerMask, int objectLayer) => objectLayer.NotIn(layerMask);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this LayerMask layerMask, int objectLayer) => objectLayer.In(layerMask);
    }
}
