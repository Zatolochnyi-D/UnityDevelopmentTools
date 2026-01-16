using System;
using UnityEngine.InputSystem;

namespace DenZ.DevelopmentTools.InputSystem
{
    public abstract class InputControl<T> : IInputControl<T> where T : struct
    {
        public event Action OnInitiated;
        public event Action OnStarted;
        public event Action OnCanceled;
        public event Action<T> OnPerformed;

        protected InputAction _inputAction;

        public virtual T Value => _inputAction.ReadValue<T>();

        public InputControl(InputAction inputAction)
        {
            _inputAction = inputAction;
            _inputAction.started += (_) => FireOnInitiated();
            _inputAction.performed += (_) => FireOnStarted();
            _inputAction.canceled += (_) => FireOnCanceled();
        }

        protected void FireOnInitiated()
        {
            OnInitiated?.Invoke();
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
    

    public abstract class InputControl : InputControl<bool>
    {
        public override bool Value => _inputAction.ReadValue<float>() == 1f;

        public InputControl(InputAction inputAction) : base(inputAction) { }
    }
}