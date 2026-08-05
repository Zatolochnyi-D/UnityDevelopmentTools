using UnityEngine;
using Zenject;

namespace DenZ.DevelopmentTools.Di
{
    public static class GameObjectGetComponentExtension
    {
        public static T GetFromContainer<T>(this GameObject gameObject)
        {
            var container = gameObject.GetComponent<Context>().Container;
            return container.Resolve<T>();
        }

        public static bool TryGetFromContainer<T>(this GameObject gameObject, out T component) where T : class
        {
            var isContainerPresent = gameObject.TryGetComponent(out Context context);
            if (isContainerPresent)
            {
                var receivedComponent = context.Container.TryResolve<T>();
                if (receivedComponent != null)
                {
                    component = receivedComponent;
                    return true;
                }
            }
            component = null;
            return false;
        }
    }
}