using System;
using System.Collections.Generic;
using DenZ.DevelopmentTools.Math;
using DenZ.DevelopmentTools.Utilities;
using UnityEngine;

namespace DenZ.DevelopmentTools.Graphs
{
    public class SquareHexGridGraphGenerator : IGraph<Vector2Int>
    {
        private readonly Vector2Int _gridSize;

        public SquareHexGridGraphGenerator(Vector2Int gridSize)
        {
            if (_gridSize.x < 0 || _gridSize.y < 0)
                throw new ArgumentException("One of size dimensions is less than 0.");
            _gridSize = gridSize;
        }

        public IEnumerable<Vector2Int> GetNeighbors(Vector2Int tileId)
        {
            if (!tileId.x.IsInside(0, _gridSize.x) || !tileId.y.IsInside(0, _gridSize.y))
                throw new ArgumentException("Provided tile id is outside of the grid.");

            var properOffset = tileId.y % 2 == 0 ? VectorIntUtils.SQUARE_HEX_GRID_NEIGHBOR_OFFSETS_LEADING : VectorIntUtils.SQUARE_HEX_GRID_NEIGHBOR_OFFSETS_NON_LEADING;

            foreach (var neighborOffset in properOffset)
            {
                var possibleNeighbor = tileId + neighborOffset;
                if (RangeUtils.IsInside(possibleNeighbor, Vector2Int.zero, _gridSize))
                    yield return possibleNeighbor;
            }
        }
    }
}