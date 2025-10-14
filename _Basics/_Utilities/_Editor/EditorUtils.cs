using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ThreeDent.DevelopmentTools.Utilities.Editor
{
    public static class EditorUtils
    {
        public static void HorizontalLine(int height = 1, Color? color = null)
        {
            color ??= new(0.4f, 0.4f, 0.4f);

            EditorGUILayout.Space();
            Rect rect = EditorGUILayout.GetControlRect(false, height);
            rect.height = height;
            EditorGUI.DrawRect(rect, color.Value);
            EditorGUILayout.Space();
        }

        public static void ClearEditorLog()
        {
            var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
            var type = assembly.GetType("UnityEditor.LogEntries");
            var method = type.GetMethod("Clear");
            method.Invoke(new object(), null);
        }
    }
}