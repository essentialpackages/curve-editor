using System;
using UnityEngine;

namespace EssentialPackages.CurveEditor.Editor
{
	/// <summary>
	/// Container to bring name and animation curve together.
	/// </summary>
	[Serializable]
	public class Curve
	{
		/// <summary>
		/// Custom name for the animation curve.
		/// </summary>
		[SerializeField] private string _name;
		
		/// <summary>
		/// Two-dimensional animation curve.
		/// </summary>
		[SerializeField] private AnimationCurve _animationCurve;
		
		/// <summary>
		/// Get name of the stored animation curve.
		/// </summary>
		public string Name => _name;
		
		/// <summary>
		/// Get animation curve.
		/// </summary>
		public AnimationCurve AnimationCurve => _animationCurve;
	}
}
