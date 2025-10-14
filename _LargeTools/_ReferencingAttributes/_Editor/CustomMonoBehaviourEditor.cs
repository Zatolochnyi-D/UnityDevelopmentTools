using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using DenZ.DevelopmentTools.Extensions;
using DenZ.DevelopmentTools.Utilities;

namespace DenZ.DevelopmentTools.ReferencingAttributes.Editor
{
    /// <summary>
    /// Extension of basic Editor class, that handles custom attributes.
    /// Custom editors should inherit from this class to have custom attributes work.
    /// </summary>
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class CustomMonoBehaviourEditor : UnityEditor.Editor
    {
        private const string ComponentOnThisNotFoundMessage = "This script requires component \"{0}\" to be present on this object.";
        private const string ComponentOnThisIndexNotFoundMessage = "This script requires component \"{0}\" to be present on this object under index {1}, but only {2} components are present on object.";
        private const string ComponentOnChildNotFoundMessage = "This script requires component \"{0}\" to be present on one of its children.";
        private const string ChildNotFoundMessage = "This script requires this object to have a child.";
        private const string ChildOnIndexNotFoundMessage = "This script requires this object to have a child under index {0} ({1} traversing is used), but only {2} children were found.";
        private const string ComponentOnParentNotFoundMessage = "This script requires component \"{0}\" to be present on one of it's parents.";
        private const string ParentNotFoundMessage = "This script requires this object to have a parent.";
        private const string ParentOnIndexNotFoundMessage = "This script requires this object to have a parent under index {0}, but only {2} parents were found.";

        private GameObject gameObject;
        private readonly List<string> warningMessages = new();

        private static bool HasRequiredAttribute(MemberInfo x)
        {
            return x.IsDefined<OnThisAttribute>() ||
                   x.IsDefined<OnChildAttribute>() ||
                   x.IsDefined<IsChildAttribute>() ||
                   x.IsDefined<OnParentAttribute>() ||
                   x.IsDefined<IsParentAttribute>();
        }

        private static IEnumerable<FieldInfo> GetSerializableFields(Type type)
        {
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var serializableFields = fields.Where(x => x.IsPublic || x.IsDefined<SerializeField>());
            return serializableFields;
        }

        private static IEnumerable<Transform> ChildProvider(Transform parent)
        {
            foreach (Transform child in parent)
                yield return child;
        }

        private void AddFieldsWithoutAttributes(VisualElement root)
        {
            GetSerializableFields(target.GetType())
            .Where(x => !HasRequiredAttribute(x))
            .Select(x => serializedObject.FindProperty(x.Name))
            .ForEach(x => root.Add(new PropertyField(x)));
        }

        private void HandleOnThisAttribute(FieldInfo field)
        {
            if (!field.FieldType.IsAssignableTo<Component>())
                return;

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
                    warningMessages.Add(string.Format(ComponentOnThisNotFoundMessage, field.FieldType.Name));
                else
                    warningMessages.Add(string.Format(ComponentOnThisIndexNotFoundMessage, field.FieldType.Name, index, components.Length));
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void HandleOnChildAttribute(FieldInfo field)
        {
            if (!field.FieldType.IsAssignableTo<Component>())
                return;

            var property = serializedObject.FindProperty(field.Name);
            property.objectReferenceValue = null;

            var attribute = field.GetCustomAttribute<OnChildAttribute>();
            var mode = attribute.TraversingMode;
            var offset = attribute.Offset;

            IEnumerable<Transform> children;
            if (mode == TraversingMode.BFS)
                children = NonLinearStructureAlgorithms.TreeBfsUnfold(gameObject.transform, ChildProvider, false);
            else
                children = NonLinearStructureAlgorithms.TreeDfsUnfold(gameObject.transform, ChildProvider, false);

            var childrenWithComponent = children.Where(x => x.TryGetComponent(field.FieldType, out _));
            if (childrenWithComponent.Count() > offset)
                property.objectReferenceValue = childrenWithComponent.Skip(offset).First().GetComponent(field.FieldType);
            else
                warningMessages.Add(string.Format(ComponentOnChildNotFoundMessage, field.FieldType.Name));

            serializedObject.ApplyModifiedProperties();
        }

        private void HandleIsChildAttribute(FieldInfo field)
        {
            if (!(field.FieldType.IsAssignableTo<GameObject>() || field.FieldType.IsAssignableTo<Transform>()))
                return;

            var property = serializedObject.FindProperty(field.Name);
            property.objectReferenceValue = null;

            var attribute = field.GetCustomAttribute<IsChildAttribute>();
            var offset = attribute.Offset;
            var mode = attribute.TraversingMode;

            IEnumerable<Transform> children;
            if (mode == TraversingMode.BFS)
                children = NonLinearStructureAlgorithms.TreeBfsUnfold(gameObject.transform, ChildProvider, false);
            else
                children = NonLinearStructureAlgorithms.TreeDfsUnfold(gameObject.transform, ChildProvider, false);

            var childrenCound = children.Count();
            if (childrenCound > offset)
            {
                var child = children.Skip(offset).First();
                property.objectReferenceValue = field.FieldType.IsAssignableTo<GameObject>() ? child.gameObject : child;
            }
            else
            {
                if (offset == 0)
                    warningMessages.Add(string.Format(ChildNotFoundMessage));
                else
                    warningMessages.Add(string.Format(ChildOnIndexNotFoundMessage, offset, mode, childrenCound));
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void HandleOnParentAttribute(FieldInfo field)
        {
            if (!field.FieldType.IsAssignableTo<Component>())
                return;

            var property = serializedObject.FindProperty(field.Name);
            property.objectReferenceValue = null;

            var offset = field.GetCustomAttribute<OnParentAttribute>().Offset;
            var parent = gameObject.transform.parent;
            var parents = new List<Transform>();
            while (parent != null)
            {
                parents.Add(parent);
                parent = parent.parent;
            }

            var parentsWithNeededComponent = parents.Where(x => x.TryGetComponent(field.FieldType, out _));
            if (parentsWithNeededComponent.Count() > offset)
                property.objectReferenceValue = parentsWithNeededComponent.Skip(offset).First().GetComponent(field.FieldType);
            else
                warningMessages.Add(string.Format(ComponentOnParentNotFoundMessage, field.FieldType));

            serializedObject.ApplyModifiedProperties();
        }

        private void HandleIsParentAttribute(FieldInfo field)
        {
            if (!(field.FieldType.IsAssignableTo<GameObject>() || field.FieldType.IsAssignableTo<Transform>()))
                return;

            var property = serializedObject.FindProperty(field.Name);
            property.objectReferenceValue = null;

            var index = field.GetCustomAttribute<IsParentAttribute>().Index;
            var parent = gameObject.transform.parent;
            var parents = new List<Transform>();
            while (parent != null)
            {
                parents.Add(parent);
                parent = parent.parent;
            }

            var parentsCound = parents.Count();
            if (parentsCound > index)
            {
                var actualParent = parents.Skip(index).First();
                property.objectReferenceValue = field.FieldType.IsAssignableTo<GameObject>() ? actualParent.gameObject : actualParent;
            }
            else
            {
                if (index == 0)
                    warningMessages.Add(string.Format(ParentNotFoundMessage));
                else
                    warningMessages.Add(string.Format(ParentOnIndexNotFoundMessage, index, parentsCound));
            }

            serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// Performs search of all the serializable fields for custom attributes and fills them if possible.
        /// If not, generates warning message that can be displayed with DisplayWarnings method.
        /// </summary>
        protected void HandleCustomAttributes()
        {
            var fieldsWithAttribute = GetSerializableFields(target.GetType()).Where(HasRequiredAttribute);

            foreach (var field in fieldsWithAttribute)
            {
                if (field.IsDefined<OnThisAttribute>())
                    HandleOnThisAttribute(field);
                else if (field.IsDefined<OnChildAttribute>())
                    HandleOnChildAttribute(field);
                else if (field.IsDefined<IsChildAttribute>())
                    HandleIsChildAttribute(field);
                else if (field.IsDefined<OnParentAttribute>())
                    HandleOnParentAttribute(field);
                else if (field.IsDefined<IsParentAttribute>())
                    HandleIsParentAttribute(field);
            }
        }

        /// <summary>
        /// Displays warnings that occured while handling custom attributes. <br/>
        /// Call in OnInspectorGUI.
        /// </summary>
        protected void DisplayWarnings()
        {
            warningMessages.ForEach(x => EditorGUILayout.HelpBox(x, MessageType.Warning));
        }

        /// <summary>
        /// Displays warnings that occured while handling custom attributes. <br/>
        /// Call in CreateInspectorGUI.
        /// </summary>
        /// <param name="root">Your root VisualElement</param>
        protected void DisplayWarnings(VisualElement root)
        {
            warningMessages.ForEach(x => root.Add(new HelpBox(x, HelpBoxMessageType.Warning)));
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
                HandleCustomAttributes();
                DisplayWarnings(root);
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