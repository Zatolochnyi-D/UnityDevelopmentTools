using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class TransformExtension
    {
        public static void DestroyChildren(this Transform transform)
        {
            foreach (Transform child in transform)
                Object.Destroy(child.gameObject);
        }

        public static void DestroyChildrenImmediate(this Transform transform)
        {
            while (transform.childCount != 0)
                Object.DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
}