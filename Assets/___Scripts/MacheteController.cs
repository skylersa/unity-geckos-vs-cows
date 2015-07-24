using UnityEngine;
using System.Collections;

public class MacheteController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Enemy")) {
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
