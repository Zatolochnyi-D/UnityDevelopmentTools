using System.Runtime.CompilerServices;
using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class LayerMaskExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this int objectLayer, LayerMask layerMask)
        {
            var objectLayerMask = 1 << objectLayer;
            return (layerMask & objectLayerMask) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this int objectLayer, LayerMask layerMask)
        {
            return !objectLayer.NotIn(layerMask);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NotIn(this LayerMask layerMask, int objectLayer)
        {
            return objectLayer.NotIn(layerMask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool In(this LayerMask layerMask, int objectLayer)
        {
            return objectLayer.In(layerMask);
        }
    }
}
