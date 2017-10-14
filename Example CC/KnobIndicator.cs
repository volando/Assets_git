using UnityEngine;
using MidiJack;

public class KnobIndicator : MonoBehaviour
{
	public int knobNumber;
	public int canal;


	public GameObject inst512;

	void Awake ()
	{
//		transform.localScale = Vector3.zero;

	}

	void Update ()
	{
//		knobNumber = 0;
//		var s = MidiMaster.GetKnobNumbers ();
		var s = MidiMaster.GetKnob (canal, 1);

//		print (s + " " + knobNumber);
//		transform.localScale = new Vector3 (1, s, 1);
		transform.rotation = Quaternion.Euler (new Vector3 (transform.rotation.x, s * 360, transform.rotation.z));
//		transform.RotateAround (inst512.transform.position, Vector3.up, s * Time.deltaTime);
	}
}
