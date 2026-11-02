using System;
using System.Collections.Generic;
using System.Linq;
using DenZ.DevelopmentTools.Extensions;
using UnityEditor;
using UnityEngine;

namespace DenZ.DevelopmentTools.PolymorphicPropertyDrawing
{
    [CustomPropertyDrawer(typeof(PolymorphicAttribute))]
    public class PolymorphicPropertyDrawer : PropertyDrawer
    {
        private Dictionary<string, Type> _typeMap;

        private static string GetFullName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;
            var nameParts = name.Split(' ');
            return nameParts.Length > 1 ? nameParts[1] : name;
        }

        private static string GetShortName(string name) => string.IsNullOrEmpty(name) ? null : name.Split('.').Last();

        private void BuildTypeMap()
        {
            var targetType = fieldInfo.FieldType;
            if (targetType.IsAssignableTo<System.Collections.IEnumerable>())
                targetType = targetType.GenericTypeArguments[0];

            _typeMap = AppDomain.CurrentDomain.GetAssemblies()
                                              .SelectMany(assembly => assembly.GetTypes())
                                              .Where(type => !type.IsAbstract && type.IsAssignableTo(targetType))
                                              .ToDictionary(type => ObjectNames.NicifyVariableName(type.Name), type => type);
        }
        
        private void FlushMissingTypes(SerializedProperty property)
        {
            var targetObject = property.serializedObject.targetObject;
            if (SerializationUtility.HasManagedReferencesWithMissingTypes(targetObject))
            {
                SerializationUtility.ClearAllManagedReferencesWithMissingTypes(targetObject);
                Debug.LogWarning($"Removed missing managed references from {targetObject.name}");
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => EditorGUI.GetPropertyHeight(property, label, true) + EditorGUIUtility.singleLineHeight;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            FlushMissingTypes(property);

            if (_typeMap == null)
                BuildTypeMap();

            var (x, y) = (position.x, position.y);
            var (width, height) = (position.width, position.height);
            var lineHeight = EditorGUIUtility.singleLineHeight;

            var typeRect = new Rect(x, y, width, lineHeight);
            var contentRect = new Rect(x, y + lineHeight, width, height - lineHeight);

            EditorGUI.BeginProperty(position, label, property);
            var unityTypeName = property.managedReferenceFullTypename;
            var typeName = GetFullName(unityTypeName);
            var displayName = GetShortName(typeName);

            if (EditorGUI.DropdownButton(typeRect, new GUIContent(displayName ?? "Not selected"), FocusType.Keyboard))
            {
                var menu = new GenericMenu();
                if (!_typeMap.Any())
                {
                    menu.AddDisabledItem(new GUIContent("No Ability Effects available"));
                    menu.ShowAsContext();
                    return;
                }

                foreach (var (name, type) in _typeMap)
                {
                    menu.AddItem(new GUIContent(name), type.FullName == typeName, () =>
                    {
                        property.managedReferenceValue = Activator.CreateInstance(type);
                        property.serializedObject.ApplyModifiedProperties();
                    });
                }
                menu.ShowAsContext();
            }

            if (property.managedReferenceValue != null)
            {
                EditorGUI.indentLevel++;
                EditorGUI.PropertyField(contentRect, property, GUIContent.none, true);
                EditorGUI.indentLevel--;
            }

            EditorGUI.EndProperty();
        }
    }
}