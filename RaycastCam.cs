using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Camera))]
[RequireComponent (typeof(LineRenderer))]
[RequireComponent (typeof(GameChanger))]

public class RaycastCam : MonoBehaviour
{
	public Camera camera;
	public int lengthOfLineRenderer = 20;
	LineRenderer lineRenderer;
	public Vector3 rayOffset;
	public int alturaRayo;
	GameChanger changer;
	public GameObject DistroCajas;

	void  Start ()
	{
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.positionCount = lengthOfLineRenderer;
		changer = GetComponent<GameChanger> ();
	}

	void Update ()
	{
		camera = GetComponent<Camera> ();

		Transform rayPos = camera.transform;

		Ray ray = new Ray (new Vector3 (rayPos.transform.position.x,
			          rayPos.transform.position.y - alturaRayo,
			          rayPos.transform.position.z),
			          rayPos.forward);
//		ray = Camera.main.ViewportPointToRay (Vector3 (0.5, 0.5, 0));   
		RaycastHit hit;
		Physics.Raycast (ray, out  hit);
		Debug.DrawLine (ray.origin, rayPos.forward * 10, Color.red);

		if (Physics.Raycast (ray, out hit, 10)) {
			Transform objectHit = hit.transform;

			if (objectHit.tag == "cubo") {
				GameChanger.ChangeAll ();
				DistroCajas.GetComponent<Distributor> ().UpdateText ();
				DistroCajas.GetComponent<Distributor> ().Remove (objectHit.gameObject);
				changer.SetTerrain ();
				print ("CUBO");
				Destroy (objectHit.gameObject);
			}
		}

		var t = Time.time;
		for (int i = 0; i < lengthOfLineRenderer; i++) {
			lineRenderer.SetPosition (i, ray.origin + rayOffset + Camera.main.transform.forward * i * 100);// Mathf.Sin (i + t)
		}
	}
}
