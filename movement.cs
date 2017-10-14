using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
	public float speed;
	public float hor, ver, Rhor, Rver;
	public Camera camWhite, cenitalCam, wireCam;
	public GameObject avatar;

	public float duration = 5.0F;
	private float startTime;

	public AudioSource noise;

	public void Start ()
	{
		startTime = Time.time;
		string[] joysticks = Input.GetJoystickNames ();
		if (joysticks.Length > 0)
			print ("Joystick: " + Input.GetJoystickNames () [0]);
	}


	// Update is called once per frame
	void Update ()
	{
		hor = Input.GetAxis ("Horizontal");
		ver = Input.GetAxis ("Vertical");

		Rhor = Input.GetAxis ("RHorizontal");
		Rver = Input.GetAxis ("RVertical");



		transform.Translate (new Vector3 (hor, 0, ver) * Time.deltaTime * speed);
		transform.Rotate (new Vector3 (0, Rhor, 0) * Time.deltaTime * speed);

		avatar.transform.Rotate (new Vector3 (0, Rhor, 0) * Time.deltaTime * speed);
//		wireCam.transform.Rotate (new Vector3 (0, Rhor, 0) * Time.deltaTime * speed);


		float t = (Time.time - startTime) / duration;
//		camWhite.fieldOfView = Mathf.Clamp (30 + Rver * 100, 10, 60);
		camWhite.fieldOfView = Mathf.SmoothStep (camWhite.fieldOfView,
			Mathf.Clamp (camWhite.fieldOfView, 10, 60) + 30 + Rver * 10,
			t * speed);

		cenitalCam.transform.position = Vector3.Slerp (new Vector3 (cenitalCam.transform.position.x,
			cenitalCam.transform.position.y,
			cenitalCam.transform.position.z),
			new Vector3 (cenitalCam.transform.position.x,
				Mathf.Clamp (cenitalCam.transform.position.y, 1000, 6000) + Rver * speed,
				cenitalCam.transform.position.z),
			speed);

		Camera.main.orthographicSize = Mathf.SmoothStep (Camera.main.orthographicSize,
			Mathf.Clamp (Camera.main.orthographicSize, 100, 580) + Rver * 10,
			t * speed);

//		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, -500, 500),
//			transform.position.y,
//			Mathf.Clamp (transform.position.z, -500, 500));

		noise.pitch = Mathf.SmoothStep (noise.pitch, 0.5f + Rhor * 6, t);

//			Mathf.Clamp (noise.pitch, Rhor * 3, Rhor * 3);
//		print ("nosie pitch " + noise.pitch);

//		Instanciate512.radius = 10 + Camera.main.orthographicSize / 10;


//		if (Input.GetKey (KeyCode.W)) {
//			transform.Translate (Vector3.forward * Time.deltaTime * speed);
//		}
//
//
//		if (Input.GetKey (KeyCode.S)) {
//			transform.Translate (Vector3.back * Time.deltaTime * speed);
//		}

	}
}
