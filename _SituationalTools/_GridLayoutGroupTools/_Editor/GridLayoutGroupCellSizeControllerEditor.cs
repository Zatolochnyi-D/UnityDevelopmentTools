using DenZ.DevelopmentTools.GridLayoutGroupTools;
using UnityEditor;

namespace DenZ.DevelopmentTools.Tools.GridLayoutGroupTools.Editor
{
    [CustomEditor(typeof(GridLayoutGroupCellSizeController))]
    public class GridLayoutGroupCellSizeControllerEditor : UnityEditor.Editor
    {
        private GridLayoutGroupCellSizeController controller;

        void OnEnable()
        {
            controller = (GridLayoutGroupCellSizeController)target;
        }

        public override void OnInspectorGUI()
        {
            controller.GridCellSizeToRectTransformSize();
        }
    }
}