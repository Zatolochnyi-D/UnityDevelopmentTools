using System;
using System.Collections.Generic;
using System.Linq;
using DenZ.DevelopmentTools.Options;

namespace DenZ.DevelopmentTools.Graphs
{
    public static class BfsPathfinding
    {
        public static void ShortestPath<T>(IGraph<T> graph, T start, Func<T, bool> endCondition, Func<IEnumerable<T>, bool> outputFunction)
        {
            var keysToVisit = new Queue<T>();
            var visitedFromMap = new Dictionary<T, Option<T>>();

            keysToVisit.Enqueue(start);
            visitedFromMap[start] = Option.None<T>();

            while (keysToVisit.Any())
            {
                var currentKey = keysToVisit.Dequeue();

                if (endCondition(currentKey))
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
                    if (!visitedFromMap.ContainsKey(neighborKey))
                    {
                        visitedFromMap[neighborKey] = currentKey;
                        keysToVisit.Enqueue(neighborKey);
                    }
                }
            }
        }

        public static Option<IEnumerable<T>> ShortestPath<T>(IGraph<T> graph, T start, T end)
        {
            var result = Option.None<IEnumerable<T>>();
            ShortestPath(graph, start, key => end.Equals(key), output => { result = Option.Some(output); return false; });
            return result;
        }
        
        public static Option<IEnumerable<T>> ShortestPath<T>(IGraph<T> graph, T start, Func<T, bool> endCondition)
        {
            var result = Option.None<IEnumerable<T>>();
            ShortestPath(graph, start, endCondition, output => { result = Option.Some(output); return false; });
            return result;
        }

        public static IEnumerable<IEnumerable<T>> ShortestPaths<T>(IGraph<T> graph, T start, IEnumerable<T> ends)
        {
            List<IEnumerable<T>> result = new();
            ShortestPath(graph, start, ends.Contains, output => { result.Add(output); return true; });
            return result;
        }

        public static IEnumerable<IEnumerable<T>> ShortestPaths<T>(IGraph<T> graph, T start, Func<T, bool> endCondition)
        {
            List<IEnumerable<T>> result = new();
            ShortestPath(graph, start, endCondition, output => { result.Add(output); return true; });
            return result;
        }
    }
}