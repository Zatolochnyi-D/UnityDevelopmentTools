using System;

namespace DenZ.DevelopmentTools.InputSystem
{
    public interface IInputControl<T> where T : struct
    {
        public event Action OnInitiated;
        public event Action OnStarted;
        public event Action OnCanceled;
        public event Action<T> OnPerformed;

        public T Value { get; }
    }
}