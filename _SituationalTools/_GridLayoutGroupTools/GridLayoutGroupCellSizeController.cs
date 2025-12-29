using UnityEngine;
using UnityEngine.UI;

namespace DenZ.DevelopmentTools.GridLayoutGroupTools
{
    public class GridLayoutGroupCellSizeController : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup gridLayout;
        [SerializeField] private RectTransform rectTransform;

        public void GridCellSizeToRectTransformSize()
        {
            gridLayout.cellSize = rectTransform.rect.size;
        }
    }
}