using EssentialPackages.CurveEditor.Editor.Utils;
using UnityEditor;
using UnityEditorInternal;

namespace EssentialPackages.CurveEditor.Editor
{
	[CustomEditor(typeof(CurveList))]
	public class CurveListInspector : UnityEditor.Editor
	{
		private ReorderableList _list;

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

				Inspector.CreateField(
					rect,
					0,
					element.FindPropertyRelative("_name"),
					"_name"
				);
				
				Inspector.CreateField(
					rect,
					SingleLineHeight,
					element.FindPropertyRelative("_animationCurve"),
					"_animationCurve"
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
