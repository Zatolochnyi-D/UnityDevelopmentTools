using UnityEngine;

namespace ThreeDent.DevelopmentTools.Extensions
{
    public static class GridExtension
    {
        /// <summary>
        /// Converts object's local position directly to grid coordinates.
        /// </summary>
        public static Vector2Int LocalToCell2d(this Grid grid, Vector3 localPosition)
        {
            return (Vector2Int)grid.LocalToCell(localPosition);
        }

        /// <summary>
        /// Converts object's grid coordinates directly to local position.
        /// </summary>
        public static Vector3 GetCell2dCenterLocal(this Grid grid, Vector2Int cell2d)
        {
            return grid.GetCellCenterLocal((Vector3Int)cell2d);
        }
    }
}