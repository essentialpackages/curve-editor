using UnityEditor;
using UnityEngine;

namespace EssentialPackages.CurveEditor.Editor.Utils
{
	/// <summary>
	/// Contains 
	/// </summary>
	public static class Inspector
	{
		/// <summary>
		/// Get the width of the GUI area for the current EditorWindow or other view.
		/// </summary>
		private static float CurrentViewWidth => EditorGUIUtility.currentViewWidth;
		
		/// <summary>
		/// Get the width in pixels reserved for labels of Editor GUI controls.
		/// </summary>
		private static float LabelWidth => EditorGUIUtility.labelWidth;
		
		/// <summary>
		/// Get the height used for a single Editor control such as a one-line EditorGUI.TextField or EditorGUI.Popup.
		/// </summary>
		private static float SingleLineHeight => EditorGUIUtility.singleLineHeight;
	
		/// <summary>
		/// Create property field including a label.
		/// </summary>
		/// <param name="rect">Rect of a single element from a reorderable list.</param>
		/// <param name="offsetY">Specifies the height inside the editor window.</param>
		/// <param name="property">Serialized property from any element inside a reorderable list.</param>
		public static void CreatePropertyField(Rect rect, float offsetY, SerializedProperty property)
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
