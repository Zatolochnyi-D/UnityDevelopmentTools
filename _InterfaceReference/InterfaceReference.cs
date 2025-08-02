using System;
using ThreeDent.DevelopmentTools.InterfaceReference.Exceptions;
using UnityEngine;

namespace ThreeDent.DevelopmentTools.InterfaceReference
{
    [Serializable]
    public class InterfaceReference<T> where T : class
    {
        private static void ThrowIfTypeIsNotAnInterface()
        {
            if (!typeof(T).IsInterface)
                throw new NotAnInterfaceException($"Interface Reference got type \"{typeof(T)}\", which is not an interface.");
        }

        [SerializeField] private MonoBehaviour script; // Due to property drawer (source of this value), this field implements interface T or is null.
        private readonly Lazy<T> thisInterface;

        public GameObject GameObject => script != null ? script.gameObject : null;
        public T Interface => thisInterface.Value;

        public InterfaceReference()
        {
            ThrowIfTypeIsNotAnInterface();
            Lazy<T> val = new(() => script as T);
        }
    }
}