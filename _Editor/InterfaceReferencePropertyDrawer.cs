using System.Linq;
using ThreeDent.DevelopmentTools;
using UnityEditor;
using UnityEngine;

namespace ThreeDent.Helpers.Tools.Editor
{
    [CustomPropertyDrawer(typeof(InterfaceReference<>))]
    public class InterfaceReferencePropertyDrawer : PropertyDrawer
    {
        private const string PropertyName = "script";

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, GUIContent.none, property);

            // MonoBehaviour field, that should be filled in process.
            SerializedProperty script = property.FindPropertyRelative(PropertyName);
            // Field is InterfaceReference<T>, it always have 1 generic type.
            // This type is needed to validate, that provided object implements type T. 
            System.Type fieldGenericType = fieldInfo.FieldType.GenericTypeArguments[0];

            // Inspector field accepts Object type, meaning any Unity object is apropriate for this field. Additional filtering required.
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            Object providedObject = EditorGUI.ObjectField(position, script.objectReferenceValue, typeof(Object), true);

            if (providedObject != null)
            {
                // GameObjects and MonoBehaviors are those we are looking for.
                if (providedObject is GameObject gameObject)
                {
                    // MonoBehaviours are custom scripts most of the time, created by user. We should grab them first, to filter out unintended
                    // collisions with objects, that implement the same interface, but are not created by user.
                    var monoBehaviours = gameObject.GetComponents<MonoBehaviour>();
                    MonoBehaviour interfaceImplementor = monoBehaviours.FirstOrDefault(x => fieldGenericType.IsAssignableFrom(x.GetType())); // default = null
                    if (interfaceImplementor != null)
                        script.objectReferenceValue = interfaceImplementor;
                }
                else if (providedObject is MonoBehaviour monoBehaviour)
                    if (fieldGenericType.IsAssignableFrom(monoBehaviour.GetType()))
                        script.objectReferenceValue = monoBehaviour;
            }
            else
                script.objectReferenceValue = null;

            EditorGUI.EndProperty();
        }
    }
}