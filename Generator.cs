using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

	public int mapWidth;
	public int mapHeight;
	public float noiseScale;

	public int octaves;
	public float persistance;
	public float lacunarity;

	public int seed;
	public Vector2 offset;

	public bool autoUpdate;
	public Noise.NormalizeMode normalizeMode;


	public void GenerateMap ()
	{
		float[,] noiseMap = Noise.GenerateNoiseMap (mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset, normalizeMode);

		MapDisplay display = FindObjectOfType<MapDisplay> ();
//		display.DrawNoiseMap (noiseMap); 

	}

	void OnValidate ()
	{
		if (mapWidth < 1) {
			mapWidth = 1;
		}

		if (mapHeight < 1) {
			mapHeight = 1;
		}

		if (lacunarity < 1) {
			lacunarity = 1;
		}

		if (octaves < 0) {
			octaves = 0;
		}
	}


}

