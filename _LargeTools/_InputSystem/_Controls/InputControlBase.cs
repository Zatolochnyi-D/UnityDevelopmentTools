using System;
using UnityEngine.InputSystem;

namespace DenZ.DevelopmentTools.InputSystem
{
    public abstract class InputControlBase
    {
        public event Action OnStarted;
        public event Action OnCanceled;

        protected InputAction _inputAction;

        public InputControlBase(InputAction inputAction)
        {
            _inputAction = inputAction;
            _inputAction.performed += (_) => FireOnStarted();
            _inputAction.canceled += (_) => FireOnCanceled();
        }

        protected void FireOnStarted()
        {
            OnStarted?.Invoke();
        }

        protected void FireOnCanceled()
        {
            OnCanceled?.Invoke();
        }
    }
}