using UnityEditor;
using UnityEngine;

namespace EssentialPackages.CurveEditor.Editor.Utils
{
	public static class Inspector
	{
		private static float CurrentViewWidth => EditorGUIUtility.currentViewWidth;
		private static float LabelWidth => EditorGUIUtility.labelWidth;
		private static float SingleLineHeight => EditorGUIUtility.singleLineHeight;
	
		public static void CreateField(Rect rect, float offsetY, SerializedProperty property)
		{
			EditorGUI.LabelField(
				new Rect(
					rect.x,
					rect.y + offsetY,
					LabelWidth - 5,
					SingleLineHeight
				),
				ObjectNames.NicifyVariableName(property.name)
			);

			EditorGUI.PropertyField(
				new Rect(
					rect.x + LabelWidth,
					rect.y + offsetY,
					CurrentViewWidth - 60 - LabelWidth,
					SingleLineHeight
				),
				property,
				GUIContent.none
			);
		}
	}
}
