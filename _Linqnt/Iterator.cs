using System;
using System.Collections;
using System.Collections.Generic;
using ThreeDent.DevelopmentTools.Options;

namespace ThreeDent.DevelopmentTools.Linqnt
{
    public readonly struct Iterator<TInput, TOutput> : IEnumerable<TOutput>
    {
        private readonly IEnumerable<TInput> values;
        private readonly Func<Option<TInput>, Option<TOutput>> converter;

        public Iterator(IEnumerable<TInput> values, Func<Option<TInput>, Option<TOutput>> converter)
        {
            this.values = values;
            this.converter = converter;
        }

        public Iterator<TInput, TNewOutput> ComposeConverters<TNewOutput>(Func<Option<TOutput>, Option<TNewOutput>> newConverter)
        {
            var converterFunc = converter;
            return new Iterator<TInput, TNewOutput>(values, x => newConverter(converterFunc(x)));
        }

        public IEnumerator<TOutput> GetEnumerator()
        {
            foreach (var value in values)
            {
                var result = converter(Option.Some(value));
                if (result is Some<TOutput> x)
                    yield return x.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class Linqnt
    {
        public static Iterator<TInput, TOutput> Select<TInput, TOutput>(this IEnumerable<TInput> collection, Func<TInput, TOutput> selector)
        {
            return new Iterator<TInput, TOutput>(collection, x => x.Map(selector));
        }

        public static Iterator<TInput, TOutput> Select<TInput, TMiddle, TOutput>(this Iterator<TInput, TMiddle> iterator, Func<TMiddle, TOutput> selector)
        {
            return iterator.ComposeConverters(x => x.Map(selector));
        }

        public static Iterator<T, T> Where<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return new Iterator<T, T>(collection, x => x.Filter(predicate));
        }

        public static Iterator<TInput, TOutput> Where<TInput, TOutput>(this Iterator<TInput, TOutput> iterator, Func<TOutput, bool> predicate)
        {
            return iterator.ComposeConverters(x => x.Filter(predicate));
        }
    }   
}
