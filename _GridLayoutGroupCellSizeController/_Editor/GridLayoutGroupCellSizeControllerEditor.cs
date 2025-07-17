using ThreeDent.DevelopmentTools;
using ThreeDent.DevelopmentTools.GridLayoutGroupTools;
using ThreeDent.DevelopmentTools.ReferencingAttributes.Editor;
using UnityEditor;
using UnityEngine.UIElements;

namespace ThreeDent.Helpers.Tools.GridLayoutGroupTools.Editor
{
    [CustomEditor(typeof(GridLayoutGroupCellSizeController))]
    public class GridLayoutGroupCellSizeControllerEditor : CustomMonoBehaviourEditor
    {
        private GridLayoutGroupCellSizeController controller;

        protected override void OnEnable()
        {
            base.OnEnable();
            controller = (GridLayoutGroupCellSizeController)target;
        }

        public override VisualElement CreateInspectorGUI()
        {
            return null;
        }

        public override void OnInspectorGUI()
        {
            HandleCustomAttributes();
            DisplayWarnings();
            controller.GridCellSizeToRectTransformSize();
        }
    }
}