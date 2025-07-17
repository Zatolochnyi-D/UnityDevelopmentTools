using ThreeDent.DevelopmentTools.ReferencingAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace ThreeDent.DevelopmentTools.GridLayoutGroupTools
{
    /// <summary>
    /// Links GridLayoutGroup cell size with object's rect transform size.
    /// </summary>
    public class GridLayoutGroupCellSizeController : MonoBehaviour
    {
        [OnThis, SerializeField] private GridLayoutGroup gridLayout;
        [OnThis, SerializeField] private RectTransform rectTransform;

        public void GridCellSizeToRectTransformSize()
        {
            gridLayout.cellSize = rectTransform.rect.size;
        }
    }
}