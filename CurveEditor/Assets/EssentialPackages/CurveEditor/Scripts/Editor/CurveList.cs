using UnityEngine;

namespace EssentialPackages.CurveEditor.Editor
{
	/// <inheritdoc />
	/// <summary>
	/// Redistributable object which holds animation curves.
	/// </summary>
	[CreateAssetMenu(fileName = "CurveList", menuName = "Essential/CurveEditor/CurveList", order = 1)]
	public class CurveList : ScriptableObject
	{
		/// <summary>
		/// Array of labeled animation curves.
		/// </summary>
		[SerializeField] private Curve[] _curve;
	}
}
