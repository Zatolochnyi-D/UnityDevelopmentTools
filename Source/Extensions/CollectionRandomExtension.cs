using System.Collections.Generic;
using System.Linq;
using DenZ.DevelopmentTools.Options;
using DenZ.DevelopmentTools.Random;


namespace DenZ.DevelopmentTools.Extensions
{
    public static class CollectionRandomExtension
    {
        public static T PeekItem<T>(this IEnumerable<T> collection, Option<Randomizer> randomizer = default)
        {
            var r = randomizer.ReadOrNew();
            int index = r.Range(0, collection.Count());
            return collection.Skip(index).First();
        }

        public static T PeekItem<T>(this List<T> collection)
        {
            int index = UnityEngine.Random.Range(0, collection.Count);
            T item = collection[index];
            return item;
        }

        public static T PickItem<T>(this List<T> collection)
        {
            int index = UnityEngine.Random.Range(0, collection.Count);
            T item = collection[index];
            collection.RemoveAt(index);
            return item;
        }
    }
}