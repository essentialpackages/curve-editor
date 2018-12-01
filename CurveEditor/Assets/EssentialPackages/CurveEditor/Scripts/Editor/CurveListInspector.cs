using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace EssentialPackages.CurveEditor.Editor
{
	[CustomEditor(typeof(CurveList))]
	public class CurveListInspector : UnityEditor.Editor
	{
		private ReorderableList _list;

		private void OnEnable()
		{
			var property = serializedObject.FindProperty("_curve");
			_list = new ReorderableList(serializedObject, property, true, true, true, true);

			_list.elementHeight = 3 * EditorGUIUtility.singleLineHeight;

			_list.drawElementCallback = (rect, index, active, focused) =>
			{
				var element = _list.serializedProperty.GetArrayElementAtIndex(index);
				rect.y += EditorGUIUtility.singleLineHeight / 2;

				EditorGUI.LabelField(
					new Rect(rect.x, rect.y, EditorGUIUtility.labelWidth - 5, EditorGUIUtility.singleLineHeight), "Name"
					
				);
				
				EditorGUI.PropertyField(
					new Rect(rect.x + EditorGUIUtility.labelWidth, rect.y, EditorGUIUtility.currentViewWidth - 60 - EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight),
					element.FindPropertyRelative("_name"),
					GUIContent.none
				);
				
				EditorGUI.LabelField(
					new Rect(rect.x, rect.y + EditorGUIUtility.singleLineHeight, EditorGUIUtility.labelWidth - 5, EditorGUIUtility.singleLineHeight), "AnimationCurve"
					
				);
				
				EditorGUI.PropertyField(
					new Rect(rect.x + EditorGUIUtility.labelWidth, rect.y + EditorGUIUtility.singleLineHeight, EditorGUIUtility.currentViewWidth - 60 - EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight),
					element.FindPropertyRelative("_animationCurve"),
					GUIContent.none
				);
			};
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			_list.DoLayoutList();
			serializedObject.ApplyModifiedProperties();
		}
	}
}
