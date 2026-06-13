using System;

namespace DenZ.DevelopmentTools.InputSystem
{
    // Create interfaces by combining the ones with needed functionality.

    public interface IAction
    {
        public event Action OnInitiated;
        public event Action OnStarted;
        public event Action OnCanceled;
    }

    public interface IPerformableAction
    {
        public event Action OnPerformed;
    }

    public interface IPerformableAction<T> where T : struct
    {
        public event Action<T> OnPerformed;
    }

    public interface IFinishableAction
    {
        public event Action OnFinished;
    }

    public interface IFinishableAction<T> where T : struct
    {
        public event Action<T> OnFinished;
    }

    public interface IReadableAction<T> where T : struct
    {
        public T Value { get; }
    }

    public interface IActionWithPerformAndFinish<T> : IAction, IPerformableAction<T>, IFinishableAction<T> where T : struct { }

    // Reuse those comments.

    /// <summary>
    /// Interface that defines Input Action in this Input System.
    /// </summary>
    /// <summary>
    /// When user starts an input action, e.g. presses the button. Equivalent to "started" in Unity's Input System.
    /// </summary>
    /// <summary>
    /// When user satisfies condition to trigger an action, e.g. holds button for 0.5 seconds. Equivalent to "performed" in Unity's Input System.
    /// </summary>
    /// <summary>
    /// When user cancels input action, e.g. releases a button. Equivalent to "canceled" in Unity's Input System.
    /// </summary>
    /// <summary>
    /// When action completes to do what it is supposed to do. It's up to your interpretation - fire it every frame while button supposed to be
    /// held is held, or when action that consists of multiple stages, like drag'n'drop, is completed.
    /// </summary>
    /// <summary>
    /// Defines Input Action that should also return value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <summary>
    /// When action completes and should return value as well.
    /// </summary>
    /// <summary>
    /// Defines Input Action that should both return value on when performed (performed constantly) and on finish (with the last perform).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <summary>
    /// When action is finished.
    /// </summary>
}