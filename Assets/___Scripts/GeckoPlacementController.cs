using UnityEngine;
using System.Collections;

public class GeckoPlacementController : MonoBehaviour {

	public GameObject macheteGeckoPrefab;

	Plane playerPlane;

	void Start () {
		playerPlane = new Plane (Vector3.forward, transform.position);
	}
	
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			float distance;
			playerPlane.Raycast (ray, out distance);
			Vector3 pos = ray.GetPoint(distance);
			pos.z = transform.position.z;
			Instantiate(macheteGeckoPrefab, pos,Quaternion.identity);
		}

	}
}
