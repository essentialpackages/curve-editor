using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace EssentialPackages.CurveEditor.Editor
{
	[CustomEditor(typeof(CurveList))]
	public class CurveListInspector : UnityEditor.Editor
	{
		private ReorderableList _list;

		private static float CurrentViewWidth => EditorGUIUtility.currentViewWidth;
		private static float LabelWidth => EditorGUIUtility.labelWidth;
		private static float SingleLineHeight => EditorGUIUtility.singleLineHeight;

		private void OnEnable()
		{
			var property = serializedObject.FindProperty("_curve");
			_list = new ReorderableList(serializedObject, property, true, true, true, true);

			_list.elementHeight = 3 * SingleLineHeight;
			
			_list.drawElementCallback = (rect, index, active, focused) =>
			{
				var element = _list.serializedProperty.GetArrayElementAtIndex(index);
				rect.y += SingleLineHeight / 2;

				CreateField(
					rect,
					0,
					element.FindPropertyRelative("_name"),
					"_name"
				);
				
				CreateField(
					rect,
					SingleLineHeight,
					element.FindPropertyRelative("_animationCurve"),
					"_animationCurve"
				);
			};
		}

		private static void CreateField(Rect rect, float offsetY, SerializedProperty property, string propertyName)
		{
			EditorGUI.LabelField(
				new Rect(
					rect.x,
					rect.y + offsetY,
					LabelWidth - 5,
					SingleLineHeight
				),
				ObjectNames.NicifyVariableName(propertyName)
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

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			_list.DoLayoutList();
			serializedObject.ApplyModifiedProperties();
		}
	}
}
