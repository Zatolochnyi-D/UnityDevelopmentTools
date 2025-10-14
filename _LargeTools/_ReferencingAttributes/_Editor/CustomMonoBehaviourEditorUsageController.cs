using UnityEditor;
using UnityEngine;

namespace DenZ.DevelopmentTools.ReferencingAttributes.Editor
{
    public class CustomMonoBehaviourEditorUsageController : ScriptableSingleton<CustomMonoBehaviourEditorUsageController>
    {
        [SerializeField] private bool useCustomMonoBehaviourEditor = true;

        public static bool UseCustomMonoBehaviourEditor => instance.useCustomMonoBehaviourEditor;

        [MenuItem("Custom MB Editor/Switch between custom and default editors")]
        private static void Switch()
        {
            instance.useCustomMonoBehaviourEditor = !instance.useCustomMonoBehaviourEditor;
        }
    }
}