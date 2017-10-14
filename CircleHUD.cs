using UnityEngine;
using System.Collections;
using MidiJack;

public class CircleHUD : MonoBehaviour
{


	public GameObject sph;
	//	public int numberOfSpheres;
	public GameObject[] spheres = new GameObject[16];
	public  float radius;
	//	int band;
	public GameObject ancla;
	public float size;

	// Use this for initialization
	void Start ()
	{

		for (int i = 0; i < spheres.Length; i++) {
			float angle = i * Mathf.PI * 2 / spheres.Length - 1;
			Vector3 pos = new Vector3 (this.transform.position.x + Mathf.Cos (angle) * radius,
				              this.transform.position.y + Mathf.Sin (angle) * radius / 2, 0);
			GameObject inst = Instantiate (sph) as GameObject;


			inst.transform.position = pos;//Vector3.forward * 2;

			inst.transform.SetParent (this.transform);
			inst.name = "sph " + i;
			//			this.transform.eulerAngles = new Vector3 (0, 2, 0);
			spheres [i] = inst;
		}
	}

	// Update is called once per frame
	void LateUpdate ()
	{

		int anclaje = (int)(ancla.transform.eulerAngles.y * 16 / 360);

		for (int i = 0; i < spheres.Length; i++) {
			if (anclaje == i) {
				spheres [i].transform.localScale = new Vector3 (.1f,
					.1f
					, .2f); 
			} else {
				spheres [i].transform.localScale = new Vector3 (size,
					size
					, size); //(WaveForm._freqBand [i / 64] * maxScale)
			}

		}

	}
}


