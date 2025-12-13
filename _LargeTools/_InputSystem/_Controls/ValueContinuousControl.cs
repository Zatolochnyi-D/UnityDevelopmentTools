using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DenZ.DevelopmentTools.InputSystem
{
    public class ValueContinuousControl<T> : InputControl<T> where T : struct
    {
        public ValueContinuousControl(InputAction inputAction) : base(inputAction)
        {
            FireContinuously(Awaitable.NextFrameAsync, FireOnPerformed);
            FireContinuously(Awaitable.FixedUpdateAsync, FireOnPerformedFixed);
        }

        private async void FireContinuously(Func<CancellationToken, Awaitable> waitingFunc, Action<T> callback)
        {
            while (true)
            {
                callback(Value);
                await waitingFunc(default);
            }
        }
    }
}