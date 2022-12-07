using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FunctionSelector : MonoBehaviour
{
	Graph graph;
	TMP_Dropdown dropdown;

	private void Awake()
	{
		dropdown = gameObject.GetComponent<TMP_Dropdown>();
		var gameObjectGraph = GameObject.Find("Graph");
		graph = gameObjectGraph.GetComponent<Graph>();
	}

    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
		if(graph.IsLerping())
		{
			dropdown.interactable = false;
		}
		else
		{
			dropdown.interactable = true;
		}
    }
}
