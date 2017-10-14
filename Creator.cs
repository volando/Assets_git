using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{


	public GameObject Plano;
	public List<GameObject> Planos;
	// = new List<GameObject> ()

	public GameObject avatar;
	public Vector3 altePos;
	Vector3 sqBounds;

	// Use this for initialization
	void Start ()
	{

		sqBounds = Plano.transform.GetComponent<MeshFilter> ().sharedMesh.bounds.size;
//		StartCoroutine ("CreatePlanos", Vector3.zero);
		CreatePlanos (transform.position);

	}

	void DeletePlanos ()
	{
		foreach (GameObject g in Planos) {
			if (g.tag != "centro")
				Destroy (g);
		}

		Planos.Clear ();
			
	}

	void CreatePlanos (Vector3 creationPos)
	{

		for (int z = -1; z < 2; z++) {
			for (int x = -1; x < 2; x++) {
				CreateFlat (z, x, creationPos);
			}
		}
	}

	void CreateFlat (int z, int x, Vector3 creationPos)
	{
		GameObject p = Instantiate (Plano) as GameObject;
		p.transform.position = new Vector3 (creationPos.x + p.transform.localScale.x + x * sqBounds.x,
			creationPos.y,
			creationPos.z + p.transform.localScale.z + z * sqBounds.z);
		p.name = " p. x " + x + "p. y " + z;
		if (x == 0 && z == 0) {
			p.tag = "centro";
		}
		Planos.Add (p);
	}

	void UpdateCentroPos ()
	{
		foreach (GameObject g in Planos) {
			if (g.tag == "centro")
				g.transform.position = transform.position;
		}
	}

	void Renew (Vector3 creationPos)
	{
		for (int z = -1; z < 2; z++) {
			for (int x = -1; x < 2; x++) {
				CreateFlat (z, x, creationPos);
				if (z != 0 && x != 0) {
					
//					UpdateCentroPos ();

//
//
//				GameObject p = Instantiate (Plano) as GameObject;
//				p.transform.position = new Vector3 (creationPos.x + p.transform.localScale.x + x * sqBounds.x,
//					creationPos.y,
//					creationPos.z + p.transform.localScale.z + z * sqBounds.z);
//				p.name = " p. x " + x + "p. y " + z;
//				Planos.Add (p);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if (Input.GetKey (KeyCode.F))
		CheckPos ();
		print (transform.position.x + " " + altePos.x + " " + sqBounds.x);
	}

	void CheckPos ()
	{

		if (transform.position.x > altePos.x + sqBounds.x / 2 || transform.position.x < altePos.x - sqBounds.x / 2) {
			altePos = transform.position;
			DeletePlanos ();
//			CreatePlanos (transform.position);
			Renew (transform.position);
		}

		if (transform.position.z > altePos.z + sqBounds.z / 2 || transform.position.z < altePos.z - sqBounds.z / 2) {
			altePos = transform.position;
			DeletePlanos ();
//			CreatePlanos (transform.position);
			Renew (transform.position);

		}

	}
}
