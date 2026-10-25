using System.Collections.Generic;

namespace DenZ.DevelopmentTools.Graphs
{
    public interface IGraph<T>
    {
        public IEnumerable<T> GetNeighbors(T tileId);
    }
}