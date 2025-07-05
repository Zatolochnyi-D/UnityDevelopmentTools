using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEditor;
using UnityEngine;
using ThreeDent.Helpers.Extensions;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using ThreeDent.Helpers.Utils;

namespace ThreeDent.DevelopmentTools.Editor
{
    /// <summary>
    /// Extension of basic Editor class, that handles custom attributes.
    /// Custom editors should inherit from this class to have custom attributes work.
    /// </summary>
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class CustomMonoBehaviourEditor : UnityEditor.Editor
    {
        private const string ComponentOnThisNotFoundMessage = "This script requires component \"{0}\" to be present on this object.";
        private const string ComponentOnThisIndexNotFoundMessage = "This script requires component \"{0}\" to be present on this object under index {1}.";
        private const string ComponentOnChildNotFoundMessage = "This script requires component \"{0}\" to be present on one of its children.";

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

        private static IEnumerable<Transform> ChildProviderForBfs(Transform parent)
        {
            foreach (Transform child in parent)
                yield return child;
        }

        private static IEnumerable<Transform> ChildProviderForDfs(Transform parent)
        {
            for (int i = parent.childCount - 1; i >= 0; i--)
                yield return parent.GetChild(i);
        }

        private void AddFieldsWithoutAttributes(VisualElement root)
        {
            GetSerializableFields(target.GetType())
            .Where(x => !HasRequiredAttribute(x))
            .Select(x => serializedObject.FindProperty(x.Name))
            .ForEach(x => root.Add(new PropertyField(x)));
        }

        private void HandleOnThisAttribute(VisualElement root, FieldInfo field)
        {
            var property = serializedObject.FindProperty(field.Name);
            property.objectReferenceValue = null;

            var index = field.GetCustomAttribute<OnThisAttribute>().Index;
            var components = gameObject.GetComponents(field.FieldType);
            if (components.Length > index)
            {
                property.objectReferenceValue = components[index];
            }
            else
            {
                if (index == 0)
                    root.Add(new HelpBox(string.Format(ComponentOnThisNotFoundMessage, field.FieldType.Name), HelpBoxMessageType.Warning));
                else
                    root.Add(new HelpBox(string.Format(ComponentOnThisIndexNotFoundMessage, field.FieldType.Name, index), HelpBoxMessageType.Warning));
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void HandleOnChildAttribute(VisualElement root, FieldInfo field)
        {
            var property = serializedObject.FindProperty(field.Name);
            property.objectReferenceValue = null;

            var attribute = field.GetCustomAttribute<OnChildAttribute>();
            var mode = attribute.TraversingMode;
            var offset = attribute.Offset;

            IEnumerable<Transform> children;
            if (mode == OnChildTraversingMode.BFS)
                children = GenericUnfoldingAlgos.UnfoldTreeWithBfs(gameObject.transform, ChildProviderForBfs, false);
            else
                children = GenericUnfoldingAlgos.UnfoldTreeWithDfs(gameObject.transform, ChildProviderForDfs, false);

            var childrenWithComponent = children.Where(x => x.TryGetComponent(field.FieldType, out _));
            if (childrenWithComponent.Count() > offset)
                property.objectReferenceValue = childrenWithComponent.Skip(offset).First().GetComponent(field.FieldType);
            else
                root.Add(new HelpBox(string.Format(ComponentOnChildNotFoundMessage, field.FieldType.Name), HelpBoxMessageType.Warning));

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

        protected virtual void OnEnable()
        {
            gameObject = ((MonoBehaviour)target).gameObject;
        }

        public override VisualElement CreateInspectorGUI()
        {
            if (CustomMonoBehaviourEditorUsageController.UseCustomMonoBehaviourEditor)
            {
                var root = new VisualElement();
                HandleCustomAttributes(root);
                AddFieldsWithoutAttributes(root);
                return root;
            }
            else
            {
                return null;
            }
        }
    }
}