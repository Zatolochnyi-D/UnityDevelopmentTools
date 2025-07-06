using UnityEngine;
using UnityEngine.UI;

namespace ThreeDent.DevelopmentTools
{
    /// <summary>
    /// Links GridLayoutGroup cell size with object's rect transform size.
    /// </summary>
    public class GridLayoutGroupCellSizeController : MonoBehaviour
    {
        [HideInInspector] private GridLayoutGroup gridLayout;
        [HideInInspector] private RectTransform rectTransform;

        public void Initialize()
        {
            if (gridLayout == null)
                gridLayout = GetComponent<GridLayoutGroup>();
            if (rectTransform == null)
                rectTransform = (RectTransform)transform;
        }

        public void GridCellSizeToRectTransformSize()
        {
            gridLayout.cellSize = rectTransform.rect.size;
        }
    }
}