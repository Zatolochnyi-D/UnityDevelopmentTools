using System;
using DenZ.DevelopmentTools.Extensions;
using DenZ.DevelopmentTools.Options;
using UnityEngine;
using Zenject;

namespace DenZ.DevelopmentTools.Di
{
    // Methods should always throw if game object doesn't have GameObjectContext. They are made for it, so why would they be called otherwise?
    public static class GameObjectGetComponentFromContextExtension
    {
        private static GameObjectContext GetContextOrThrow(GameObject gameObject) => gameObject.TryGetComponent<GameObjectContext>().ReadOrThrow(new InvalidOperationException("GameObjectContext was not present on the game object."));

        public static T GetFromContainer<T>(this GameObject gameObject) => GetContextOrThrow(gameObject).Container.Resolve<T>();

        public static Option<T> TryGetFromContainer<T>(this GameObject gameObject) where T : class => Option.FromPossibleNull(GetContextOrThrow(gameObject).Container.TryResolve<T>());

        public static Option<T> TryGetFromPossibleContainerless<T>(this GameObject gameObject) where T : class => Option.FromPossibleNull(gameObject.GetComponent<GameObjectContext>()).Bind(x => Option.FromPossibleNull(x.Container.TryResolve<T>()));
    }
}