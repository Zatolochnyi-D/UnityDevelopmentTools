using System;
using System.Collections;
using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class MonoBehaviorTimersExtension
    {
        private static IEnumerator SingleUseTimer(Action actionToCall, float seconds, bool useTimeScale)
        {
            yield return useTimeScale ? new WaitForSeconds(seconds) : new WaitForSecondsRealtime(seconds);
            actionToCall.Invoke();
        }

        private static IEnumerator SingleUseTimer(Action actionToCall, int frames)
        {
            for (int i = 0; i < frames; i++) yield return null;
            actionToCall.Invoke();
        }

        private static IEnumerator RepeatableTimer(Action actionToCall, float seconds, bool useTimeScale)
        {
            while (true)
            {
                yield return useTimeScale ? new WaitForSeconds(seconds) : new WaitForSecondsRealtime(seconds);
                actionToCall.Invoke();
            }
        }

        private static IEnumerator RepeatableTimer(Action actionToCall, int frames)
        {
            while (true)
            {
                for (int i = 0; i < frames; i++) yield return null;
                actionToCall.Invoke();
            }
        }

        public static Coroutine InvokeOnce(this MonoBehaviour script, Action actionToCall, float seconds, bool useTimeScale = true)
        {
            return script.StartCoroutine(SingleUseTimer(actionToCall, seconds, useTimeScale));
        }

        public static Coroutine InvokeRepeatedly(this MonoBehaviour script, Action actionToCall, float seconds, bool useScaledTime = true)
        {
            return script.StartCoroutine(RepeatableTimer(actionToCall, seconds, useScaledTime));
        }

        public static Coroutine InvokeOnce(this MonoBehaviour script, Action actionToCall, int frames)
        {
            return script.StartCoroutine(SingleUseTimer(actionToCall, frames));
        }

        public static Coroutine InvokeRepeatedly(this MonoBehaviour script, Action actionToCall, int frames)
        {
            return script.StartCoroutine(RepeatableTimer(actionToCall, frames));
        }
    }
}
