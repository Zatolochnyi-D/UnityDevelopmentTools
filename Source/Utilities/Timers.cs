using System;
using System.Threading;
using UnityEngine;

namespace DenZ.DevelopmentTools.Utilities
{
    public static class Timers
    {
        public static async Awaitable InvokeEachFrameIndefinitely(Action actionToCall, CancellationToken token = default, bool callOnStart = false)
        {
            if (callOnStart)
                actionToCall.Invoke();
            while (!token.IsCancellationRequested)
            {
                await Awaitable.NextFrameAsync(token);
                actionToCall.Invoke();
            }
        }

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
                await Awaitable.NextFrameAsync(token);
            if (token.IsCancellationRequested)
                return;
            actionToCall.Invoke();
        }

        public static async Awaitable InvokeIndefinitely(Action actionToCall, float seconds, CancellationToken token = default, bool callOnStart = false)
        {
            if (callOnStart)
                actionToCall.Invoke();
            while (!token.IsCancellationRequested)
            {
                await Awaitable.WaitForSecondsAsync(seconds, token);
                actionToCall.Invoke();
            }
        }
    }
}