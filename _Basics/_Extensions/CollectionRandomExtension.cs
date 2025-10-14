using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ThreeDent.DevelopmentTools.Extensions
{
    public static class CollectionRandomExtension
    {
        public static T PeekItem<T>(this IEnumerable<T> collection)
        {
            int length = collection.Count();
            int index = Random.Range(0, length);
            T item = collection.Skip(index).First();
            return item;
        }

        public static T PeekItem<T>(this List<T> collection)
        {
            int index = Random.Range(0, collection.Count);
            T item = collection[index];
            return item;
        }

        public static T PickItem<T>(this List<T> collection)
        {
            int index = Random.Range(0, collection.Count);
            T item = collection[index];
            collection.RemoveAt(index);
            return item;
        }
    }
}