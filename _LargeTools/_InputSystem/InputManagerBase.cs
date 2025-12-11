using System;
using UnityEngine.InputSystem;

namespace DenZ.DevelopmentTools.InputSystem
{
    public abstract class InputManagerBase<T> where T : IInputActionCollection2, IDisposable, new()
    {
        protected T _inputActions;

        public InputManagerBase()
        {
            _inputActions = new();
        }
    }
}