using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DenZ.DevelopmentTools.InputSystem
{
    public class ButtonHoldControl : InputControl
    {
        private CancellationTokenSource _eventCancellation;
        private readonly Func<CancellationToken, Awaitable> waitingFunc;

        public ButtonHoldControl(InputAction inputAction, UpdateType updateType = UpdateType.Default) : base(inputAction)
        {
            _inputAction.performed += (_) => Start();
            _inputAction.canceled += (_) => Cancel();
            waitingFunc = updateType switch
            {
                UpdateType.Default => Awaitable.NextFrameAsync,
                UpdateType.Fixed => Awaitable.FixedUpdateAsync,
                _ => throw FastExeptions.NonExistentEnumValue<UpdateType>(),
            };
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

        private async void FireContinuously(CancellationToken token)
        {
            while (true)
            {
                if (token.IsCancellationRequested)
                    return;
                FireOnPerformed();
                await waitingFunc(default);
            }
        }
    }
}