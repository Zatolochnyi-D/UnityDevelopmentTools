using System;
using System.Collections.Generic;
using System.Linq;
using DenZ.DevelopmentTools.Options;

namespace DenZ.DevelopmentTools.Graphs
{
    public static class BfsPathfinding
    {
        public static void ShortestPath<T>(IGraph<T> graph,
                                           T start,
                                           Func<T, bool> endValidationFunction,
                                           Func<IEnumerable<T>, bool> outputFunction,
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
                    var tailKey = currentKey;
                    var path = new LinkedList<T>();
                    path.AddFirst(tailKey);
                    while (visitedFromMap[tailKey].IsSome)
                    {
                        tailKey = visitedFromMap[tailKey].ValueUnsafe;
                        path.AddFirst(tailKey);
                    }
                    if (!outputFunction(path))
                        return;
                }

                foreach (var neighborKey in graph.GetNeighbors(currentKey))
                {
                    if (exclusionFunction.Map(x => x(neighborKey)).ReadOrDefault(false))
                        continue;
                    
                    if (!visitedFromMap.ContainsKey(neighborKey))
                    {
                        visitedFromMap[neighborKey] = currentKey;
                        keysToVisit.Enqueue(neighborKey);
                    }
                }
            }
        }

        public static Option<IEnumerable<T>> ShortestPath<T>(IGraph<T> graph,
                                                             T start,
                                                             T end,
                                                             Option<Func<T, bool>> exclusionFunction = default)
        {
            var result = Option.None<IEnumerable<T>>();
            ShortestPath(graph, start, key => end.Equals(key), output => { result = Option.Some(output); return false; }, exclusionFunction);
            return result;
        }
        
        public static Option<IEnumerable<T>> ShortestPath<T>(IGraph<T> graph,
                                                             T start,
                                                             Func<T, bool> endCondition,
                                                             Option<Func<T, bool>> exclusionFunction = default)
        {
            var result = Option.None<IEnumerable<T>>();
            ShortestPath(graph, start, endCondition, output => { result = Option.Some(output); return false; }, exclusionFunction);
            return result;
        }

        public static IEnumerable<IEnumerable<T>> ShortestPaths<T>(IGraph<T> graph,
                                                                   T start,
                                                                   IEnumerable<T> ends,
                                                                   Option<Func<T, bool>> exclusionFunction = default)
        {
            List<IEnumerable<T>> result = new();
            ShortestPath(graph, start, ends.Contains, output => { result.Add(output); return true; }, exclusionFunction);
            return result;
        }

        public static IEnumerable<IEnumerable<T>> ShortestPaths<T>(IGraph<T> graph,
                                                                   T start,
                                                                   Func<T, bool> endCondition,
                                                                   Option<Func<T, bool>> exclusionFunction = default)
        {
            List<IEnumerable<T>> result = new();
            ShortestPath(graph, start, endCondition, output => { result.Add(output); return true; }, exclusionFunction);
            return result;
        }
    }
}