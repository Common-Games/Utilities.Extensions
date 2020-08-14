using System.Collections;
using System.Collections.Generic;

using UnityEngine;

#if UNITY_DOTS
using Unity.Mathematics;
#endif

namespace CommonGames.Utilities.Extensions
{
	using JetBrains.Annotations;

	public static partial class Math
	{
		#region Clamping

		public static float Clamp(this float value, in float min, in float max) 
			=> Mathf.Clamp(value: value, min: min, max: max);

		public static float Clamp01(this float value) 
			=> Mathf.Clamp01(value: value);
		
		public static float ClampAngle(this float angle, float min, float max)
		{
			while (angle < -360 || angle > 360)
			{
				if(angle < -360)
				{
					angle += 360;
				}
				if(angle > 360)
				{
					angle -= 360;
				}
			}

			return Clamp(angle, min, max);
		}

		#endregion

		#region Rounding

		[PublicAPI]
		public static float Round(this float value) 
			=> Mathf.Round(value);
		[PublicAPI]
		public static int RoundToInt(this float value) 
			=> Mathf.RoundToInt(value);
		
		public static float Floor(this float value) 
			=> Mathf.Floor(value);
		[PublicAPI]
		public static int FloorToInt(this float value) 
			=> Mathf.FloorToInt(value);

		[PublicAPI]
		public static float Ceil(this float value) 
			=> Mathf.Ceil(value);
		
		[PublicAPI]
		public static int CeilToInt(this float value) 
			=> Mathf.CeilToInt(value);

		#endregion
		
		[PublicAPI]
		public static bool Approximately(this float a, in float b) => Mathf.Approximately(a, b);
		[PublicAPI]
		public static bool NotApproximately(this float a, in float b) => !Mathf.Approximately(a, b);
		
		#if UNITY_DOTS
		public static bool BurstApproximately(this float a, in float b)
		{
			return Mathf.Abs(b - a) < Mathf.Max(0.000001f * Mathf.Max(Mathf.Abs(a), Mathf.Abs(b)), 1.17549435E-38f * 8);
		}
		
		//public static bool BurstApproximately(this float a, in float b) => math.(a, b);
		
		#endif

		[PublicAPI]
		public static float Abs(this float value) => Mathf.Abs(value);
		
		[PublicAPI]
		public static float ToAbs(ref this float value) => Mathf.Abs(value);
		
		[PublicAPI]
		public static float Pow(this float value, in float power) => Mathf.Pow(value, power);
		
		[PublicAPI]
		public static float Sqrt(this float value) => Mathf.Sqrt(value);
	}
}