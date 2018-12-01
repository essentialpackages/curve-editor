using System;
using UnityEngine;

namespace EssentialPackages.CurveEditor.Editor
{
	[Serializable]
	public class Curve
	{
		[SerializeField] private string _name;
		[SerializeField] private AnimationCurve _animationCurve;
		
		public string Name => _name;
		public AnimationCurve AnimationCurve => _animationCurve;
	}
}
