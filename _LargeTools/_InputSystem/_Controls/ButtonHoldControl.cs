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
                await Awaitable.NextFrameAsync();
            }
        }
    }
}