using System;
using System.Collections.Generic;
using DenZ.DevelopmentTools.Extensions;
using DenZ.DevelopmentTools.Utilities;
using UnityEngine;

namespace DenZ.DevelopmentTools.Graphs
{
    public class SquareHexGridGraphGenerator : IGraph<Vector2Int>
    {
        private readonly Vector2Int _gridSize;
        private readonly int _leadingRowMarker; // odd/even used as marker.

        public SquareHexGridGraphGenerator(Vector2Int gridSize, bool isFirstLeading)
        {
            if (_gridSize.x < 0 || _gridSize.y < 0)
                throw new ArgumentException("One of size dimensions is less than 0.");
            _gridSize = gridSize;
            _leadingRowMarker = isFirstLeading ? 0 : 1; // if first leading, then even rows are leading, otherwise odd rows are leading.
        }

        public IEnumerable<Vector2Int> GetNeighbors(Vector2Int tileId)
        {
            if (tileId.x.IsOutsideRange((0, _gridSize.x)) || tileId.y.IsOutsideRange((0, _gridSize.y)))
                throw new ArgumentException("Provided tile id is outside of the grid.");

            var isRowLeading = tileId.y % 2 == _leadingRowMarker;
            var properOffset = isRowLeading ? VectorIntUtils.SQUARE_HEX_GRID_NEIGHBOR_OFFSETS_LEADING : VectorIntUtils.SQUARE_HEX_GRID_NEIGHBOR_OFFSETS_NON_LEADING;

            var neighbors = new List<Vector2Int>();
            foreach (var neighborOffset in properOffset)
            {
                var possibleNeighbor = tileId + neighborOffset;
                if (possibleNeighbor.x.IsInsideRange((0, _gridSize.x)) && possibleNeighbor.y.IsInsideRange((0, _gridSize.y)))
                    neighbors.Add(possibleNeighbor);
            }
            return neighbors;
        }
    }
}