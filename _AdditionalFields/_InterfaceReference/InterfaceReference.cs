using System;
using UnityEngine;

namespace DenZ.DevelopmentTools.InterfaceReference
{
    [Serializable]
    public class InterfaceReference<T> where T : class
    {
        [SerializeField] private MonoBehaviour script; // Due to property drawer (source of this value), this field implements interface T or is null.
        private readonly Lazy<T> thisInterface;

        public GameObject GameObject => script != null ? script.gameObject : null;
        public T Interface => thisInterface.Value;

        public InterfaceReference()
        {
            thisInterface = new(() => script as T);
        }
    }
}