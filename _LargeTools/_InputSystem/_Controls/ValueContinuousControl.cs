using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DenZ.DevelopmentTools.InputSystem
{
    public class ValueContinuousControl<T> : InputControl<T> where T : struct
    {
        private readonly Func<CancellationToken, Awaitable> waitingFunc;

        public ValueContinuousControl(InputAction inputAction, UpdateType updateType = UpdateType.Default) : base(inputAction)
        {
            waitingFunc = updateType switch
            {
                UpdateType.Default => Awaitable.NextFrameAsync,
                UpdateType.Fixed => Awaitable.FixedUpdateAsync,
                _ => throw FastExeptions.NonExistentEnumValue<UpdateType>(),
            };
            FireContinuously();
        }

        private async void FireContinuously()
        {
            while (true)
            {
                FireOnPerformed(Value);
                await waitingFunc(default);
            }
        }
    }
}