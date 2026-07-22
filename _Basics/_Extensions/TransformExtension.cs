using UnityEngine;

public static class TransformExtension
{
    public static void DestroyChildren(this Transform transform)
    {
        while (transform.childCount != 0)
            Object.Destroy(transform.gameObject);
    }

    public static void DestroyChildrenImmediate(this Transform transform)
    {
        while (transform.childCount != 0)
            Object.DestroyImmediate(transform.GetChild(0).gameObject);
    }
}