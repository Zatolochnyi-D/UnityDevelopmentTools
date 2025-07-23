using System;
using System.Collections.Generic;
using ThreeDent.DevelopmentTools.Options;
using UnityEngine;

namespace ThreeDent.DevelopmentTools.Linqnt
{
    public readonly struct Iterator<TInput, TOutput> //where TInput : Option<TInput> where TOutput : Option<TOutput>
    {
        private readonly IEnumerable<TInput> values;
        private readonly Func<TInput, TOutput> converter;

        public Iterator(IEnumerable<TInput> values, Func<TInput, TOutput> converter)
        {
            this.values = values;
            this.converter = converter;
        }

        public readonly Iterator<TInput, TNewResult> ComposeConverters<TNewResult>(Func<TOutput, TNewResult> newConverter) where TNewResult : Option<TNewResult>
        {
            var converterFunc = converter;
            return new Iterator<TInput, TNewResult>(values, x => newConverter(converterFunc(x)));
        }

        public readonly IEnumerable<TOutput> GetResult()
        {
            foreach (var value in values)
            {
                yield return converter(value);
            }
        }
    }

    public class Tester
    {
        public static List<int> values = new List<int>() { 1, 2, 3, 4, 5 };

        public void Test()
        {
            // var conv = new Iter<int, string>(values, ConvertionFuncs.ToString);
            // var conv2 = conv.CombineIters(ConvertionFuncs.AddSuffix);
            // var conv3 = conv2.CombineIters(ConvertionFuncs.Parse);
            // foreach (var res in conv.GetResult())
            //     Debug.Log($"{res} - {res.GetType()}");
            // Debug.Log("-----");
            // foreach (var res in conv2.GetResult())
            //     Debug.Log($"{res} - {res.GetType()}");
            // Debug.Log("-----");
            // foreach (var res in conv3.GetResult())
            //     Debug.Log($"{res} - {res.GetType()}");
        }
    }

    public static class Linqnt
    {
        public static Iterator<TInput, TOutput> Select<TInput, TOutput>(this IEnumerable<TInput> collection, Func<TInput, TOutput> selector)
        {
            return new Iterator<TInput, TOutput>(collection, selector);
        }

        // public static Iterator<TInput, TOutput> Select<TInput, TMiddle, TOutput>(this Iterator<TInput, TMiddle> iterator, Func<TMiddle, TOutput> selector)
        // {
        //     return iterator.ComposeConverters(selector);
        // }

        // public static Iterator<TInput, TOutput> Where<TInput, TOutput>(this Iterator<TInput, TOutput> iterator, Func<TInput, bool> predicate)
        // {

        // }
    }
}
