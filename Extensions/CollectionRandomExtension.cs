using System.Collections.Generic;
using System.Linq;
using DenZ.DevelopmentTools.Math;
using DenZ.DevelopmentTools.Options;
using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public class Randomizer
    {
        private System.Random _random;

        public Randomizer()
        {
            _random = new();
        }

        public Randomizer(int seed)
        {
            _random = new(seed);
        }

        public int Range(int minInclusive, int maxExclusive)
        {
            var randomValue = MathS.Lerp(minInclusive, maxExclusive - 1, (float)_random.NextDouble());
            return Mathf.RoundToInt(randomValue);
        }
    }

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