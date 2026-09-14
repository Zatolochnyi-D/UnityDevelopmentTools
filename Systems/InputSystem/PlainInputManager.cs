using System;
using UnityEngine.InputSystem;

namespace DenZ.DevelopmentTools.InputSystem
{
    /// <summary>
    /// Shorthand for custom plain Input Managers (used in DI), that automatically creates instance of Input Actions, provided in
    /// generic parameter.
    /// </summary>
    /// <typeparam name="T">Unity's Input Actions, that will be wrapped by this Input Manager.</typeparam>
    public abstract class PlainInputManager<T> where T : IInputActionCollection2, IDisposable, new()
    {
        protected T Inputs;

        public PlainInputManager()
        {
            Inputs = new();
        }
    }
}