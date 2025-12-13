using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DenZ.DevelopmentTools.InputSystem
{
    public class ButtonHoldControl : InputControl
    {
        private CancellationTokenSource _eventCancellation;

        public ButtonHoldControl(InputAction inputAction) : base(inputAction)
        {
            _inputAction.performed += (_) => Start();
            _inputAction.canceled += (_) => Cancel();
        }

        private void Start()
        {
            _eventCancellation?.Cancel();
            _eventCancellation = new();
            FireContinuously(_eventCancellation.Token, Awaitable.NextFrameAsync, FireOnPerformed);
            FireContinuously(_eventCancellation.Token, Awaitable.FixedUpdateAsync, FireOnPerformedFixed);
        }

        private void Cancel()
        {
            _eventCancellation?.Cancel();
        }

        private async void FireContinuously(CancellationToken token, Func<CancellationToken, Awaitable> waitingFunc, Action callback)
        {
            while (true)
            {
                if (token.IsCancellationRequested)
                    return;
                callback();
                await waitingFunc(default);
            }
        }
    }
}