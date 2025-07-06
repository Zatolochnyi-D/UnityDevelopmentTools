using ThreeDent.DevelopmentTools;
using UnityEditor;

namespace ThreeDent.Helpers.Tools.Editor
{
    [CustomEditor(typeof(GridLayoutGroupCellSizeController))]
    public class GridLayoutGroupCellSizeControllerEditor : UnityEditor.Editor
    {
        private GridLayoutGroupCellSizeController controller;

        void OnEnable()
        {
            controller = (GridLayoutGroupCellSizeController)target;
            controller.Initialize();
            controller.GridCellSizeToRectTransformSize();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            controller.GridCellSizeToRectTransformSize();
        }
    }
}