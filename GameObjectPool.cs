using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ThreeDent.DevelopmentTools
{
    /// <summary>
    /// Class for simple pool operations. Returns copies of given object on request. If no objects in pool, creates new copy to return.
    /// <br/> If object is in pool is determined by it's "active" flag (false - in pool).
    /// </summary>
    public class GameObjectPool
    {
        private readonly GameObject original;
        private readonly List<GameObject> pool = new();
        private readonly Transform parent;

        public GameObjectPool(GameObject original, int amountToPreInit = 0, Transform parent = null)
        {
            this.original = original;
            this.parent = parent;
            for (int i = 0; i < amountToPreInit; i++)
                CreateNew();
        }

        private GameObject CreateNew()
        {
            GameObject instantiatedObject = Object.Instantiate(original, parent);
            instantiatedObject.SetActive(false);
            pool.Add(instantiatedObject);
            return instantiatedObject;
        }

        public GameObject Get()
        {
            GameObject pooledObject = pool.FirstOrDefault(x => !x.activeSelf);
            if (pooledObject == null)
                pooledObject = CreateNew();
            return pooledObject;
        }
    }
}