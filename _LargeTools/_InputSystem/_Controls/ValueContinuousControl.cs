using UnityEngine;
using UnityEngine.InputSystem;

namespace DenZ.DevelopmentTools.InputSystem
{
    public class ValueContinuousControl<T> : InputControl<T> where T : struct
    {
        public ValueContinuousControl(InputAction inputAction) : base(inputAction)
        {
            FireContinuously();
        }

        private async void FireContinuously()
        {
            while (true)
            {
                FireOnPerformed(Value);
                await Awaitable.NextFrameAsync();
            }
        }
    }
}