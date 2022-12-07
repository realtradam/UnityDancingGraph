using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Graph : MonoBehaviour
{
	[SerializeField]
	Transform pointPrefab;

	[SerializeField, Range(10, 200)]
	int resolution = 100;

	[SerializeField, Range(0.1f, 2f)]
	float size = 0.3f;

	[SerializeField, Range(0, 2)]
	int function = 1;

	Transform[] points;

	void Awake() {
		points = new Transform[resolution];
		float step = 8f / points.Length;
		for(int i = 0; i < points.Length; i++) {
			Transform point = Instantiate(pointPrefab);
			points[i] = point;
			Vector3 position = pointPrefab.localPosition;
			point.SetParent(transform, false);
			position.x = (i + 0.5f) * step - 4f;
			point.localPosition = position;
			point.localScale *= size;
		}
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		MathFunctionLibrary.Function visual_function = MathFunctionLibrary.GetFunction(function);
		float time = Time.time;
		for(int i = 0; i < points.Length; i++) {
			Transform point = points[i];
			Vector3 position = point.localPosition;
			position.y = visual_function(position.x, time);
			point.localPosition = position;
		}
	}
}
