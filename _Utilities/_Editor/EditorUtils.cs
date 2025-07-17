using UnityEditor;
using UnityEngine;

namespace ThreeDent.DevelopmentTools.Utilities.Editor
{
    public static class EditorUtils
    {
        /// <summary>
        /// Draws horizontal line in the Inspector with one space before and after.
        /// </summary>
        public static void HorizontalLine(int height = 1, Color? color = null)
        {
            color ??= new(0.4f, 0.4f, 0.4f);

            EditorGUILayout.Space();
            Rect rect = EditorGUILayout.GetControlRect(false, height);
            rect.height = height;
            EditorGUI.DrawRect(rect, color.Value);
            EditorGUILayout.Space();
        }
    }
}