using EssentialPackages.CurveEditor.Editor.Utils;
using UnityEditor;
using UnityEditorInternal;

namespace EssentialPackages.CurveEditor.Editor
{
	/// <inheritdoc />
	/// <summary>
	/// Custom inspector for <see cref="CurveSpecification"/>.
	/// </summary>
	[CustomEditor(typeof(CurveSpecification))]
	public class CurveListInspector : UnityEditor.Editor
	{
		/// <summary>
		/// Makes an array or list reorderable within the Unity inspector.
		/// </summary>
		private ReorderableList _list;

		/// <summary>
		/// Get the height used for a single Editor control such as a one-line EditorGUI.TextField or EditorGUI.Popup.
		/// </summary>
		private static float SingleLineHeight => EditorGUIUtility.singleLineHeight;

		/// <summary>
		/// Create reorderable list when object is loaded.
		/// </summary>
		private void OnEnable()
		{
			var property = serializedObject.FindProperty("_curve");
			_list = new ReorderableList(serializedObject, property, true, true, true, true);

			_list.elementHeight = 3 * SingleLineHeight;
			
			_list.drawElementCallback = (rect, index, active, focused) =>
			{
				var element = _list.serializedProperty.GetArrayElementAtIndex(index);
				rect.y += SingleLineHeight / 2;

				Inspector.CreatePropertyField(
					rect,
					0,
					element.FindPropertyRelative("_name")
				);
				
				Inspector.CreatePropertyField(
					rect,
					SingleLineHeight,
					element.FindPropertyRelative("_animationCurve")
				);
			};
		}

		/// <summary>
		/// Allow modifications inside reorderable list.
		/// </summary>
		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			_list.DoLayoutList();
			serializedObject.ApplyModifiedProperties();
		}
	}
}
