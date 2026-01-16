using System;
using UnityEngine;

namespace Apartment664.Universal
{
    public abstract class ComponentMarker<T> : MonoBehaviour where T : Component
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
    }
}