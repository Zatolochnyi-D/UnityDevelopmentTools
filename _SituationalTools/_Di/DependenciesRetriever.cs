using UnityEngine;
using Zenject;

namespace Apartment664.Universal
{
    public class DependenciesRetriever : MonoBehaviour
    {
        [Inject] private DiContainer _container;

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}