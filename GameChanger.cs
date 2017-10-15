using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameChanger : MonoBehaviour
{

	public  Material Terrain, Cubes, HUD;
	public static Color colorBg, colorMat;
	public GameObject ancla, MapGenerator;


	// Use this for initialization
	void Start ()
	{
		ChangeAll ();
		SetTerrain ();
	}


	public static void ChangeAll ()
	{
		colorBg = new Color (Random.Range (0, 1.0f), Random.Range (.0f, 1.0f), Random.Range (.0f, 1.0f), 1f);
		colorMat = new Color (Random.Range (0, 1.0f), Random.Range (.0f, 1.0f), Random.Range (.0f, 1.0f), 1f);
//		SetTerrain ();
		Camera.main.backgroundColor = colorBg;
	}

	public void SetTerrain ()
	{

		Terrain.color = colorMat;
		Cubes.color = colorBg;

		MapGenerator.GetComponent<ChangeAttributes> ().Change (colorMat);


	}

}
