using System;

namespace DenZ.DevelopmentTools.InputSystem
{
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
}