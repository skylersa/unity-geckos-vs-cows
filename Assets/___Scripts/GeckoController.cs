using UnityEngine;
using System.Collections;

public class GeckoController : MonoBehaviour {

	float speed = 10f;

	void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag("Enemy")) {
			Quaternion rotation = Quaternion.LookRotation
				(other.transform.position - transform.position, transform.TransformDirection(Vector3.back));
			Quaternion desiredRotation = new Quaternion(0, 0, rotation.z, rotation.w);
			transform.rotation = Quaternion.Slerp(transform.rotation,desiredRotation, Time.deltaTime * speed); 
		}
	}
	
}