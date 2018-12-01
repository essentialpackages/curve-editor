using UnityEngine;

namespace EssentialPackages.CurveEditor.Editor
{
	[CreateAssetMenu(fileName = "CurveList", menuName = "Essential/CurveEditor/CurveList", order = 1)]
	public class CurveList : ScriptableObject
	{
		[SerializeField] private Curve[] _curve;
	}
}
