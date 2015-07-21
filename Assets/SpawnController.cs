using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {
	public GameObject prefab;

	void Start () {
		InvokeRepeating ("Spawn", 0f, 1f);
	}
	
	void Spawn () {
		Instantiate (prefab, transform.position, transform.rotation);
	}
}
