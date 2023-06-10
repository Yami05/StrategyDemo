using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathfExt
{
	public static float Remap(this float value, float fromMin, float fromMax, float toMin, float toMax)
	{
		float normalizedValue = Mathf.InverseLerp(fromMin, fromMax, value);
		return Mathf.Lerp(toMin, toMax, normalizedValue);
	}

}
