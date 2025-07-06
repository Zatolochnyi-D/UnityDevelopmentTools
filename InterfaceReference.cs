using ThreeDent.DevelopmentTools.Exceptions;
using UnityEngine;

namespace ThreeDent.DevelopmentTools
{
    [System.Serializable]
    public class InterfaceReference<T> where T : class
    {
        private static void ThrowIfTypeIsNotAnInterface()
        {
            if (!typeof(T).IsInterface)
                throw new NotAnInterfaceException($"Interface Reference got type \"{typeof(T)}\", which is not an interface.");
        }

        [SerializeField] private MonoBehaviour script; // Due to property drawer (source this value), this field implements interface T or is null.
        private T thisInterface;

        public GameObject GameObject => script != null ? script.gameObject : null;

        public InterfaceReference()
        {
            ThrowIfTypeIsNotAnInterface();
        }

        public T GetInterface()
        {
            thisInterface ??= script as T;
            return thisInterface;
        }
    }
}