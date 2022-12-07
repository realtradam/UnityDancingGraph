using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FunctionLerp : MonoBehaviour
{
	public TMP_Text text; 
	private Graph graph;

	void Awake()
	{
		var gameObjectGraph = GameObject.Find("Graph");
		graph = gameObjectGraph.GetComponent<Graph>();
	}

	void Update()
	{
		text.text = "Function Lerp: " + graph.GetLerp().ToString("0.0");
	}
}
