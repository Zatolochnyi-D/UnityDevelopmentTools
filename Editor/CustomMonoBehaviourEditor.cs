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

        private void AddFieldsWithoutAttributes(VisualElement root)
        {
            var fields = target.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var serializableFields = fields.Where(x => x.IsPublic || x.IsDefined<SerializeField>());
            var fieldsWithoutAttribute = serializableFields.Where(x => !HasRequiredAttribute(x));
            var properties = fieldsWithoutAttribute.Select(x => serializedObject.FindProperty(x.Name));
            foreach (var property in properties)
                root.Add(new PropertyField(property));
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
            if (!CustomMonoBehaviourEditorUsageController.UseCustomMonoBehaviourEditor)
                return;
            var fields = target.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var serializableFields = fields.Where(x => x.IsPublic || x.IsDefined<SerializeField>());
            var fieldsWithAttribute = serializableFields.Where(HasRequiredAttribute);
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
                return root;
            }
            else
            {
                return null;
            }
        }
    }
}