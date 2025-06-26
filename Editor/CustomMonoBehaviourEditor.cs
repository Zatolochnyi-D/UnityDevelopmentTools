using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEditor;
using UnityEngine;
using ThreeDent.Helpers.Extensions;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace ThreeDent.DevelopmentTools.Editor
{
    /// <summary>
    /// Extension of basic Editor class, that handles custom attributes.
    /// Custom editors should inherit from this class to have custom attributes work.
    /// </summary>
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class CustomMonoBehaviourEditor : UnityEditor.Editor
    {
        private List<string> warningMessages;
        private IEnumerable<SerializedProperty> properties;
        private GameObject gameObject;
        private VisualElement root;

        private void CollectProperties()
        {
            if (!CustomMonoBehaviourEditorUsageController.UseCustomMonoBehaviourEditor)
                return;

            warningMessages = new();

            var fields = target.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var serializableFields = fields.Where(x => x.IsPublic || x.IsDefined<SerializeField>());
            static bool hasRequiredAttributes(MemberInfo x) => x.IsDefined<OnThisAttribute>() || x.IsDefined<OnChildAttribute>();
            var fieldsWithAttribute = serializableFields.Where(hasRequiredAttributes);
            var fieldsWithoutAttribute = serializableFields.Where(x => !hasRequiredAttributes(x));

            // OnThis, OnChild looks for components on game object, so type of fields with those attributes should derive from Component.
            var fieldsWithProperlyUsedAttribute = fieldsWithAttribute.Where(x => x.FieldType.IsAssignableTo<Component>());
            foreach (var field in fieldsWithProperlyUsedAttribute)
            {
                if (field.IsDefined<OnThisAttribute>())
                    HandleOnThisAttribute(field);
                else if (field.IsDefined<OnChildAttribute>())
                    HandleOnChildAttribute(field);
            }

            properties = fieldsWithoutAttribute.Select(x => serializedObject.FindProperty(x.Name));
        }

        private void HandleOnThisAttribute(FieldInfo field)
        {
            var property = serializedObject.FindProperty(field.Name);
            property.objectReferenceValue = null;

            if (gameObject.TryGetComponent(field.FieldType, out var component))
                property.objectReferenceValue = component;
            else
                warningMessages.Add($@"This script requires component ""{field.FieldType.Name}"" to be present on this object.");
                
            serializedObject.ApplyModifiedProperties();
        }

        private void HandleOnChildAttribute(FieldInfo field)
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

        protected virtual void OnEnable()
        {
            gameObject = ((MonoBehaviour)target).gameObject;
            CollectProperties();
        }

        public override VisualElement CreateInspectorGUI()
        {
            root = new VisualElement();
            foreach (var message in warningMessages)
                root.Add(new HelpBox(message, HelpBoxMessageType.Warning));
            foreach (var property in properties)
                root.Add(new PropertyField(property));
            return root;
        }

        public void Redraw()
        {
            CollectProperties();
        }

        // public override void OnInspectorGUI()
        // {
        //     Debug.Log("B");
        //     if (CustomMonoBehaviourEditorUsageController.UseCustomMonoBehaviourEditor)
        //     {
        //         foreach (var message in warningMessages)
        //             EditorGUILayout.HelpBox(message, MessageType.Warning);
        //         foreach (var property in properties)
        //             EditorGUILayout.PropertyField(property);
        //         serializedObject.ApplyModifiedProperties();
        //     }
        //     else
        //     {
        //         base.OnInspectorGUI();
        //     }
        // }
    }
}