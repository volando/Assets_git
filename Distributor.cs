using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distributor : MonoBehaviour
{
	public GameObject plano;

	public List<GameObject> planos;

	public GameObject ancla;
	public int distanciaDeCajas, numeroDeCajas;
	public Text textDisplay;

	// Use this for initialization
	void Start ()
	{

		for (int i = 0; i < numeroDeCajas; i++) {

			Vector3 pos = new Vector3 (ancla.transform.position.x + Random.Range (-distanciaDeCajas, distanciaDeCajas),
				              2,
				              ancla.transform.position.z + Random.Range (-distanciaDeCajas, distanciaDeCajas));


			
			planos.Add (Instantiate (plano, pos, Quaternion.identity));
			UpdateText ();
		}
	}

	public void UpdateText ()
	{
		textDisplay.text = "SAMPLES " + (planos.Count).ToString ();
	}

	public void Remove (GameObject g)
	{
		planos.Remove (g);
		UpdateText ();
	}

}
