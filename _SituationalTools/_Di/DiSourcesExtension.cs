using System;
using DenZ.DevelopmentTools.Options;
using UnityEngine;
// using UnityEngine.AddressableAssets;
using Zenject;

namespace DenZ.DevelopmentTools.Di
{
    public static class DiSourcesExtension
    {
        public static ScopeConcreteIdArgConditionCopyNonLazyBinder FromMarker<TComponent, TWrapper, TMarker>(this ConcreteIdBinderGeneric<TWrapper> binder,
                                                                                                             GameObject markerSource,
                                                                                                             Func<TComponent, TWrapper> factory)
            where TComponent : Component
            where TWrapper : TypeWrapper<TComponent>
            where TMarker : ComponentMarker<TComponent>
        {
            return binder.FromMethod(() =>
            {
                var component = Option.FromPossibleNull(markerSource.GetComponentInChildren<TMarker>())
                                      .ReadOrThrow(new ZenjectException($"Marker {typeof(TMarker)} was not attached"))
                                      .Component;
                return factory(component);
            });
        }

        public static ScopeConcreteIdArgConditionCopyNonLazyBinder FromMarkerInHierarchy<TComponent, TWrapper, TMarker>(this ConcreteIdBinderGeneric<TWrapper> binder,
                                                                                                                        Func<TComponent, TWrapper> factory)
            where TComponent : Component
            where TWrapper : TypeWrapper<TComponent>
            where TMarker : ComponentMarker<TComponent>
        {
            return binder.FromMethod(() =>
            {
                var component = Option.FromPossibleNull(UnityEngine.Object.FindAnyObjectByType<TMarker>())
                                      .ReadOrThrow(new ZenjectException($"Marker {typeof(TMarker)} was not attached"))
                                      .Component;
                return factory(component);
            });
        }

        // TODO: find a way to avoid strings.
        // public static ScopeConcreteIdArgConditionCopyNonLazyBinder FromAddressable<T>(this ConcreteBinderGeneric<T> binder)
        // {
        //     return binder.FromMethod(() =>
        //     {
        //         return Addressables.LoadAssetAsync<T>(typeof(T).Name).WaitForCompletion();
        //     });
        // }

        // public static ScopeConcreteIdArgConditionCopyNonLazyBinder FromAddressablePrefab<TWrapper>(this ConcreteBinderGeneric<TWrapper> binder, Func<GameObject, TWrapper> factory)
        // {
        //     return binder.FromMethod(() =>
        //     {
        //         return factory(Addressables.LoadAssetAsync<GameObject>(typeof(TWrapper).Name).WaitForCompletion());
        //     });
        // }
    }
}