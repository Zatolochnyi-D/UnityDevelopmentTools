using System.Runtime.CompilerServices;
using UnityEngine;

namespace DenZ.DevelopmentTools.Extensions
{
    public static class GridExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2Int LocalToCell2d(this Grid grid, Vector3 localPosition) => grid.LocalToCell(localPosition).AsXY();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 GetCell2dCenterLocal(this Grid grid, Vector2Int cell2d) => grid.GetCellCenterLocal(cell2d.AsXY0()); // potential issue when other swizzling options are selected.

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 GetCell2dCenterWorld(this Grid grid, Vector2Int cell2d) => grid.GetCellCenterWorld(cell2d.AsXY0());
    }
}