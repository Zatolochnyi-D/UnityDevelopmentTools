using System;
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
        private GameObject gameObject;

        private static bool HasRequiredAttribute(MemberInfo x)
        {
            return x.IsDefined<OnThisAttribute>() || x.IsDefined<OnChildAttribute>();
        }

        private static IEnumerable<FieldInfo> GetSerializableFields(Type type)
        {
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var serializableFields = fields.Where(x => x.IsPublic || x.IsDefined<SerializeField>());
            return serializableFields;
        }

        private void AddFieldsWithoutAttributes(VisualElement root)
        {
            var fieldsWithoutAttribute = GetSerializableFields(target.GetType()).Where(x => !HasRequiredAttribute(x));
            var properties = fieldsWithoutAttribute.Select(x => serializedObject.FindProperty(x.Name));
            foreach (var property in properties)
                root.Add(new PropertyField(property));
        }

        private void FillParentsOnChildFields()
        {
            // var parent = gameObject.transform.parent;
            // while (parent != null)
            // {
            //     foreach (var script in parent.GetComponents<MonoBehaviour>())
            //     {
            //         var serializedParent = new SerializedObject(parent);
            //         var onChildFields = GetSerializableFields(script.GetType()).Where(x => x.IsDefined<OnChildAttribute>());
            //         foreach (var field in onChildFields)

            //     }


            //     parent = parent.transform.parent;
            // }
            // var obj = new SerializedObject(gameObject.transform.parent.gameObject);
            // var obj = new SerializedObject(target);
            // obj.FindProperty("number").floatValue = 9999f;
            // obj.ApplyModifiedProperties();
        }

        private void HandleOnThisAttribute(VisualElement root, FieldInfo field)
        {
            var property = serializedObject.FindProperty(field.Name);
            property.objectReferenceValue = null;

            if (gameObject.TryGetComponent(field.FieldType, out var component))
                property.objectReferenceValue = component;
            else
                root.Add(new HelpBox($@"This script requires component ""{field.FieldType.Name}"" to be present on this object.", HelpBoxMessageType.Warning));

            serializedObject.ApplyModifiedProperties();
        }

        private void HandleOnChildAttribute(VisualElement root, FieldInfo field)
        {
            var property = serializedObject.FindProperty(field.Name);
            property.objectReferenceValue = null;

            foreach (Transform child in gameObject.transform)
                if (child.TryGetComponent(field.FieldType, out var component))
                    property.objectReferenceValue = component;

            if (property.objectReferenceValue == null)
                root.Add(new HelpBox($@"This script requires component ""{field.FieldType.Name}"" to be present on one of its children.", HelpBoxMessageType.Warning));

            serializedObject.ApplyModifiedProperties();
        }

        protected void HandleCustomAttributes(VisualElement root)
        {
            var fieldsWithAttribute = GetSerializableFields(target.GetType()).Where(HasRequiredAttribute);
            var fieldsWithProperlyUsedAttribute = fieldsWithAttribute.Where(x => x.FieldType.IsAssignableTo<Component>());

            foreach (var field in fieldsWithProperlyUsedAttribute)
            {
                if (field.IsDefined<OnThisAttribute>())
                    HandleOnThisAttribute(root, field);
                else if (field.IsDefined<OnChildAttribute>())
                    HandleOnChildAttribute(root, field);
            }
        }

        public override VisualElement CreateInspectorGUI()
        {
            if (CustomMonoBehaviourEditorUsageController.UseCustomMonoBehaviourEditor)
            {
                var root = new VisualElement();
                gameObject = ((MonoBehaviour)target).gameObject;
                HandleCustomAttributes(root);
                AddFieldsWithoutAttributes(root);
                FillParentsOnChildFields();
                return root;
            }
            else
            {
                return null;
            }
        }
    }
}