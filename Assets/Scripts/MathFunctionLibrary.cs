using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEngine.Mathf;

public static class MathFunctionLibrary 
{
	public delegate float Function(float x, float t);

	static Function[] functions = {
		Wave,
		MultiWave,
		Ripple
	};

	public static Function GetFunction(int index)
	{
		return functions[index];
	}

	public static float Wave(float x, float t)
	{
		return Sin(PI * (x + t));
	}

	public static float MultiWave(float x, float t)
	{
		float y = Wave(x, t * 0.5f);
		y += Sin(2f * PI * (x + t)) * 0.5f;
		return y * (2f / 3f);
	}

	public static float Ripple (float x, float t) {
		float d = Abs(x);
		float y = Sin(PI * (4f * d - (2f * t)));
		return y / (1f + 10f * d);
	}

}
