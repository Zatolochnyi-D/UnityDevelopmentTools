using System;
using System.Collections.Generic;
using System.Linq;
using DenZ.DevelopmentTools.Monads;

namespace DenZ.DevelopmentTools.Graphs
{
    public static class BfsPathfinding
    {
        public static void ShortestPath<T>(IGraph<T> graph,
                                           T start,
                                           Func<T, bool> endValidationFunction,
                                           Func<Path<T>, bool> outputFunction,
                                           Option<Func<T, bool>> exclusionFunction = default)
        {
            var keysToVisit = new Queue<T>();
            var visitedFromMap = new Dictionary<T, Option<T>>();

            keysToVisit.Enqueue(start);
            visitedFromMap[start] = Option.None<T>();

            while (keysToVisit.Any())
            {
                var currentKey = keysToVisit.Dequeue();

                if (endValidationFunction(currentKey))
                {
                    var to = currentKey;
                    var tailKey = currentKey;
                    var fullPath = new LinkedList<T>();
                    fullPath.AddFirst(tailKey);
                    while (visitedFromMap[tailKey].IsSome)
                    {
                        tailKey = visitedFromMap[tailKey].ValueUnsafe;
                        fullPath.AddFirst(tailKey);
                    }
                    var from = tailKey;
                    var path = new Path<T>(from, to, fullPath);
                    if (!outputFunction(path))
                        return;
                }

                foreach (var neighborKey in graph.GetNeighbors(currentKey))
                {
                    if (exclusionFunction.Map(x => x(neighborKey)).ReadOrDefaultTo(false))
                        continue;

                    if (!visitedFromMap.ContainsKey(neighborKey))
                    {
                        visitedFromMap[neighborKey] = currentKey;
                        keysToVisit.Enqueue(neighborKey);
                    }
                }
            }
        }

        public static Option<Path<T>> ShortestPath<T>(IGraph<T> graph,
                                                             T start,
                                                             T end,
                                                             Option<Func<T, bool>> exclusionFunction = default)
        {
            var result = Option.None<Path<T>>();
            ShortestPath(graph, start, key => end.Equals(key), output => { result = Option.Some(output); return false; }, exclusionFunction);
            return result;
        }

        public static Option<Path<T>> ShortestPath<T>(IGraph<T> graph,
                                                             T start,
                                                             Func<T, bool> endCondition,
                                                             Option<Func<T, bool>> exclusionFunction = default)
        {
            var result = Option.None<Path<T>>();
            ShortestPath(graph, start, endCondition, output => { result = Option.Some(output); return false; }, exclusionFunction);
            return result;
        }

        public static IEnumerable<Path<T>> ShortestPaths<T>(IGraph<T> graph,
                                                                   T start,
                                                                   IEnumerable<T> ends,
                                                                   Option<Func<T, bool>> exclusionFunction = default)
        {
            List<Path<T>> result = new();
            ShortestPath(graph, start, ends.Contains, output => { result.Add(output); return true; }, exclusionFunction);
            return result;
        }

        public static IEnumerable<Path<T>> ShortestPaths<T>(IGraph<T> graph,
                                                                   T start,
                                                                   Func<T, bool> endCondition,
                                                                   Option<Func<T, bool>> exclusionFunction = default)
        {
            List<Path<T>> result = new();
            ShortestPath(graph, start, endCondition, output => { result.Add(output); return true; }, exclusionFunction);
            return result;
        }
    }
}