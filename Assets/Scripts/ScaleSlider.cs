using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScaleSlider : MonoBehaviour
{
	public Slider slider;
	private Graph graph;
	private TMP_Text text; 

	void Awake()
	{
		var gameObjectGraph = GameObject.Find("Graph");
		graph = gameObjectGraph.GetComponent<Graph>();
		var gameObjectText = GameObject.Find("ScaleText");
		text = gameObjectText.GetComponent<TMP_Text>();
		slider.onValueChanged.AddListener((value) => {
				graph.SetFunctionScale((float)value);
				text.text = "Function Scale: " + value.ToString("0.0");
				});
	}
}
