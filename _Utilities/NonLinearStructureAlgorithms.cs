using System;
using System.Collections.Generic;
using System.Linq;
using ThreeDent.DevelopmentTools.Extensions;

namespace ThreeDent.DevelopmentTools.Utilities
{
    public static class NonLinearStructureAlgorithms
    {
        public static IEnumerable<T> TreeBfsUnfold<T>(T root, Func<T, IEnumerable<T>> childrenProvider, bool includeRoot = true)
        {
            var result = new List<T>();
            var queue = new Queue<T>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var localRoot = queue.Dequeue();
                result.Add(localRoot);
                childrenProvider(localRoot).ForEach(queue.Enqueue);
            }
            return includeRoot ? result : result.Skip(1);
        }

        public static IEnumerable<T> TreeDfsUnfold<T>(T root, Func<T, IEnumerable<T>> childrenProvider, bool includeRoot = true)
        {
            var result = new List<T>();
            var stack = new Stack<T>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                var localRoot = stack.Pop();
                result.Add(localRoot);
                childrenProvider(localRoot).Reverse().ForEach(stack.Push);
            }
            return includeRoot ? result : result.Skip(1);
        }
    }
}
