using System;
using UnityEngine.InputSystem;

namespace DenZ.DevelopmentTools.InputSystem
{
    public interface IInputControl<T> where T : struct
    {
        public event Action OnStarted;
        public event Action OnCanceled;
        public event Action<T> OnPerformed;

        public T Value { get; }
    }
    

    public abstract class InputControl<T> : IInputControl<T> where T : struct
    {
        public event Action OnStarted;
        public event Action OnCanceled;
        public event Action<T> OnPerformed;

        protected InputAction _inputAction;

        public virtual T Value => _inputAction.ReadValue<T>();

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

        protected void FireOnPerformed(T args)
        {
            OnPerformed?.Invoke(args);
        }
    }
}