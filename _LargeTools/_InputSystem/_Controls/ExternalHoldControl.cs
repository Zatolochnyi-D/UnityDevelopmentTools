using System;
using System.Threading;
using UnityEngine;

namespace DenZ.DevelopmentTools.InputSystem
{
    public class ExternalHoldControl<T> : IInputControl<T> where T : struct
    {
        public event Action OnStarted;
        public event Action OnCanceled;
        public event Action<T> OnPerformed;

        private readonly Func<T> _valueGetter;
        private readonly Func<CancellationToken, Awaitable> _waitMethod;
        private T _previousValue;

        public T Value => _valueGetter();

        public ExternalHoldControl(Func<T> valueGetter, UpdateType updateType = UpdateType.Default)
        {
            _valueGetter = valueGetter;
            _waitMethod = InputSystemUtils.GetWaitMethodFactory(updateType);
            CheckForChangesContinuouslyAsync();
        }

        private async void CheckForChangesContinuouslyAsync()
        {
            while (true)
            {
                var value = _valueGetter();
                if (!_previousValue.Equals(value))
                {
                    if (value.Equals(default))
                    {
                        OnCanceled?.Invoke();
                    }
                    else
                    {
                        OnStarted?.Invoke();
                    }
                }
                else if (!value.Equals(default))
                {
                    OnPerformed?.Invoke(value);
                }

                _previousValue = value;
                await _waitMethod(default);
            }
        }
    }
}