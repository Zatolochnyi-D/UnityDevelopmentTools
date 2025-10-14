using UnityEngine;
using UnityEditor;

namespace ThreeDent.DevelopmentTools.SceneReference.Editor
{
    // Draws SceneReference in the Inspector.
    // On assigning scene asset, assigns it to SceneReference.sceneAsset, and it's name to SceneReference.sceneName.
    // If scene asset removed from property, assigns to both SceneReference.sceneAsset and SceneReference.sceneName null.
    [CustomPropertyDrawer(typeof(SceneReference))]
    public class SceneReferencePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, GUIContent.none, property);
            SerializedProperty sceneAsset = property.FindPropertyRelative("sceneAsset");
            SerializedProperty sceneName = property.FindPropertyRelative("sceneName");
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            if (sceneAsset != null)
            {
                sceneAsset.objectReferenceValue = EditorGUI.ObjectField(position, sceneAsset.objectReferenceValue, typeof(SceneAsset), false);

                if (sceneAsset.objectReferenceValue != null)
                    sceneName.stringValue = ((SceneAsset)sceneAsset.objectReferenceValue).name;
                else
                    sceneName.stringValue = null;
            }
            EditorGUI.EndProperty();
        }
    }
}