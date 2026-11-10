using System.Collections.Generic;

namespace DenZ.DevelopmentTools.Graphs
{
    public readonly struct Path<TKey>
    {
        public TKey From { get; }
        public TKey To { get; }
        public IEnumerable<TKey> FullPath { get; }

        public Path(TKey from, TKey to, IEnumerable<TKey> fullPath)
        {
            From = from;
            To = to;
            FullPath = fullPath;
        }
    }
}