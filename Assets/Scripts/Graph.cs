using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Graph : MonoBehaviour
{
	[SerializeField]
	Transform pointPrefab;

	const int max_resolution = 50;

	int resolution = 30;
	int old_resolution = 30;

	static MathFunctionLibrary.FunctionEnum function;
	MathFunctionLibrary.FunctionEnum old_function;

	[SerializeField, Range(0.1f, 2.0f)]
	float function_scale = 1.0f;

	[SerializeField, Range(0f, 10f)]
	float lerp_speed = 2.0f;
	float lerp_timer = 0f;
	bool lerping = false;

	// prevents lag spike from skipping too many frames of animation
	const float lerp_max_delta = 1f/20f; 


	Transform[] points;

	public float GetLerp()
	{
		if(lerp_speed <= 0)
		{
			return 0f;
		}
		else
		{
			return lerp_timer / lerp_speed;
		}
	}

	public void SetFunctionScale(float scale)
	{
		function_scale = scale;
	}

	public void SetResolution(int res)
	{
		resolution = res;
	}

	public void SetFunction(int func)
	{
		function = (MathFunctionLibrary.FunctionEnum)func;
	}

	public bool IsLerping()
	{
		return lerping;
	}

	void UpdateResolution()
	{
		float step = 2f / resolution;
		for(int i = 0, x = 0, z = 0; i < (max_resolution * max_resolution); i++, x++) {
			Transform point = points[i];
			if(i >= (resolution * resolution))
			{
				point.gameObject.SetActive(false);
			}
			else
			{
				point.gameObject.SetActive(true);
				if(x == resolution)
				{
					x = 0;
					z += 1;
				}
				Vector3 position = pointPrefab.localPosition;
				position.x = (x + 0.5f) * step - 1f;
				position.z = (z + 0.5f) * step - 1f;
				point.localPosition = position;
				point.localScale = new Vector3(step, step, step);
			}
		}
	}

	void Awake()
	{
		points = new Transform[max_resolution * max_resolution];
		float step = 2f / resolution;
		for(int i = 0, x = 0, z = 0; i < (max_resolution * max_resolution); i++, x++) {
			Transform point = Instantiate(pointPrefab);
			points[i] = point;
			if(i >= (resolution * resolution))
			{
				point.gameObject.SetActive(false);
			}
			if(x == resolution)
			{
				x = 0;
				z += 1;
			}
			Vector3 position = pointPrefab.localPosition;
			point.SetParent(transform, false);
			position.x = (x + 0.5f) * step - 1f;
			position.z = (z + 0.5f) * step - 1f;
			point.localPosition = position;
			point.localScale = new Vector3(step, step, step);
		}
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		float time = Time.time;

		if(old_resolution != resolution) {
			old_resolution = resolution;
			UpdateResolution();
		}

		if(function != old_function)
		{
			if(lerp_timer <= 0f)
			{
				if(lerping)
				{
					lerping = false;
					old_function = function;
				}
				else
				{
					lerping = true;
					lerp_timer = lerp_speed;
				}
			}
			else
			{
				lerp_timer -= Mathf.Min(Time.deltaTime, lerp_max_delta);
			}
		}

		MathFunctionLibrary.Function visual_function = MathFunctionLibrary.GetFunction(function);
		MathFunctionLibrary.Function previous_function = MathFunctionLibrary.GetFunction(old_function);

		for(int i = 0; i < resolution * resolution; i++) {
			Transform point = points[i];
			Vector3 position = point.localPosition;
			if(function == old_function)
			{
				position.y = visual_function(
						position.x * function_scale,
						position.z * function_scale,
						time
						);
			}
			else
			{
				var starting = previous_function(
						position.x * function_scale,
						position.z * function_scale,
						time
						);
				var target = visual_function(
						position.x * function_scale,
						position.z * function_scale,
						time
						);
				position.y = Mathf.Lerp(target, starting, lerp_timer / lerp_speed);
			}
			point.localPosition = position;
		}
	}
}
