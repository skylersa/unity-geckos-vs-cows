using UnityEngine;
using System.Collections;

public class GeckoPlacementController : MonoBehaviour {

	private GameObject geckoPrefab;

	Plane playerPlane;

	public void SelectGecko (GameObject geckoPrefab){
		this.geckoPrefab = geckoPrefab;
	}

	void Start () {
		playerPlane = new Plane (Vector3.forward, transform.position);
	}
	
	public void PlaceGecko () {
		if (geckoPrefab != null && MoneyTextController.AvaialbleMoney() >= 300) {
			MoneyTextController.AddMoney(-300);
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			float distance;
			playerPlane.Raycast (ray, out distance);
			Vector3 pos = ray.GetPoint(distance);
			pos.z = transform.position.z;
			Instantiate(geckoPrefab, pos, Quaternion.identity);
		}
	}
}
