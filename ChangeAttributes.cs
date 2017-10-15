using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAttributes : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Change (Color c)
	{
		foreach (Transform t in transform) {
			t.gameObject.GetComponent<MeshRenderer> ().material.color = c;
		}

		gameObject.GetComponent<MapGenerator> ().noiseScale = Random.Range (10, 80);
		gameObject.GetComponent<MapGenerator> ().octaves = Random.Range (2, 4);
		gameObject.GetComponent<MapGenerator> ().lacunarity = Random.Range (1, 4);
		gameObject.GetComponent<MapGenerator> ().meshHeightMultiplier = Random.Range (40, 300);
//		gameObject.GetComponent<MapGenerator>().noiseScale
//		gameObject.GetComponent<MapGenerator>().noiseScale

	}
}
