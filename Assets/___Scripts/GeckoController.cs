using UnityEngine;
using System.Collections;

public class GeckoController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Enemy")){
			Quaternion rotation = Quaternion.LookRotation
				(other.transform.position - transform.position, transform.TransformDirection(Vector3.back));
			transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
		}
	}

}
