using System.Collections.Generic;
using UnityEngine;

namespace DenZ.DevelopmentTools.Utilities
{
    public static class VectorIntUtils
    {
        public static readonly IReadOnlyCollection<Vector2Int> CHESSBOARD_NEIGHBOR_OFFSETS = new Vector2Int[]
        {
            Vector2Int.up,
            Vector2Int.up + Vector2Int.right,
            Vector2Int.right,
            Vector2Int.right + Vector2Int.down,
            Vector2Int.down,
            Vector2Int.down + Vector2Int.left,
            Vector2Int.left,
            Vector2Int.left + Vector2Int.up
        };

        public static readonly IReadOnlyCollection<Vector2Int> MANHATTAN_NEIGHBOR_OFFSETS = new Vector2Int[]
        {
            Vector2Int.up,
            Vector2Int.right,
            Vector2Int.down,
            Vector2Int.left
        };

        // Lines that are more left than other, non-leading.
        public static readonly IReadOnlyCollection<Vector2Int> SQUARE_HEX_GRID_NEIGHBOR_OFFSETS_LEADING = new Vector2Int[]
        {
            Vector2Int.up,
            Vector2Int.right,
            Vector2Int.down,
            Vector2Int.down + Vector2Int.left,
            Vector2Int.left,
            Vector2Int.up + Vector2Int.left
        };

        public static readonly IReadOnlyCollection<Vector2Int> SQUARE_HEX_GRID_NEIGHBOR_OFFSETS_NON_LEADING = new Vector2Int[]
        {
            Vector2Int.up,
            Vector2Int.up + Vector2Int.right,
            Vector2Int.right,
            Vector2Int.down + Vector2Int.right,
            Vector2Int.down,
            Vector2Int.left
        };
    }
}