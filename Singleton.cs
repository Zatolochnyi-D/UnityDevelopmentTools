using ThreeDent.DevelopmentTools.Exceptions;
using UnityEngine;

namespace ThreeDent.DevelopmentTools
{
    /// <summary>
    /// Class that handles singleton set up.
    /// </summary>
    /// <typeparam name="T">Class that inherits singleton.</typeparam>
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;

        /// <exception cref="SingletonMissingException">Thrown when singleton was not created at the moment of calling this getter.</exception>
        public static T Instance
        { 
            get => instance ?? throw new SingletonMissingException($"Singleton {typeof(T)} does not exist currently. Check if you have created it.");
        }

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = (T)this;
            }
            else
            {
                Debug.LogWarning($"There is already one instance of {typeof(T)}. Make sure there are no duplicates.");
            }
        }
    }
}