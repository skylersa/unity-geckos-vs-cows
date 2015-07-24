using UnityEngine;
using System.Collections;

public class MacheteController : MonoBehaviour {
	public GameObject explosionprefab;
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Enemy")) {
//			GameObject clone = Instantiate (explosionprefab, transform.position, transform.rotation) as GameObject;
			GameObject clone = Instantiate (explosionprefab);
			clone.transform.position = transform.position;
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
	
	void Update () {
		//transform.position += new Vector3 (0f, 5f, 0f) * Time.deltaTime;

		float angle = 300f * Time.time; 
		transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
	}
}
