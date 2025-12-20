using System;
using UnityEngine.InputSystem;

namespace DenZ.DevelopmentTools.InputSystem
{
    public abstract class InputControl : InputControlBase
    {
        public event Action OnPerformed;

        public virtual bool Value => _inputAction.ReadValue<float>() == 1f;

        public InputControl(InputAction inputAction) : base(inputAction) { }

        protected void FireOnPerformed()
        {
            OnPerformed?.Invoke();
        }
    }

    public abstract class InputControl<T> : InputControlBase where T : struct
    {
        public event Action<T> OnPerformed;

        public virtual T Value => _inputAction.ReadValue<T>();

        public InputControl(InputAction inputAction) : base(inputAction) { }

        protected void FireOnPerformed(T args)
        {
            OnPerformed?.Invoke(args);
        }
    }
}