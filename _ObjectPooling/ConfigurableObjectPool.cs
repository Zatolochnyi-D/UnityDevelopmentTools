using UnityEngine;
using UnityEngine.Pool;

namespace ThreeDent.DevelopmentTools.ObjectPooling
{
    public abstract class ConfigurableObjectPool<T> where T : class
    {
        protected IObjectPool<T> pool;

        public ConfigurableObjectPool(bool collectionCheck, int defaultCapacity, int maxSize)
        {
            pool = new ObjectPool<T>(OnCreate, OnGet, OnRelease, OnDestroy, collectionCheck, defaultCapacity, maxSize);
        }

        protected abstract T OnCreate();

        protected abstract void OnGet(T instance);

        protected abstract void OnRelease(T instance);

        protected abstract void OnDestroy(T instance);

        public virtual T Get()
        {
            return pool.Get();
        }

        public virtual PooledObject<T> GetSelfreturnable()
        {
            return pool.Get(out _);
        }

        public virtual void Release(T instance)
        {
            pool.Release(instance);
        }
    }
}