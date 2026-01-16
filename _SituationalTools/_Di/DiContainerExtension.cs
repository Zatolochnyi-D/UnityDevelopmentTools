using System;
using UnityEngine;
using Zenject;

namespace Apartment664.Universal
{
    public static class DiContainerExtension
    {
        public static void BindMonoBehaviourService<T>(this DiContainer container) where T : Component
        {
            container.Bind<T>()
                     .To<T>()
                     .FromNewComponentOnNewGameObject()
                     .AsSingle()
                     .NonLazy();
        }

        public static void BindMonoBehaviourService<T>(this DiContainer container, Action<InjectContext, T> onInstantiated) where T : Component
        {
            container.Bind<T>()
                     .To<T>()
                     .FromNewComponentOnNewGameObject()
                     .AsSingle()
                     .OnInstantiated(onInstantiated)
                     .NonLazy();
        }
    }
}