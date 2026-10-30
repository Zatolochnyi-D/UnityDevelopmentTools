using System;
using UnityEngine;

namespace DenZ.DevelopmentTools.Random
{
    public class Randomizer
    {
        private readonly System.Random _random;

        public float Value => Convert.ToSingle(_random.NextDouble());

        public Randomizer()
        {
            _random = new();
        }

        public Randomizer(int seed)
        {
            _random = new(seed);
        }

        public int Range(int minInclusive, int maxExclusive) => _random.Next(minInclusive, maxExclusive);

        public Vector2Int Range(Vector2Int minInclusive, Vector2Int maxExclusive)
        {
            return new(
                _random.Next(minInclusive.x, maxExclusive.x),
                _random.Next(minInclusive.y, maxExclusive.y)
            );
        }

        public Vector2Int Range(Vector2Int maxExclusive) => Range(Vector2Int.zero, maxExclusive);
    }
}