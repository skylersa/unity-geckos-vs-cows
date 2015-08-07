using UnityEngine;
using System.Collections;

public class GeckoController : MonoBehaviour {

	private float speed = 10f;
	private GameObject target;

	void Start() {
		gameObject.GetComponent<SpawnController> ().enabled = false;
	}

	void OnTriggerStay2D(Collider2D other) {
		if (target == null && other.CompareTag("Enemy")) {
			target = other.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (target == other.gameObject) {
			target = null;
		}
	}

	void Update() {
		gameObject.GetComponent<SpawnController> ().enabled = target != null;
		if (target != null) {
			Quaternion rotation = Quaternion.LookRotation
				(target.transform.position - transform.position, transform.TransformDirection(Vector3.back));
			Quaternion desiredRotation = new Quaternion(0, 0, rotation.z, rotation.w);
			transform.rotation = Quaternion.Slerp(transform.rotation,desiredRotation, Time.deltaTime * speed); 
		}
	}
	
}