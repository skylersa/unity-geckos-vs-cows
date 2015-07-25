using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public int durability = 4;
	public GameObject explosionprefab;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Enemy")) {
			GameObject clone = Instantiate (explosionprefab);
			clone.transform.position = transform.position;
			Destroy (other.gameObject);
			durability -= 1;
			if (durability <= 0) {
				Destroy (gameObject);
			}
		}
	}
	
	void Update () {
		float angle = 300f * Time.time; 
		transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
	}
}
