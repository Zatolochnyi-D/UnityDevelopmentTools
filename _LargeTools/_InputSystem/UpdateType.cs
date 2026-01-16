using System;
using System.Threading;
using UnityEngine;

namespace DenZ.DevelopmentTools.InputSystem
{
    public enum UpdateType
    {
        Default,
        Fixed,
    }

    public static class InputSystemUtils
    {
        public static Func<CancellationToken, Awaitable> GetProperAwaitableWaitMethod(UpdateType updateType)
        {
            return updateType switch
            {
                UpdateType.Default => Awaitable.NextFrameAsync,
                UpdateType.Fixed => Awaitable.FixedUpdateAsync,
                _ => throw FastExeptions.NonExistentEnumValue<UpdateType>(),
            };
        }
    }
}