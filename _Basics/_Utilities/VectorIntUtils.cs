using System;
using System.Collections.Generic;
using System.Linq;
using DenZ.DevelopmentTools.Extensions;
using UnityEngine;

namespace DenZ.DevelopmentTools.Utilities
{
    public static class VectorIntUtils
    {
        public static readonly IReadOnlyCollection<Vector2Int> CHESSBOARD_NEIGHBORS = new Vector2Int[]
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

        public static readonly IReadOnlyCollection<Vector2Int> MANHATTAN_NEIGHBORS = new Vector2Int[]
        {
            Vector2Int.up,
            Vector2Int.right,
            Vector2Int.down,
            Vector2Int.left
        };
    }
}