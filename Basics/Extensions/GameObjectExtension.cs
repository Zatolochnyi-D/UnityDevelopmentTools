using DenZ.DevelopmentTools.Options;
using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class GameObjectExtension
    {
        public static Option<T> TryGetComponent<T>(this GameObject gameObject) where T : class
        {
            return Option.FromPossibleNull(gameObject.GetComponent<T>());
        }
    }
}