//using UnityEngine;
//using System.Collections;
//
//public class Vertices : MonoBehaviour
//{
//	public Vector3[] newVertices;
//	public Vector2[] newUV;
//	public int[] newTriangles;
//
//	void Start ()
//	{
//		MeshSetup ();	
//
//	}
//
//
//	void MeshSetup ()
//	{
//		Mesh mesh = new Mesh ();
//		GetComponent<MeshFilter> ().mesh = mesh;
//
//
//
//		for (int i = 0; i < 10; i++) {
//			for (int j = 0; j < 10; j++) {
//				newVertices [i] = new Vector3 (i, j);
//			}
//			mesh.vertices = newVertices;
//			for (int t = 0; t < 30; t++) {
//				newTriangles [t] = t;
//				newTriangles [t + 1] = t + 1;
//				newTriangles [t + 2] = t + 2;
//			}
//
//			mesh.triangles = newTriangles;
//			mesh.uv = newUV;
//
//		}
//
//		//	void Update ()
//		//	{
//		//		Mesh mesh = GetComponent<MeshFilter> ().mesh;
//		//		Vector3[] vertices = mesh.vertices;
//		//		int i = 0;
//		//		while (i < vertices.Length) {
//		//			Vector3 v = vertices [i];
//		//			//			v = vertices [i] += new Vector3 (v.x, 0, v.z);
//		//			vertices [i] = new Vector3 (v.x, Random.Range (0f, 10.10f), v.z);
//		//			i++;
//		//		}
//		//		mesh.vertices = vertices;
//		//		mesh.RecalculateBounds ();
//		//	}
//
//
//		//	void MeshSetup ()
//		//	{
//		//		for (int i = 0; i < 10; i++) {
//		//			print (i);
//		//			newVertices = new Vector3[i] {
//		//				new Vector3 (i * -1, 0, i * 1),
//		//				new Vector3 (i * 1, 0, i * 1),
//		//				new Vector3 (i * 1, 0, i * -1),
//		//				new Vector3 (i * -1, 0, i * -1)
//		//			};
//		//			newUV = new Vector2[i] {
//		//				new Vector2 (0, 256),
//		//				new Vector2 (256, 256),
//		//				new Vector2 (256, 0),
//		//				new Vector2 (0, 0)
//		//			};
//		////			newTriangles = new int[] { 0, 1, 2, 0, 2, 3 };
//		////			newTriangles [i] = i;//new int[] { 0 + i, 1 + i, 2 + 1 };
//		//		}
//		//
//		//	}
//
//	}
//}
//


using UnityEngine;
using System.Collections;
using MidiJack;

//using System.Collections.Generic;

public class Vertices : MonoBehaviour
{

	//	public Camera cam;
	public int alturaCam, distanciaCam;
	Vector3[] vertices;
	Vector3[] values;
	Mesh mesh;
	public float a, b, c, d;
	public float spd, perlinScale, waveSpeed, waveHeight;

	void Awake ()
	{
		mesh = GetComponent<MeshFilter> ().mesh;
		vertices = mesh.vertices;
		values = new Vector3[mesh.vertices.Length];

		for (int j = 0; j < values.Length; j++) {
			Vector3 v = values [j];

			values [j] = new Vector3 (v.x + Mathf.Cos (j + v.x), (j * j), v.z); //cos(x),y2

		}
	}

	void step ()
	{
		
		Vector3[] demo = new Vector3[values.Length];

		for (int j = 0; j < values.Length - 1; j++) {
			demo [j] = values [j + (int)d];
		}

		demo [demo.Length - 1] = values [0];
		values = demo;
	}



	void Update ()
	{

		perlinScale = .8f;//MidiMaster.GetKnob (74, 0) * 1.2f;
		waveSpeed = MidiMaster.GetKnob (18, 1) * 0.5f;
		b = MidiMaster.GetKnob (7, 1);
		waveHeight = MidiMaster.GetKnob (114, 1) * 6;
		var d = MidiMaster.GetKnob (71, 1) * 200;

		transform.rotation = Quaternion.Euler (new Vector3 (transform.rotation.x, b * 360, transform.rotation.z));
	
//		print ("nobs " + a + " " + c);

		if (Input.GetKey (KeyCode.C)) {
			step ();
		}

		for (int j = 0; j < vertices.Length; j++) {
			Vector3 v = vertices [j];
			vertices [j] = new Vector3 (v.x, Mathf.PerlinNoise (v.x, v.z) * a * a, v.z); // * WaveForm._freqBand [j / 64] * d
//			vertices [j] = new Vector3 (v.x, (Mathf.Sin (values [j].y) * a) % c * (WaveForm._freqBand [j / 64] * 100), v.z);
//			print ("WV " + WaveForm.samples);
			if (j == vertices.Length - 1)
				step ();
		}

		mesh.vertices = vertices;
		mesh.RecalculateBounds ();


		AnimateMesh ();
		
	}

	void AnimateMesh ()
	{
		if (!mesh)
			mesh = GetComponent< MeshFilter > ().mesh;

		Vector3[] vertices = mesh.vertices;

		for (int i = 0; i < vertices.Length; i++) {
			float pX = (vertices [i].x * perlinScale) + (Time.timeSinceLevelLoad * waveSpeed);
			float pZ = (vertices [i].z * perlinScale) + (Time.timeSinceLevelLoad * waveSpeed);

			vertices [i].y = (Mathf.PerlinNoise (pX, pZ) - 0.5f) * waveHeight;
		}

		mesh.vertices = vertices;
	}
}

