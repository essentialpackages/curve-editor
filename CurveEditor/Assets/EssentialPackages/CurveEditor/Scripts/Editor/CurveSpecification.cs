using UnityEngine;

namespace EssentialPackages.CurveEditor.Editor
{
	/// <inheritdoc />
	/// <summary>
	/// Redistributable object which holds animation curves.
	/// </summary>
	[CreateAssetMenu(fileName = "CurveSpecification", menuName = "Essential/CurveEditor/CurveSpecification", order = 1)]
	public class CurveSpecification : ScriptableObject
	{
		/// <summary>
		/// Array of labeled animation curves.
		/// </summary>
		[SerializeField] private Curve[] _curve;
	}
}
