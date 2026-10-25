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
            var index = randomizer.ReadOrNew().Range(0, collection.Count());
            return collection.ElementAt(index);
        }



        public static T PeekItem<T>(this IList<T> collection, Option<Randomizer> randomizer = default)
        {
            var index = randomizer.ReadOrNew().Range(0, collection.Count);
            return collection[index];
        }

        public static T PickItem<T>(this IList<T> collection, Option<Randomizer> randomizer = default)
        {
            var index = randomizer.ReadOrNew().Range(0, collection.Count);
            var item = collection[index];
            collection.RemoveAt(index);
            return item;
        }
    }
}