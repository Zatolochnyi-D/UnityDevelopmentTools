using System;
using System.Threading;
using UnityEngine;

namespace DenZ.DevelopmentTools.Utilities
{
    public static class Timers
    {
        public static async Awaitable InvokeOnce(Action actionToCall, float seconds, CancellationToken token = default)
        {
            await Awaitable.WaitForSecondsAsync(seconds, token);
            if (token.IsCancellationRequested)
                return;
            actionToCall.Invoke();
        }

        public static async Awaitable InvokeOnce(Action actionToCall, int frames, CancellationToken token = default)
        {
            for (int i = 0; i < frames; i++)
            {
                await Awaitable.NextFrameAsync(token);                
                if (token.IsCancellationRequested)
                    return;
            }
            actionToCall.Invoke();
        }
    }
}