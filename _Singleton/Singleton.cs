using ThreeDent.DevelopmentTools.Singleton.Exceptions;
using UnityEngine;

namespace ThreeDent.DevelopmentTools.Singleton
{
    /// <summary>
    /// Class that handles singleton set up.
    /// </summary>
    /// <typeparam name="T">Class that inherits singleton.</typeparam>
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;

        /// <exception cref="SingletonMissingException">Thrown when singleton was not created at the moment of calling this getter.</exception>
        public static T Instance => instance ?? throw new SingletonMissingException($"Singleton {typeof(T)} does not exist currently. Check if it calls base.Awake() or at least exists on scene.");

        protected virtual void Awake()
        {
            if (instance == null)
                instance = (T)this;
            else
                Debug.LogWarning($"There is already one instance of {typeof(T)}. Make sure there are no duplicates.");
        }
    }
}