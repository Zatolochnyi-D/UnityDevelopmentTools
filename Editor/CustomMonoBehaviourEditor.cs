using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEditor;
using UnityEngine;
using ThreeDent.Helpers.Extensions;

namespace ThreeDent.DevelopmentTools.Editor
{
    /// <summary>
    /// Extension of basic Editor class, that handles custom attributes.
    /// Custom editors should inherit from this class to have custom attributes work.
    /// </summary>
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class CustomMonoBehaviourEditor : UnityEditor.Editor
    {
        private readonly List<string> warningMessages = new();
        private IEnumerable<SerializedProperty> properties;
        private GameObject gameObject;

        private void CollectProperties()
        {
            if (!CustomMonoBehaviourEditorUsageController.UseCustomMonoBehaviourEditor)
                return;

            var fields = target.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var serializableFields = fields.Where(x => x.IsPublic || x.IsDefined<SerializeField>());

            static bool haveRequiredAttribute(MemberInfo x)
            {
                return x.IsDefined<OnThisAttribute>() || x.IsDefined<OnChildAttribute>();
            }
            var fieldsByAttributesPresence = serializableFields.GroupBy(haveRequiredAttribute);

            foreach (var fieldWithAttribute in fieldsByAttributesPresence.Where(x => x.Key).SelectMany(x => x))
            {
                if (fieldWithAttribute.IsDefined<OnThisAttribute>())
                    HandleOnThisAttribute(fieldWithAttribute);
                else if (fieldWithAttribute.IsDefined<OnChildAttribute>())
                    HandleOnChildAttribute(fieldWithAttribute);
            }

            properties = fieldsByAttributesPresence.Where(x => !x.Key).SelectMany(x => x).Select(x => serializedObject.FindProperty(x.Name));
        }

        protected virtual void OnEnable()
        {
            CollectProperties();
            gameObject = ((MonoBehaviour)target).gameObject;
        }

        private void HandleOnThisAttribute(FieldInfo field)
        {
            // Check that field object is derived from Component, that's the only type that can be attached to GameObject.
            if (typeof(Component).IsAssignableFrom(field.FieldType))
            {
                var property = serializedObject.FindProperty(field.Name);
                if (((MonoBehaviour)target).gameObject.TryGetComponent(field.FieldType, out var component))
                {
                    property.objectReferenceValue = component;
                }
                else
                {
                    property.objectReferenceValue = null;
                    warningMessages.Add($@"This script requires component ""{field.FieldType.Name}"" to be present on this object.");
                }
                serializedObject.ApplyModifiedProperties();
            }
        }

        private void HandleOnChildAttribute(FieldInfo field)
        {
            // Check that field object is derived from Component, that's the only type that can be attached to GameObject.
            if (typeof(Component).IsAssignableFrom(field.FieldType))
            {
                var property = serializedObject.FindProperty(field.Name);

                if (gameObject.transform.childCount == 0)
                {
                    property.objectReferenceValue = null;
                    warningMessages.Add($@"This script requires component ""{field.FieldType.Name}"" to be present on one of its children.");
                }
                foreach (Transform child in gameObject.transform)
                {
                    if (child.TryGetComponent(field.FieldType, out var component))
                    {
                        property.objectReferenceValue = component;
                    }
                    else
                    {
                        property.objectReferenceValue = null;
                        warningMessages.Add($@"This script requires component ""{field.FieldType.Name}"" to be present on one of its children.");
                    }
                }

                serializedObject.ApplyModifiedProperties();
            }
        }

        public override void OnInspectorGUI()
        {
            Debug.Log("B");
            if (CustomMonoBehaviourEditorUsageController.UseCustomMonoBehaviourEditor)
            {
                foreach (var message in warningMessages)
                    EditorGUILayout.HelpBox(message, MessageType.Warning);
                foreach (var property in properties)
                    EditorGUILayout.PropertyField(property);
                serializedObject.ApplyModifiedProperties();
            }
            else
            {
                base.OnInspectorGUI();
            }
        }
    }
}