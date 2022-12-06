using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(10, 100)]
    int resolution = 10;

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
            position.y = Mathf.Sin(Mathf.PI * (position.x + time));// * position.x * position.x;
            point.localPosition = position;
        }
    }
}
