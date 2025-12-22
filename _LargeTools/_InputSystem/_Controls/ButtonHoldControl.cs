using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DenZ.DevelopmentTools.InputSystem
{
    public class ButtonHoldControl : InputControl
    {
        private readonly Func<CancellationToken, Awaitable> _waitMethod;
        private CancellationTokenSource _eventCancellation;

        public ButtonHoldControl(InputAction inputAction, UpdateType updateType = UpdateType.Default) : base(inputAction)
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

        private async void FireContinuously(CancellationToken token)
        {
            while (true)
            {
                if (token.IsCancellationRequested)
                    return;
                FireOnPerformed(Value);
                await _waitMethod(default);
            }
        }
    }
}