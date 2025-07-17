using System;
using System.Collections;
using UnityEngine;

namespace ThreeDent.DevelopmentTools.Extensions
{
    public static class MonoBehaviorTimersExtension
    {
        // Seconds
        private static IEnumerator SingleUseTimer(Action actionToCall, float seconds, bool useScaledTime)
        {
            yield return useScaledTime ? new WaitForSeconds(seconds) : new WaitForSecondsRealtime(seconds);
            actionToCall.Invoke();
        }

        // Frames
        private static IEnumerator SingleUseTimer(Action actionToCall, int frames)
        {
            for (int i = 0; i < frames; i++) yield return null;
            actionToCall.Invoke();
        }

        // Seconds
        private static IEnumerator RepeatableTimer(Action actionToCall, float seconds, bool useScaledTime)
        {
            while (true)
            {
                yield return useScaledTime ? new WaitForSeconds(seconds) : new WaitForSecondsRealtime(seconds);
                actionToCall.Invoke();
            }
        }

        // Frames
        private static IEnumerator RepeatableTimer(Action actionToCall, int frames)
        {
            while (true)
            {
                for (int i = 0; i < frames; i++) yield return null;
                actionToCall.Invoke();
            }
        }

        /// <summary>
        /// Creates coroutine on this object that calls action after specified seconds.
        /// </summary>
        /// <param name="useScaledTime">Defines if the timer is affected by Time.timeScale.</param>
        /// <returns>Created coroutine.</returns>
        public static Coroutine InvokeOnce(this MonoBehaviour script, Action actionToCall, float seconds, bool useScaledTime = true)
        {
            return script.StartCoroutine(SingleUseTimer(actionToCall, seconds, useScaledTime));
        }

        /// <summary>
        /// Creates coroutine on this object that calls action after specified seconds repeatedly.
        /// </summary>
        /// <param name="useScaledTime">Defines if the timer is affected by Time.timeScale.</param>
        /// <returns>Created coroutine.</returns>
        public static Coroutine InvokeRepeatedly(this MonoBehaviour script, Action actionToCall, float seconds, bool useScaledTime = true)
        {
            return script.StartCoroutine(RepeatableTimer(actionToCall, seconds, useScaledTime));
        }

        /// <summary>
        /// Creates coroutine on this object that calls action after specified amount of frames.
        /// </summary>
        /// <returns>Created coroutine.</returns>
        public static Coroutine InvokeOnce(this MonoBehaviour script, Action actionToCall, int frames)
        {
            return script.StartCoroutine(SingleUseTimer(actionToCall, frames));
        }

        /// <summary>
        /// Creates coroutine on this object that calls action after specified amount of frames repeatedly.
        /// </summary>
        /// <returns>Created coroutine.</returns>
        public static Coroutine InvokeRepeatedly(this MonoBehaviour script, Action actionToCall, int frames)
        {
            return script.StartCoroutine(RepeatableTimer(actionToCall, frames));
        }
    }
}
