using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEngine.Mathf;

public static class MathFunctionLibrary 
{
	public delegate float Function(float x, float z, float t);

	public enum FunctionEnum {
		Wave,
		MultiWave,
		Ripple
	}

	static Function[] functions = {
		Wave,
		MultiWave,
		Ripple
	};

	public static Function GetFunction(FunctionEnum name)
	{
		return functions[(int)name];
	}

	public static float Wave(float x, float z, float t)
	{
		return Sin(PI * (x + z + t));
	}

	public static float MultiWave(float x, float z, float t)
	{
		float y = Wave(x, z, t * 0.5f);
		y += Sin(2f * PI * (x + t)) * 0.5f;
		return y * (2f / 3f);
	}

	public static float Ripple (float x, float z, float t) {
		float d = Sqrt(x * x + z * z);
		float y = Sin(PI * (4f * d - (2f * t)));
		return y / (1f + 10f * d);
	}

}
