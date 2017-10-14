using UnityEngine;
using System.Collections.Generic;
using MidiJack;

public class KnobIndicatorGroup : MonoBehaviour
{
	public GameObject prefab;
	public GameObject cubo;

	List<KnobIndicator> indicators;

	void Start ()
	{
		indicators = new List<KnobIndicator> ();
//		cubo.transform.position = Vector3.right * indicators.Count;

		// Initialize the indicator.
//		var indicator = cubo.GetComponent<KnobIndicator> ();
////		indicator.knobNumber = 0;//channels [indicators.Count];
//
//		// Add it to the indicator list.
//		indicators.Add (indicator);


	}

	void Update ()
	{
//		var channels = MidiMaster.GetKnobNumbers ();
//
//		print (indicators.Count + " " + channels.Length);
//		// If a new chennel was added...
//		if (indicators.Count != channels.Length) {
////			if (cubo.GetComponent<KnobIndicator> ().knobNumber == channels [indicators.Count])
////			print (channels.Length + " " + MidiMaster.GetKnob (cubo.GetComponent<KnobIndicator> ().knobNumber));
////
//			// Instantiate the new indicator.
//			var go = Instantiate<GameObject> (cubo);
//			go.transform.position = Vector3.right * indicators.Count;
//
//			// Initialize the indicator.
//			var indicator = go.GetComponent<KnobIndicator> ();
//			indicator.knobNumber = channels [indicators.Count];
//
//			// Add it to the indicator list.
//			indicators.Add (indicator);
//		}
	}
}
