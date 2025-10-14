using DenZ.DevelopmentTools.GridLayoutGroupTools;
using DenZ.DevelopmentTools.ReferencingAttributes.Editor;
using UnityEditor;

namespace DenZ.Helpers.Tools.GridLayoutGroupTools.Editor
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

        public override void OnInspectorGUI()
        {
            var (fields, _) = GetPropertyGroups();
            ProcessAutoassignedFields(fields);
            controller.GridCellSizeToRectTransformSize();
        }
    }
}