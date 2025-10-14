using ThreeDent.DevelopmentTools.Singleton.Exceptions;
using UnityEngine;

namespace ThreeDent.DevelopmentTools.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;

        public static T Instance => instance ?? throw new SingletonMissingException($"Singleton {typeof(T)} does not exist currently. Check if it calls base.Awake() or exists on scene.");

        protected virtual void Awake()
        {
            if (instance == null)
                instance = (T)this;
            else
                Debug.LogWarning($"There is already one instance of {typeof(T)}. Make sure there are no duplicates.");
        }
    }
}