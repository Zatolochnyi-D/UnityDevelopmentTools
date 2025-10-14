using System.Runtime.CompilerServices;
using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class GridExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int LocalToCell2d(this Grid grid, Vector3 localPosition)
        {
            return (Vector2Int)grid.LocalToCell(localPosition);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 GetCell2dCenterLocal(this Grid grid, Vector2Int cell2d)
        {
            return grid.GetCellCenterLocal((Vector3Int)cell2d);
        }
    }
}