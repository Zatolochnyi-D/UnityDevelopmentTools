using UnityEngine;

namespace ThreeDent.DevelopmentTools.ObjectPooling
{
    public class GameObjectPool : ConfigurableObjectPool<GameObject>
    {
        private readonly GameObject original;
        private readonly Transform parent;

        public GameObjectPool(GameObject original, Transform parent = null, bool collectionCheck = true, int defaultCapacity = 0, int maxSize = int.MaxValue) : base(collectionCheck, defaultCapacity, maxSize)
        {
            this.original = original;
            this.parent = parent;
        }

        protected override GameObject OnCreate()
        {
            var newInstance = Object.Instantiate(original, parent);
            newInstance.SetActive(false);
            return newInstance;
        }

        protected override void OnGet(GameObject instance)
        {
            instance.SetActive(true);
        }

        protected override void OnRelease(GameObject instance)
        {
            instance.SetActive(false);
            instance.transform.parent = parent;
        }

        protected override void OnDestroy(GameObject instance)
        {
            Object.Destroy(instance);
        }
    }
}