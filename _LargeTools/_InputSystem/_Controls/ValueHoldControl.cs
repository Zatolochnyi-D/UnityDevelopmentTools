using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DenZ.DevelopmentTools.InputSystem
{
    public class ValueHoldControl<T> : InputControl<T> where T : struct
    {
        private CancellationTokenSource _eventCancellation;

        public ValueHoldControl(InputAction inputAction) : base(inputAction)
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

        private async void FireContinuously(CancellationToken cancellationToken, Func<CancellationToken, Awaitable> waitingFunc, Action<T> callback)
        {
            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                    return;
                callback(Value);
                await waitingFunc(default);
            }
        }
    }
}