using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//fadea el texto


//[RequireComponent (Text)]
public class Fade : MonoBehaviour
{
	public Text text;
	public Color colorFadeTo;
	public float fadeTime;


	// Use this for initialization
	void Start ()
	{
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if ((Input.GetAxis ("Horizontal") > .5f ||
		    Input.GetAxis ("Vertical") > .5f ||
		    Input.GetAxis ("RHorizontal") > .5f ||
		    Input.GetAxis ("RVertical") > .5f)) {

			StartCoroutine ("fade");

		}
	}

	IEnumerator fade ()
	{
		
		text.CrossFadeAlpha (0, fadeTime, true);


		yield return new WaitForSeconds (.1f);
	}
}
