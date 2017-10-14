using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDown : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.rotation = Quaternion.Euler (new Vector3 (90, 0, 0));

	}
}
