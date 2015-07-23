using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {
	public GameObject prefab;

	void Start () {
		InvokeRepeating ("Spawn", 0f, 1f);
	}
	
	void Spawn () {
		GameObject clone = Instantiate (prefab, transform.position, transform.rotation) as GameObject;
		clone.transform.rotation = Quaternion.identity;
		Rigidbody rb = clone.GetComponent<Rigidbody> ();
		rb.velocity = transform.up;
	}
}
