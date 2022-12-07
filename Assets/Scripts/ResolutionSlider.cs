using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionSlider : MonoBehaviour
{
	public Slider slider;
	private Graph graph;
	private TMP_Text text; 

	void Awake()
	{
		var gameObjectGraph = GameObject.Find("Graph");
		graph = gameObjectGraph.GetComponent<Graph>();
		var gameObjectText = GameObject.Find("ResolutionText");
		text = gameObjectText.GetComponent<TMP_Text>();
		slider.onValueChanged.AddListener((value) => {
				graph.SetResolution((int)value);
				text.text = "Resolution: " + value.ToString();
				});
	}
}
