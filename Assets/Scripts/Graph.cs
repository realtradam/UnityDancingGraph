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
		float time = Time.time;
		for(int i = 0; i < points.Length; i++) {
			Transform point = points[i];
			Vector3 position = point.localPosition;
			if(function == 0)
			{
				position.y = MathFunctionLibrary.Wave(position.x, time);
			}
			else if(function == 1)
			{
				position.y = MathFunctionLibrary.MultiWave(position.x, time);
			}
			else if(function == 2)
			{
				position.y = MathFunctionLibrary.Ripple(position.x, time);
			}
			point.localPosition = position;
		}
	}
}
