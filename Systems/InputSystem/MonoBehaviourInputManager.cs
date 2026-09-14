using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DenZ.DevelopmentTools.InputSystem
{
    /// <summary>
    /// Shorthand for custom Input Manager components (attached to GOs), that automatically creates instance of Input Actions,
    /// provided in generic parameter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MonoBehaviourInputManager<T> : MonoBehaviour where T : IInputActionCollection2, IDisposable, new()
    {
        protected T Inputs;

        protected virtual void Awake()
        {
            Inputs = new();
        }
    }
}