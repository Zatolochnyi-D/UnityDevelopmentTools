using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DenZ.DevelopmentTools.InputSystem
{
    public class ValueContinuousControl<T> : InputControl<T> where T : struct
    {
        private readonly Func<CancellationToken, Awaitable> _waitMethod;

        public ValueContinuousControl(InputAction inputAction, UpdateType updateType = UpdateType.Default) : base(inputAction)
        {
            _waitMethod = InputSystemUtils.GetWaitMethodFactory(updateType);
            FireContinuously();
        }

        private async void FireContinuously()
        {
            while (true)
            {
                FireOnPerformed(Value);
                await _waitMethod(default);
            }
        }
    }
}