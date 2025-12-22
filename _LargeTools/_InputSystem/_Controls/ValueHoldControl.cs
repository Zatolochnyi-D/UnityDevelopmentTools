using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DenZ.DevelopmentTools.InputSystem
{
    public class ValueHoldControl<T> : InputControl<T> where T : struct
    {
        private readonly Func<CancellationToken, Awaitable> _waitMethod;
        private CancellationTokenSource _eventCancellation;

        public ValueHoldControl(InputAction inputAction, UpdateType updateType = UpdateType.Default) : base(inputAction)
        {
            _inputAction.performed += (_) => Start();
            _inputAction.canceled += (_) => Cancel();
            _waitMethod = InputSystemUtils.GetWaitMethodFactory(updateType);
        }

        private void Start()
        {
            _eventCancellation?.Cancel();
            _eventCancellation = new();
            FireContinuously(_eventCancellation.Token);
        }

        private void Cancel()
        {
            _eventCancellation?.Cancel();
        }

        private async void FireContinuously(CancellationToken cancellationToken)
        {
            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                    return;
                FireOnPerformed(Value);
                await _waitMethod(default);
            }
        }
    }
}