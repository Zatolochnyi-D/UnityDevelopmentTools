using System;
using UnityEngine.InputSystem;

namespace DenZ.DevelopmentTools.InputSystem
{
    public interface IInputControl
    {
        public event Action OnStarted;
        public event Action OnCanceled;
        public event Action OnPerformed;

        public bool Value { get; }
    }


    public abstract class InputControl : IInputControl
    {
        public event Action OnStarted;
        public event Action OnCanceled;
        public event Action OnPerformed;

        protected InputAction _inputAction;

        public virtual bool Value => _inputAction.ReadValue<float>() == 1f;

        public InputControl(InputAction inputAction)
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

        protected void FireOnPerformed()
        {
            OnPerformed?.Invoke();
        }
    }
}