using UnityEngine;

namespace ThreeDent.DevelopmentTools.Extensions
{
    public static class LayerMaskExtension
    {
        public static bool NotIn(this int objectLayer, LayerMask layerMask)
        {
            var objectLayerMask = 1 << objectLayer;
            return (layerMask & objectLayerMask) == 0;
        }

        public static bool In(this int objectLayer, LayerMask layerMask)
        {
            return !objectLayer.NotIn(layerMask);
        }
        
        public static bool NotIn(this LayerMask layerMask, int objectLayer)
        {
            return objectLayer.NotIn(layerMask);
        }

        public static bool In(this LayerMask layerMask, int objectLayer)
        {
            return objectLayer.In(layerMask);
        }
    }
}
