using System;
using UnityEngine;

namespace DenZ.DevelopmentTools.Di
{
    public abstract class ComponentMarker<T, TWrapper> : MonoBehaviour where T : Component where TWrapper : TypeWrapper<T>
    {
        public T Component
        {
            get
            {
                if (TryGetComponent<T>(out var component))
                    return component;
                else
                    throw new InvalidOperationException($"Marker {GetType()} failed to get component from its Game Object.");
            }
        }

        public abstract TWrapper WrappedComponent { get; }
    }
}