using UnityEngine;
using System.Collections;

public class Triangle : MonoBehaviour
{

	Vector3[] vertices = new Vector3[] {
		new Vector3 (-10, 0, 0),
		new Vector3 (0, 20, 0),
		new Vector3 (10, 0, 0)
	};

	int[] triangles = new int[] {
		0, 1, 2
	};

	Vector3[] normals = new Vector3[] {
		Vector3.forward,
		Vector3.forward,
		Vector3.forward
	};
		
	private MeshFilter mf;

	void Start ()
	{
		mf = GetComponent<MeshFilter> ();
		mf.mesh = new Mesh ();
		mf.mesh.vertices = vertices;
		mf.mesh.triangles = triangles;
		mf.mesh.normals = normals;
		GetComponent<MeshRenderer> ().material.color = Color.white;

	}

	void Update ()
	{
//		if (Input.GetKeyDown (KeyCode.A)) {
		mf.mesh.vertices = new[] {
			new Vector3 (Random.Range (1, 3), Random.Range (1, 3), 0),
			new Vector3 (Random.Range (1, 3), Random.Range (1, 3), 0),
			new Vector3 (Random.Range (1, 3), Random.Range (1, 3), 0)

		};
//		Debug.Log ("Up is pressed.");
//		}
	}
}
