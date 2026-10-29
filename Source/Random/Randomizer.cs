using System;

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
    }
}