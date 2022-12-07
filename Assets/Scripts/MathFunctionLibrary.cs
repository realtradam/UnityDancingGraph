using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEngine.Mathf;

public static class MathFunctionLibrary 
{
	public delegate float Function(float x, float t);

	public static float GetFunction(float x, float t)
	{
		if(index == 0)
		{
			return Wave;
		}
		else if(index == 1)
		{
			return MultiWave;
		}
		else //if(index == 2)
		{
			return Ripple;
		}
	}

	public static float Wave(float x, float t)
	{
		return Sin(PI * (x + t));
	}

	public static float MultiWave(float x, float t)
	{
		float y = MathFunctionLibrary.Wave(x, t * 0.5f);
		y += Sin(2f * PI * (x + t)) * 0.5f;
		return y * (2f / 3f);
	}

	public static float Ripple(float x, float t) {
		float d = Abs(x);
		float y = Sin(PI * (4f * d - (2f * t)));
		return y / (1f + 10f * d);
	}
	/*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	*/
}
