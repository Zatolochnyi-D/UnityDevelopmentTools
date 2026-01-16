using UnityEngine;
using Zenject;

namespace DenZ.DevelopmentTools.Di
{
    public class DependenciesRetriever : MonoBehaviour
    {
        private DiContainer _container;

        [Inject]
        public void Construct(DiContainer container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}